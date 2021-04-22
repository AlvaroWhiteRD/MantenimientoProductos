using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmSuccess : Form
    {
        public FrmSuccess(string mensaje)
        {
            InitializeComponent();
            lblMensajeSuccess.Text = mensaje;
        }

        public static void mensajeConfirmacion(string mensaje)
        {
            FrmSuccess formConfirmacion = new FrmSuccess(mensaje);
            formConfirmacion.ShowDialog();
        }
        private void btbAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
