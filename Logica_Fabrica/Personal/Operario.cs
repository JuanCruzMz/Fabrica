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
    public class Operario : Personal
    {
        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        public Operario(string nombre, string contrasenia) : base(nombre, contrasenia, ENivelDeAcceso.NivelDeAcceso1)
        {

        }

        #region Métodos (1)

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        public override string MostrarInformacion()
        {
            return $"> {Nombre}:\n- Contraseña: {Contrasenia}";
        }

        #endregion
    }
}
