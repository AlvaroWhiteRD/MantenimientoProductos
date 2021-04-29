using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Login.Users_Management
{
    public partial class FrmNewUser : Form
    {
        E_UsersManagement _entitiesUserManagement = new E_UsersManagement();
        N_UsersManagement _objUserManagement = new N_UsersManagement();
        FrmSuccess frmSuccess;

        public bool update = false;

        public FrmNewUser()
        {
            InitializeComponent();
            CmbItemsEmployee();
        }
        //metodo que se encarga de llenar el combobox con los datos del empleado.
        public void CmbItemsEmployee()
        {

            N_Employees _itemsEmployee = new N_Employees();
            cmbNameEmployee.DataSource = _itemsEmployee.ShowEmployeeFullNameID();
            //quiero que tenga el valor del id
            cmbNameEmployee.ValueMember = "idEmployee";
            //pero quiero que el usuario vea el nombre
            cmbNameEmployee.DisplayMember = "NameEmployee";
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (update == false)
            {
                try
                {
                    //llenamos nuestra entidad con los campos del formulario
                    _entitiesUserManagement.IdEmployee = Convert.ToInt32(cmbNameEmployee.SelectedValue);
                    _entitiesUserManagement.UserName = txtNameUser.Text;
                    _entitiesUserManagement.IdRol = (cmbRolUser.SelectedIndex + 1);
                    //la contraseña no se enviara desde el input porque la misma sera la misma para
                    //todos los nuevos usuarios 123456789 luego se le pedira a cada usuario que
                    //personalice su contraseña.
                    //_entitiesUserManagement.Password = txtPassword.Text;                 
                

                    _objUserManagement.InsertUser(_entitiesUserManagement);
                    frmSuccess = new FrmSuccess("USUARIO GUARDADO!");
                    frmSuccess.ShowDialog();

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se logro guardar el registro. " + ex.Message);
                }

            }
            if (update == true)
            {
                try
                {
                    _entitiesUserManagement.IdEmployee = Convert.ToInt32(cmbNameEmployee.SelectedValue);
                    _entitiesUserManagement.UserName = txtNameUser.Text;
                    _entitiesUserManagement.IdRol = (cmbRolUser.SelectedIndex + 1);
                    _entitiesUserManagement.IdUser = Convert.ToInt32(txtIdUser.Text);

                    _objUserManagement.UpdateUser(_entitiesUserManagement);
                    frmSuccess = new FrmSuccess("USUARIO ACTUALIZADO!");
                    frmSuccess.ShowDialog();
                    Close();
                    update = false;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se logro actualizar el registro. " + ex.Message, "Valla, algo no anda bien");
                }
            }
        }
        private void lblExit_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
