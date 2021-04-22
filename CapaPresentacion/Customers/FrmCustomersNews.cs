using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Customers
{
    public partial class FrmCustomersNews : Form
    {

        E_Customers _entitiesCustomer = new E_Customers();
        N_Customers _objCustomer = new N_Customers();
        FrmSuccess frmSuccess;

        public bool update = false;
        public FrmCustomersNews()
        {
            InitializeComponent();
        }
    private void btnSaveClient_Click(object sender, EventArgs e)
        {
            if (update == false)
            {
                try
                {

                    _entitiesCustomer.CustomerName = txtNameClient.Text;
                    _entitiesCustomer.ClientLastName = txtLastNameClient.Text;
                    _entitiesCustomer.ClientMaternalSurname = txtMothersLastNameClient.Text;
                    _entitiesCustomer.DniClient = Convert.ToInt32(txtDniClient.Text);
                    _entitiesCustomer.CustomerEmail = txtEmailClient.Text;
                    _entitiesCustomer.PhoneClient = Convert.ToInt32(txtPhoneClient.Text);
                    _entitiesCustomer.CustomerCivilStatus = cmbCivilStatusClient.SelectedItem.ToString();
                    _entitiesCustomer.CustomerGender = cmbGenderClient.SelectedItem.ToString();
                    _entitiesCustomer.CustomerAddress = txtAddressClient.Text;
                    _entitiesCustomer.CustomerRegistrationDate = Convert.ToDateTime(dtDateAdmissionClient.Text);

                    _objCustomer.InsertCustomer(_entitiesCustomer);
                    frmSuccess = new FrmSuccess("CLIENTE REGISTRADO!");
                    frmSuccess.ShowDialog();

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se logro guardar el registro. " + ex.Message, "Valla, algo no anda bien");
                }

            }
            if (update == true)
            {
                try
                {
                    _entitiesCustomer.IdClient = Convert.ToInt32(txtIdClient.Text);
                    _entitiesCustomer.CustomerName = txtNameClient.Text;
                    _entitiesCustomer.ClientLastName = txtLastNameClient.Text;
                    _entitiesCustomer.ClientMaternalSurname = txtMothersLastNameClient.Text;
                    _entitiesCustomer.DniClient = Convert.ToInt32(txtDniClient.Text);
                    _entitiesCustomer.CustomerEmail = txtEmailClient.Text;
                    _entitiesCustomer.PhoneClient = Convert.ToInt32(txtPhoneClient.Text);
                    _entitiesCustomer.CustomerCivilStatus = cmbCivilStatusClient.SelectedItem.ToString();
                    _entitiesCustomer.CustomerGender = cmbGenderClient.SelectedItem.ToString();
                    _entitiesCustomer.CustomerAddress = txtAddressClient.Text;
                    _entitiesCustomer.CustomerRegistrationDate = Convert.ToDateTime(dtDateAdmissionClient.Text);

                    _objCustomer.UpdateCustomer(_entitiesCustomer);
                    frmSuccess = new FrmSuccess("CLIENTE ACTUALIZADO!");
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
