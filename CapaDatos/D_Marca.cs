using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
//using CapaEntidades;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class D_Marca
    {
        //realizamos la conexion a la base de datos.
        //conectar viene de la conexion del App.config
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        //metodo encargado de listar datos 
        //pasamos como argumento a la lista la clase E_Categoria
        public List<E_Marca> ListarMarcas(string buscar )
        {
            //leemos los datos de la base de datos
            SqlDataReader LeerFilas;
            //le pasamos la cadena de texto con el nombre de nuestro procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_BUSCARMARCA", conexion);
            //ahora le decimos que ese dato que le pasamos no es un texto normal si no un procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            //agregamos los campos de la consulta
            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            //asignamos el cdm a leerFila para que lea la ejecucion de las filas
            LeerFilas = cmd.ExecuteReader();
            //creamos una lista de registro
            List<E_Marca> Listar = new List<E_Marca>();
            //recorremos los registros de la dbase
            while (LeerFilas.Read())
            {    
                //agregamos cada registro a mi lista(*Listar*)
                Listar.Add(new E_Marca
                {
                    IdMarca = LeerFilas.GetInt32(0),
                    CodigoMarca = LeerFilas.GetString(1),
                    NombreMarca = LeerFilas.GetString(2),
                    DescripcionMarca = LeerFilas.GetString(3)
                }); 

                
            }
            conexion.Close();
            LeerFilas.Close();
            //retornamos un objeto List<>
            return Listar;
        }

        //metodo encargado de insertar las marcas
        public void InsertarMarca(E_Marca marca)
        {
            //le pasamos la cadena de texto con el nombre de nuestro procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_INSERTARMARCA", conexion);
            //ahora le decimos que ese dato que le pasamos no es un texto normal si no un procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            //agregamos los campos de la consulta
            cmd.Parameters.AddWithValue("@NOMBRE", marca.NombreMarca);
            cmd.Parameters.AddWithValue("@DESCRIPCION", marca.DescripcionMarca);
            //ejecutamos la consulta
            cmd.ExecuteNonQuery(); 
            conexion.Close();
        }

        public void EditarMarca(E_Marca marca)
        {//le pasamos la cadena de texto con el nombre de nuestro procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_EDITARMARCA",conexion);
            //ahora le decimos que ese dato que le pasamos no es un texto normal si no un procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            //agregamos los campos de la consulta
            cmd.Parameters.AddWithValue("@IDMARCA", marca.IdMarca);
            cmd.Parameters.AddWithValue("@NOMBRE", marca.NombreMarca);
            cmd.Parameters.AddWithValue("@DESCRIPCION", marca.DescripcionMarca);
            //ejecutamos la consulta
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarMarca(E_Marca marca)
        {
            //le pasamos la cadena de texto con el nombre de nuestro procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_ELIMINARMARCA", conexion);
            //ahora le decimos que ese dato que le pasamos no es un texto normal si no un procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            //agregamos los campos de la consulta
            cmd.Parameters.AddWithValue("@IDMARCA", marca.IdMarca);
            //ejecutamos la consulta
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
