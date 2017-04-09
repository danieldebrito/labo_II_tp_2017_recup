using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libreria_tp1;

namespace formCalculadora
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
            this.limpiar();
        }

        /// <summary>
        /// Inicializa los componentes del formulario
        /// </summary>
        private void limpiar()
        {
            this.lblResultado.Text = "0.00";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperacion.Text = "";
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero n2 = new Numero(txtNumero2.Text);
            Numero n1 = new Numero(txtNumero1.Text);

            lblResultado.Text = libreria_tp1.Calculadora.Operar(n1,n2,cmbOperacion.Text).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void Calculadora_Load(object sender, EventArgs e)
        {

        }
    }
}
