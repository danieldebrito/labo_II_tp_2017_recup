using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;
using Archivos;


namespace ClasesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]
    [XmlInclude(typeof(Jornada))]
    public class Universidad
    {
        #region enumerados
        public enum EClases { Laboratorio = 1, SPD = 2, Legislacion = 3 };
        #endregion

        #region atributos y propiedades
        protected List<Alumno> alumnos;
        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }

        protected List<Jornada> jornada;
        public List<Jornada> Jornadas
        {
            get { return jornada; }
            set { jornada = value; }
        }

        private List<Profesor> profesor;
        public List<Profesor> Profesor
        {
            get { return profesor; }
            set { profesor = value; }
        }
        #endregion

        #region indexador
        public Jornada this[int indice]
        {
            get
            {
                if (indice >= this.Jornadas.Count || indice < 0)
                    return null;
                else
                    return this.Jornadas[indice];
            }
            set
            {
                this.Jornadas[indice] = value;
            }
        }
        #endregion

        #region constructores
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Profesor = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        #endregion

        #region metodos
        /// <summary>
        /// Retorna cadena con las jornadas de la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad u)
        {
            StringBuilder sb = new StringBuilder();

            if (u.Jornadas != null)
            {
                sb.AppendLine("JORNADAS: ");
                foreach (Jornada j in u.Jornadas)
                    sb.AppendLine(j.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Retorna y hace publicas las jornadas de la universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Un alumno es igual a una universidad si esta inscripto en ella
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator == (Universidad u, Alumno a)
        {
            foreach (Alumno item in u.Alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Un alumno es distinto a una universidad si no esta inscripto en ella
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator != (Universidad u, Alumno a)
        {
            return !(u == a);
        }

        /// <summary>
        /// Una universidad es igual a un profesor si da clases en ella
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator == (Universidad u, Profesor p)
        {
            foreach (Profesor item in u.Profesor)
            {
                if (item == p)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Un profesor es distinto a una universidad si no da clases en ella
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator != (Universidad u, Profesor p)
        {
            return !(u == p);
        }

        /// <summary>
        /// Igualar EClase y Universidad retorna un profesor que puede dar la clase de acuerdo a su atributo
        /// </summary>
        /// <param name="u"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Profesor operator == (Universidad u, EClases c)
        {
            Profesor p = null;
            try
            {
                foreach (Profesor pAux in u.Profesor)
                {
                    if (pAux == (Universidad.EClases)c)
                        return pAux;
                }
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            return p;
        }

        /// <summary>
        /// Desigualar EClase Universidad retorna un profesor que no da la clase segun su atributo
        /// </summary>
        /// <param name="u"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Profesor operator != (Universidad u, EClases c)
        {
            Profesor p = null;

            foreach (Profesor pAux in u.Profesor)
            {
                if (pAux != (Universidad.EClases)c)
                    return pAux;
            }
            return p;
        }

        /// <summary>
        /// Inscribe un alumno a la universidad, chequea que ya no este inscripto
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator + (Universidad u, Alumno a)
        {
            bool ok = true;
            foreach (Alumno item in u.Alumnos)
            {
                if (a == item)
                    ok = false;
            }
            if(ok)
                u.Alumnos.Add(a);
            if (!ok)
                throw new AlumnoRepetidoException();

            return u;
        }

        /// <summary>
        /// Incorpora un profesor a la universidad, chequea que no este previamente incorporado
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Universidad operator + (Universidad u, Profesor p)
        {
            bool ok = false;
            foreach (Profesor aux in u.Profesor)
            {
                if (aux == p)
                {
                    ok = true;
                    break;
                }
            }
            if (!ok)
                u.Profesor.Add(p);

            return u;
        }

        /// <summary>
        ///  Suma de EClase y Universidad genera una jornada con profesor y alumnos que dictan y cursan respectivamente
        /// </summary>
        /// <param name="u"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Universidad operator + (Universidad u, EClases c)
        {
            Profesor p = u == (EClases)c;

            if (object.Equals(null, p))
                throw new SinProfesorException();

            Jornada j = new Jornada((EClases)c, p);

            foreach (Alumno a in u.Alumnos)
            {
                if (a == (EClases)c)
                    j += a;
            }

            u.Jornadas.Add(j);

            return u;
        }

        /// <summary>
        /// Guarda un archivo xml con informacion de la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad u)
        {
            Xml<Universidad> datosXml = new Xml<Universidad>();
            return datosXml.guardar("Universidad.xml", u);
        }

        /// <summary>
        /// Lee informacion de un archivo xml con informacion de la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Universidad Leer(Universidad u)
        {
            Xml<Universidad> datos = new Xml<Universidad>();
            Universidad datosU;
            datos.leer("Gimnasio.xml", out datosU);
            return datosU;
        }
        #endregion
    }
}
