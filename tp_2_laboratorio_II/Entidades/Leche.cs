using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2017
{
    public class Leche: Producto
    {
        #region enumerado
        public enum ETipo { Entera, Descremada }
        #endregion

        #region atributos
        ETipo _tipo;
        #endregion

        #region constructores

        /// <summary>
        /// Por defecto, el atributo TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : base(marca, codigo, color)
        {
            this._tipo = ETipo.Entera;
        }

        /// <summary>
        /// Sobrecarga de constructor con el atributo TIPO
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color,ETipo tipo)
            : this(marca, codigo, color)
        {
            this._tipo = tipo;
        }

        #endregion

        #region propiedades

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get { return 20; }
        }

        #endregion

        #region metodos

        /// <summary>
        /// Retorna toda la informacion del Producto.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this._tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        
        #endregion
    }
}
