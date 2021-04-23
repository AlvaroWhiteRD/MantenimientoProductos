using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidades;


namespace CapaPresentacion
{
    public partial class FrmProductos : Form
    {
        N_Productos objNegocio = new N_Productos();

        Form mensaje;

        public FrmProductos()
        {
            InitializeComponent();
            mostrarProductos();
            ocultarMoverAncharColumnas();
        }

        public void mostrarProductos()
        {
            //N_Productos objNegocio = new N_Productos();
            tablaProductos.DataSource = objNegocio.ListandoProductos();
        }

        public void ocultarMoverAncharColumnas()
        {
            //ocultamos los campos ids de la base de datos
            tablaProductos.Columns[2].Visible = false;
            tablaProductos.Columns[5].Visible = false;
            tablaProductos.Columns[7].Visible = false;

            //le cambiamos el anchos a nuestras columnas
            tablaProductos.Columns[0].Width = 50;
            tablaProductos.Columns[1].Width = 50;
            tablaProductos.Columns[3].Width = 100;
            tablaProductos.Columns[4].Width = 150;
            tablaProductos.Columns[6].Width = 200;

            //movemos las columnas editar y eliminar al otro extremo de la tabla
            tablaProductos.Columns[0].DisplayIndex = 11;
            tablaProductos.Columns[1].DisplayIndex = 11;
        }
        public void BuscarProducto(string buscar)
        { 
            N_Productos objNegocio = new N_Productos();
            tablaProductos.DataSource = objNegocio.BuscarProducto(buscar);
        }
        //metodo para buscr mientras se escribe en el texbox
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarProducto(txtBuscar.Text);
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            //instanciamos el formulario FrmNuevoProducto el cual se abrira como un modal
            FrmNuevoProducto frmNuevoProducto = new FrmNuevoProducto();
            frmNuevoProducto.ShowDialog();
            frmNuevoProducto.Actualizar = false;
            mostrarProductos();


        }

        //en este evento vamos a trabajar con la ediccion o eliminacion de los registros de la tabla 
        private void tablaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaProductos.Rows[e.RowIndex].Cells["eliminar"].Selected)
            {
                mensaje = new FrmError("ELIMINAR ESTE PRODUCTO?");
                DialogResult dialogResult = mensaje.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    int eliminar = Convert.ToInt32(tablaProductos.Rows[e.RowIndex].Cells[2].Value.ToString());
                    objNegocio.EliminarProducto(eliminar);

                    this.mensaje= new FrmSuccess("REGISTRO ELIMINADO!");
                    this.mensaje.ShowDialog();

                    mostrarProductos();
                }
            }
            else if (tablaProductos.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                FrmNuevoProducto frmNuevoProducto = new FrmNuevoProducto();
                //actualizamos nuestra valiable actualizar para poder editar
                frmNuevoProducto.Actualizar = true;
                //pasamos los valores a nuestro formulario nuevoProducto
                frmNuevoProducto.txtIdProducto.Text = tablaProductos.Rows[e.RowIndex].Cells["idProducto"].Value.ToString();
                frmNuevoProducto.txtCodigoMarca.Text = tablaProductos.Rows[e.RowIndex].Cells["codigo"].Value.ToString();
                frmNuevoProducto.txtNombreProducto.Text = tablaProductos.Rows[e.RowIndex].Cells["producto"].Value.ToString();
                frmNuevoProducto.txtPrecioCompra.Text = tablaProductos.Rows[e.RowIndex].Cells["precio_compra"].Value.ToString();
                frmNuevoProducto.txtPrecioVenta.Text = tablaProductos.Rows[e.RowIndex].Cells["precio_venta"].Value.ToString();
                frmNuevoProducto.txtStock.Text = tablaProductos.Rows[e.RowIndex].Cells["Stock"].Value.ToString();
                frmNuevoProducto.cmbCategoria.Text = tablaProductos.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
                frmNuevoProducto.cmbMarca.Text = tablaProductos.Rows[e.RowIndex].Cells["Marca"].Value.ToString();

                frmNuevoProducto.ShowDialog();
                /*
                   this.mensaje= new FrmSuccess("REGISTRO ACTUALIZADO!!");
                    this.mensaje.ShowDialog();
                 */
                mostrarProductos();
            }
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            //abrimos el formulario de marca
            FrmMarca _frmMarca = new FrmMarca();
            _frmMarca.ShowDialog();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            
            //abrimos el formulario de catgoria
            FrmCategoria _frmCategoria = new FrmCategoria();
            _frmCategoria.ShowDialog();
        }

    }
}
