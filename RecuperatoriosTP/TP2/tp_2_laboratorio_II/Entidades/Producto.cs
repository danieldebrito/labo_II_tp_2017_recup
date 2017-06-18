using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public abstract class Producto
    {
        #region enumerado
        
        public enum EMarca { Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico }
        
        #endregion

        #region atributos
        
        protected EMarca _marca;
        protected string _codigoDeBarras;
        protected ConsoleColor _colorPrimarioEmpaque;
        
        #endregion

        #region constructor
        
        protected Producto(EMarca marca, string codeBar, ConsoleColor color)
        {
            this._marca = marca; 
            this._codigoDeBarras = codeBar;
            this._colorPrimarioEmpaque = color;
        }
        
        #endregion

        #region propiedades
       
        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto
        /// </summary>
        public abstract short CantidadCalorias { get; }
        
        #endregion
       
        #region metodos

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        
        #endregion

        #region operadores
        
        /// <summary>
        /// Retorna toda la informacion del producto.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static explicit operator string (Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p._codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p._marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p._colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
       
        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator == (Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator != (Producto v1, Producto v2)
        {
            return !(v1 == v2);
        }
       
        #endregion
    }
}
