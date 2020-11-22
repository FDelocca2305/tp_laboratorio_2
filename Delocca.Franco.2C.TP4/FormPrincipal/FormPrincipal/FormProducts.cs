using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseDeDatos;
using Entidades;
using Excepciones;

namespace FormPrincipal
{
    public partial class FormProducts : Form
    {
        /// <summary>
        /// Declaro el dao para interactuar con al base de datos
        /// </summary>
        ProductosDAO prodDao = new ProductosDAO();

        /// <summary>
        /// La variable operaciones va a ser de flag para el boton agregar/editar
        /// </summary>
        string operacion = "Insertar";

        /// <summary>
        /// Esta variable va a ser de ayuda para borrar el producto
        /// </summary>
        string idProd;

        /// <summary>
        /// El windowstate es para que se abra maximizado y ocupe todo el espacio del formulario padre
        /// </summary>
        public FormProducts()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// En el evento load del form listo las categorias, marcas en sus combos y lleno el datagrid con los datos de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormProducts_Load(object sender, EventArgs e)
        {
            ListarCategorias();
            ListarMarcas();
            ListarProductos();
        }

        /// <summary>
        /// Declaro el dao de productos e invoco la funcion listar categorias y lleno los datos del combo categorias
        /// </summary>
        private void ListarCategorias()
        {
            ProductosDAO prodDao = new ProductosDAO();
            cmbCategoria.DataSource = prodDao.ListarCategorias();
            cmbCategoria.DisplayMember = "CATEGORIA";
            cmbCategoria.ValueMember = "IDCATEG";
        }

        /// <summary>
        /// Declaro el dao de productos e invoco la funcion listar marcas y lleno los datos del combo marcas
        /// </summary>
        private void ListarMarcas()
        {
            ProductosDAO prodDao = new ProductosDAO();
            cmbMarca.DataSource = prodDao.ListarMarcas();
            cmbMarca.DisplayMember = "MARCA";
            cmbMarca.ValueMember = "IDMARCA";
        }

        /// <summary>
        /// Limpio el txtbox de descripcion y el de precio
        /// </summary>
        private void LimpiarFormulario()
        {
            txtDescripcion.Clear();
            txtPrecio.Clear();
        }

        /// <summary>
        /// Cuando doy click en agregar me fijo que valor tiene el flag si es Insertar creo un objeto del tipo producto asignandole los valores de los inputs y combos
        /// invoco la funcion insertarproductos y le paso como parametro el objeto creado
        /// finalmente muestro un mensaje si no una excepcion
        /// 
        /// si el valor de operacion es Editar creo el objeto, le paso el valor de idprod declarado arriba y el objeto creado a la funcion editar producto, vuelvo a declarar
        /// la variable operacion como insertar finalmente limpio los inputs y recargo el datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                if (operacion == "Insertar")
                {
                    Producto producto = new Producto(Convert.ToInt32(cmbCategoria.SelectedValue), Convert.ToInt32(cmbMarca.SelectedValue), txtDescripcion.Text, Convert.ToDouble(txtPrecio.Text));
                    prodDao.InsertarProductos(producto);

                    MessageBox.Show("Se inserto un nuevo registro");

                }
                else if(operacion == "Editar")
                {
                    Producto producto = new Producto(Convert.ToInt32(cmbCategoria.SelectedValue), Convert.ToInt32(cmbMarca.SelectedValue), txtDescripcion.Text, Convert.ToDouble(txtPrecio.Text));
                    prodDao.EditarProductos(Convert.ToInt32(idProd), producto);
                    operacion = "Insertar";
                    MessageBox.Show("Se actualizo correctamente el registro");
                }

                ListarProductos();
                LimpiarFormulario();
            }
            catch (Exception)
            {

                throw new ErrorDataBaseException("Hubo un error al insertar el registro");
            }
            
        }

        /// <summary>
        /// Invoco la funcion de listar productos para pasarlos al datagrid
        /// </summary>
        private void ListarProductos()
        {
            ProductosDAO prodDao = new ProductosDAO();

            dataGridView1.DataSource = prodDao.ListarProductos();
        }

        /// <summary>
        /// Cuando le hago click al boton editar paso los datos de la fila seleccionada a los inputs/combos
        /// si se apreta y no hay ninguna fila seleccionada tira un mensaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                operacion = "Editar";

                cmbCategoria.Text = dataGridView1.CurrentRow.Cells["CATEGORIA"].Value.ToString();
                cmbMarca.Text = dataGridView1.CurrentRow.Cells["MARCA"].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["PRECIO"].Value.ToString();
                idProd = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila antes de editar");
            }
        }

        /// <summary>
        /// Cuando le hago click al boton eliminar agarro la fila y me fijo el valor que tiene el campo ID de esa fila
        /// y le paso ese valor a la funcion elimianr producto convertido a int
        /// luego recargo la tabla con la funcion listarproductos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    prodDao.EliminarProducto(Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value.ToString()));
                    MessageBox.Show("Se elimino la fila");

                    ListarProductos();
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
    }
}
