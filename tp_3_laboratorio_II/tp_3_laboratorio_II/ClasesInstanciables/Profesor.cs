using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    [Serializable]
    public sealed class Profesor: Universitario
    {
        #region enumerados
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;
        #endregion

        #region constructores
        static Profesor()
        {
            _random = new Random();
        }
        public Profesor(){}
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            _clasesDelDia = new Queue<Universidad.EClases>(2);
            _clasesDelDia.Enqueue((Universidad.EClases)_random.Next(1, 4));
            _clasesDelDia.Enqueue((Universidad.EClases)_random.Next(1, 4));
        }
        #endregion

        #region metodos

        /// <summary>
        /// Retorna toda la informacion de la clase
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            
            return sb.ToString();
        }

        /// <summary>
        /// retornará la cadena "CLASES DEL DÍA " junto al nombre de la clases que da
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DÍA:  ");
            foreach (Universidad.EClases c in this._clasesDelDia)
            {
                sb.AppendLine(c.ToString());
            }

            return  sb.ToString();
        }

        /// <summary>
        /// Retorna y hace publicos todos los datos de la clase
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Un Profesor es ugual a una EClase si puede dictar la clase
        /// </summary>
        /// <param name="p"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool operator == (Profesor p, Universidad.EClases c)
        {
            foreach (Universidad.EClases item in p._clasesDelDia)
            {
                if ((Universidad.EClases)c == (Universidad.EClases)item)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Un Profesor no es ugual a una EClase si no puede dictar la clase
        /// </summary>
        /// <param name="p"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool operator != (Profesor p, Universidad.EClases c)
        {
            return !(p == c);
        }
        #endregion
    }
}
