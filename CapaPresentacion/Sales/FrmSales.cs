using CapaEntidades;
using CapaNegocio;
using CapaNegocio.SessionUsers;
using CapaPresentacion.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Collections;

namespace CapaPresentacion.Sales
{
    public partial class FrmSales : Form
    {
        //creamos el objeto para buscar en la base de datos los productos.
        N_Productos objBusinessProduct = new N_Productos();


        FrmSuccess formSuccess;
        FrmError formErro;

        public FrmSales()
        {
            InitializeComponent();
            lblEmployeeName.Text = SessionUsers.EmployeeName + " " + SessionUsers.LastName;
            txtQuantityToSell.Text = "";
            txtQuantityToSell.Focus();
            //ItemsCmbClient();
        }

        //metodo que se encarga de agregar cada producto a la tabla de ventas
        public void SaveProductsToaList(string search)
        {
            //le pasamos la consulta al datatabble
            DataTable tableProduct = objBusinessProduct.SearchProductSale(search);


            //verificamos si hay alguna busqueda que coincida con los productos de la base de datos.
            //si los hay se continua, sino detemos la busqueda
            if (tableProduct.Rows.Count > 0)
            {
                var index = dgvTableSales.Rows.Add();

                try
                {


                    foreach (DataRow productRow in tableProduct.Select())
                    {
                        int amount = 0;
                        double salePrice = 0;
                        //variable que guardara el total del monto del producto en esa fila. precio * cantidad.
                        double total = 0;

                        //llenamos las filas de la tabla con los datos que llegan de la base de datos
                        //idProduct nombre de la celda de la tabla
                        //IDPRODUCTO nombre del campo de la base de datos                
                        dgvTableSales.Rows[index].Cells["amount"].Value = txtQuantityToSell.Text;
                        dgvTableSales.Rows[index].Cells["idProduct"].Value = productRow["IDPRODUCTO"];
                        dgvTableSales.Rows[index].Cells["codeProduct"].Value = productRow["CODIGO"];
                        dgvTableSales.Rows[index].Cells["product"].Value = productRow["PRODUCTO"];
                        dgvTableSales.Rows[index].Cells["salePrice"].Value = productRow["PRECIO_VENTA"];
                        dgvTableSales.Rows[index].Cells["stock"].Value = productRow["STOCK"];

                        //declaramos las variables para buscar el 
                        amount = Convert.ToInt32(txtQuantityToSell.Text);
                        salePrice = Convert.ToDouble(dgvTableSales.Rows[index].Cells["salePrice"].Value);
                        //ahora llenamos el campo total de la tabla.
                        //para eso usaremos la formula (cantidad * precio)
                        total = (amount * salePrice);
                        //luego de calcular el total este se agrega a la tabla
                        dgvTableSales.Rows[index].Cells["total"].Value = total;

                        //realizamos la formula de la cantidad de produco por el precio del mismo
                        //var result = Convert.ToDouble(tableProduct.Compute("Sum(PRECIO_VENTA)*" + amount + "", ""));

                        CalculateTotal();

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(" error " + ex.Message);

                }


            }
            else
            {
                lblCodeProduct.ForeColor = Color.Red;
                lblCodeProduct.Text = "Producto No Encontrado.";
                return;
            }

        }

        //metodo que se encarga de validar que el producto en la venta no se agregue mas de una vez
        //sino mas bien, que se sume a la cantidad de productos.
        /* public void Exits(string exists)
         {

             foreach (DataGridViewRow rows in dgvTableSales.Rows)
             {
                 //buscamos la celda a utilizar para la validacion
                 //en este caso el 5 es donde esta el CODIGO
                 string validadExiste = rows.Cells[0].Value.ToString();
                 if (exists == validadExiste)
                 {
                     MessageBox.Show("igual");
                 }
                 else
                     MessageBox.Show("no igual");


             }
             //le pasamos el total a nuestro label  de pago para mostrarlo al usuario.
             //txtTotalToPay.Text = "RD$  " + total;

             //limpiamos los campos luego de la busquedad
             txtQuantityToSell.Text = "";
             txtCodeProduct.Text = "";
             txtQuantityToSell.Focus();
         }*/
        //este metodo se encarga de sumar el valor de todas las CELDAS(total) de nuestro datagridview.
        //este metodo se usara donde se crea y eliminan las celdas.
        private void CalculateTotal()
        {
            //creamos la variable que almacenara el total de la compra del cliente
            double total = 0;

            foreach (DataGridViewRow rows in dgvTableSales.Rows)
            {
                //buscamos la celda a utilizar para la suma
                //en este caso el 5 es donde esta la columna TOTAL
                double importe = double.Parse(rows.Cells[5].Value.ToString());
                total += importe;
            }
            //le pasamos el total a nuestro label  de pago para mostrarlo al usuario.
            txtTotalToPay.Text = total.ToString();

            //limpiamos los campos luego de la busquedad
            txtQuantityToSell.Text = "";
            txtCodeProduct.Text = "";
            txtQuantityToSell.Focus();


        }

        //metodo que se encarga de buscar por dni a los clintes
        //para luego mostrar su informacion
        private void searchDNI_TextChanged(object sender, EventArgs e)
        {
            //validamos que el dni tenga 11 caracteres para empezar la busqueda.
            if (searchDNI.Text.Length <= 9)
            {
                return;
            }

            N_Customers _itemsClient = new N_Customers();
            //creamos la lista que contendra los datos de la base de datos
            List<E_Customers> listing = new List<E_Customers>();
            //llenamos la lista
            listing = _itemsClient.SearchClientDNI(int.Parse(searchDNI.Text));
            //recorremos la lista
            foreach (var item in listing)
            {
                lblCustomer.Text = item.CustomerName + " " + item.ClientLastName + " " + item.ClientMaternalSurname;
                lblAddressCustomer.Text = item.CustomerAddress;
                txtIdCliente.Text = item.IdClient.ToString();
            }


        }
        //metodo que se encarga de validar solo numero en el input cantidadd
        /*private void txtQuantityToSell_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidationFormUtilities.OnlyNumber(sender, e);

        }*/

        //metodo que se encarga de validar solo numero en el input buscar por cedula o dni
        private void searchDNI_KeyPress(object sender, KeyPressEventArgs e)
        {

            ValidationFormUtilities.OnlyNumber(sender, e);

        }
        //metodo que se encarga de eliminar un registro de la tabla
        private void dgvTableSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //verificamos que el boton de delete de la tabla se haya presionado 
            /*if (dgvTableSales.Rows[e.RowIndex].Cells["delete"].Selected)
            {
                //borramos el registro de la tabla
                dgvTableSales.Rows.Remove(dgvTableSales.CurrentRow);
                
            }*/

            if (e.RowIndex < 0 || e.ColumnIndex != dgvTableSales.Columns["delete"].Index)
            {
                return;
            }
            dgvTableSales.Rows.RemoveAt(e.RowIndex);
            CalculateTotal();
        }

