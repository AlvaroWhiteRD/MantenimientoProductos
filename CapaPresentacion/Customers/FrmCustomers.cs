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
    public partial class FrmCustomers : Form
    {
        N_Customers objCustomer = new N_Customers();

        Form message;
        public FrmCustomers()
        {
            InitializeComponent();
            ShowCustomer();
            HideShiwWidthRow();
        }

        public void ShowCustomer()
        {
            tableClient.DataSource = objCustomer.ShowCliemt();
        }

        private void btnNewClient_Click(object sender, EventArgs e)
        {
            //instanciamos el formulario nuevoCliente el cual se abrira como un modal
            FrmCustomersNews _newClient = new FrmCustomersNews();
            _newClient.ShowDialog();
            _newClient.update = false;
            ShowCustomer();
        }

        public void SearchCustomer(string search)
        {
            tableClient.DataSource = objCustomer.SearchCustomer(search);
        }
        private void txtSearchClient_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchCustomer(txtSearchClient.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex, "Algo no anda bien");
            }
        }
        //metodo que se encarga de ocultar, mover y anchar algunas columnas
        public void HideShiwWidthRow()
        {

            //ocultamos los campos ids de la base de datos en la tabla
            tableClient.Columns[2].Visible = false;//id cliente
            tableClient.Columns[10].Visible = false;//genero
            tableClient.Columns[9].Visible = false;//estado civil
            tableClient.Columns[8].Visible = false;//email
            tableClient.Columns[12].Visible = false;//fecha

            //le cambiamos el anchos a nuestras columnas
            tableClient.Columns[0].Width = 40;
            tableClient.Columns[1].Width = 40;

            tableClient.Columns[3].Width = 65;//dni
            tableClient.Columns[4].Width = 65;//phone
            tableClient.Columns[5].Width = 65;//nombre
            tableClient.Columns[6].Width = 65;//apellido
            tableClient.Columns[7].Width = 65;//materno
            //tableClient.Columns[8].Width = 85;//email
            //tableClient.Columns[9].Width = 85;//estado civil
            //tableClient.Columns[10].Width = 85;//genero
            tableClient.Columns[11].Width = 225;//direccion
            //tableClient.Columns[12].Width = 30;//fecha


            //movemos las columnas editar y eliminar al otro extremo de la tabla
            tableClient.Columns[0].DisplayIndex = 12;//editar
            tableClient.Columns[1].DisplayIndex = 12;//eliminar

            
           
        }

        private void tableClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (tableClient.Rows[e.RowIndex].Cells["delete"].Selected)
                {
                    message = new FrmError("ELIMINAR ESTE CLIENTE?");
                    DialogResult dialogResult = message.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        int idClient = Convert.ToInt32(tableClient.Rows[e.RowIndex].Cells[2].Value.ToString());
                        objCustomer.DeleteCustomer(idClient);

                        this.message = new FrmSuccess("REGISTRO ELIMINADO! ");
                        this.message.ShowDialog();

                        ShowCustomer();
                    }
                }
                else if (tableClient.Rows[e.RowIndex].Cells["edit"].Selected)
                {
                    FrmCustomersNews frmCustomerNew = new FrmCustomersNews();
                    //actualizamos nuestra valiable actualizar para poder editar
                    frmCustomerNew.update = true;
                    //pasamos los valores a nuestro formulario nuevoEmpleado
                    frmCustomerNew.txtIdClient.Text = tableClient.Rows[e.RowIndex].Cells[2].Value.ToString();
                    frmCustomerNew.txtNameClient.Text = tableClient.Rows[e.RowIndex].Cells[5].Value.ToString();
                    frmCustomerNew.txtLastNameClient.Text = tableClient.Rows[e.RowIndex].Cells[6].Value.ToString();
                    frmCustomerNew.txtMothersLastNameClient.Text = tableClient.Rows[e.RowIndex].Cells[7].Value.ToString();

                    frmCustomerNew.txtDniClient.Text = tableClient.Rows[e.RowIndex].Cells[3].Value.ToString();
                    frmCustomerNew.txtPhoneClient.Text = tableClient.Rows[e.RowIndex].Cells[4].Value.ToString();
                    frmCustomerNew.txtEmailClient.Text = tableClient.Rows[e.RowIndex].Cells[8].Value.ToString();
                    frmCustomerNew.cmbCivilStatusClient.Text = tableClient.Rows[e.RowIndex].Cells[9].Value.ToString();
                    frmCustomerNew.cmbGenderClient.Text = tableClient.Rows[e.RowIndex].Cells[10].Value.ToString();
                    frmCustomerNew.txtAddressClient.Text = tableClient.Rows[e.RowIndex].Cells[11].Value.ToString();
                    frmCustomerNew.dtDateAdmissionClient.Text = tableClient.Rows[e.RowIndex].Cells[12].Value.ToString();

                    frmCustomerNew.ShowDialog();

                    ShowCustomer();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Valla a ocurrido un error");
            }
        }
    }
}
