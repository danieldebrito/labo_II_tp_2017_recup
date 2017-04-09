using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreria_tp1
{
    public class Calculadora
    {
        #region Methods
        /// <summary>
        /// Opera dos objetos de tipo Numero
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double ret = 0;
            
            switch (validarOperador(operador))
            {
                case "-":
                    ret = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*":
                    ret = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    if (numero2.getNumero() == (double)0)
                        ret = 0;
                    else
                    ret = numero1.getNumero() / numero2.getNumero();
                    break;
                default:
                    ret = numero1.getNumero() + numero2.getNumero();
                    break;
            }
            return ret;
        }

        /// <summary>
        /// Valida el operador de operacion
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static string validarOperador(string operador)
        {
            if (operador != "-" && operador != "/" && operador != "*")
                return "+";
            return operador;
        }
        #endregion
    }
}
