using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmInformacion : Form
    {
        public FrmInformacion( string mensaje)
        {
            InitializeComponent();

            lblMensajeEliminar.Text = mensaje;
        }

        private void FrmInformacion_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAceptarEliminar_Click(object sender, EventArgs e)
        {
            //si el usuario presiona el boton de aceptar esta confirmando el borrado
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
