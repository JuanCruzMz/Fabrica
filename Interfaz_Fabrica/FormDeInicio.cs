using Logica_Fabrica;

namespace Interfaz_Fabrica
{
    /// <summary>
    /// TODO: Documentar.
    /// </summary>
    public partial class FormDeInicio : Form
    {
        #region Constructores y Load

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        public FormDeInicio()
        {
            InitializeComponent();
        }

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        private void FormDeInicio_Load(object sender, EventArgs e)
        {
            Fabrica.IniciarFabrica();
        }

        #endregion


        #region Métodos (6)

        /// <summary>
        /// Valida que los textos ingresados correspondan con un nombre y una contraseña válidas, tras lo cual crea y muestra una nueva instancia de "FormMenuPrincipal", pasándole como parámetro el nivel de acceso del usuario ingresado.
        /// </summary>
        private void btn_Iniciar_Sesion_Click(object sender, EventArgs e)
        {
            if (Fabrica.ValidarNombre(txt_Nombre.Text) == true)
            {
                if (Fabrica.ValidarContrasenia(txt_Nombre.Text, txt_Contrasenia.Text) == true)
                {
                    FormMenuPrincipal formMenuPrincipal = new(this, Fabrica.RetornarNivelDeAccesoDeUnMiembroDelPersonal(txt_Nombre.Text));

                    formMenuPrincipal.Show();

                    Hide();
                }
                else
                {
                    MessageBox.Show("El texto ingresado como contraseña no corresponde con la de un usuario registrado. Por favor, ingrese una contraseña válida."); //TODO: Hacer que salga un mensaje distinto cuando se intente ingresar con el campo vacío.
                }
            }
            else
            {
                MessageBox.Show("El texto ingresado como nombre no corresponde con el de un usuario registrado. Por favor, ingrese un nombre válido.");
            }
        }

        /// <summary>
        /// Autocompleta los campos de texto "txt_Nombre.Text" y "txt_Contrasenia.Text" con un nombre y una contraseña correspondiente a un supervisor registrado para agilizar el ingreso.
        /// </summary>
        private void btn_AutocompletarSupervisor_Click(object sender, EventArgs e)
        {
            Fabrica.RetornarNombreYContraseniaDeUnMiembroDelPersonalAleatorio(2, out string nombreDeSupervisorAleatorio, out string ContraseniaDeSupervisorAleatorio);

            txt_Nombre.Text = nombreDeSupervisorAleatorio;
            txt_Contrasenia.Text = ContraseniaDeSupervisorAleatorio;
        }

        /// <summary>
        /// Autocompleta los campos de texto "txt_Nombre.Text" y "txt_Contrasenia.Text" con un nombre y una contraseña correspondiente a un operario registrado para agilizar el ingreso.
        /// </summary>
        private void btn_AutocompletarOperario_Click(object sender, EventArgs e)
        {
            Fabrica.RetornarNombreYContraseniaDeUnMiembroDelPersonalAleatorio(1, out string nombreDeOperarioAleatorio, out string ContraseniaDeOperarioAleatorio);

            txt_Nombre.Text = nombreDeOperarioAleatorio;
            txt_Contrasenia.Text = ContraseniaDeOperarioAleatorio;
        }

        /// <summary>
        /// Muestra un "MessageBox" con información sobre el uso del formulario y sus controles.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ayuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Complete los campos con la información pedida para iniciar sesión y acceder al menú principal.\n" +
                            "Presione el botón \"Iniciar sesión\" para confirmar los datos ingresados y acceder.\n" +
                            "Presione alguno de los botones de \"Autocompletar\" para hackear completamente la matrix y acceder sin escribir nada.\n" +

                            "\nPresione el botón \"Cerrar\" para cerrar la aplicación.", "Menú de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Cierra la aplicación.
        /// </summary>
        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        /// <summary>
        /// Da una última oportunidad al usuario de cancelar el cierre de la aplicación.
        /// </summary>
        private void FormDeInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de querer cerrar la aplicación?", "Cerrar", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #endregion
    }
}