        //evento-metodo- que se encarga de enviar la venta para el insert a la base de datos
        private void pbApplySale_Click(object sender, EventArgs e)
        {

            //realizamos la instancia de nuestra entidad y nuetro negocio.
            N_Sales applySale = new N_Sales();
            N_SalesConcepts applySaleConcepts = new N_SalesConcepts();
            E_Sales entitySale = new E_Sales();
            E_SalesConcepts entitySaleConcept;

            try
            {
                string noNumber = txtIdCliente.Text;
                int number = 0;
                //si el cliente no existe en la venta le agregamos un valor por defecto a nuestro cliente
                //validamos de que la cadena sea un numero
                if (!int.TryParse(noNumber, out number))
                {
                    txtIdCliente.Text = "1003";

                }
                //validamos de que el datagridview(tabla) tenga datos.
                if (dgvTableSales.Rows.Count == 0)
                {
                    txtQuantityToSell.Focus();
                    lblCodeProduct.Text = "CODIGO PRODUCTO";
                    lblCodeProduct.ForeColor = Color.DarkGray;
                    return;
                }

                //le pasamos los valores a nuestra entidad
                entitySale.IdUser = SessionUsers.IdUser;
                entitySale.IdClient = Int32.Parse(txtIdCliente.Text);
                entitySale.Total = decimal.Parse(txtTotalToPay.Text);
                entitySale.DateOfSale = DateTime.Now;

                //realizamos el envio de los datos para la insercion a la base de datos
                int idSale = applySale.GenerarateSalesInsert(entitySale);

              
                //si el insert se realiza exitosamente en la tabla ventas
                //se realizara el segundo insert a la tabla detalle de venta.
                if (idSale > 0)

                {
                    //creamos la lista que contendra nuestra entidad E_SalesConcepts
                    List<E_SalesConcepts> list_SalesConcepts = new List<E_SalesConcepts>();
                    //creamos un ciclo para recorrer cada celda de la tabla(datagridview sales)
                    foreach (DataGridViewRow rows in dgvTableSales.Rows)
                    {
                        //creamos el objeto
                        entitySaleConcept = new E_SalesConcepts();

                        //el tomamos el ultimo id insertado
                        entitySaleConcept.IdSale = idSale;
                        //buscamos en la celda a utilizar para el id del producto
                        entitySaleConcept.IdProduct = Int32.Parse(rows.Cells[6].Value.ToString());
                        //buscamos en la celda a utilizar para el precio del producto
                        entitySaleConcept.SalePrice = decimal.Parse(rows.Cells[4].Value.ToString());
                        //buscamos en la celda a utilizar para el total del producto.
                        entitySaleConcept.Amount = Int32.Parse(rows.Cells[2].Value.ToString());
                        //llenamos la lista con nuestra entidad 
                        list_SalesConcepts.Add(entitySaleConcept);
                    }
                    //realizamos el segundo insert
                    //insert a la tabla detalle de venta

                    if (list_SalesConcepts.Count>0)
                    {
                        applySaleConcepts.GenerarateSaleConceptInsert(list_SalesConcepts);
                        //else error
                    }

                    //venta exitosa
                    formSuccess = new FrmSuccess("Venta Exitosa!");
                    formSuccess.ShowDialog();
                    //luego de completar la venta limpiamos la tabla venta.
                    //dgvTableSales.DataSource = "";
                    dgvTableSales.Columns.Clear();
                    CalculateTotal();

                    //limpiamos todos los campos de la venta
                    searchDNI.Text = "";
                    lblCustomer.Text = "Cliente al contado";
                    lblAddressCustomer.Text = "Direccion Del Cliente";
                }
                else
                {

                    formErro = new FrmError("Error en la venta.");
                    formErro.ShowDialog();
                    return;

                }



            }
            catch (Exception ex)
            {

                MessageBox.Show("algo no anda bien..." + ex);
            }
        }
        //metodo que busca los productos para agregarlo a la tabla
        private void txtCodeProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtQuantityToSell.Text))
                {
                    txtQuantityToSell.Focus();
                    txtCodeProduct.Text = "";
                    return;

                }
                else
                {
                    //SearchProduct(txtCodeProduct.Text);
                    SaveProductsToaList(txtCodeProduct.Text);


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERROR EN LA BUSQUEDA. " + ex.Message);
            }
        }
        //metodo que valida solo numero en el campo cantidad
        private void txtQuantityToSell_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validamos solo <<numero>> en el textbox.
            ValidationFormUtilities.OnlyNumber(sender, e);
          
        }
        //metodo que valida solo numero en el textbox
        /*private void txtQuantityToSell_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            ValidationFormUtilities.OnlyNumber(sender, e);
        }*/
    }





}
