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
    internal class Producto
    {
        #region Atributos (2)

        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        private readonly string nombre;

        /// <summary>
        /// Representa el tiempo que le toma a una máquina de la fábrica, fabricar este producto (en segundos).
        /// </summary>
        private uint tiempoDeProduccionEnMilisegundos;

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
        internal uint TiempoDeProduccionEnMilisegundos
        {
            get { return tiempoDeProduccionEnMilisegundos; }
        }

        #endregion


        /// <summary>
        /// TODO: Documentar.
        /// </summary>
        internal Producto(string nombre, uint tiempoDeProduccionEnMilisegundos)
        {
            this.nombre = nombre;
            this.tiempoDeProduccionEnMilisegundos = tiempoDeProduccionEnMilisegundos;
        }


        #region Sobrecarga de operadores de conversión explícitos (2)

        /// <summary>
        /// Convierte una cadena de texto al producto cuyo nombre corresponda.
        /// Lanza una excepción ("ArgumentException") si el nombre de algún no coincide con la cadena de texto.
        /// </summary>
        /// <param name="textoAConvertir">Cadena de texto convertida a producto.</param>
        public static explicit operator Producto?(string textoAConvertir)
        {
            switch (textoAConvertir)
            {
                case "Barra de cobre":

                    return new Producto("Barra de cobre", 30000);

                case "Barra de hierro":

                    return new Producto("Barra de hierro", 45000);

                case "":

                    return null;

                default:
                    
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// Convierte un producto al número entero positivo que corresponda con la indexación de dicho producto en el inventario de productos de la fábrica.
        /// Lanza una excepción ("ArgumentException") si el producto no tiene el nombre de un producto registrado en el inventario de prodcutos de la fábrica.
        /// </summary>
        /// <param name="productoAConvertir">Producto convertido a entero positivo.</param>
        public static explicit operator uint(Producto productoAConvertir)
        {
            switch (productoAConvertir.Nombre)
            {
                case "Barra de cobre":

                    return 1;

                case "Barra de hierro":

                    return 2;

                default:
                    
                    throw new ArgumentException();
            }
        }

        #endregion
    }
}