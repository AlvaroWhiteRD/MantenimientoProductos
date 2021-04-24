using CapaNegocio.SessionUsers;
using CapaPresentacion.Customers;
using CapaPresentacion.Empleados;
using CapaPresentacion.Login;
using CapaPresentacion.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class FrmPrincipal : Form
    {
        FrmLogin login;

        public FrmPrincipal()
        {
            InitializeComponent();
            lblUserSession.Text = SessionUsers.UserName;
            lblNameSession.Text = SessionUsers.EmployeeName + " " + SessionUsers.LastName;
        }

        public void pantallaOK()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            pantallaOK();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            Form mensanje = new FrmError("SALIR DEL SISTEMA?");
            dialogResult = mensanje.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                //cerramos el formulario principal
                this.Close();
                //y abrimos otra vez el login.
                login = new FrmLogin();
                login.Show();

            }
        }

        // creamos una variable para el cambio de formulario dentro del wrapper
        private Form formSeleccionado = null;

        private void AbrirFormularioEnWrapper(Form formularioHijo)
        {
            if (formSeleccionado != null)
                //si existe otro formulario abierto lo cerramos para abrir el nuevo
                formSeleccionado.Close();

            formSeleccionado = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.Dock = DockStyle.Fill;
            //agremos el formulario hijo al panel WRAPPER
            Wrapper.Controls.Add(formularioHijo);
            Wrapper.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        private void btnDashboad_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnWrapper(new FrmDashboard());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnWrapper(new FrmProductos());
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnWrapper(new FrmEmployee());
        }
        private void btnClients_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnWrapper(new FrmCustomers());
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnWrapper(new FrmSales());
        }

        //pasos para hacer que se mueva el formulario
        //PASO 1: declarar como globales
        private int xClick = 0, yClick = 0;

        private void moverFormulario(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                xClick = e.X; yClick = e.Y;
            }
            else
            {
                this.Left = this.Left + (e.X - xClick);
                this.Top = this.Top + (e.Y - yClick);
            }
        }


        //PASO 2: en el evento MouseMove del Form
        private void moverForm(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                xClick = e.X; yClick = e.Y;
            }
            else
            {
                this.Left = this.Left + (e.X - xClick);
                this.Top = this.Top + (e.Y - yClick);
            }
        }
    }
}

