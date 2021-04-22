using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
using System.Data;

namespace CapaDatos
{
   public class D_Categoria
    {
        //realizamos la conexion a la base de datos.
        //conectar viene de la conexion del App.config
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);
       
        //metodo encargado de listar datos 
        //pasamos como argumento a la lista la clase E_Categoria
        public List<E_Categoria> ListarCategorias(string buscar)
        {
            //leemos los datos de la base de datos
            SqlDataReader leerFilas;
            /*
             * invocamos a nuestra clase que ejecuta nuestros procedientos en la databases
             * instanciamos la clase SqlCommand y le pasamos el nombre del procedimiento almacenado
             * que vamos a utlizar para esta consulta mas la conexion.
            */
            SqlCommand cmd = new SqlCommand("SP_BUSCARCATEGORIA", this.conexion);

            /* 
             *le decimos que la consulta sera de un procediento almaceno y  
             *no una consulta normal. 
             */
            cmd.CommandType = CommandType.StoredProcedure;
            // abrimos la conexion
            this.conexion.Open();
            //enviamos el parametro a buscar en la database
            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            //asignamos el cdm a leerFila para que lea la ejecucion de las filas
            leerFilas = cmd.ExecuteReader();
            //agregamos una lista de registro
            List<E_Categoria> Listar = new List<E_Categoria>();
            //con un ciclo leemos los registros de la dbase
            while (leerFilas.Read())
            {
                //agregamos cada registro a mi lista(*Listar*)
                Listar.Add(new E_Categoria
                {
                    IdCategoria = leerFilas.GetInt32(0),
                    CodigoCategoria = leerFilas.GetString(1),
                    NombreCategoria = leerFilas.GetString(2),
                    DescripcionCategoria = leerFilas.GetString(3)

                });
                
                
            }
            //cerramos la conexion
            this.conexion.Close();
            //cerramos llerFila
            leerFilas.Close();
            //retornamos un objeto List<>
            return Listar;

        }//fin de listarCategoria

        //metodo encargado de INSERTAR datos A La Categoria
        public void InsertarCategoria(E_Categoria categoria)
        {
            /*
             * invocamos a nuestra clase que ejecuta nuestros procedientos almacenado
             * instanciamos la clase SqlCommand y le pasamos el nombre del procedimiento almacenado
             * que vamos a utlizar para esta consulta, mas la conexion.
            */
            SqlCommand cmd = new SqlCommand("SP_INSERTARCATEGORIA", this.conexion);
            /* 
            *le decimos que la consulta sera de un procediento almacenado y 
            *no una consulta de text. 
            */
            cmd.CommandType = CommandType.StoredProcedure;
            // abrimos la conexion
            this.conexion.Open();

            //enviamos los parametros para la consulta en la database
            cmd.Parameters.AddWithValue("@NOMBRE",categoria.NombreCategoria);
            cmd.Parameters.AddWithValue("@DESCRIPCION",categoria.DescripcionCategoria);

            //ejecutamos la consulta
            cmd.ExecuteNonQuery();
            //cerramos la conexion
            conexion.Close();

        }

        public void EditarCategoria(E_Categoria categoria)
        {
            /*
          * invocamos a nuestra clase que ejecuta nuestros procedientos almacenado
          * instanciamos la clase SqlCommand y le pasamos el nombre del procedimiento almacenado
          * que vamos a utlizar para esta consulta, mas la conexion.
         */
            SqlCommand cmd = new SqlCommand("SP_EDITARCATEGORIA",conexion);
            /* 
           *le decimos que la consulta sera de un procediento almacenado y 
           *no una consulta de text. 
           */
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            //enviamos los parametros para la consulta en la database
            cmd.Parameters.AddWithValue("IDCATEGORIA",categoria.IdCategoria);
            cmd.Parameters.AddWithValue("NOMBRE", categoria.NombreCategoria);
            cmd.Parameters.AddWithValue("DESCRIPCION",categoria.DescripcionCategoria);

            //ejecutamos la consulta y  cerramos la conexion
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarCategoria(E_Categoria categoria)
        {
             /*
                * invocamos a nuestra clase que ejecuta nuestros procedientos almacenado
                * instanciamos la clase SqlCommand y le pasamos el nombre del procedimiento almacenado
                * que vamos a utlizar para esta consulta, mas la conexion.
               */
            SqlCommand cmd = new SqlCommand("SP_ELIMINARCATEGORIA", conexion);
            /* 
                *le decimos que la consulta sera de un procediento almacenado y 
                *no una consulta de text. 
                */
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            //enviamos los parametros para la consulta en la database
            cmd.Parameters.AddWithValue("@IDCATEGORIA", categoria.IdCategoria);   
            //ejecutamos la consulta y  cerramos la conexion
            cmd.ExecuteNonQuery();
            conexion.Close();

        }

    }
}
