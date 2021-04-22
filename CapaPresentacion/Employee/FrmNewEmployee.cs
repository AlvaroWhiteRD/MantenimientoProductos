using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Empleados
{
    public partial class FrmNewEmployee : Form
    {
        E_Employees _entities = new E_Employees();
        N_Employees _objBusines = new N_Employees();
        FrmSuccess frmSuccess;


        public bool update = false;
        public FrmNewEmployee()
        {
            InitializeComponent();
            ItemsCmbDepartment("");
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void ItemsCmbDepartment(string search)
        { 
           
            N_Departments _itemsDepartment = new N_Departments();
            cmbDepartment.DataSource = _itemsDepartment.ShowDepartments(search);
            //quiero que tenga el valor del id
            cmbDepartment.ValueMember = "IdDepartment";
            //pero quiero que el usuario vea el nombre
            cmbDepartment.DisplayMember = "NameDepartment";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (update == false)
            {
                try
                {/*
                    //quiero que tenga el valor del id
                    cmbCivilStatus.ValueMember = "CivilStatus";
                    //pero quiero que el usuario vea el nombre
                    cmbDepartment.DisplayMember = "CivilStatus";

                    //quiero que tenga el valor del id
                    cmbSex.ValueMember = "Sex";
                    //pero quiero que el usuario vea el nombre
                    cmbSex.DisplayMember = "Sex";*/

                    _entities.NameEmployee = txtNameEmployee.Text;
                    _entities.LastName = txtLastName.Text;
                    _entities.MothersLastName = txtMothersLastName.Text;
                    _entities.Dni = Convert.ToInt32(txtDni.Text);
                    _entities.Email = txtEmail.Text;
                    _entities.Phone = Convert.ToInt32(txtPhone.Text);
                    _entities.CivilStatus = cmbCivilStatus.SelectedItem.ToString();
                    _entities.Sex = cmbSex.SelectedItem.ToString();
                    _entities.IdDepartment= Convert.ToInt32(cmbDepartment.SelectedValue);
                    _entities.AddressEmployee = txtAddress.Text;
                    _entities.DateOfAdmission = Convert.ToDateTime(dtDateAdmission.Text);

                    _objBusines.InsertEmployee(_entities);
                    frmSuccess = new FrmSuccess("EMPLEADO GUARDADO!");
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
                    _entities.IdEmployee = Convert.ToInt32(txtIdEmployee.Text);
                    _entities.NameEmployee = txtNameEmployee.Text;
                    _entities.LastName = txtLastName.Text;
                    _entities.MothersLastName = txtMothersLastName.Text;
                    _entities.Dni = Convert.ToInt32(txtDni.Text);
                    _entities.Email = txtEmail.Text;
                    _entities.Phone = Convert.ToInt32(txtPhone.Text);
                    _entities.CivilStatus = cmbCivilStatus.SelectedItem.ToString();
                    _entities.Sex = cmbSex.SelectedItem.ToString();
                    _entities.IdDepartment = Convert.ToInt32(cmbDepartment.SelectedValue);
                    _entities.AddressEmployee = txtAddress.Text;
                    _entities.DateOfAdmission = Convert.ToDateTime(dtDateAdmission.Text);

                    _objBusines.UpdateEmployee(_entities);
                    frmSuccess = new FrmSuccess("EMPLEADO ACTUALIZADO!");
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
    }
}