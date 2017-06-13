using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    [Serializable]
    public sealed class Alumno : Universitario
    {
        #region enumerado
        public enum EEstadoCuenta {AlDia, Deudor, Becado };
        #endregion

        #region atributos
        public Universidad.EClases _claseQueToma;
        public EEstadoCuenta _estadoCuenta;
        #endregion

        #region constructores
        public Alumno() { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id,nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion

        #region metodos

        /// <summary>
        /// Retorna cadena con todos los atributos de la clase
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());

            switch (this._estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    sb.AppendLine("ESTADO DE CUENTA: CUOTA AL DIA");
                    break;
                case EEstadoCuenta.Deudor:
                    sb.AppendLine("ESTADO DE CUENTA: CUOTA CON DEUDA");
                    break;
                case EEstadoCuenta.Becado:
                    sb.AppendLine("ESTADO DE CUENTA: BECADO");
                    break;
                default:
                    sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta.ToString());
                    break;
            }
            sb.AppendLine("TOMA CLASES DE: " + this._claseQueToma.ToString());
            
            return sb.ToString();
        }

        /// <summary>
        /// Retorna cadena con clase que toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma.ToString();
        }

        /// <summary>
        /// Retorna y hace publicos todos los atributos de la clase
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Un alumno es igual a una EClase si cursa esa clase y si su estado de cuenta no es deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="ec"></param>
        /// <returns></returns>
        public static bool operator == (Alumno a, Universidad.EClases ec)
        {
            if ((Universidad.EClases)ec == (Universidad.EClases)a._claseQueToma && EEstadoCuenta.Deudor != (EEstadoCuenta)a._estadoCuenta && a != null)
                return true;
            return false;
        }

        /// <summary>
        /// Un alumno no es igual a una EClase si no cursa esa clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="ec"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases ec)
        {
            return (Universidad.EClases)a._claseQueToma != (Universidad.EClases)ec;
        }
        #endregion
    }
}
