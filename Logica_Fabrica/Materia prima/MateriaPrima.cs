using Logica_Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_Fabrica
{
    /// <summary>
    /// TODO: Documentar.
    /// </summary>
    internal class MateriaPrima
    {
        #region Atributos (2)

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        private string nombre;
        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        private uint cantidad;

        #endregion

        #region Propiedades (2)

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        internal string Nombre
        {
            get { return nombre; }
        }

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        internal uint Cantidad
        {
            get { return cantidad; }

            set { cantidad = value; }
        }

        #endregion


        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        public MateriaPrima(string nombre, uint cantidad)
        {
            this.nombre = nombre;
            this.cantidad = cantidad;
        }


        #region Sobrecargas de los métodos "ToString", "Equals" y "GetHashCode".

        /// <summary>
        /// Devuelve el nombre de la materia prima.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return nombre;
        }

        public override bool Equals(object obj)
        {
            return obj is MateriaPrima miembroDelPersonal && nombre == miembroDelPersonal.nombre;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(nombre);
        }

        #endregion
    }
}
