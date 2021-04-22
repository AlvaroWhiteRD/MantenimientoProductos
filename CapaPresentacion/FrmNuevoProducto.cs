using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmNuevoProducto : Form
    {
        //valiable usada para decidir si edito o guado
        public bool Actualizar = false;

        //FrmNuevoProducto _nuevoProducto = new FrmNuevoProducto();
       E_Productos entidad = new E_Productos();
       N_Productos negocio = new N_Productos();

        FrmSuccess frmConfirmacion;


        public FrmNuevoProducto()
        {
            InitializeComponent();
            ListarCategoria();
            ListarMarca();

        }

        public void ListarCategoria()
        {
            N_Categoria negocioCategoria = new N_Categoria();
            cmbCategoria.DataSource = negocioCategoria.ListandoCategoria("");
            //quiero que tenga el valor del id
            cmbCategoria.ValueMember = "IdCategoria";
            //pero quiero que el usuario vea el nombre
            cmbCategoria.DisplayMember = "NombreCategoria"; 

        }
        public void ListarMarca()
        {
            N_Marca negocioMarca = new N_Marca();
            cmbMarca.DataSource = negocioMarca.ListarMarcas("");
            //quiero que tenga el valor del id
            cmbMarca.ValueMember = "IdMarca";
            //pero quiero que el usuario vea el nombre
            cmbMarca.DisplayMember = "NombreMarca";
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Actualizar == false)
            {
                try
                {
                    entidad.Producto = txtNombreProducto.Text;
                    entidad.PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                    entidad.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    entidad.Stock = Convert.ToInt32(txtStock.Text);
                    entidad.IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                    entidad.IdMarca = Convert.ToInt32(cmbMarca.SelectedValue);

                    negocio.CrearProducto(entidad);
                    frmConfirmacion = new FrmSuccess("PRODUCTO GUARDADO!");
                    frmConfirmacion.ShowDialog();

                    Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se logro guardar el registro. "+ ex.Message);
                }

            }
            if (Actualizar == true)
            {
                try
                {
                    entidad.IdProducto = Convert.ToInt32(txtIdProducto.Text);
                    entidad.Producto = txtNombreProducto.Text;
                    entidad.PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                    entidad.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    entidad.Stock = Convert.ToInt32(txtStock.Text);
                    entidad.IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                    entidad.IdMarca = Convert.ToInt32(cmbMarca.SelectedValue);

                    negocio.ActualizarProducto(entidad);
                    frmConfirmacion = new FrmSuccess("PRODUCTO ACTUALIZADO!");
                    frmConfirmacion.ShowDialog();
                    Close();
                    Actualizar = false;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se logro actualizar el registro. " + ex.Message);
                }
            }
        }

      
    }
}
