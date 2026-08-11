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
    public partial class FormMenuPrincipal : Form
    {
        #region Atributos (3)

        /// <summary>
        /// Refiere a la instancia de "FormDeInicio" que invocó a esta instancia de "FormMenuPrincipal". 
        /// Se le pasará como parámetro al constructor de "FormMenuPrincipal" para que pueda ser mostrado al salir.
        /// </summary>
        public Form formPrevio;

        /// <summary>
        /// Refiere al nivel de acceso del ususario ingresado (debe ser igual a "1" o "2").
        /// Se le pasará como parámetro al constructor de "FormMenuPrincipal" para determinar que botones quedarán accesibles al mismo.
        /// </summary>
        public uint nivelDeAccesoDelUsuario;

        /// <summary>
        /// Mensaje a ser mostrado por el botón de ayuda, dependiendo del nivel de acceso del usuario.
        /// </summary>
        public string mensajeDelBotonDeAyuda;

        #endregion


        #region Constructor y Load

        /// <summary>
        /// Constructor normal del formulario, que además recibe un formulario a ser guardado como "formPrevio" y el nivel de acceso del usuario ingresado.
        /// </summary>
        /// <param name="formPrevio">Formulario a ser guardado y mostrado al hacer el "Close()" de esta instancia.</param>
        /// <param name="nivelDeAccesoDelUsuario">Número que determinará el nivel de acceso del ususario ingresado (debe ser igual a "1" o "2").</param>
        public FormMenuPrincipal(Form formPrevio, uint nivelDeAccesoDelUsuario)
        {
            InitializeComponent();

            this.formPrevio = formPrevio;
            this.nivelDeAccesoDelUsuario = nivelDeAccesoDelUsuario;
        }

        /// <summary>
        /// Determina que nivel de acceso tiene el usuario ingresado y carga el menú principal con los controles e información correspondientes.
        /// Cambia el color de fondo del formulario a "Cyan", así como oculta los controles "btn_VerAlmacen" y "btn_VerOperarios", si el nivel de acceso del usuario corresponde al de un operario.
        /// Carga el texto mostrado al pulsar el botón de ayuda del formulario, dependiendo del nivel de acceso del usuario.
        /// </summary>
        /// <exception cref="ArgumentException">Lanzada si el atributo "nivelDeAccesoDelUsuario" es distinto de "1" o "2".</exception>
        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            switch (nivelDeAccesoDelUsuario)
            {
                case 1:

                    BackColor = Color.Cyan;

                    btn_VerAlmacen.Hide();
                    btn_VerOperarios.Hide();

                    mensajeDelBotonDeAyuda = "Presione el botón \"Ver máquinas\" para entrar al menú de máquinas de la fábrica.\n" +

                                             "\nPresione el botón \"Cerrar sesión\" para regresar al menú de inicio.";

                    break;

                case 2:

                    mensajeDelBotonDeAyuda = "Presione el botón \"Ver máquinas\" para entrar al menú de máquinas de la fábrica.\n" +
                                             "Presione el botón \"Ver almacén\" para entrar al menú del almacén de la fábrica.\n" +
                                             "Presione el botón \"Ver operarios\" para ver una lista de los operarios registrados en el sistema de la fábica.\n" +

                                             "\nPresione el botón \"Cerrar sesión\" para regresar al menú de inicio.";

                    break;

                default: throw new ArgumentException();
            }
        }

        #endregion


        #region Métodos (6)

        /// <summary>
        /// Crea y muestra una nueva instancia de "FormMaquinas".
        /// </summary>
        private void btn_VerMaquinas_Click(object sender, EventArgs e)
        {
            FormMaquinas formMaquinas = new(this);

            formMaquinas.Show();

            Hide();
        }

        /// <summary>
        /// Crea y muestra una nueva instancia de "FormAlmacen".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_VerAlmacen_Click(object sender, EventArgs e)
        {
            FormAlmacen formAlmacen = new(this);

            formAlmacen.Show();

            Hide();
        }

        /// <summary>
        /// Muestra la información de los operarios registrados en el sistema.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_VerOperarios_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Fabrica.MostrarOperarios(), "Operarios registrados");
        }

        /// <summary>
        /// Muestra un "MessageBox" con información sobre el uso del formulario y sus controles.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ayuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(mensajeDelBotonDeAyuda, "Menú principal", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Cierra el menú principal y, si el usuario confirma la acción, vuelve a mostrar el menú de inicio de sesión.
        /// </summary>
        private void btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Da una última oportunidad al usuario de cancelar el cierre de sesión.
        /// </summary>
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de querer cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                formPrevio.Show();
            }
        }

        #endregion
    }
}
