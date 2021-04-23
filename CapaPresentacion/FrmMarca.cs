using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class FrmMarca : Form
    {

        private string IdMarca;
        private bool editarMarca = false;

        E_Marca objEntidadMarca = new E_Marca();
        N_Marca objNegocioMarca = new N_Marca();
        public FrmMarca()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Close();
        }

        private void FrmMarca_Load(object sender, EventArgs e)
        { 
            mostrarBuscarTablasDB("");
            accionesTabla();
        }

        public void mostrarBuscarTablasDB(string buscar)
        {
            N_Marca objNegocio = new N_Marca();
            
            tablaMarca.DataSource = objNegocio.ListarMarcas(buscar);
        }
        //en este metodo le damos el estilo a la tabla y el tamano de las columnas
        public void accionesTabla()
        {
            //ocultamos la primera columnas
            tablaMarca.Columns[0].Visible = false;
            //le damos un nuevo tamano a la columnas
            tablaMarca.Columns[1].Width = 60;
            tablaMarca.Columns[2].Width = 170;
            //al momento de cargar la tabla no hayan filas seleccionadas
            tablaMarca.ClearSelection();
        }

        private void txtBuscarMarca_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTablasDB(txtBuscarMarca.Text);
        }

        public void LimpiarCajasDeTexto()
        {
            editarMarca = false;
            //limpiamos los campos
            txtCodigoMarca.Text = "";
            txtNombreMarca.Text = "";
            txtDescripcionMarca.Text = "";

            txtNombreMarca.Focus();
        }
        private void btnNuevoMarca_Click(object sender, EventArgs e)
        {
            LimpiarCajasDeTexto();
        }

        private void btnEditarMarca_Click(object sender, EventArgs e)
        {
            if (tablaMarca.SelectedRows.Count > 0)
            {
                editarMarca = true;
                //recogemos los datos del formulario y con ellos llenamos los campos para luego editar
                //en el boton guardar es donde estamos registro o guadamos uno nuevo
                IdMarca = tablaMarca.CurrentRow.Cells[0].Value.ToString();
                txtCodigoMarca.Text = tablaMarca.CurrentRow.Cells[1].Value.ToString();
                txtNombreMarca.Text = tablaMarca.CurrentRow.Cells[2].Value.ToString();

                txtDescripcionMarca.Text = tablaMarca.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleciona La MARCA A Editar");
            }
        }

        private void btnGuardarMarca_Click(object sender, EventArgs e)
        {
            if (editarMarca == false)//si es falso procedemos a guardar
            {
                try
                {
                    //llenamos los campos a insertar
                    objEntidadMarca.NombreMarca = txtNombreMarca.Text.ToUpper();
                    objEntidadMarca.DescripcionMarca = txtDescripcionMarca.Text.ToUpper();

                    objNegocioMarca.InsertarMarca(objEntidadMarca);

                    FrmSuccess.mensajeConfirmacion("Registro Guardado Exitosamente...");
                    LimpiarCajasDeTexto();
                    //actualizamos la tabla
                    mostrarBuscarTablasDB("");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se logro GUARDAR el registro. "+ editarMarca+"  --" + ex);

                }

            }
            if (editarMarca == true)//si Editarse es <true>
            {
                try
                {
                    //llenamos los campos a insertar
                    objEntidadMarca.IdMarca = Convert.ToInt32(IdMarca);
                    objEntidadMarca.NombreMarca = txtNombreMarca.Text.ToUpper();
                    objEntidadMarca.DescripcionMarca = txtDescripcionMarca.Text.ToUpper();

                    objNegocioMarca.EditarMarca(objEntidadMarca);

                    FrmSuccess.mensajeConfirmacion("Se EDITO el Registro Exitosamente...");
                    LimpiarCajasDeTexto();
                    //actualizamos la tabla
                    mostrarBuscarTablasDB("");
                    editarMarca = false;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se logro EDITAR el registro. " + ex);

                }
            }
        }

        private void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                              
                    if (tablaMarca.SelectedRows.Count > 0)
                    {

                    DialogResult dialogResult = new DialogResult();
                    FrmError frmMensaje = new FrmError("ELIMINAR ESTE REGISTRO?");
                    dialogResult = frmMensaje.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                        {
                            //llenamos los campos
                            objEntidadMarca.IdMarca = Convert.ToInt32(tablaMarca.CurrentRow.Cells[0].Value.ToString());

                            objNegocioMarca.EliminarMarca(objEntidadMarca);

                            FrmSuccess.mensajeConfirmacion("REGISTRO ELIMINADO CORRECTAMENTE");
                            //actualizamos la tabla
                            mostrarBuscarTablasDB("");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione la CATEGORIA a eliminar!! ");
                    }
                
            }
            catch (Exception erro)
            {
                MessageBox.Show("Seleccione la MARCA que desea Eliminar!! "+ erro);
            }
        }

    }
}
