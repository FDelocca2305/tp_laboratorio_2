using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
            this.lblResultado.Text = string.Empty;
        }

        /// <summary>
        /// Vacia campos de texto
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
            this.lblResultado.Text = string.Empty;
        }

        /// <summary>
        /// llama a la funcion operar de la clase calculadora
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>retorna el resultado que recibe de la operacion hecha por la clase calculadora</returns>
        private double Operar(string numero1, string numero2, string operador)
        {
            double resultado = Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);

            return resultado;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado =  Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            string nuevoResultado = resultado.ToString();

            lblResultado.Text = nuevoResultado;
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultado = Numero.DecimalBinario(lblResultado.Text);

            lblResultado.Text = resultado;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string resultado = Numero.BinarioDecimal(lblResultado.Text);

            lblResultado.Text = resultado;
        
        }
    }
}
