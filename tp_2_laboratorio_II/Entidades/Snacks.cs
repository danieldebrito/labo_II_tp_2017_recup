using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Snacks: Producto
    {
        #region constructor

        public Snacks(EMarca marca, string codigo, ConsoleColor color)
            : base(marca, codigo, color)
        {
        }

        #endregion

        #region propiedades

        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get { return 104;}
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

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        
        #endregion
    }
}
