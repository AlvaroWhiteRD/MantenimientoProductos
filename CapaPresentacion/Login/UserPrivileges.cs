using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Login
{
    class UserPrivileges

    {
        public static void AdminPrivileges()
        {

            FrmPrincipal frmPrincipal = new FrmPrincipal();

            FrmLogin _login = new FrmLogin();
           // _login.Hide();
            //Application.Exit();

            frmPrincipal.ShowDialog();

        }

        public static void CashierPrivileges()
        {
            FrmPrincipal _frmPrincipal = new FrmPrincipal();
            FrmLogin _login = new FrmLogin();

            // _login.Close();
            //Application.Exit();
            _frmPrincipal.ShowDialog();
        }
    }
}
