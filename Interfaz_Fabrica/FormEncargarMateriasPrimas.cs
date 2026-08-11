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
    public partial class FormEncargarMateriasPrimas : Form
    {
        #region Constructor y Load

        /// <summary>
        /// Constructor normal del formulario, que además recibe un formulario a ser guardado como "formPrevio"
        /// </summary>
        /// <param name="formPrevio"></param>
        public FormEncargarMateriasPrimas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        private void FormEncargarMateriasPrimas_Load(object sender, EventArgs e)
        {
            #region cmb_TipoDeMateriaPrima

            cmb_TipoDeMateriaPrima.DataSource = Fabrica.MostrarTiposDeMateriasPrimas();

            #endregion
        }

        #endregion


        #region Métodos (3)

        /// <summary>
        /// Llama al método "EncargarMateriaPrima", de la clase "Fabrica", pasándole como argumentos los valores de los controles "txt_CantidadDeMateriaPrima" y "cmb_TipoDeMateriaPrima".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConfirmarEncargo_Click(object sender, EventArgs e)
        {
            string mensajeAMostrar = Fabrica.EncargarMateriaPrima(txt_CantidadDeMateriaPrima.Text, cmb_TipoDeMateriaPrima.Text, out bool huboError);

            if (huboError == false)
            {
                MessageBox.Show(mensajeAMostrar, "Encargo realizado");

                Close();
            }
            else
            {
                MessageBox.Show(mensajeAMostrar, "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        /// <summary>
        /// Muestra un "MessageBox" con información sobre el uso del formulario y sus controles.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ayuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Complete los campos con la información pedida y presione el botón \"Confirmar encargo\" para solicitar la materia prima deseada (el encargo no puede superar las mil unidades).\n" +

                            "\nPresione el botón \"Volver\" para cancelar el encargo y volver el menú del almacén.", "Menú de encargo de materias primas", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Cierra el menú de encargo de materias primas y vuelve a darle el foco al menú de gestión del almacén.
        /// </summary>
        private void btn_Volver_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}