using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class Universitario: Persona
    {
        #region atributos
        private int _legajo;
        #endregion

        #region constructores
        public Universitario() { }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido,dni, nacionalidad)
        {
            this._legajo = legajo;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Retorna todos los atributos de la clase
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.Append("LEGAJO: " + this._legajo.ToString());
            
            return sb.ToString();
        }

        /// <summary>
        /// Retorna la clase en que participa
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        
        /// <summary>
        /// Sobrecarga de Equals para determinar si dos obj son del mismo tipo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }

        /// <summary>
        /// Dos Universitario son iguales si son del mismo tipo y su DNI o legago son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator == (Universitario pg1, Universitario pg2)
        {
            if(!object.Equals(pg1,null) && !object.Equals(pg2,null))
            {
                if (pg1.Equals(pg2) && pg1.DNI == pg2.DNI || pg1._legajo == pg2._legajo)
                return true;
            }
            return false;
        }

        /// <summary>
        /// Dos Universitario son distintos si no son del mismo tipo y si su DNI o legajo son distintos
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator != (Universitario pg1, Universitario pg2)
        { 
            return !(pg1 == pg2);
        }
        #endregion
    }
}
