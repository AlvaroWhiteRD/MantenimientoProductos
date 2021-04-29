using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaNegocio
{
    public class N_Customers
    {
        /*
           creamos los metodos de tipo list para la comunicacion entre las capas
          * de negocio con la capa de datos
        */

        //instanciamos la clase de la capaDatos 
        D_Customers objCustomer = new D_Customers();

        public List<E_Customers> ShowCliemt()
        {
            return objCustomer.ShowCliemt(); 
        }
        public List<E_Customers> SearchCustomer(string search)
        {
            return objCustomer.SearchCustomer(search);
        }
        public void InsertCustomer(E_Customers _customers)
        {
            objCustomer.InsertCustomer(_customers);
        }
        public void UpdateCustomer(E_Customers _customers)
        {
            objCustomer.UpdateCustomer(_customers);
        }
        public void DeleteCustomer(int _customers)
        {
            objCustomer.DeleteCustomer(_customers);
        }
        public List<E_Customers> SearchClientDNI(int search)
        {
            return objCustomer.SearchClientDNI(search);
        }
    }
}
