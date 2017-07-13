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
        // nombre del archivo
        private string _fileName;

        public Texto(string file)
        {
            this._fileName = file;
        }

        public bool guardar(string datos)
        {
            try
            {
                // true para que agregue datos 
                using (StreamWriter sw = new StreamWriter(this._fileName, true))
                {
                    sw.WriteLine(datos);
                    sw.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(this._fileName))
                {
                    while (!sr.EndOfStream)
                    {
                        datos.Add(sr.ReadLine());
                    }
                    sr.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                datos = default(List<string>);
                return false;
            }
        }
    }
}
