using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormPrincipal
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cuando hago click en la opcion productos del menu se muestra el formulario de productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProducts frm = new FormProducts();
            label1.Visible = false;
            label2.Visible = false;
            frm.MdiParent = this;
            frm.Show();
        }

        /// <summary>
        /// Cuando hago click en la opcion ventas del menu se muestra el formulario de ventas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVentas frm = new FormVentas();
            label1.Visible = false;
            label2.Visible = false;
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
