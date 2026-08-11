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
    public class Supervisor : Personal
    {
        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        public Supervisor(string nombre, string contrasenia) : base(nombre, contrasenia, ENivelDeAcceso.NivelDeAcceso2)
        {

        }
    }
}
