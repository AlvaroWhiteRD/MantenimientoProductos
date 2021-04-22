using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CapaEntidades;


namespace CapaDatos
{
    public class D_Departments
    {
        //realizamos la conexion a la base de datos.
        //conectar viene de la conexion del App.config
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        //metodo encargado de listar datos 
        //pasamos como argumento a la lista la clase E_departamento
        public List<E_Departments> ShowDepartments(string search)
        {
            //leemos los datos de la base de datos
            SqlDataReader readerRow;
            //le pasamos la cadena de texto con el nombre de nuestro procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_search_departments", connection);
            //ahora le decimos que ese dato que le pasamos no es un texto normal si no un procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            //agregamos los campos de la consulta
            cmd.Parameters.AddWithValue("@search", search);
            //asignamos el cdm a leerFila para que lea la ejecucion de las filas
            readerRow = cmd.ExecuteReader();
            //creamos una lista de registro
            List<E_Departments> listing = new List<E_Departments>();
            //recorremos los registros de la dbase
            while (readerRow.Read())
            {
                //agregamos cada registro a mi lista(*listing*)
                listing.Add(new E_Departments
                {
                    IdDepartment = readerRow.GetInt32(0),
                    NameDepartment = readerRow.GetString(1)
                });


            }
            connection.Close();
            readerRow.Close();
            //retornamos un objeto List<>
            return listing;
        }

        //metodo encargado de insertar las marcas
        public void InsertDepartment(E_Departments _department)
        {
            //le pasamos la cadena de texto con el nombre de nuestro procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_add_department", connection);
            //ahora le decimos que ese dato que le pasamos no es un texto normal si no un procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            //agregamos los campos de la consulta
            cmd.Parameters.AddWithValue("@name_department", _department.NameDepartment);
            //ejecutamos la consulta
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateDepartment(E_Departments _department)
        {//le pasamos la cadena de texto con el nombre de nuestro procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_update_department", connection);
            //ahora le decimos que ese dato que le pasamos no es un texto normal si no un procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            //agregamos los campos de la consulta
            cmd.Parameters.AddWithValue("@id_department", _department.IdDepartment);
            cmd.Parameters.AddWithValue("@name_department", _department.NameDepartment);

            //ejecutamos la consulta
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteDepartment(E_Departments _department)
        {
            //le pasamos la cadena de texto con el nombre de nuestro procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_delete_department", connection);
            //ahora le decimos que ese dato que le pasamos no es un texto normal si no un procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            //agregamos los campos de la consulta
            cmd.Parameters.AddWithValue("@id_department", _department.IdDepartment);
            //ejecutamos la consulta
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}
