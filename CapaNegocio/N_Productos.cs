using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class N_Productos
    {

        D_Productos data = new D_Productos();
        E_Productos entidad = new E_Productos();

        public DataTable ListandoProductos()
        {
            return data.ListarProductos();
        } 

        public DataTable BuscarProducto(string buscar)
        {
            return data.BuscarProducto(buscar);
        }
        public DataTable SearchProductSale(string buscar)
        {
            return data.SearchProductSale(buscar);
        }


        public void CrearProducto(E_Productos _producto)
        {
            data.CrearProducto(_producto);
        }
        public void ActualizarProducto(E_Productos _producto)
        {
            data.ActualizarProducto(_producto);
        }
        public void EliminarProducto(int id)
        {
            data.EliminarProducto(id);
        }
    }
}
