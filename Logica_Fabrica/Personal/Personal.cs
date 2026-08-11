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
    public abstract class Personal
    {
        #region Atributos (3)

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        private string nombre;
        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        private string contrasenia;
        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        private ENivelDeAcceso nivelDeAcceso;

        #endregion

        #region Enumerados (1)

        /// <summary>
        /// Representa los distintos niveles de acceso existentes para el personal de la fábrica, permitiendo diferir entre operarios y supervisores.
        /// </summary>
        protected enum ENivelDeAcceso
        {
            NivelDeAcceso1 = 1, NivelDeAcceso2 = 2
        }

        #endregion

        #region Propiedades (3)

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
        internal string Contrasenia
        {
            get { return contrasenia; }
        }

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        internal uint NivelDeAcceso
        {
            get { return (uint)nivelDeAcceso; }
        }

        #endregion


        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        protected Personal(string nombre, string contrasenia, ENivelDeAcceso nivelDeAcceso)
        {
            this.nombre = nombre;
            this.contrasenia = contrasenia;
            this.nivelDeAcceso = nivelDeAcceso;
        }


        #region Métodos (4)

        #region Métodos normales (1)

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        public virtual string MostrarInformacion()
        {
            return string.Empty;
        }

        #endregion

        #region Sobrecargas de los métodos "ToString", "Equals" y "GetHashCode".

        /// <summary>
        /// Devuelve el nombre del miembro del personal.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return nombre;
        }

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is Personal miembroDelPersonal && nombre == miembroDelPersonal.nombre;
        }

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(nombre);
        }

        #endregion

        #endregion
    }
}
