using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreria_tp1
{
    public class Numero
    {
        #region Fields
        private double _numero;
        #endregion

        #region Methods
        /// <summary>
        /// Devuelve un valor del tipo double de la instamcia actual
        /// </summary>
        /// <returns></returns>
        public double getNumero()
        {
            return this._numero;
        }
        
        /// <summary>
        /// Establece un valor validado de tipo double a la instancia actual, a partir de un string
        /// </summary>
        /// <param name="numero"></param>
        private void setNumero(string numero)
        {
            this._numero = validarNumero(numero);
        }
        
        /// <summary>
        /// Valida y comvierte un string en double
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns></returns>
        private double validarNumero(string numeroString)
        { 
            double numero;

            if (!(double.TryParse(numeroString, out numero)))
                return 0;
            return numero;
        }
        
        /// <summary>
        /// Constructor por defecto, inucializa el atributo _numero en cero
        /// </summary>
        public Numero():this(0)
        {
        }
        
        /// <summary>
        /// constructor, asigna el parametro de tipo double al atributo _numero
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this._numero = numero;
        }
        
        /// <summary>
        /// constructor, asigna el parametro de tipo string al atributo _numero
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            this.setNumero(numero);
        }
        #endregion
    }
}
