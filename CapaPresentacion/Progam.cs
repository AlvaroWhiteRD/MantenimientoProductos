using CapaPresentacion.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
   static class Progam
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
            //Application.Run(new FrmLogin());

        }

    }
}
