using System;
using System.Security.AccessControl;
using System.Text;

namespace Logica_Fabrica
{
    /// <summary>
    /// Clase estática principal de la aplicación, encargada de manejar la lógica de la fábrica. Actúa como punto de control entre los distintos componentes de la fábrica (personal, máquinas, materia prima y productos).
    /// </summary>
    public static class Fabrica
    {
        #region Atributos y eventos (13)

        #region Eventos (9)

        /// <summary>
        /// Evento encargado de notificar a los formularios que un producto acaba de terminar de ser producido.
        /// </summary>
        public static event Action ProductoTerminado;

        #region Reservas de materias primas agotadas (3)

        /// <summary>
        /// Evento encargado de notificar a las máquinas y formularios que las reservas de carbón de la fábrica acaban de agotarse.
        /// </summary>
        public static event Action ReservasDeCarbonAgotadas;
        /// <summary>
        /// Evento encargado de notificar a las máquinas y formularios que las reservas de cobre de la fábrica acaban de agotarse.
        /// </summary>
        public static event Action ReservasDeCobreAgotadas;
        /// <summary>
        /// Evento encargado de notificar a las máquinas y formularios que las reservas de hierro de la fábrica acaban de agotarse.
        /// </summary>
        public static event Action ReservasDeHierroAgotadas;

        #endregion

        #region Segundos del tiempo restante del producto en producción de las máquinas, restados (5)

        /// <summary>
        /// Evento encargado de notificar a los formularios que el tiempo de restante del producto en producción de la máquina 1 acaba de ser decrementado.
        /// </summary>
        public static event Action SegundoDelTiempoRestanteDelProductoEnProduccionDeLaMaquina1Restado;
        /// <summary>
        /// Evento encargado de notificar a los formularios que el tiempo de restante del producto en producción de la máquina 2 acaba de ser decrementado.
        /// </summary>
        public static event Action SegundoDelTiempoRestanteDelProductoEnProduccionDeLaMaquina2Restado;
        /// <summary>
        /// Evento encargado de notificar a los formularios que el tiempo de restante del producto en producción de la máquina 3 acaba de ser decrementado.
        /// </summary>
        public static event Action SegundoDelTiempoRestanteDelProductoEnProduccionDeLaMaquina3Restado;
        /// <summary>
        /// Evento encargado de notificar a los formularios que el tiempo de restante del producto en producción de la máquina 4 acaba de ser decrementado.
        /// </summary>
        public static event Action SegundoDelTiempoRestanteDelProductoEnProduccionDeLaMaquina4Restado;
        /// <summary>
        /// Evento encargado de notificar a los formularios que el tiempo de restante del producto en producción de la máquina 5 acaba de ser decrementado.
        /// </summary>
        public static event Action SegundoDelTiempoRestanteDelProductoEnProduccionDeLaMaquina5Restado;

        #endregion

        #endregion

        #region Listas (4)

        /// <summary>
        /// Representa el listado del personal de la fábrica.
        /// </summary>
        private static List<Personal> listadoDelPersonal;
        /// <summary>
        /// Representa el listado del las máquinas de la fábrica.
        /// </summary>
        private static List<Maquina> listaDeMaquinas;
        /// <summary>
        /// Representa las reservas de materias primas de la fábrica.
        /// </summary>
        private static Dictionary<uint, MateriaPrima> reservasDeMateriasPrimas;
        /// <summary>
        /// Representa el inventario de productos de la fábrica.
        /// </summary>
        private static Dictionary<uint, List<Producto>> inventarioDeProductos;

        #endregion

        #endregion

        #region Propiedades (1)

        /// <summary>
        /// Propiedad «getter» del atributo «listadoDelPersonal».
        /// </summary>
        internal static Dictionary<uint, List<Producto>> InventarioDeProductos
        {
            get { return inventarioDeProductos; }
        }

        #endregion


        /// <summary>
        /// Constructor. Instancia las listas de la fábrica y les hardcodea datos.
        /// </summary>
        static Fabrica()
        {
            CargarReservasDeMateriasPrimas();
            CargarInventarioDeProductos();
            CargarMaquinas(); //TODO: Encontrar la forma de que se puedan cargar las máquinas antes que los productos (para mantener el orden que tiene toda la applicación respecto a eso: Personal, máquinas, productos y por último, materias primas).
            CargarPersonal();
        }

