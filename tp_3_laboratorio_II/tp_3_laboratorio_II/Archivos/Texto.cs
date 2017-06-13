using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";

        /// <summary>
        /// Guarda archivo de texto
        /// </summary>
        /// <param name="archivo">path del archivo</param>
        /// <param name="dato">cadena a guardar</param>
        /// <returns></returns>
        public bool guardar(string archivo, string dato)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(this.path + archivo, true))
                {
                    sw.WriteLine(dato);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        
        /// <summary>
        /// Lee archivo de texto
        /// </summary>
        /// <param name="archivo">path del archivo</param>
        /// <param name="datos">cadena a guardar</param>
        /// <returns></returns>
        public bool leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader sr = new StreamReader(this.path + archivo))
                {
                    datos = sr.ReadToEnd();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                datos = "";
                return false;
            }
        }
    }
}
