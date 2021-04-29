using CapaEntidades;
using CapaNegocio;
using CapaNegocio.SessionUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Login
{
    public partial class FrmUpdatePassword : Form
    {
        E_Users usersEntities = new E_Users();
        N_Users users = new N_Users();



        public FrmUpdatePassword()
        {
            InitializeComponent();
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {

            if (txtOldPassword.Text == "" || string.IsNullOrEmpty(txtOldPassword.Text))
            {
                if (txtOldPassword.Text != "")
                {
                    lblErroOldPassword.Visible = false;
                }
                lblErroOldPassword.ForeColor = System.Drawing.Color.Red;
                lblErroOldPassword.Visible = true;
                lblErroOldPassword.Text = "Campos Obligatorios";
                txtOldPassword.Focus();
                return;
            }
            if (txtPasswordNew.Text == "" || string.IsNullOrEmpty(txtPasswordNew.Text))
            {
                if (!string.IsNullOrEmpty(txtOldPassword.Text))
                {
                    lblErroOldPassword.Visible = false;
                }
                if (txtPasswordNew.Text != "")
                {
                    lblEerroPass.Visible = false;
                }
                lblEerroPass.ForeColor = System.Drawing.Color.Red;
                lblEerroPass.Visible = true;
                lblEerroPass.Text = "Campos Obligatorios";
                txtPasswordNew.Focus();
                return;
            }
            if (txtPasswordNew.Text != txtPasswordRepeat.Text)
            {
                if (txtPasswordNew.Text != "")
                {
                    lblEerroPass.Visible = false;
                }
                lblErroPasswordRepeat.ForeColor = System.Drawing.Color.Red;
                lblErroPasswordRepeat.Visible = true;
                lblErroPasswordRepeat.Text = "Contraseñas NO Coinciden";
                txtPasswordNew.Text = "";
                txtPasswordNew.Focus();
                return;
            }

            //encriptamos el password.
            string passwordOld = CapaDatos.EncryptPassword.GetSHA256(txtOldPassword.Text);
            string passwordNew = CapaDatos.EncryptPassword.GetSHA256(txtPasswordNew.Text);

            usersEntities = users.LoginValidate(SessionUsers.UserName, passwordOld);

            if (usersEntities == null)
            {
                lblErroOldPassword.ForeColor = System.Drawing.Color.Red;
                lblErroOldPassword.Visible = true;
                lblErroOldPassword.Text = "La Contraseña No Es Valida";
                txtOldPassword.Focus();
            }
            else
            {
                lblErroOldPassword.Visible = false;
                try
                {
                    int passwordChanged = users.UpdatePassword(SessionUsers.IdUser, passwordNew);

                    if (passwordChanged == 1)
                    {
                        Close();

                        FrmSuccess frmSuccess = new FrmSuccess("Contraseña Actualizada");
                        frmSuccess.ShowDialog();
                    }
                }
                catch (Exception es)
                {

                    MessageBox.Show("error " + es.Message);
                }

            }
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
