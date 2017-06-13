using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]
    [XmlInclude(typeof(Jornada))]
    public class Jornada
    {
        #region atributos y propiedades
        private List<Alumno> _alumnos;
        public List<Alumno> Alumnos
        {
            get { return _alumnos; }
            set { _alumnos = value; }
        }

        private Universidad.EClases _clase;
        public Universidad.EClases Clase
        {
            get { return _clase; }
            set { _clase = value; }
        }

        private Profesor _instructor;
        public Profesor Instructor
        {
            get { return _instructor; }
            set { _instructor = value; }
        }
        #endregion

        #region constructores
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        #region metodos

        /// <summary>
        /// Un alumno es igual a una jornada si cursa la clase de la misma
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator == (Jornada j, Alumno a)
        {
            if (a == (Universidad.EClases)j.Clase)
                return true;
            return false;
        }

        /// <summary>
        /// Un alumno no es igual a una jornada si no cursa la clase de la misma
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator != (Jornada j, Alumno a)
        { 
            return !(j == a);
        }   

        /// <summary>
        /// Agrega un alumno a una jornada si el mismo no esta previamente cargado
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator + (Jornada j, Alumno a)
        {
            bool ok = false;
            foreach (Alumno aux in j._alumnos)
            {
                    if (aux == a)
                    {
                        ok = true;
                        break;
                    }
            }
            if (!ok)
                j._alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();

            return j;
        }

        /// <summary>
        /// muestra y hace publicos los atributos de la clase
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (!object.Equals(this,null) && !object.Equals(this.Clase, null) && !object.Equals(this.Instructor, null))
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendFormat("CLASE DE {0} POR {1}", this.Clase.ToString(), this.Instructor.ToString());
                sb.AppendLine("ALUMNOS");

                foreach (Alumno a in this._alumnos)
                {
                    sb.AppendLine(a.ToString());
                }
                sb.AppendLine("<------------------------------------------------>");

                return sb.ToString();
            }
            else
                return "";
        }

        /// <summary>
        /// Guarda un archivo de texto con informacion de la jordada
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto _tex = new Texto();
            return _tex.guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Lee un archivo de texto con informacion de la jornada
        /// </summary>
        /// <returns></returns>
        public static bool Leer()
        {
            string datos = "";
            Texto _tex = new Texto();
            return _tex.leer("Jornada.txt", out datos);
        }
        #endregion
    }
}
