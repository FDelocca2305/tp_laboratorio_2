using BaseDeDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Excepciones;
using Archivos;
using System.Threading;
using MetodosDeExtension;

namespace FormPrincipal
{
    public partial class FormVentas : Form
    {
        /// <summary>
        /// Declaro el dao para interactuar con al base de datos
        /// </summary>
        VentasDAO ventaDao = new VentasDAO();

        /// <summary>
        /// La variable operaciones va a ser de flag para el boton agregar/editar
        /// </summary>
        string operacion = "Insertar";

        /// <summary>
        /// Esta variable va a ser de ayuda para borrar el producto
        /// </summary>
        string idVentas;


        /// <summary>
        /// El windowstate es para que se abra maximizado y ocupe todo el espacio del formulario padre
        /// </summary>
        public FormVentas()
        {

            InitializeComponent();
            lblPrecioProducto.Text = "";
            WindowState = FormWindowState.Maximized;
            
        }

        /// <summary>
        /// En el evento load del form listo los productos y lleno el datagrid con los datos de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVentas_Load(object sender, EventArgs e)
        {
            ListarProductos();
            ListarVentas();

        }

        /// <summary>
        /// Invoco la funcion de listar productos para pasarlos al datagrid
        /// </summary>
        private void ListarProductos()
        {
            VentasDAO ventasDao = new VentasDAO();

            cmbProductos.DisplayMember = "DESCRIPCION";
            cmbProductos.ValueMember = "IDPROD";
            cmbProductos.DataSource = ventasDao.ListarProductos();
            

        }

        /// <summary>
        /// Listo la ventas de la base de datos para visualizarlas en el datagrid
        /// </summary>
        private void ListarVentas()
        {
            VentasDAO ventasDao = new VentasDAO();

            dataGridView1.DataSource = ventasDao.ListarVentas();
        }

        /// <summary>
        /// Cuando doy click en agregar me fijo que valor tiene el flag si es Insertar creo un objeto del tipo venta asignandole los valores de los inputs y combos
        /// invoco la funcion insertarventas y le paso como parametro el objeto creado
        /// finalmente muestro un mensaje si no una excepcion
        /// 
        /// si el valor de operacion es Editar creo el objeto, le paso el valor de idventa declarado arriba y el objeto creado a la funcion editar venta, vuelvo a declarar
        /// la variable operacion como insertar finalmente limpio los inputs y recargo el datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            try
            {

                if (operacion == "Insertar")
                {
                    Venta venta = new Venta(Convert.ToInt32(cmbProductos.SelectedValue), Convert.ToInt32(txtCant.Text));
                    ventaDao.InsertarVentas(venta);

                    MessageBox.Show("Se inserto un nuevo registro");

                }
                else if (operacion == "Editar")
                {
                    Venta venta = new Venta(Convert.ToInt32(cmbProductos.SelectedValue), Convert.ToInt32(txtCant.Text));
                    ventaDao.EditarVentas(Convert.ToInt32(this.idVentas), venta);
                    operacion = "Insertar";
                    btnAgregarVenta.Text = "Agregar";

                    MessageBox.Show("Se actualizo correctamente el registro");
                }

                ListarVentas();
            }
            catch (Exception)
            {

                throw new ErrorDataBaseException("Hubo un error al insertar el registro");
            }
        }

        /// <summary>
        /// Cuando le hago click al boton eliminar agarro la fila y me fijo el valor que tiene el campo ID de esa fila
        /// y le paso ese valor a la funcion eliminar venta convertido a int
        /// luego recargo la tabla con la funcion listarventas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrarVenta_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    ventaDao.EliminarVenta(Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value.ToString()));
                    MessageBox.Show("Se elimino la fila");

                    ListarVentas();
                }
                catch (Exception)
                {

                    throw new ErrorDataBaseException("No se pudo borrar el registro");
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila antes de borrar");
            }
        }

        /// <summary>
        /// Cuando le hago click al boton editar paso los datos de la fila seleccionada a los inputs/combos
        /// si se apreta y no hay ninguna fila seleccionada tira un mensaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditarVenta_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                operacion = "Editar";

                btnAgregarVenta.Text = "Editar";

                cmbProductos.Text = dataGridView1.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                txtCant.Text = dataGridView1.CurrentRow.Cells["CANTIDAD"].Value.ToString();
                //txtPrecio.Text = dataGridView1.CurrentRow.Cells["PRECIO"].Value.ToString();
                idVentas = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila antes de editar");
            }
        }

        /// <summary>
        /// Al hacer click en el boton generar factura creo un objeto con los datos de la fila elegida y los serializo en un archivo xml y muestro un mensaje de ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Venta venta = new Venta(Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value.ToString()), dataGridView1.CurrentRow.Cells["DESCRIPCION"].Value.ToString(), Convert.ToInt32(dataGridView1.CurrentRow.Cells["CANTIDAD"].Value.ToString()), Convert.ToInt32(dataGridView1.CurrentRow.Cells["TOTAL"].Value.ToString()));

                Xml<Venta> xml = new Xml<Venta>();

                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";

                DateTime tiempo = new DateTime();

                long timestamp = tiempo.GetTimeStamp();

                if (xml.Guardar(ruta + "Venta" + timestamp + ".xml", venta))
                {
                    MessageBox.Show("Se guardo la venta en el escritorio");
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el archivo correctamente");
                }
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila antes de editar");
            }
        }

        /// <summary>
        /// Cuando se cambia el valor del combo selecciono el precio de ese producto pasandole la id
        /// y la declaro en el label de precio como una muestra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProductos_SelectedValueChanged(object sender, EventArgs e)
        {
            this.lblPrecioProducto.Text = ventaDao.SelectProductPrice(Convert.ToInt32(cmbProductos.SelectedValue)).ToString();
        }

    }
}
