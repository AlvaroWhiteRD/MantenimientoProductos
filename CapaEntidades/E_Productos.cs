using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class E_Productos
    {
        private int idProducto;
        private string codigoProducto;
        private string producto;
        private int idCategoria;
        private int idMarca;
        private decimal precioCompra;
        private decimal precioVenta;
        private int stock;
        private string buscar;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string CodigoProducto { get => codigoProducto; set => codigoProducto = value; }
        public string Producto { get => producto; set => producto = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public int IdMarca { get => idMarca; set => idMarca = value; }
        public decimal PrecioCompra { get => precioCompra; set => precioCompra = value; }
        public decimal PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int Stock { get => stock; set => stock = value; }
        public string Buscar { get => buscar; set => buscar = value; }
    }
}
