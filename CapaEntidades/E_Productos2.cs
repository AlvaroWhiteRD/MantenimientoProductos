using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    class E_Productos2
    {

        public E_Productos2(int idProducto,string codigo,
            string producto, string categoria, string marca,
            double precioCompra,int stock
           )

        {

        }
        private int idProducto;
        private string codigo;
        private string producto;
        private string categoria;
        private string marca;
        //private int idCategoria;
        //private int idMarca;
        private decimal precioCompra;
        //private decimal precioVenta;
        private int stock;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Producto { get => producto; set => producto = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Marca { get => marca; set => marca = value; }
        public decimal PrecioCompra { get => precioCompra; set => precioCompra = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
