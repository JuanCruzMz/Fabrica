namespace Logica_Fabrica
{
    /// <summary>
    /// Representa una máquina a funcionar dentro de la fábrica. Produce productos a partir de su correspondiente materia prima, en tiempo real.
    /// </summary>
    internal class Maquina
    {
        #region Atributos (9)

        /// <summary>
        /// Código identificador único de la máquina.
        /// </summary>
        private readonly string identificador;
        /// <summary>
        /// Estado actual de la máquina.
        /// </summary>
        private bool estaEncendida;
        /// <summary>
        /// Representa el producto que está actualmente, siendo producido por la máquina.
        /// </summary>
        /// 
        /// <remarks>
        /// This field holds a reference to the <see cref="Producto"/> object that is being processed or manufactured. It may be <see langword="null"/> if no product is currently in production. //TODO: Traducir.
        /// </remarks>
        private Producto? productoEnProduccion;
        /// <summary>
        /// Representa el tiempo restante (en segundos) para que el producto que actualmente esta máquina tiene en producción, se finalice. El mismo se actualiza en tiempo real.
        /// </summary>
        private uint tiempoRestanteDelProductoEnProduccionEnSegundos;

        #region Eventos (y sus delegados)

        /// <summary>
        /// Delegado utilizado por el evento "ProductoTerminado".
        /// </summary>
        /// <param name="productoProducido">Producto que acaba de ser producido.</param>
        public delegate void NotificadorProductoTerminado(Producto productoProducido);
        /// <summary>
        /// Evento encargado de notificar a la clase estática "Fabrica" que el producto de esta máquina acaba de terminar de ser producido.
        /// </summary>
        public event NotificadorProductoTerminado ProductoTerminado;

        /// <summary>
        /// Delegado utilizado por el evento "SegundoDelTiempoRestanteDelProductoEnProduccionRestado".
        /// </summary>
        /// <param name="identificador">Identifficador de la máquina cuyo producto en producción, cuyo tiempo restante fue decrementado.</param>
        public delegate void NotificadorSegundoDelTiempoRestanteDelProductoEnProduccionRestado(string identificador);
        /// <summary>
        /// Evento encargado de notificar a la clase estática "Fabrica" que el tiempo de restante del producto en producción de esta máquina acaba de ser decrementado
        /// </summary>
        public event NotificadorSegundoDelTiempoRestanteDelProductoEnProduccionRestado SegundoDelTiempoRestanteDelProductoEnProduccionRestado;

        #endregion

        /// <summary>
        /// «CancellationToken» asociado tanto al hilo encargado de producir el producto en producción de la máquina, como al encargado de decrementar el tiempo restante de dicho producto en producción.
        /// </summary>
        private CancellationTokenSource cancelacionDeProduccionYDecrementoDelTiempoRestante;

        #endregion

        #region Propiedades (3)

        /// <summary>
        /// Propiedad «getter»/«setter» del atributo «EstaEncendida».
        /// </summary>
        internal bool EstaEncendida
        {
            get { return estaEncendida; }

            set { estaEncendida = value; }
        }

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        internal Producto? ProductoEnProduccion
        {
            get { return productoEnProduccion; }

            set { productoEnProduccion = value; }
        }

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        internal uint TiempoRestanteDelProductoEnProduccionEnSegundos
        {
            get { return tiempoRestanteDelProductoEnProduccionEnSegundos; }
        }

        #endregion


        #region Constructores (2)

        /// <summary>
        /// Asigna a la máquina el identificador pasado como parámetro y carga los valores del resto de atributos, correspondientes a una máquina "apagada".
        /// </summary>
        /// <param name="identificador">Cadena de texto asignada al atributo "identificador".</param>
        internal Maquina(string identificador)
        {
            this.identificador = identificador;
            estaEncendida = false;
            productoEnProduccion = null;
            tiempoRestanteDelProductoEnProduccionEnSegundos = 0;

            cancelacionDeProduccionYDecrementoDelTiempoRestante = new();
        }

        /// <summary>
        /// Asigna a la máquina el identificador y el producto en producción pasados como parámetros, inicia la producción del mismo en un hilo secundario (previa validación) y carga los valores del resto de atributos, correspondientes a una máquina "encendida".
        /// </summary>
        /// <param name="identificador">Cadena de texto asignada al atributo "identificador".</param>
        /// <param name="productoEnProduccion">Producto asignado al atributo "productoEnProduccion".</param>
        /// <exception cref="ArgumentNullException">Lanzada si el parámetro "productoEnProduccion" es "null".</exception>
        internal Maquina(string identificador, Producto? productoEnProduccion) : this(identificador)
        {
            estaEncendida = true;
            this.productoEnProduccion = productoEnProduccion;

            if (productoEnProduccion is not null)
            {
                ComenzarProduccion();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        #endregion


        #region Métodos (10)

        #region Métodos normales (7)

        /// <summary>
        /// Ejecuta el método «ActualizarTiempoRestanteDelProductoEnProduccion» y pone a ejecutar el método «ProducirProductoEnProduccion» en un hilo secundario.
        /// </summary>
        private void ComenzarProduccion()
        {
            ActualizarTiempoRestanteDelProductoEnProduccion();
            Task.Run(() => { ProducirProductoEnProduccion(); }, cancelacionDeProduccionYDecrementoDelTiempoRestante.Token);
        }

        /// <summary>
        /// Inicia la producción del producto en producción en bucle, hasta que se solicite la cancelación de la misma o se agoten las reservas de materia prima necesarias para la producción de dicho producto.
        /// Asocia el método "SuspenderProduccion" al evento de la clcase "Fábrica" que anuncia el agotamiento de las reservas de mateira prima que corresponda con el actual producto en producción.
        /// Llama al método "RestarTiempoRestanteDelProductoEnProduccion" en un hilo secundario, al que se le pasa como parámetro el mismo token de cancelación que al hilo actual.
        /// Valida que siga habiendo materia prima suficiente como para hacer el siguiente producto, haciendo uso del método "ValidarQueHayaMateriaPrima" de la clase "Fábrica".
        /// Duerme el hilo actual por el tiempo que tome producir el producto en producción.
        /// Valida que la cancelación del hilo no haya sido solicitada, para evitar la producción del producto si dicha cancelación fue solicitada durante el último "Thread.Sleep".
        /// Agrega una nueva instancia del producto en producción al inventario de productos de la fábrica.
        /// Lanza el evento "ProductoTerminado", si hay al menos un método suscripto a él.
        /// </summary>
        /// <exception cref="ArgumentNullException">Lanzada si el atributo "productoEnProduccion" es nulo.</exception>
        private void ProducirProductoEnProduccion()
        {
            switch (productoEnProduccion?.Nombre)
            {
                case "Barra de cobre":

                    Fabrica.ReservasDeCobreAgotadas += SuspenderProduccion;

                    break;

                case "Barra de hierro":

                    Fabrica.ReservasDeHierroAgotadas += SuspenderProduccion;

                    break;

                default:

                    throw new ArgumentNullException();
            }

            Task.Run(() => { RestarTiempoRestanteDelProductoEnProduccion(); }, cancelacionDeProduccionYDecrementoDelTiempoRestante.Token);

            do
            {
                if (Fabrica.ValidarQueHayaMateriaPrima(productoEnProduccion) == true)
                {
                    Thread.Sleep((int)productoEnProduccion.TiempoDeProduccionEnMilisegundos);

                    if (!cancelacionDeProduccionYDecrementoDelTiempoRestante.IsCancellationRequested)
                    {
                        Fabrica.InventarioDeProductos[(uint)productoEnProduccion].Add(new Producto(productoEnProduccion.Nombre, productoEnProduccion.TiempoDeProduccionEnMilisegundos)); //Agrega un nuevo producto al inventario de productos de la fábrica.

                        ProductoTerminado?.Invoke(productoEnProduccion);
                    }
                }
            } while (estaEncendida == true && !cancelacionDeProduccionYDecrementoDelTiempoRestante.IsCancellationRequested);
        }

        /// <summary>
        /// Cambia el estado de una máquina al opuesto del actual ("encendida" o "apagada").
        /// Si el estado actual de la máquina es "encendida", cancela el hilo de producción actual y cambia el valor del atributo "estaProduciendo" a "false".
        /// Si el estado actual de la máquina es "apagada", inicia la producción del producto recibido como parámetro en un hilo secundario y cambia el valor del atributo "estaProduciendo" a "true".
        /// </summary>
        /// <param name="productoAProducirEnCasoDeEncender">Producto a ser producido en caso de que el estado de la máquina sea cambiado a «encendida».</param>
        internal void CambiarEstado(Producto? productoAProducirEnCasoDeEncender)
        {
            if (estaEncendida == true)
            {
                SuspenderProduccion();

                estaEncendida = false;
            }
            else
            {
                productoEnProduccion = productoAProducirEnCasoDeEncender;

                ComenzarProduccion();

                estaEncendida = true;
            }
        }

        /// <summary>
        /// Inicia la producción del producto pasado como parámetro en un hilo secundario (previa validaciones).
        /// Valida que el nuevo producto a producir no sea nulo.
        /// Valida que el estado actual de la máquina sea "apagada" (es decir, que no tenga un producto en producción) o que el nuevo producto a producir sea distinto al producto en producción actual.
        /// Si el estado actual de la máquina es "encendida", cancela el hilo de producción actual. De lo contrario, cambia el atributo "estaProduciendo" a "true".
        /// Llama al método "ActualizarTiempoRestanteDelProductoEnProduccion".
        /// <param name="productoAlQueCambiar">Producto asignado al atributo "productoEnProduccion".</param>
        /// <param name="mensajeDeError">Cadena de texto retornada a modo de mensaje de error, si es que ocurre uno. Si no hay error, "string.Empty".</param>
        /// <exception cref="ArgumentNullException">Lanzada si el parámetro "productoAlQueCambiar" es "null".</exception>
        internal void CambiarProductoEnProduccion(Producto? productoAlQueCambiar, out string mensajeDeError)
        {
            if (productoAlQueCambiar is not null)
            {
                if (Fabrica.ValidarQueHayaMateriaPrima(productoAlQueCambiar) == true)
                {
                    if (productoEnProduccion is null || (uint)productoEnProduccion != (uint)productoAlQueCambiar)
                    {
                        if (estaEncendida == true)
                        {
                            SuspenderProduccion();

                            cancelacionDeProduccionYDecrementoDelTiempoRestante = new CancellationTokenSource(); //TODO: Averiguar cómo hacer para que el "cancelacionDeProduccionYDecrementoDelTiempoRestante" cierre todo lo que tiene que cerrar, antes de asignarle un token nuevo.
                        }
                        else
                        {
                            estaEncendida = true;
                        }

                        productoEnProduccion = productoAlQueCambiar;

                        ComenzarProduccion();

                        mensajeDeError = string.Empty;
                    }
                    else
                    {
                        mensajeDeError = "Por favor, seleccione un producto diferente al que se está produciendo";
                    }
                }
                else
                {
                    mensajeDeError = "No hay suficiente materia prima para fabricar ese producto.";
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Resta una unidad al atributo "tiempoRestanteDelProductoEnProduccionEnSegundos" por cada segundo que pasa, hasta que la máquina "sea apagada" o la cancelación del hilo sea solicitada.
        /// Actualiza el tiempo restante del producto en producción cuando dicho valor llega a cero, sincronizando el atributo con el inicio de la fabricación de la siguiente unidad del producto en producción.
        /// Evita la resta si la cancelación del hilo fue solicitada mientras se producía la misma (durante el último "Thread.Sleep(1000)").
        /// </summary>
        internal void RestarTiempoRestanteDelProductoEnProduccion()
        {
            do
            {
                if (tiempoRestanteDelProductoEnProduccionEnSegundos == 0)
                {
                    ActualizarTiempoRestanteDelProductoEnProduccion();
                }

                Thread.Sleep(1000);

                if (!cancelacionDeProduccionYDecrementoDelTiempoRestante.IsCancellationRequested)
                {
                    tiempoRestanteDelProductoEnProduccionEnSegundos--;
                    SegundoDelTiempoRestanteDelProductoEnProduccionRestado?.Invoke(identificador);
                }
            }
            while (estaEncendida == true && !cancelacionDeProduccionYDecrementoDelTiempoRestante.IsCancellationRequested);
        }

        /// <summary>
        /// Pasa a segundos el tiempo de producción del producto en producción actual (dividiendolo entre mil) y lo asigna al atributo "tiempoRestanteDelProductoEnProduccionEnSegundos", actualizando el mismo.
        /// </summary>
        internal void ActualizarTiempoRestanteDelProductoEnProduccion()
        {
            tiempoRestanteDelProductoEnProduccionEnSegundos = productoEnProduccion.TiempoDeProduccionEnMilisegundos / 1000;
        }

        /// <summary>
        /// Supende la producción del actual producto en producción.
        /// Cancela tanto el tanto el hilo encargado de la producción del producto, como el encargado de decrementar el tiempo restante para producir dicho producto.
        /// Cambia el valor del atributo "estaProduciendo" a "false".
        /// Cambia el valor del atributo "productoEnProduccion" a "null"
        /// </summary>
        internal void SuspenderProduccion()
        {
            cancelacionDeProduccionYDecrementoDelTiempoRestante.Cancel();

            estaEncendida = false;

            productoEnProduccion = null;
        }

        #endregion

        #region Sobrecargas de los métodos "ToString", "Equals" y "GetHashCode"

        /// <summary>
        /// Devuelve el identificador de la máquina.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return identificador;
        }

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is Maquina maquina &&
                   identificador == maquina.identificador;
        }

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(identificador);
        }

        #endregion

        #endregion
    }
}