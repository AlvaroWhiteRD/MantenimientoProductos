using CapaEntidades;
using CapaNegocio;
using CapaNegocio.SessionUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Login
{
    public partial class FrmLogin : Form
    {
        N_Users users = new N_Users();
        E_Users usersEntities = new E_Users();

        public FrmLogin()
        {
            InitializeComponent();
            usarPlaceholder();
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void usarPlaceholder()
        {
            //txtUserName.Focus();
            txtUserName.PlaceholderText = "Nombre De Usuario";
            txtPassword.PlaceholderText = "Escriba Su Contraseña";

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtUserName.Text == "" || string.IsNullOrEmpty(txtUserName.Text))
                {
                    if (txtPassword.Text != "")
                    {
                        lbEerroPass.Visible = false;
                    }
                    lbEerroUser.ForeColor = System.Drawing.Color.Red;
                    lbEerroUser.Visible = true;
                    lbEerroUser.Text = "Campos Obligatorios";
                    txtUserName.Focus();
                    return;
                }
                if (txtPassword.Text == "" || string.IsNullOrEmpty(txtPassword.Text))
                {
                    if (txtUserName.Text != "")
                    {
                        lbEerroUser.Visible = false;
                    }
                    lbEerroPass.ForeColor = System.Drawing.Color.Red;
                    lbEerroPass.Visible = true;
                    lbEerroPass.Text = "Campos Obligatorios";
                    lbEerroPass.Focus();
                    return;
                }


                usersEntities = users.LoginValidate(txtUserName.Text, txtPassword.Text);

                //luego de validar el user y pass ingresado sean valido. 
                if (usersEntities != null)
                {
                    //creamos una session
                    //y llenamos los datos del usuariio logueado en nuestras variables globales.
                    SessionUsers.IdUser = usersEntities.IdUser;
                    SessionUsers.IdRol = usersEntities.IdRol;
                    SessionUsers.UserName = usersEntities.UserName;
                    SessionUsers.EmployeeName = usersEntities.EmployeeName;
                    SessionUsers.LastName = usersEntities.LastName;
                    SessionUsers.Email = usersEntities.Emaill;

                    //validamos el rol del usuario que esta logueado
                    switch (usersEntities.IdRol)
                    {
                        case 1:
                            UserPrivileges.AdminPrivileges();
                            //Application.Exit();
                            break;

                        case 2:
                            UserPrivileges.CashierPrivileges();
                            //Application.Exit();
                            break;

                        case 3:
                            MessageBox.Show("No se que hacer contigo  " + usersEntities.EmployeeName, "todo bien");
                            break;


                    }
                }
                else
                {
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    txtUserName.Focus();
                    MessageBox.Show("Usuario O Contraseseña no son valido ", "Algo no anda bien.");

                }



                /* if (usersEntities == "")
                 {
                     //FrmPrincipal frmPrincipal = new FrmPrincipal();
                     //this.Hide();
                     //frmPrincipal.ShowDialog();
                 }
                 else if (usersEntities)
                 {
                     MessageBox.Show("Usuario o Contraseña incorrectos ." , "Valla, algo no anda bien!!");

                 }
                 else
                 {
                     MessageBox.Show("algo no esta muy bien .", "Valla, algo no anda bien!!");

                 }*/
            }
            catch (Exception ex)
            {

                MessageBox.Show("Usuario o Contraseña incorrectos no puede ser ." + ex.Message, "Valla, algo no anda bien!!");
            }
        }
    }
}




