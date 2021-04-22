using CapaNegocio;
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
    public partial class FrmProductModal : Form
    {
        N_Productos objNegocio = new N_Productos();
        public bool modalSales = false;

        public FrmProductModal()
        {
            InitializeComponent();
            ShowProducts();
            HideAndWidenColumns();


        }

        public void ShowProducts()
        {
            tableProductSale.DataSource = objNegocio.ListandoProductos();
        }

        public void HideAndWidenColumns()
        {
                           //ocultamos los campos ids de la base de datos
                tableProductSale.Columns[0].Visible = false;
                tableProductSale.Columns[3].Visible = false;
                //tableProductSale.Columns[4].Visible = false;
                tableProductSale.Columns[5].Visible = false;
                tableProductSale.Columns[6].Visible = false;
                tableProductSale.Columns[7].Visible = false;
                //tableProductSale.Columns[9].Visible = false;

                //le cambiamos el anchos a nuestras columnas
                //tableProductSale.Columns[0].Width = 50;
                tableProductSale.Columns[1].Width = 150;
                tableProductSale.Columns[2].Width = 150;
                tableProductSale.Columns[4].Width = 150;
                tableProductSale.Columns[6].Width = 150;
                tableProductSale.Columns[8].Width = 100;
                tableProductSale.Columns[9].Width = 100;
          
        }
        public void SearchProductSale(string search)
        {
            tableProductSale.DataSource = objNegocio.BuscarProducto(search);
        }

        /*private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarProducto(txtBuscar.Text);
        }*/
        //evento para buscr mientras se escribe en el texbox
        private void txtSearchProductSale_TextChanged(object sender, EventArgs e)
        {
            SearchProductSale(txtSearchProductSale.Text);
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tableProductSale_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                FrmSales frmSales = new FrmSales();

                /*frmSales.tableSales.Rows.Add(new string[] {
                Convert.ToString(tableProductSale[0, tableProductSale.CurrentRow.Index].Value),
                Convert.ToString(tableProductSale[1, tableProductSale.CurrentRow.Index].Value)
            });*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("paso algo " + ex.Message);
            }
            /* foreach (DataGridViewRow row in tableProductSale.SelectedRows)
             {
                 String a,b;
                 a = this.tableProductSale.CurrentRow.Cells["CODIGO"].Value.ToString();
                 b = this.tableProductSale.CurrentRow.Cells["PRODUCTO"].Value.ToString();
                 MessageBox.Show(a,b);
                 FrmSales frmSales = new FrmSales();
                 foreach (Form frm in Application.OpenForms)
                 {
                     if (frm.Name == "FrmSales")
                     {
                         MessageBox.Show("igual");
                         frmSales = (FrmSales)frm;
                         frmSales.dgvTableSale.Rows.Add(a,b);
                         this.Close();
                         break;
                     }
                     else { MessageBox.Show("no igual"); }

                 }

             }*/

        }

      /*  private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in tableProductSale.SelectedRows)
            {
                String codeProduct, product;
                codeProduct = this.tableProductSale.CurrentRow.Cells["CODIGO"].Value.ToString();
                product = this.tableProductSale.CurrentRow.Cells["PRODUCTO"].Value.ToString();
                
                MessageBox.Show(codeProduct, product);

                FrmSales frmSales = new FrmSales();

                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Name == "FrmSales")
                    {
                        MessageBox.Show("igual");
                        frmSales = (FrmSales)frm;
                        frmSales.dgvTableSale.Rows.Add(codeProduct, product);
                        this.Close();
                        break;
                    }
                    else { 
                        MessageBox.Show("no igual"); 
                    }

                }

            }
        }*/
        /*try
   {
       //FrmSales frmSales = new FrmSales();

       //frmSales.txtNameProductSale.Text = tableProductSale.CurrentRow.Cells["PRODUCTO"].Value.ToString();//nombre dl producto
       //frmSales.txtUnitPriceSale.Text = tableProductSale.CurrentRow.Cells["PRECIO_VENTA"].Value.ToString();//precio unitario

       //frmSales.txtCodeProductSale.Text = tableProductSale.CurrentRow.Cells["CODIGO"].Value.ToString();//codigo producto
                                                                                                       //AddOwnedForm(FrmProductModal);
       IEnviarDatosEntresForm interfa = Owner as IEnviarDatosEntresForm;
       DataGridViewRow fila = tableProductSale.SelectedRows[0] as DataGridViewRow;
       interfa.agregarDatosATabla(fila);
       this.Close();
       //frmSales.Show();

   catch (Exception ex)
   {

       MessageBox.Show("problemas con la tabla "+ex.Message);            }
}*/
    }
}
/*Si lo que buscas es que los datos seleccionados se carguen en cuadros de texto (clase Textbox) entonces no hay nada distinto, lo único que debes de cambiar -del código propuesto- es lo siguiente:

Private Sub FormB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
	
	txtId.Text = FilaSelecionada.Cells(0).Value.ToString
	txtNombre.Text = FilaSelecionada.Cells(1).Value.ToString
	txtEdad.Text = FilaSelecionada.Cells(2).Value.ToString

End Sub*/