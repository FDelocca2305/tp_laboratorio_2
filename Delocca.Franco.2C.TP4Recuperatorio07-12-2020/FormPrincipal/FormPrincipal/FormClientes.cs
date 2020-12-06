using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FormPrincipal
{
    public partial class FormClientes : Form
    {
        Cliente cliente;
        Thread hilo;
        string flag = "Iniciar";

        /// <summary>
        /// Instancio cliente y me subscribo al evento ActualizarListaDeClientes
        /// </summary>
        public FormClientes()
        {
            InitializeComponent();
            
            this.cliente = new Cliente();
            this.cliente.Entro += ActualizarListaDeClientes;
        }

        /// <summary>
        /// Una vez que hago click creo un hilo secundario y lo inicio
        /// Si el flag esta en detener aborto el hilo para que no entren mas clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntrada_Click(object sender, EventArgs e)
        {
            if (flag == "Iniciar")
            {
                this.hilo = new Thread(this.cliente.EntrarAlLocal);
                this.hilo.Start();

                this.flag = "Detener";

                this.btnEntrada.Text = "No permitir mas clientes";

            }
            else if (flag == "Detener")
            {
                this.hilo.Abort();
                this.btnEntrada.Text = "Permitir entrada de clientes";
            }
               
        }

        /// <summary>
        /// Metodo que actualiza la lista de clientes con un callback
        /// </summary>
        /// <param name="cliente"></param>
        private void ActualizarListaDeClientes(Cliente cliente)
        {
            if (lstEntradaClientes.InvokeRequired)
            {
                EntroAlLocal entro = new EntroAlLocal(ActualizarListaDeClientes);
                this.Invoke(entro, cliente);
            }
            else
            {
                lstEntradaClientes.Items.Add(cliente.ToString());
            }
            
        }

        /// <summary>
        /// Mientras se cierra el formulario me fijo si el hilo esta corriendo, si lo esta lo aborto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormClientes_FormClosing(object sender, FormClosedEventArgs e)
        {
            if (this.hilo.IsAlive)
            {
                this.hilo.Abort();
            }
        }


        






    }
}