        #region Métodos (20)

        #region Métodos del manejo del personal (6)

        /// <summary>
        /// Busca e intenta retornar un miembro del personal de la fábrica en base al nombre que se le pasa como parámetro.
        /// </summary>
        /// <param name="nombreDelMiembroDelPersonalABuscar">Cadena de texto que representa el nombre del miembro del personal a buscar.</param>
        /// <returns>Retornará el miembro del personal de la fábrica cuyo nombre coincida con el que se le pasa como parámetro. Caso contrario, retornara "null".</returns>
        public static Personal? BuscarPersonalPorNombre(string nombreDelMiembroDelPersonalABuscar)
        {
            foreach (Personal miembroDelPersonalABuscar in listadoDelPersonal)
            {
                if (miembroDelPersonalABuscar.ToString() == nombreDelMiembroDelPersonalABuscar)
                {
                    return miembroDelPersonalABuscar;
                }
            }

            return null;
        }

        /// <summary>
        /// Valida que el nombre pasado como parametro figure en el listado del personal de la fábrica.
        /// </summary>
        /// <param name="nombreAValidar"></param>
        /// <returns>Retornará "true" si el nombre figura en el listado del personal de la fábrica. Caso contrario, retornará "false".</returns>
        public static bool ValidarNombre(string nombreAValidar)
        {
            if (BuscarPersonalPorNombre(nombreAValidar) is not null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Valida que la contraseña pasada como parametro corresponda con el nombre del miembro del personal de la fábrica pasado como parámetro, previa validación.
        /// </summary>
        /// <param name="nombreDelMiembroDelPersonal">Cadena de texto que representa el nombre del miembro del personal de la fábrica.</param>
        /// <param name="contraseniaAValidar">Cadena de texto que representa la contraseña.</param>
        /// <returns>Retornará "true" si la contraseña corresponde con el nombre del miembro del personal de la fábrica. Caso contrario, retornará "false".</returns>
        public static bool ValidarContrasenia(string nombreDelMiembroDelPersonal, string contraseniaAValidar)
        {
            foreach (Personal miembroDelPersonal in listadoDelPersonal)
            {
                if (miembroDelPersonal.ToString() == nombreDelMiembroDelPersonal)
                {
                    if (miembroDelPersonal.Contrasenia == contraseniaAValidar)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Recorrerá el listado del personal para luego retornar los nombres y contraseñas de todos los operarios de la fábrica.
        /// </summary>
        /// <returns>Retornará una cadena de texto con la información de los operarios registrados en la fábrica.</returns>
        public static string MostrarOperarios()
        {
            StringBuilder infoDeOperarios = new();

            for (int i = 0; i < listadoDelPersonal.Count; i++)
            {
                if (listadoDelPersonal[i] is Operario)
                {
                    infoDeOperarios.AppendLine($"{listadoDelPersonal[i].MostrarInformacion()}\n");
                }
            }

            return infoDeOperarios.ToString();
        }

        /// <summary>
        /// Retorna el nivel de acceso del miembro del personal cuyo nombre coincida con la cadena de texto pasada como parámetro.
        /// </summary>
        /// <param name="nombreDelMiembroDelPersonal">Cadena de texto a partir de la cual se ubica al miembro del personal, cuyo nivel de acceso se retorna.</param>
        /// <returns>nivel de acceso del miembro del personal cuyo nombre coincida con la cadena de texto pasada como parámetro.</returns>
        public static uint RetornarNivelDeAccesoDeUnMiembroDelPersonal(string nombreDelMiembroDelPersonal)
        {
            return BuscarPersonalPorNombre(nombreDelMiembroDelPersonal).NivelDeAcceso;
        }

        /// <summary>
        /// Retorna el nombre y la contraseña de un miembro aleatorio del personal de la fábrica, con el nivel de acceso pasado como parámetro.
        /// </summary>
        /// <param name="nivelDeAccesoDelMiembroDelPersonal">Número que indica el nivel de acceso del miembro del personal cuyo nombre y contraseña son retornados (debe ser igual a "1" o "2").</param>
        /// <param name="nombreDelMiembroDelPersonalAleatorio">Cadena de texto con el nombre del miembro aleatorio del personal a ser retornado.</param>
        /// <param name="contraseniaDelMiembroDelPersonalAleatorio">Contraseña del miembro aleatorio del personal a ser retornada.</param>
        /// <exception cref="Exception">Lanzada si el parámetro "nivelDeAccesoDelMiembroDelPersonal" es distinto de "1" o "2".</exception>
        public static void RetornarNombreYContraseniaDeUnMiembroDelPersonalAleatorio(uint nivelDeAccesoDelMiembroDelPersonal, out string nombreDelMiembroDelPersonalAleatorio, out string contraseniaDelMiembroDelPersonalAleatorio)
        {
            Random rnd;
            int indiceAleatorio;
            Personal miembroDelPersonalAleatorio;

            switch (nivelDeAccesoDelMiembroDelPersonal)
            {
                case 1:

                    do
                    {
                        rnd = new();
                        indiceAleatorio = rnd.Next(listadoDelPersonal.Count);


                        miembroDelPersonalAleatorio = listadoDelPersonal[indiceAleatorio];
                    } while (miembroDelPersonalAleatorio is not Operario);

                    break;

                case 2:

                    do
                    {
                        rnd = new();
                        indiceAleatorio = rnd.Next(listadoDelPersonal.Count);

                        miembroDelPersonalAleatorio = listadoDelPersonal[indiceAleatorio];
                    } while (miembroDelPersonalAleatorio is not Supervisor);

                    break;

                default: throw new Exception();
            }

            nombreDelMiembroDelPersonalAleatorio = miembroDelPersonalAleatorio.Nombre;
            contraseniaDelMiembroDelPersonalAleatorio = miembroDelPersonalAleatorio.Contrasenia;
        }

        #endregion

        #region Métodos del manejo de las máquinas (6)

        /// <summary>
        /// Retorna el estado de la máquina cuyo índice coincida con el número pasado como parámetro.
        /// </summary>
        /// <param name="indiceDeLaMaquina">Número de la máquina cuyo estado es retornado.</param>
        /// <returns>Estado de la máquina cuyo índice coincida con el número pasado como parámetro.</returns>
        public static bool RetornarEstadoDeUnaMaquina(uint indiceDeLaMaquina)
        {
            return listaDeMaquinas[(int)indiceDeLaMaquina - 1].EstaEncendida;
        }

        /// <summary>
        /// Cambia el estado de la máquina cuyo índice coincida con el número pasado como parámetro y actualiza el producto en producción de dicha máquina por el que corresponda cuyo nombre coincida con la cadena de texto pasada como parámetro.
        /// </summary>
        /// <param name="indiceDeLaMaquina">Número de la máquina cuyo estado es cambiado.</param>
        /// <param name="indiceDeLaMaquina">Cadena de texto que corresponde al nombre del producto que comienza a ser producido, en caso de que el estado de la máquina sea cambiado a «encendido».</param>
        public static void CambiarEstadoDeUnaMaquina(uint indiceDeLaMaquina, string nombreDelProductoASerProducido)
        {
            listaDeMaquinas[(int)indiceDeLaMaquina - 1].CambiarEstado((Producto?)nombreDelProductoASerProducido);
        }
        /// <summary>
        /// Sobrecarga hecha para que no se deba pasar un producto a producir cuando el usuario solo intenta detener la producción. Cambia el estado de la máquina cuyo índice coincida con el número pasado como parámetro.
        /// </summary>
        /// <param name="indiceDeLaMaquina">Número de la máquina cuyo estado es cambiado.</param>
        public static void CambiarEstadoDeUnaMaquina(uint indiceDeLaMaquina)
        {
            CambiarEstadoDeUnaMaquina(indiceDeLaMaquina, "");
        }

        /// <summary>
        /// Cambia el producto de la máquina, cuyo índice coincida con el número pasado como parámetro, por el producto cuyo nombre coincida con la cadena de texto pasada como parámetro.
        /// </summary>
        /// <param name="indiceDeLaMaquina">Número de la máquina cuyo producto en producción es cambiado.</param>
        /// <param name="nombreDelProductoAlQueCambiar">Cadena de texto que corresponde al nombre del producto al que se cambia.</param>
        /// <param name="mensajeDeError">Cadena de texto mostrada al usuario a modo de mensaje de error, si es que ocurre uno. Si no hay error, "string.Empty"</param>
        public static void CambiarProductoEnProduccionDeUnaMaquina(uint indiceDeLaMaquina, string nombreDelProductoAlQueCambiar, out string mensajeDeError)
        {
            try
            {
                listaDeMaquinas[(int)indiceDeLaMaquina - 1].CambiarProductoEnProduccion((Producto?)nombreDelProductoAlQueCambiar, out mensajeDeError);
            }
            catch (ArgumentNullException)
            {
                mensajeDeError = "El producto seleccionado fue \"null\"";
            }
        }

        /// <summary>
        /// Retorna el nombre del producto en producción de la máquina cuyo índice coincida con el número pasado como parámetro.
        /// </summary>
        /// <param name="indiceDeLaMaquina">Número de la máquina cuyo producto, cuyo nombre es retornado.</param>
        public static string RetornarNombreDelProductoDeUnaMaquina(uint indiceDeLaMaquina)
        {
            return listaDeMaquinas[(int)indiceDeLaMaquina - 1].ProductoEnProduccion.Nombre;
        }

        /// <summary>
        /// Retorna el tiempo de producción (en segundos) del producto en producción de la máquina cuyo índice coincida con el número pasado como parámetro.
        /// </summary>
        /// <param name="indiceDeLaMaquina">Número de la máquina cuyo producto, cuyo tiempo de producción (en segundos) es retornado.</param>
        public static uint RetornarTiempoRestanteEnSegundosDelProductoDeUnaMaquina(uint indiceDeLaMaquina)
        {
            return listaDeMaquinas[(int)indiceDeLaMaquina - 1].TiempoRestanteDelProductoEnProduccionEnSegundos;
        }

        /// <summary>
        /// Lanza el evento que notifica a los formularios que el tiempo restante del producto en producción de una máquina fue decrementado, que corresponda con la máquina cuyo producto en producción, cuyo tiempo restante fue decrementado.
        /// </summary>
        /// <param name="identificadorDeLaMaquinaCuyoTiempoRestanteDelProductoFueRestado">Identificador de la máquina cuyo producto en producción, cuyo tiempo restante fue decrementado.</param>
        /// <exception cref="ArgumentNullException">Lanzada si alguno la caddena de texto pasada como parámetro no es exitosamente comparada con el identificador de alguna máquina de la fábrica.</exception>
        public static void LanzarEventoSegundoDelTiempoRestanteDelProductoEnProduccionDeUnaMaquinaRestado(string identificadorDeLaMaquinaCuyoTiempoRestanteDelProductoFueRestado)
        {
            switch (identificadorDeLaMaquinaCuyoTiempoRestanteDelProductoFueRestado)
            {
                case "AAA-0001": //TODO: Buscar una forma de comparar por los identificadores de cada máquina de la lista de máquinas y no por una cadena hardcodeada como "AAA-0001".

                    SegundoDelTiempoRestanteDelProductoEnProduccionDeLaMaquina1Restado?.Invoke();

                    break;

                case "AAA-0002":

                    SegundoDelTiempoRestanteDelProductoEnProduccionDeLaMaquina2Restado?.Invoke();

                    break;

                case "AAA-0003":

                    SegundoDelTiempoRestanteDelProductoEnProduccionDeLaMaquina3Restado?.Invoke();

                    break;

                case "AAA-0004":

                    SegundoDelTiempoRestanteDelProductoEnProduccionDeLaMaquina4Restado?.Invoke();

                    break;

                case "AAA-0005":

                    SegundoDelTiempoRestanteDelProductoEnProduccionDeLaMaquina5Restado?.Invoke();

                    break;

                default:

                    throw new ArgumentNullException();
            }
        }

        #endregion

        #region Métodos del manejo de las materias primas (6)

        /// <summary>
        /// Retorna una lista de strings con las reservas de materias primas disponibles en la fábrica.
        /// </summary>
        /// <returns>Una lista de strings, cuyos elementos corresponderán con los distintos tipos y cantidades de materias primas de la fábrica.</returns>
        public static List<string> MostrarReservasDeMateriasPrimas()
        {
            List<string> reservasDeMateriasPrimasAMostrar = new();

            foreach (MateriaPrima materiaPrimaAMostrar in reservasDeMateriasPrimas.Values)
            {
                reservasDeMateriasPrimasAMostrar.Add($"{materiaPrimaAMostrar.Nombre}: {materiaPrimaAMostrar.Cantidad}.");
            }

            return reservasDeMateriasPrimasAMostrar;
        }

        /// <summary>
        /// Retorna una lista de strings con los tipos de materias primas disponibles en la fábrica.
        /// </summary>
        /// <returns>Una lista de strings, cuyos elementos corresponderán con los distintos tipos de materias primas de la fábrica.</returns>
        public static List<string> MostrarTiposDeMateriasPrimas()
        {
            List<string> tiposDeMateriasPrimas = new();

            foreach (MateriaPrima materiaPrimaAMostrar in reservasDeMateriasPrimas.Values)
            {
                tiposDeMateriasPrimas.Add($"{materiaPrimaAMostrar.Nombre}");
            }

            return tiposDeMateriasPrimas;
        }

        /// <summary>
        /// Valida e intenta agregar la cantidad solicitada a la reserva de la materia prima pedida.
        /// </summary>
        /// <param name="cantidadAEncargar">Cadena de texto que representa la cantidad de materia prima a agregar.</param>
        /// <param name="tipoAEncargar">Cadena de texto que representa el tipo de materia prima a agregar.</param>
        /// <param name="huboError">Informa si el mensaje retornado deberá ser mostrado en formato de error o no.</param>
        /// <returns>Un mensaje a ser mostrado al usuario, informando sobre el resultado de la operación.</returns>
        public static string EncargarMateriaPrima(string cantidadAEncargar, string tipoAEncargar, out bool huboError)
        {
            if (uint.TryParse(cantidadAEncargar, out uint cantidadAEncargarParseadaAUint))
            {
                if (cantidadAEncargarParseadaAUint > 0 && cantidadAEncargarParseadaAUint < 1000)
                {
                    switch (tipoAEncargar)
                    {
                        case "Carbón":

                            AgregarMateriaPrima(1, cantidadAEncargarParseadaAUint);

                            break;

                        case "Cobre":

                            AgregarMateriaPrima(2, cantidadAEncargarParseadaAUint);

                            break;

                        case "Hierro":

                            AgregarMateriaPrima(3, cantidadAEncargarParseadaAUint);

                            break;
                    }

                    huboError = false;

                    return "Se encargó con éxito la materia prima solicitada.";
                }
                else
                {
                    huboError = true;

                    return "El tamaño del encargo debe corresponder con un número entre cero y mil";
                }
            }
            else if (cantidadAEncargar == "")
            {
                huboError = true;

                return "Por favor, ingrese un número válido para realizar el encargo.";
            }
            else
            {
                huboError = true;

                return "Alguno de los caracteres ingresados no es un número válido. Por favor, ingrese un número válido.";
            }
        }

        /// <summary>
        /// Agrega la cantidad indicada a la reserva de la materia prima indicada. 
        /// </summary>
        /// <param name="indiceDeLaMateriaPrimaAAgregar">Número que representa el indice de la materia prima a agregar en lista de las reservas de materias primas de la fábrica.</param>
        /// <param name="cantidadAAgregar">Número que representa la cantidad de materia prima a agregar.</param>
        public static void AgregarMateriaPrima(uint indiceDeLaMateriaPrimaAAgregar, uint cantidadAAgregar)
        {
            reservasDeMateriasPrimas[indiceDeLaMateriaPrimaAAgregar].Cantidad += cantidadAAgregar;
        }

        /// <summary>
        /// Resta de las reservas de la fábrica, la cantidad de materia prima necesaria para producir el tipo de producto pasado como parámetro.
        /// </summary>
        /// <param name="productoProducido">Producto que acaba de ser producido a partir del cual se determina el tipo y la cantidad de materia prima a restar.</param>
        /// <exception cref="ArgumentNullException">Lanzada si la propiedad "Nombre" del parámetro "productoProducido" no puede ser comparado con una cadena de texto exitosamente.</exception>
        internal static void RestarMateriaPrima(Producto productoProducido)
        {
            switch (productoProducido.Nombre)
            {
                case "Barra de cobre":

                    reservasDeMateriasPrimas[2].Cantidad -= 10;

                    break;

                case "Barra de hierro":

                    reservasDeMateriasPrimas[3].Cantidad -= 10;

                    break;

                default:

                    throw new ArgumentNullException();
            }

            ProductoTerminado?.Invoke();
        }

        /// <summary>
        /// Valida que haya suficiente materia prima como para producir al menos una unidad más del producto pasado como parámetro.
        /// </summary>
        /// <param name="productoCuyasMateriasPrimasValidar">Producto cuya materia/s prima/s requerida/s valida que haya.</param>
        /// <returns></returns>
        internal static bool ValidarQueHayaMateriaPrima(Producto productoCuyasMateriasPrimasValidar)
        {
            switch (productoCuyasMateriasPrimasValidar.Nombre)
            {
                case "Barra de cobre":

                    if (reservasDeMateriasPrimas[2].Cantidad >= 10)
                    {
                        return true;
                    }
                    else
                    {
                        ReservasDeCobreAgotadas?.Invoke();

                        return false;
                    }

                case "Barra de hierro":

                    if (reservasDeMateriasPrimas[3].Cantidad >= 10)
                    {
                        return true;
                    }
                    else
                    {
                        ReservasDeHierroAgotadas?.Invoke();

                        return false;
                    }

                default:

                    throw new ArgumentNullException();
            }
        }

        #endregion

        #region Métodos del manejo de los productos (2)

        /// <summary>
        /// Retorna un array de cadenas de texto con los nombres de los distintos productos producidos en la fábrica. 
        /// </summary>
        /// <returns>Array de cadenas de texto con los nombres de los productos del inventario.</returns>
        public static string[] RetornarNombresDeProductos()
        {
            string[] productosAMostrar = new string[inventarioDeProductos.Values.Count];

            for (int i = 0; i < inventarioDeProductos.Count; i++)
            {
                productosAMostrar[i] += inventarioDeProductos[(uint)i + 1].First().Nombre;
            }

            return productosAMostrar;
        }

        /// <summary>
        /// Retorna una lista de strings con el inventario de productos de la fábrica.
        /// </summary>
        /// <returns>Una lista de strings, cuyos elementos corresponderán con los distintos tipos y cantidades de productos de la fábrica.</returns>
        public static List<string> MostrarInventarioDeProductos()
        {
            List<string> inventarioDeProductosAMostrar = new()
            {
                $"{inventarioDeProductos[1].First().Nombre}: {inventarioDeProductos[1].Count}.",
                $"{inventarioDeProductos[2].First().Nombre}: {inventarioDeProductos[2].Count}."
            };

            return inventarioDeProductosAMostrar;
        }

        #endregion

        #region Métodos de carga (Hardcodeo) (4)

        /// <summary>
        /// Carga (hardcodea) el personal de la fábrica en el sistema.
        /// </summary>
        private static void CargarPersonal()
        {
            listadoDelPersonal = new(5);
            {
                Supervisor supervisor1 = new("Leito", "nomeacuerdoelapellido");
                Supervisor supervisor2 = new("Lautaro", "lezama");

                Operario operario1 = new("Joel", "fabrica123");
                Operario operario2 = new("Alexis", "fabrica123");
                Operario operario3 = new("Franco", "fabrica123");

                listadoDelPersonal.Add(supervisor1);
                listadoDelPersonal.Add(supervisor2);
                listadoDelPersonal.Add(operario1);
                listadoDelPersonal.Add(operario2);
                listadoDelPersonal.Add(operario3);
            }
        }

        /// <summary>
        /// Carga (hardcodea) las máquinas de la fábrica en el sistema.
        /// Asocia el método "RestarMateriaPrima" a al evento "ProductoTerminado" de cada máquina.
        /// Asocia el método "LanzarEventoSegundoDelTiempoRestanteDelProductoEnProduccionDeUnaMaquinaRestado" a los eventos "SegundoDelTiempoRestanteDelProductoEnProduccionRestado" de cada máquina.
        /// </summary>
        private static void CargarMaquinas()
        {
            listaDeMaquinas = new(5);
            {
                Maquina maquina1 = new("AAA-0001", inventarioDeProductos[1].First());
                Maquina maquina2 = new("AAA-0002");
                Maquina maquina3 = new("AAA-0003");
                Maquina maquina4 = new("AAA-0004");
                Maquina maquina5 = new("AAA-0005");

                listaDeMaquinas.Add(maquina1);
                listaDeMaquinas.Add(maquina2);
                listaDeMaquinas.Add(maquina3);
                listaDeMaquinas.Add(maquina4);
                listaDeMaquinas.Add(maquina5);

                maquina1.ProductoTerminado += RestarMateriaPrima;
                maquina2.ProductoTerminado += RestarMateriaPrima;
                maquina3.ProductoTerminado += RestarMateriaPrima;
                maquina4.ProductoTerminado += RestarMateriaPrima;
                maquina5.ProductoTerminado += RestarMateriaPrima;

                maquina1.SegundoDelTiempoRestanteDelProductoEnProduccionRestado += LanzarEventoSegundoDelTiempoRestanteDelProductoEnProduccionDeUnaMaquinaRestado;
                maquina2.SegundoDelTiempoRestanteDelProductoEnProduccionRestado += LanzarEventoSegundoDelTiempoRestanteDelProductoEnProduccionDeUnaMaquinaRestado;
                maquina3.SegundoDelTiempoRestanteDelProductoEnProduccionRestado += LanzarEventoSegundoDelTiempoRestanteDelProductoEnProduccionDeUnaMaquinaRestado;
                maquina4.SegundoDelTiempoRestanteDelProductoEnProduccionRestado += LanzarEventoSegundoDelTiempoRestanteDelProductoEnProduccionDeUnaMaquinaRestado;
                maquina5.SegundoDelTiempoRestanteDelProductoEnProduccionRestado += LanzarEventoSegundoDelTiempoRestanteDelProductoEnProduccionDeUnaMaquinaRestado;
            }
        }

        /// <summary>
        /// Carga (hardcodea) las reservas de materias primas de la fábrica en el sistema.
        /// </summary>
        private static void CargarReservasDeMateriasPrimas()
        {
            reservasDeMateriasPrimas = new(3);
            {
                Carbon carbon = new("Carbón", 150);
                Cobre cobre = new("Cobre", 110);
                Hierro hierro = new("Hierro", 80);

                reservasDeMateriasPrimas.Add(1, carbon);
                reservasDeMateriasPrimas.Add(2, cobre);
                reservasDeMateriasPrimas.Add(3, hierro);
            };
        }

        /// <summary>
        /// Carga (hardcodea) el inventario de productos de la fábrica en el sistema.
        /// </summary>
        private static void CargarInventarioDeProductos()
        {
            inventarioDeProductos = new(2);
            {
                List<Producto> inventarioDeBarrasDeCobre = new();
                {
                    for (int i = 0; i < 13; i++)
                    {
                        inventarioDeBarrasDeCobre.Add(new Producto("Barra de cobre", 30000));
                    }
                }

                List<Producto> inventarioDeBarrasDeHierro = new();
                {
                    for (int i = 0; i < 8; i++)
                    {
                        inventarioDeBarrasDeHierro.Add(new Producto("Barra de hierro", 45000));
                    }
                }

                inventarioDeProductos.Add(1, inventarioDeBarrasDeCobre);
                inventarioDeProductos.Add(2, inventarioDeBarrasDeHierro);
            };
        }

        #endregion

        #region Otros métodos (1)

        /// <summary>
        /// Método solo utilizado para que "FormDeInicio" llame al contructor de la clase estática "Fábrica" y se inicie la producción de los productos antes de que el usuario inicie sesión. //TODO: Encontrar una mejor forma de hacer esto.
        /// </summary>
        public static void IniciarFabrica()
        {

        }

        #endregion

        #endregion
    }
}