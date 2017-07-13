using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel;

namespace Hilo
{
    // delegados
    public delegate void FullDescarga(string html);
    public delegate void Descargando(int progreso);

    public class Descargador
    {
        private string html;
        private Uri direccion;

        // eventos del tipo delegados
        public event FullDescarga Descargo;
        public event Descargando Descargando;

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Descargando(e.ProgressPercentage);
        }

        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                
                this.html = e.Result;
                // lanza evento
                Descargo(e.Result);
            }
            catch (Exception excepcion)
            {
                this.Descargo(excepcion.Message);
            }
        }
    }
}
