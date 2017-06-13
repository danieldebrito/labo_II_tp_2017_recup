using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Firma de metodo en interface para guardar archivos
        /// </summary>
        /// <param name="archivo">path del archivo</param>
        /// <param name="datos">coleccion de objetos</param>
        /// <returns></returns>
        bool guardar (string archivo, T datos);

        /// <summary>
        /// Firma de metodo en interface para leer archivos
        /// </summary>
        /// <param name="archivo">path del archivo</param>
        /// <param name="datos">coleccion de objetos</param>
        /// <returns></returns>
        bool leer (string archivo, out T datos);
    }
}
