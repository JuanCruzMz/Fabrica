using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Logica_Fabrica;

namespace Interfaz_Fabrica
{
    /// <summary>
    /// TODO: Documentar.
    /// </summary>
    public partial class FormMaquinas : Form
    {
        #region Atributos (2)

        /// <summary>
        /// Refiere a la instancia del formulario que invocó a esta instancia de "FormMaquinas". 
        /// Se le pasará como parámetro al constructor de "FormMaquinas" para que pueda ser mostrado al salir.
        /// </summary>
        public Form formPrevio;

        /// <summary>
        /// Variable utilizada como bandera en los métodos "cmb_CambiarProducciónMaquina_SelectedIndexChanged" para evitar que estos sean invocados apenas es cargado el formulario.
        /// </summary>
        private bool SeTerminoDeCargarElForm;

        #endregion


        #region Constructor y Load

        /// <summary>
        /// Constructor normal del formulario, que además recibe un formulario a ser guardado como "formPrevio"
        /// </summary>
        /// <param name="formPrevio">TODO: e</param>
        public FormMaquinas(Form formPrevio)
        {
            InitializeComponent();

            this.formPrevio = formPrevio;
        }

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        private void FormMaquinas_Load(object sender, EventArgs e)
        {
            #region Máquina 1

            Fabrica.SegundoDelTiempoRestanteDelProductoEnProduccionDeLaMaquina1Restado += Actualizarlbl_ProduccionMaquina1;

            if (Fabrica.RetornarEstadoDeUnaMaquina(1) == true)
            {
                switch (Fabrica.RetornarNombreDelProductoDeUnaMaquina(1))
                {
                    case "Barra de cobre":

                        Fabrica.ReservasDeCobreAgotadas += EstablecerValoresPorDefectoALosControlesDeLaMaquina1;

                        break;

                    case "Barra de hierro":

                        Fabrica.ReservasDeHierroAgotadas += EstablecerValoresPorDefectoALosControlesDeLaMaquina1;

                        break;

                    default:

                        throw new Exception();
                }

                lbl_ProduccionMaquina1.Text = $"Produciendo: {Fabrica.RetornarNombreDelProductoDeUnaMaquina(1)} en {Fabrica.RetornarTiempoRestanteEnSegundosDelProductoDeUnaMaquina(1)} segundos...";

                btn_ReanudarMaquina1.Hide();
                lbl_SeleccionUnProductoMaquina1.Hide();
            }
            else
            {
                EstablecerValoresPorDefectoALosControlesDeLaMaquina1();
            }

            cmb_CambiarProducciónMaquina1.DataSource = Fabrica.RetornarNombresDeProductos();

            #endregion

            SeTerminoDeCargarElForm = true;
        }

        #endregion


        #region Métodos (19)

        #region Máquina 1

        /// <summary>
        /// Detiene la producción de la primera máquina de la fábrica.
        /// </summary>
        private void btn_DetenerMaquina1_Click(object sender, EventArgs e)
        {
            Fabrica.CambiarEstadoDeUnaMaquina(1);

            lbl_ProduccionMaquina1.Text = "N/A.";

            btn_ReanudarMaquina1.Show();
            btn_DetenerMaquina1.Hide();
        }

        /// <summary>
        /// Reanuda la producción de la primera máquina de la fábrica, si esta se encuentra detenida.
        /// </summary>
        private void btn_ReanudarMaquina1_Click(object sender, EventArgs e)
        {
            Fabrica.CambiarEstadoDeUnaMaquina(1, cmb_CambiarProducciónMaquina1.Text);

            #region Recarga del nombre y tiempo restante de producción del producto de la máquina 1, así como del texto de la etiqueta "lbl_ProduccionMaquina1".

            lbl_ProduccionMaquina1.Text = $"Produciendo: {Fabrica.RetornarNombreDelProductoDeUnaMaquina(1)} en {Fabrica.RetornarTiempoRestanteEnSegundosDelProductoDeUnaMaquina(1)} segundos...";

            #endregion

            btn_DetenerMaquina1.Show();
            btn_ReanudarMaquina1.Hide();
        }

