using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Employee.Departments
{
    public partial class FrmDepartments : Form
    {

        private string idDepartment;
        private bool editDepartment = false;

        E_Departments objEntity = new E_Departments();
        N_Departments objBusiness = new N_Departments();


        public FrmDepartments()
        {
            InitializeComponent();
        }

        private void formExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmDepartments_Load(object sender, EventArgs e)
        {
            ShowDepartments("");
            ActiosTable();
        }
        public void ShowDepartments(string search)
        {
            N_Departments objDepartment = new N_Departments();
            //limpiamos la tabla para que no haya filas seleccionadas
            tableDepartment.ClearSelection();

            tableDepartment.DataSource = objDepartment.ShowDepartments(search);
        }

        //en este metodo le damos el estilo a la tabla y el tamano de las columnas
        public void ActiosTable()
        {
            //ocultamos la primera columnas
            tableDepartment.Columns[1].Visible = false;
            //le damos un nuevo tamano a la columnas
            tableDepartment.Columns[0].Width = 150;
           // tableDepartment.Columns[2].Width = 170;
            //al momento de cargar la tabla no hayan filas seleccionadas
            tableDepartment.ClearSelection();
        }

        private void txtSearchDepartment_TextChanged(object sender, EventArgs e)
        {
            ShowDepartments(txtSearchDepartment.Text);
        }
        //limpiamos las cajas de textos
        private void CleanTextBoxes()
        {
            editDepartment = false;

            txtSearchDepartment.Text = "";
            txtNameDepartment.Text = "";

            txtNameDepartment.Focus();
            btnSaveDepartment.TabIndex = 1;

        }

        private void btnNewDepartment_Click(object sender, EventArgs e)
        {
            CleanTextBoxes();
        }

        private void btnEditDepartment_Click(object sender, EventArgs e)
        {
            if (tableDepartment.SelectedRows.Count > 0)
            {
                editDepartment = true;
                //recogemos los datos del formulario y con ellos llenamos los campos para luego editar
                //en el boton guardar es donde estamos registro o guadamos uno nuevo
                idDepartment = tableDepartment.CurrentRow.Cells[0].Value.ToString();
                txtNameDepartment.Text = tableDepartment.CurrentRow.Cells[1].Value.ToString();

            }
            else
            {
                MessageBox.Show("Selecionw el DEPARTAMENTO que deseas actualizar", "No haz seleccionado ninguna opcion");
            }
        }


        private void btnSaveDepartment_Click(object sender, EventArgs e)
        {
            if (editDepartment == false)//si es falso procedemos a guardar
            {
                try
                {
                    //llenamos los campos a insertar
                    objEntity.NameDepartment = txtNameDepartment.Text.ToUpper().Trim();

                    objBusiness.InsertDepartment(objEntity);

                    FrmSuccess.mensajeConfirmacion("Registro Guardado Exitosamente...");
                    CleanTextBoxes();
                    //actualizamos la tabla
                    ShowDepartments("");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(""  + ex.Message);

                }

            }
            if (editDepartment == true)//si Editarse es <true>
            {
                try
                {
                    //llenamos los campos a insertar
                    objEntity.IdDepartment = Convert.ToInt32(idDepartment.Trim());
                    objEntity.NameDepartment = txtNameDepartment.Text.ToUpper().Trim();

                    objBusiness.UpdateDepartment(objEntity);

                    FrmSuccess.mensajeConfirmacion("Se Actualizo el Registro");
                    CleanTextBoxes();
                    //actualizamos la tabla
                    ShowDepartments("");
                    editDepartment = false;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se logro EDITAR el registro. " + ex);

                }
            }
        }

        private void btnDeleteDepartment_Click(object sender, EventArgs e)
        {
            try
            {

                if (tableDepartment.SelectedRows.Count > 0)
                {

                    DialogResult dialogResult = new DialogResult();
                    FrmError frmMessage = new FrmError("ELIMINAR ESTE REGISTRO?");
                    dialogResult = frmMessage.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        //llenamos los campos
                        objEntity.IdDepartment = Convert.ToInt32(tableDepartment.CurrentRow.Cells[1].Value.ToString());
                        objBusiness.DeleteDepartment(objEntity);

                        FrmSuccess.mensajeConfirmacion("REGISTRO ELIMINADO");

                       //actualizamos la tabla
                        ShowDepartments("");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione el departamento a eliminar!! ", "Algo no anda bien");
                }

            }
            catch (Exception erro)
            {
              
                MessageBox.Show("Seleccione el departamento a eliminar!! ", " Algo no anda bien" + erro.Message);
            }
        }

        private void btnEditDepartment_Click_1(object sender, EventArgs e)
        {
            if (tableDepartment.SelectedRows.Count > 0)
            {
                editDepartment = true;
                //recogemos los datos del formulario y con ellos llenamos los campos para luego editar
                //en el boton guardar es donde editamos registro o guadamos uno nuevo
                idDepartment = tableDepartment.CurrentRow.Cells[1].Value.ToString();
                txtNameDepartment.Text = tableDepartment.CurrentRow.Cells[0].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleciona el departamento que desea Editar", "Algo no anda bien :(");
            }
        }
    }
    
}
