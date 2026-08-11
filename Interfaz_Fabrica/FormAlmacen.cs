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
    public partial class FormAlmacen : Form
    {
        #region Atributos (1)

        /// <summary>
        /// Refiere a la instancia del formulario que invocó a esta instancia de "FormAlmacen".
        /// Se le pasará como parámetro al constructor de "FormAlmacen" para que pueda ser mostrado al salir.
        /// </summary>
        public Form formPrevio;

        #endregion


        #region Constructor y Load

        /// <summary>
        /// Constructor normal del formulario, que además recibe un formulario a ser guardado como "formPrevio".
        /// </summary>
        /// <param name="formPrevio">Refiere a la instancia del formulario que invocó a esta instancia de "FormAlmacen".</param>
        public FormAlmacen(Form formPrevio)
        {
            InitializeComponent();

            this.formPrevio = formPrevio;
        }

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        private void FormAlmacen_Load(object sender, EventArgs e)
        {
            Fabrica.ProductoTerminado += RecargarListas;

            #region lst_ReservasDeMateriasPrimas

            foreach (string reservaDeMateriaPrima in Fabrica.MostrarReservasDeMateriasPrimas())
            {
                lst_ReservasDeMateriasPrimas.Items.Add(reservaDeMateriaPrima);
            }

            #endregion

            #region lst_InventarioDeProductos

            foreach (string listadoDelProducto in Fabrica.MostrarInventarioDeProductos())
            {
                lst_InventarioDeProductos.Items.Add(listadoDelProducto);
            }

            #endregion
        }

        #endregion


        #region Métodos (4)

        /// <summary>
        /// Recarga las listas "lst_ReservasDeMateriasPrimas" y "lst_InventarioDeProductos", previa validación.
        /// Valida, con el uso de la propiedad "InvokeRequired", que el método sea llamado desde el hilo principal. De lo contrario, se llama a si mismo, tras cambiar al hilo principal.
        /// </summary>
        public void RecargarListas()
        {
            if(InvokeRequired)
            {
                Action CambiarAlHiloPrincipal = RecargarListas;

                Invoke(CambiarAlHiloPrincipal);
            }
            else
            {
                lst_ReservasDeMateriasPrimas.Items.Clear(); //TODO: Error en tiempo de ejecución: *A veces* dice que el índice está fuera de rango. No entiendo el patrón.

                foreach (string reservaDeMateriaPrima in Fabrica.MostrarReservasDeMateriasPrimas())
                {
                    lst_ReservasDeMateriasPrimas.Items.Add(reservaDeMateriaPrima);
                }

                lst_InventarioDeProductos.Items.Clear(); //TODO: Error en tiempo de ejecución: *A veces* dice que el índice está fuera de rango. No entiendo el patrón.

                foreach (string listadoDelProducto in Fabrica.MostrarInventarioDeProductos())
                {
                    lst_InventarioDeProductos.Items.Add(listadoDelProducto);
                }
            }
        }

        /// <summary>
        /// Crea y muestra una nueva instancia de "FormEncargarMateriasPrimas", tras cuyo cierre, recarga el contenido de la lista "lst_ReservasDeMateriasPrimas".
        /// </summary>
        private void btn_EncargarMateriasPrimas_Click(object sender, EventArgs e)
        {
            FormEncargarMateriasPrimas formEncargarMateriasPrimas = new();

            formEncargarMateriasPrimas.ShowDialog();

            #region Recarga de la lista "lst_ReservasDeMateriasPrimas"

            lst_ReservasDeMateriasPrimas.Items.Clear();

            foreach (string reservaDeMateriaPrima in Fabrica.MostrarReservasDeMateriasPrimas())
            {
                lst_ReservasDeMateriasPrimas.Items.Add(reservaDeMateriaPrima);
            }

            #endregion
        }

        /// <summary>
        /// Muestra un "MessageBox" con información sobre el uso del formulario y sus controles.
        /// </summary>
        private void btn_Ayuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Presione el botón \"Encargar materias primas\" para acceder al menú de encargo de materias primas.\n" +

                            "\nPresione el botón \"Volver\" para regresar al menú principal.", "Menú de gestión del almacén", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Cierra el menú de almacén y vuelve a mostrar el menú principal con el nivel de acceso correspondiente al del usuario que haya iniciado sesión.
        /// </summary>
        private void btn_Volver_Click(object sender, EventArgs e)
        {
            Close();

            formPrevio.Show();
        }

        #endregion
    }
}
