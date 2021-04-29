using CapaNegocio;
using CapaPresentacion.Login.Users_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Users_Management
{
    public partial class FrmUsersManagement : Form
    {
        N_UsersManagement objUserManagement = new N_UsersManagement();
        Form mensaje;

        public FrmUsersManagement()
        {
            InitializeComponent();
            
            ShowUsers();
            HideShiwWidthRow();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            //instanciamos el formulario FrmNuevoProducto el cual se abrira como un modal
            FrmNewUser _newUserForm = new FrmNewUser();
            _newUserForm.ShowDialog();
            _newUserForm.update = false;
           
            ShowUsers();
            HideShiwWidthRow();
        }

        private void ShowUsers()
        {
            tableUsers.DataSource = objUserManagement.ShowUsers();
        }
        //metodo que se encarga de ocultar, mover y anchar algunas columnas
        public void HideShiwWidthRow()
        {
            //ocultamos los campos ids de la base de datos en la tabla
            //tableUsers.Columns[2].Visible = false;//
           tableUsers.Columns[3].Visible = false;//idempleado
            tableUsers.Columns[9].Visible = false;//iduser
            tableUsers.Columns[5].Visible = false;//
            tableUsers.Columns[2].Visible = false;//rol


            //le cambiamos el anchos a nuestras columnas
            /* tableUsers.Columns[0].Width = 5;//editar
             tableUsers.Columns[1].Width = 5;//eliminar
             tableUsers.Columns[2].Width = 5;//idrol
             tableUsers.Columns[4].Width = 10;//username
             tableUsers.Columns[6].Width = 10;//nombre empleado
             tableUsers.Columns[7].Width = 10;//paterno
             tableUsers.Columns[8].Width = 50;//materno
            */
            //tableUsers.Columns[0].Width = 5;//editar
            //tableUsers.Columns[0].Width = 10;//editar
            //tableUsers.Columns[1].Width = 10;//eliminar

            //movemos las columnas editar y eliminar al otro extremo de la tabla
            tableUsers.Columns[0].DisplayIndex = 10;//editar
            tableUsers.Columns[1].DisplayIndex = 10;//eliminar
        
        }
        //evento que se encargara de eliminar o editar los datos de la tabla
        private void tableUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (tableUsers.Rows[e.RowIndex].Cells["delete"].Selected)
                {
                    mensaje = new FrmError("ELIMINAR ESTE USUARIO?");
                    DialogResult dialogResult = mensaje.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        int idUser = Convert.ToInt32(tableUsers.Rows[e.RowIndex].Cells[9].Value.ToString());
                        objUserManagement.DeleteUser(idUser);

                        this.mensaje = new FrmSuccess("USUARIO ELIMINADO! ");
                        this.mensaje.ShowDialog();

                        ShowUsers();
                    }
                }
                else if (tableUsers.Rows[e.RowIndex].Cells["edit"].Selected)
                {
                    FrmNewUser frmNewUser = new FrmNewUser();
                    //actualizamos nuestra valiable actualizar para poder editar
                    frmNewUser.update = true;
                    //pasamos los valores a nuestro formulario nuevoEmpleado
                    frmNewUser.txtNameUser.Text = tableUsers.Rows[e.RowIndex].Cells["userName"].Value.ToString();
                    frmNewUser.cmbRolUser.Text = tableUsers.Rows[e.RowIndex].Cells[10].Value.ToString();
                    frmNewUser.cmbNameEmployee.Text = tableUsers.Rows[e.RowIndex].Cells[6].Value.ToString();
                    frmNewUser.txtIdUser.Text = tableUsers.Rows[e.RowIndex].Cells[9].Value.ToString();
                    frmNewUser.ShowDialog();

                    ShowUsers();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Valla a ocurrido un error");
            }
        }
    }
}
