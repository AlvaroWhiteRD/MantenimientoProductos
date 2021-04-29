using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Employee.Departments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Empleados
{
    public partial class FrmEmployee : Form
    {
        N_Employees objBusine = new N_Employees();
        //E_Employees objEntitis = new E_Employees();

        Form mensaje;

        public FrmEmployee()
        {
            InitializeComponent();

            ShowEmployee();
            HideShiwWidthRow();

        }


        private void btnDepartment_Click(object sender, EventArgs e)
        {
            //abrimos el formulario de DEPARTAMENTOS
            FrmDepartments _frmDepartment = new FrmDepartments();
            _frmDepartment.ShowDialog();
        }

        public void ShowEmployee()
        {
           tableEmployee.DataSource = objBusine.ShowEmployee();
        }
        //metodo que se encarga de ocultar, mover y anchar algunas columnas
        public void HideShiwWidthRow()
        {
            //ocultamos los campos ids de la base de datos en la tabla
            tableEmployee.Columns[2].Visible = false;
            tableEmployee.Columns[5].Visible = false;//iddepartamento***
           // tableEmployee.Columns[13].Visible = false;//idempleado

            //le cambiamos el anchos a nuestras columnas
            tableEmployee.Columns[0].Width = 40;
            tableEmployee.Columns[1].Width = 40;

            tableEmployee.Columns[3].Width = 60;
            tableEmployee.Columns[4].Width = 60;
            tableEmployee.Columns[6].Width = 60;
            tableEmployee.Columns[7].Width = 60;
            tableEmployee.Columns[8].Width = 60;
            tableEmployee.Columns[9].Width = 60;
            tableEmployee.Columns[10].Width = 60;
            tableEmployee.Columns[11].Width = 60;
            tableEmployee.Columns[12].Width = 130;
            tableEmployee.Columns[13].Width = 60;
            tableEmployee.Columns[14].Width = 60;

            //movemos las columnas editar y eliminar al otro extremo de la tabla
           
            tableEmployee.Columns[0].DisplayIndex = 14;//editar
            tableEmployee.Columns[1].DisplayIndex = 14;//eliminar
            //tableEmployee.Columns[4].DisplayIndex = 4;//telefono
            //tableEmployee.Columns[3].DisplayIndex = 5;//dni


            /*       //movemos las demas columnas en la pocision deseada
                tableEmployee.Columns[6].DisplayIndex = 0;//nombre
                tableEmployee.Columns[8].DisplayIndex = 1;//paterno
                tableEmployee.Columns[7].DisplayIndex = 2;//materno
                 tableEmployee.Columns[4].DisplayIndex = 3;//telefono
                            tableEmployee.Columns[9].DisplayIndex = 4;//email

                            tableEmployee.Columns[3].DisplayIndex = 5;//dni
                            tableEmployee.Columns[10].DisplayIndex = 6;//estado civil
                            tableEmployee.Columns[11].DisplayIndex = 7;//sexo
                            tableEmployee.Columns[13].DisplayIndex = 8;//fecha
                            tableEmployee.Columns[14].DisplayIndex = 9;//departamento
                            tableEmployee.Columns[12].DisplayIndex = 10;//direccion
                */


        }


        private void tableEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (tableEmployee.Rows[e.RowIndex].Cells["delete"].Selected)
                {
                    mensaje = new FrmError("ELIMINAR ESTE CLIENTE?");
                    DialogResult dialogResult = mensaje.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        int idEmployee = Convert.ToInt32(tableEmployee.Rows[e.RowIndex].Cells[2].Value.ToString());
                        objBusine.DeleteEmployee(idEmployee);

                        this.mensaje = new FrmSuccess("REGISTRO ELIMINADO! ");
                        this.mensaje.ShowDialog();

                        ShowEmployee();
                    }
                } 
                else if (tableEmployee.Rows[e.RowIndex].Cells["edit"].Selected)
                {
                    FrmNewEmployee frmNewEmployee = new FrmNewEmployee();
                    //actualizamos nuestra valiable actualizar para poder editar
                    frmNewEmployee.update = true;
                    //pasamos los valores a nuestro formulario nuevoEmpleado
                    frmNewEmployee.txtIdEmployee.Text = tableEmployee.Rows[e.RowIndex].Cells[2].Value.ToString();
                    frmNewEmployee.txtNameEmployee.Text = tableEmployee.Rows[e.RowIndex].Cells[6].Value.ToString();
                    frmNewEmployee.txtLastName.Text = tableEmployee.Rows[e.RowIndex].Cells[8].Value.ToString();
                    frmNewEmployee.txtMothersLastName.Text = tableEmployee.Rows[e.RowIndex].Cells[7].Value.ToString();
                    frmNewEmployee.txtDni.Text = tableEmployee.Rows[e.RowIndex].Cells[3].Value.ToString();
                    frmNewEmployee.txtPhone.Text = tableEmployee.Rows[e.RowIndex].Cells[4].Value.ToString();
                    frmNewEmployee.txtEmail.Text = tableEmployee.Rows[e.RowIndex].Cells[9].Value.ToString();
                    frmNewEmployee.cmbCivilStatus.Text = tableEmployee.Rows[e.RowIndex].Cells[10].Value.ToString();
                    frmNewEmployee.cmbSex.Text = tableEmployee.Rows[e.RowIndex].Cells[11].Value.ToString();
                    frmNewEmployee.txtAddress.Text = tableEmployee.Rows[e.RowIndex].Cells[12].Value.ToString();
                    frmNewEmployee.dtDateAdmission.Text = tableEmployee.Rows[e.RowIndex].Cells[13].Value.ToString();
                    frmNewEmployee.cmbDepartment.Text = tableEmployee.Rows[e.RowIndex].Cells[14].Value.ToString();
                
                    frmNewEmployee.ShowDialog();

                    ShowEmployee();
                
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: "+ex.Message,"Valla a ocurrido un error");
            }
          
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
        //instanciamos el formulario FrmNuevoProducto el cual se abrira como un modal
            FrmNewEmployee _newEmployeeForm = new FrmNewEmployee();
            _newEmployeeForm.ShowDialog();
            _newEmployeeForm.update = false;
            ShowEmployee();
        }
        public void BuscarProducto(string search)
        {
            tableEmployee.DataSource = objBusine.SearchEmployee(search);
        }
        private void txtSearchEmployee_TextChanged(object sender, EventArgs e)
        { 
            
            try
            {
               BuscarProducto(txtSearchEmployee.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:: "+ex.Message," Valla, algo no ando bien");
            }
        }
    }
}