        /// <summary>
        /// Cambia el producto que tiene en producción la primera máquina de la fábrica.
        /// Llama al método "CambiarProductoEnProduccionDeUnaMaquina" de la clase "Fabrica", pasándole el número "1" y el texto del "comboBox" "cmb_CambiarProducciónMaquina1" (previa validación).
        /// Valida que el formulario se haya terminado de cargar, para que el método no sea invocado antes de que el usuario pueda interactuar con el control (ya que, por alguna razón, el formulario hace eso).
        /// Valida que el producto a cambiar no sea el mismo que el que ya se está produciendo y muestra un mensaje de error, de ser ese el caso.
        /// Recarga del nombre y tiempo restante de producción del producto de la máquina, así como del texto de la etiqueta "lbl_ProduccionMaquina1".
        /// Muestra el botón "btn_DetenerMaquina1" y oculta la etiqueta "lbl_SeleccionUnProductoMaquina1".
        /// </summary>
        private void cmb_CambiarProducciónMaquina1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SeTerminoDeCargarElForm == true)
            {
                Fabrica.CambiarProductoEnProduccionDeUnaMaquina(1, cmb_CambiarProducciónMaquina1.Text, out string mensajeDeError);

                if (mensajeDeError == string.Empty)
                {
                    lbl_ProduccionMaquina1.Text = $"Produciendo: {Fabrica.RetornarNombreDelProductoDeUnaMaquina(1)} en {Fabrica.RetornarTiempoRestanteEnSegundosDelProductoDeUnaMaquina(1)} segundos...";

                    btn_DetenerMaquina1.Show();
                    lbl_SeleccionUnProductoMaquina1.Hide();
                }
                else
                {
                    MessageBox.Show(mensajeDeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Recarga la etiqueta "lbl_ProduccionMaquina1", previa validación.
        /// Valida, con el uso de la propiedad "InvokeRequired", que el método sea llamado desde el hilo principal. De lo contrario, se llama a si mismo, tras cambiar al hilo principal.
        /// </summary>
        private void Actualizarlbl_ProduccionMaquina1() //TODO: El tiempo mostrado está al rededor de tres segundos atrasado respecto al tiempo real que falta para que se termine de producir el producto.
        {
            if (InvokeRequired)
            {
                Action CambiarAlHiloPrincipal = Actualizarlbl_ProduccionMaquina1;

                Invoke(CambiarAlHiloPrincipal); //TODO: Excepción: "System.ObjectDisposedException: 'Cannot access a disposed object. ObjectDisposed_ObjectName_Name'".
            }
            else
            {
                lbl_ProduccionMaquina1.Text = $"Produciendo: {Fabrica.RetornarNombreDelProductoDeUnaMaquina(1)} en {Fabrica.RetornarTiempoRestanteEnSegundosDelProductoDeUnaMaquina(1)} segundos...";
            }
        }

        /// <summary>
        /// Establece los controles de la máquina 1 a sus valores por defecto, previa validación.
        /// Valida, con el uso de la propiedad "InvokeRequired", que el método sea llamado desde el hilo principal. De lo contrario, se llama a si mismo, tras cambiar al hilo principal.
        /// Cambia el texto de la etiqueta "lbl_ProduccionMaquina1" a "N/A.".
        /// Oculta el botón "btn_ReanudarMaquina1".
        /// Oculta el botón "btn_DetenerMaquina1".
        /// Cambia el texto de la etiqueta "lbl_SeleccionUnProductoMaquina1" a "<-- Seleccione un producto\n        para iniciar la máquina" y lo muestra.
        /// </summary>
        private void EstablecerValoresPorDefectoALosControlesDeLaMaquina1()
        {
            if (InvokeRequired)
            {
                Action CambiarAlHiloPrincipal = EstablecerValoresPorDefectoALosControlesDeLaMaquina1;

                Invoke(CambiarAlHiloPrincipal);
            }
            else
            {
                lbl_ProduccionMaquina1.Text = "N/A.";

                btn_ReanudarMaquina1.Hide();
                btn_DetenerMaquina1.Hide();

                lbl_SeleccionUnProductoMaquina1.Text = "<-- Seleccione un producto\n" +
                                                       "       para iniciar la máquina";
                lbl_SeleccionUnProductoMaquina1.Show();
            }
        }

        #endregion

        #region Máquina 2

        /// <summary>
        /// Detiene la producción de la segunda máquina de la fábrica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DetenerMaquina2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Reanuda la producción de la segunda máquina de la fábrica, si esta se encuentra detenida.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ReanudarMaquina2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Cambia el producto que tiene en producción la segunda máquina de la fábrica.
        /// Llama al método "CambiarProductoEnProduccionDeUnaMaquina" de la clase "Fabrica", pasándole el número "2" y el texto del "comboBox" "cmb_CambiarProducciónMaquina2" (previa validación).
        /// Valida que el formulario se haya terminado de cargar, para que el método no sea invocado antes de que el usuario pueda interactuar con el control (ya que, por alguna razón, el formulario hace eso).
        /// Valida que el producto a cambiar no sea el mismo que el que ya se está produciendo y muestra un mensaje de error, de ser ese el caso.
        /// Recarga del nombre y tiempo restante de producción del producto de la máquina, así como del texto de la etiqueta "lbl_ProduccionMaquina2".
        /// Muestra el botón "btn_DetenerMaquina2" y oculta la etiqueta "lbl_SeleccionUnProductoMaquina2".
        /// </summary>
        private void cmb_CambiarProducciónMaquina2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Máquina 3

        /// <summary>
        /// Detiene la producción de la tercera máquina de la fábrica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DetenerMaquina3_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Reanuda la producción de la tercera máquina de la fábrica, si esta se encuentra detenida.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ReanudarMaquina3_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Cambia el producto que tiene en producción la tercera máquina de la fábrica.
        /// Llama al método "CambiarProductoEnProduccionDeUnaMaquina" de la clase "Fabrica", pasándole el número "3" y el texto del "comboBox" "cmb_CambiarProducciónMaquina3" (previa validación).
        /// Valida que el formulario se haya terminado de cargar, para que el método no sea invocado antes de que el usuario pueda interactuar con el control (ya que, por alguna razón, el formulario hace eso).
        /// Valida que el producto a cambiar no sea el mismo que el que ya se está produciendo y muestra un mensaje de error, de ser ese el caso.
        /// Recarga del nombre y tiempo restante de producción del producto de la máquina, así como del texto de la etiqueta "lbl_ProduccionMaquina3".
        /// Muestra el botón "btn_DetenerMaquina3" y oculta la etiqueta "lbl_SeleccionUnProductoMaquina3".
        /// </summary>
        private void cmb_CambiarProducciónMaquina3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Máquina 4

        /// <summary>
        /// Detiene la producción de la cuarta máquina de la fábrica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DetenerMaquina4_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Reanuda la producción de la cuarta máquina de la fábrica, si esta se encuentra detenida.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ReanudarMaquina4_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Cambia el producto que tiene en producción la cuarta máquina de la fábrica.
        /// Llama al método "CambiarProductoEnProduccionDeUnaMaquina" de la clase "Fabrica", pasándole el número "4" y el texto del "comboBox" "cmb_CambiarProducciónMaquina4" (previa validación).
        /// Valida que el formulario se haya terminado de cargar, para que el método no sea invocado antes de que el usuario pueda interactuar con el control (ya que, por alguna razón, el formulario hace eso).
        /// Valida que el producto a cambiar no sea el mismo que el que ya se está produciendo y muestra un mensaje de error, de ser ese el caso.
        /// Recarga del nombre y tiempo restante de producción del producto de la máquina, así como del texto de la etiqueta "lbl_ProduccionMaquina4".
        /// Muestra el botón "btn_DetenerMaquina4" y oculta la etiqueta "lbl_SeleccionUnProductoMaquina4".
        /// </summary>
        private void cmb_CambiarProducciónMaquina4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Máquina 5

        /// <summary>
        /// Detiene la producción de la quinta máquina de la fábrica.
        /// </summary>
        private void btn_DetenerMaquina5_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Reanuda la producción de la quinta máquina de la fábrica.
        /// Recarga del nombre y tiempo restante de producción del producto de la máquina 5, así como del texto de la etiqueta "lbl_ProduccionMaquina5".
        /// Muestra el botón "btn_DetenerMaquina5" y oculta el botón "btn_ReanudarMaquina5".
        /// </summary>
        private void btn_ReanudarMaquina5_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Cambia el producto que tiene en producción la quinta máquina de la fábrica.
        /// Llama al método "CambiarProductoEnProduccionDeUnaMaquina" de la clase "Fabrica", pasándole el número "5" y el texto del "comboBox" "cmb_CambiarProducciónMaquina5" (previa validación).
        /// Valida que el formulario se haya terminado de cargar, para que el método no sea invocado antes de que el usuario pueda interactuar con el control (ya que, por alguna razón, el formulario hace eso).
        /// Valida que el producto a cambiar no sea el mismo que el que ya se está produciendo y muestra un mensaje de error, de ser ese el caso.
        /// Recarga del nombre y tiempo restante de producción del producto de la máquina, así como del texto de la etiqueta "lbl_ProduccionMaquina5".
        /// Muestra el botón "btn_DetenerMaquina5" y oculta la etiqueta "lbl_SeleccionUnProductoMaquina5".
        /// </summary>
        private void cmb_CambiarProducciónMaquina5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        /// <summary>
        /// Muestra un "MessageBox" con información sobre el uso del formulario y sus controles.
        /// </summary>
        private void btn_Ayuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("", "Menú de máquinas", MessageBoxButtons.OK, MessageBoxIcon.Question); //TODO: Cambiar texto del botón de ayuda de "FormMaquinas" en cuanto estén terminados todos los controles del mismo.
        }

        /// <summary>
        /// Cierra el menú de máquinas y vuelve a mostrar el menú principal con el nivel de acceso correspondiente al del usuario que haya iniciado sesión.
        /// </summary>
        private void btn_Volver_Click(object sender, EventArgs e)
        {
            Close();

            formPrevio.Show();
        }

        #endregion
    }
}