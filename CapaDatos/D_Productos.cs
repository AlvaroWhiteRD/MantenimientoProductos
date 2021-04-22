using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CapaEntidades;
namespace CapaDatos
{
    public class D_Productos
    {
        //realizamos la conexion a la base de datos. 
        //conectar viene de la conexion del App.config
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public DataTable ListarProductos()
        {
            DataTable tabla = new DataTable();
            SqlDataReader leerFilas;
            /*
          * invocamos a nuestra clase que ejecuta nuestros procedientos en la databases
          * instanciamos la clase SqlCommand y le pasamos el nombre del procedimiento almacenado
          * que vamos a utlizar para esta consulta mas la conexion.
         */ 
            SqlCommand cmd = new SqlCommand("SP_LISTARPRODUCTOS",connection);
            /* 
          *le decimos que la consulta sera de un procediento almaceno y 
          *no una consulta normal. 
          */
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            leerFilas = cmd.ExecuteReader();

            tabla.Load(leerFilas);

            leerFilas.Close();
            connection.Close();

            return tabla;

        }
        //metodo que busca solo un producto para agregarlo a la tabla de venta
        public DataTable SearchProductSale(string search)
        {
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_Search_product_sale",connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            cmd.Parameters.AddWithValue("@search_code", search);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(table);

            connection.Close();

            return table;
        }
        //metodo que busca todos los productos
        public DataTable BuscarProducto(string search)
        {
            DataTable tabla = new DataTable();
            /*
                * invocamos a nuestra clase que ejecuta nuestros procedientos en la databases
                * instanciamos la clase SqlCommand y le pasamos el nombre del procedimiento almacenado
                * que vamos a utlizar para esta consulta mas la conexion.
                */
            SqlCommand cmd = new SqlCommand("SP_BUSCARPRODUCTOS", connection);
            /* 
            *le decimos que la consulta sera de un procediento almaceno y 
            *no una consulta normal. 
            */
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            //pasamos el parametro a buscar
            cmd.Parameters.AddWithValue("@BUSCAR", search);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);

            connection.Close();

            return tabla;

        }

        public void EliminarProducto(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARPRODUCTOS",connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            cmd.Parameters.AddWithValue("@IDPRODUCTO", id);

            cmd.ExecuteNonQuery();
            connection.Close();

        }

        public void CrearProducto(E_Productos _producto)
        {
            SqlCommand cmd = new SqlCommand("SP_CREARPRODUCTOS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            cmd.Parameters.AddWithValue("@PRODUCTO",_producto.Producto);
            cmd.Parameters.AddWithValue("@PRECIO_COMPRA", _producto.PrecioCompra);
            cmd.Parameters.AddWithValue("@PRECIO_VENTA", _producto.PrecioVenta);
            cmd.Parameters.AddWithValue("@STOCK", _producto.Stock);
            cmd.Parameters.AddWithValue("@IDCATEGORIA", _producto.IdCategoria);
            cmd.Parameters.AddWithValue("@IDMARCA", _producto.IdMarca);
            //executamos la consulta
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void ActualizarProducto(E_Productos _producto)
        {
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZARPRODUCTOS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            cmd.Parameters.AddWithValue("@IDPRODUCTO", _producto.IdProducto);
            cmd.Parameters.AddWithValue("@PRODUCTO", _producto.Producto);
            cmd.Parameters.AddWithValue("@PRECIO_COMPRA", _producto.PrecioCompra);
            cmd.Parameters.AddWithValue("@PRECIO_VENTA", _producto.PrecioVenta);
            cmd.Parameters.AddWithValue("@STOCK", _producto.Stock);
            cmd.Parameters.AddWithValue("@IDCATEGORIA", _producto.IdCategoria);
            cmd.Parameters.AddWithValue("@IDMARCA", _producto.IdMarca);

            cmd.ExecuteNonQuery();
            connection.Close();   
        }



    }
}
