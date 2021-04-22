using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CapaEntidades;


namespace CapaDatos
{
    public class D_Employees
    {
        //realizamos la conexion a la base de datos. 
        //conectar viene de la conexion del App.config
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        //metodo encargado de listar datos 
        //pasamos como argumento a la lista la clase 
        public List<E_Employees> ShowEmployee()
        {
            //leemos los datos de la base de datos
            SqlDataReader readerRow;
            //le pasamos la cadena de texto con el nombre de nuestro procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_show_employees", connection);
            //ahora le decimos que ese dato que le pasamos no es un texto normal si no un procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            //asignamos el cmd a leerFila para que lea la ejecucion de las filas
            readerRow = cmd.ExecuteReader();
            //creamos una lista de registro
            List<E_Employees> listing = new List<E_Employees>();

            while (readerRow.Read())
            {
                
                //pasamos los datos de nuestra bse de datos a nuestra objeto entidad a travez de la lista
                listing.Add( new E_Employees
                {
                   //IdEmployee = readerFil.GetInt32(0),
                    NameEmployee = readerRow.GetString(0),
                    MothersLastName = readerRow.GetString(1),
                    LastName = readerRow.GetString(2),
                    Dni = readerRow.GetInt32(3),
                    Email = readerRow.GetString(4),
                    Phone = readerRow.GetInt32(5),
                    Sex = readerRow.GetString(6),
                    CivilStatus = readerRow.GetString(7),
                    
                    AddressEmployee = readerRow.GetString(8),                  
                    DateOfAdmission = readerRow.GetDateTime(9),
                    IdDepartment = readerRow.GetInt32(10),
                    Department = readerRow.GetString(11),
                    IdEmployee = readerRow.GetInt32(12)

                });
            }
            connection.Close();
            readerRow.Close();

            return listing;


        }
        public List<E_Employees> SearchEmployee(string search)
        {
            //leemos los datos de la base de datos
            SqlDataReader readerRow;
            //le pasamos la cadena de texto con el nombre de nuestro procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_search_employees", connection);
            //ahora le decimos que ese dato que le pasamos no es un texto normal si no un procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            //agregamos los campos de la consulta
            cmd.Parameters.AddWithValue("@search", search);

            //asignamos el cdm a leerFila para que lea la ejecucion de las filas
            readerRow = cmd.ExecuteReader();
            //creamos una lista de registro
            List<E_Employees> listing = new List<E_Employees>();


            while (readerRow.Read())
            {
                //pasamos los datos de nuestra bse de datos a nuestra objeto entidad a travez de la lista
                listing.Add(new E_Employees
                {
                    NameEmployee = readerRow.GetString(0),
                    MothersLastName = readerRow.GetString(2),
                    LastName = readerRow.GetString(1),
                    Dni = readerRow.GetInt32(3),
                    Email = readerRow.GetString(4),
                    Phone = readerRow.GetInt32(5),
                    Sex = readerRow.GetString(12),
                    CivilStatus = readerRow.GetString(6),

                    AddressEmployee = readerRow.GetString(7),
                    DateOfAdmission = readerRow.GetDateTime(8),
                    IdDepartment = readerRow.GetInt32(9),
                    Department = readerRow.GetString(10),
                   // IdEmployee = readerRow.GetInt32(12)

                });
            }
            connection.Close();
            readerRow.Close();

            return listing;


        }
        public void InsertEmployee(E_Employees _employee)
        {
            SqlCommand cmd = new SqlCommand("SP_create_employees", connection);

            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            cmd.Parameters.AddWithValue("@name_employee", _employee.NameEmployee);
            cmd.Parameters.AddWithValue("@last_name", _employee.LastName);
            cmd.Parameters.AddWithValue("@mothers_last_name", _employee.MothersLastName);
            cmd.Parameters.AddWithValue("@dni", _employee.Dni);
            cmd.Parameters.AddWithValue("@email", _employee.Email);
            cmd.Parameters.AddWithValue("@sex", _employee.Sex);
            cmd.Parameters.AddWithValue("@phone", _employee.Phone);
            cmd.Parameters.AddWithValue("@civil_status", _employee.CivilStatus);
            cmd.Parameters.AddWithValue("@address_employee", _employee.AddressEmployee);
            cmd.Parameters.AddWithValue("@date_of_admission", _employee.DateOfAdmission);
            cmd.Parameters.AddWithValue("@id_department", _employee.IdDepartment);

            cmd.ExecuteNonQuery();
            connection.Close();

        
        }
        public void UpdateEmployee(E_Employees _employee)
        {
            SqlCommand cmd = new SqlCommand("SP_update_employees", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            cmd.Parameters.AddWithValue("@id_employee", _employee.IdEmployee);
            cmd.Parameters.AddWithValue("@name_employee", _employee.NameEmployee);
            cmd.Parameters.AddWithValue("@last_name", _employee.LastName);
            cmd.Parameters.AddWithValue("@mothers_last_name", _employee.MothersLastName);
            cmd.Parameters.AddWithValue("@dni", _employee.Dni);
            cmd.Parameters.AddWithValue("@email", _employee.Email);
            cmd.Parameters.AddWithValue("@phone", _employee.Phone);
            cmd.Parameters.AddWithValue("@civil_status", _employee.CivilStatus);
            cmd.Parameters.AddWithValue("@sex", _employee.Sex);
            cmd.Parameters.AddWithValue("@address_employee", _employee.AddressEmployee);
            cmd.Parameters.AddWithValue("@date_of_admission", _employee.DateOfAdmission);
            cmd.Parameters.AddWithValue("@id_department", _employee.IdDepartment);

            cmd.ExecuteNonQuery();
            connection.Close();

        }
        public void DeleteEmployee(int _employees)
        {
            SqlCommand cmd = new SqlCommand("SP_delete_employee", connection);

            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            cmd.Parameters.AddWithValue("@id_employee", _employees);

            cmd.ExecuteReader();
            connection.Close();
        }

    }
}