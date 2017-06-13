using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Xml.Serialization;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region enumerados
        public enum ENacionalidad { Argentino, Extranjero };
        #endregion

        #region atributos y propiedades
        private string _nombre;
        public string Nombre
        {
            get { return ValidarNombreApellido(_nombre); }
            set { _nombre = ValidarNombreApellido(value); }
        }
            
        private String _apellido;
        public String Apellido
        {
            get { return ValidarNombreApellido(_apellido); }
            set { _apellido = ValidarNombreApellido(value); }
        }
        
        private int _dni;
        public int DNI
        {
            get { return ValidarDni(this._nacionalidad, this._dni); }
            set { this._dni = ValidarDni(this._nacionalidad,value); }
        }

        private ENacionalidad _nacionalidad;
        public ENacionalidad Nacionalidad
        {
            get { return _nacionalidad; }
            set { _nacionalidad = value; }
        }
        #endregion

        #region constructores
        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.DNI = ValidarDni(nacionalidad, dni);
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = ValidarDni(nacionalidad, dni);
        }
        #endregion

        #region metodos
        /// <summary>
        /// Muestra todos los atrubutos de la clase
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1} \n",this.Apellido,this.Nombre);
            sb.Append("NACIONALIDAD: " + this.Nacionalidad);
            
            return sb.ToString();
        }

        /// <summary>
        /// Valida si es un numero de DNI valido y si condice con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                return ValidarDni(nacionalidad,int.Parse(dato));
            }
            catch (FormatException)
            {
                throw new DniInvalidoException();
            }
        }

        /// <summary>
        /// Valida si na nacionalidad condice con el nro de DNI
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            bool ok = true;

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        ok = false;
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 90000000 || dato > 99999999)
                        ok = false;
                    break;
                default:
                    throw new NacionalidadInvalidaException();
            }
            if (!ok)
                throw new NacionalidadInvalidaException();
            else
                return dato;
        }

        /// <summary>
        /// Valida una cadena valida para nombre o apellido y la formatea
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            Regex rgx = new Regex(@"^[a-zA-Z]+$");
            if (rgx.IsMatch(dato))
                return myTI.ToTitleCase(myTI.ToLower(dato));
            else
                return null;
        }
        #endregion
    }
}
