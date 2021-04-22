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
    public partial class FrmCategoria : Form
    {

        private string IdCategoria;
        private bool Editarse = false;

        E_Categoria objEntidad = new E_Categoria();
        N_Categoria objNegocio = new N_Categoria();
        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Close();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            mostrarBuscarTablasDB("");
            accionesTabla();
        }

        public void mostrarBuscarTablasDB(string buscar)
        {
            N_Categoria objNegocio = new N_Categoria();
            
            tablaCategoria.DataSource = objNegocio.ListandoCategoria(buscar);
        }
        //en este metodo le damos el estilo a la tabla y el tamano de las columnas
        public void accionesTabla()
        {
            //ocultamos la primera columnas
            tablaCategoria.Columns[0].Visible = false;
            //le damos un nuevo tamano a la columnas
            tablaCategoria.Columns[1].Width = 60;
            tablaCategoria.Columns[2].Width = 170;
            //al momento de cargar la tabla no hayan filas seleccionadas
            tablaCategoria.ClearSelection();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTablasDB(txtBuscar.Text);
        }

        public void LimpiarCajasDeTexto()
        {
            Editarse = false;
            //limpiamos los campos
            txtCodigoCategoria.Text = "";
            txtNombreCategoria.Text = "";
            txtDescripcionCategoria.Text = "";

            txtNombreCategoria.Focus();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCajasDeTexto();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaCategoria.SelectedRows.Count > 0)
            {
                Editarse = true;
                //recogemos los datos del formulario y con ellos llenamos los campos para luego editar
                IdCategoria = tablaCategoria.CurrentRow.Cells[0].Value.ToString();
                txtCodigoCategoria.Text = tablaCategoria.CurrentRow.Cells[1].Value.ToString();
                txtNombreCategoria.Text = tablaCategoria.CurrentRow.Cells[2].Value.ToString();

                txtDescripcionCategoria.Text = tablaCategoria.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleciona La Categoria A Editar");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editarse == false)//si Editarse es <falso>
            {
                try
                {
                    //llenamos los campos a insertar
                    objEntidad.NombreCategoria = txtNombreCategoria.Text.ToUpper();
                    objEntidad.DescripcionCategoria = txtDescripcionCategoria.Text.ToUpper();

                    objNegocio.InsertarCategoria(objEntidad);

                    MessageBox.Show("Registro Guardado Exitosamente...");
                    LimpiarCajasDeTexto();
                    //actualizamos la tabla
                    mostrarBuscarTablasDB("");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se logro GUARDAR el registro. "+ ex);

                }

            }
            if (Editarse == true)//si Editarse es <true>
            {
                try
                {
                    //llenamos los campos a insertar
                    objEntidad.IdCategoria = Convert.ToInt32(IdCategoria);
                    objEntidad.NombreCategoria = txtNombreCategoria.Text.ToUpper();
                    objEntidad.DescripcionCategoria = txtDescripcionCategoria.Text.ToUpper();

                    objNegocio.EditandoCategoria(objEntidad);

                    MessageBox.Show("Se Edito el Registro Exitosamente...");
                    LimpiarCajasDeTexto();
                    //actualizamos la tabla
                    mostrarBuscarTablasDB("");
                    Editarse = false;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se logro EDITAR el registro. " + ex);

                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaCategoria.SelectedRows.Count > 0)
            {
                //llenamos los campos
                objEntidad.IdCategoria = Convert.ToInt32(tablaCategoria.CurrentRow.Cells[0].Value.ToString());

                objNegocio.EliminandoCategoria(objEntidad);

                MessageBox.Show("Se ELIMINO el registro. " );
                //actualizamos la tabla
                mostrarBuscarTablasDB("");

            }
            else
            {
                MessageBox.Show("Seleccione la CATEGORIA a eliminar!! ");

            }
        }
        
    }
}
