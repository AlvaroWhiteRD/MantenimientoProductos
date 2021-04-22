using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class D_Customers
    {
        //realizamos la conexion a la base de datos. 
        //conectar viene de la conexion del App.config
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);


       
        //metodo encargado de listar datos 
        //pasamos como argumento a la lista la clase 
        public List<E_Customers> ShowCliemt()
        {
            //leemos los datos de la base de datos
            SqlDataReader readerRow;
            //le pasamos la cadena de texto con el nombre de nuestro procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_show_customers", connection);
            //indicamos que nuestra consulta es un procediento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            //asignamos el cmd a leerFila para que lea la ejecucion de las filas
            readerRow = cmd.ExecuteReader();
            //creamos una lista de registro 
            List<E_Customers> listing = new List<E_Customers>();

            while (readerRow.Read())
                {
                listing.Add(new E_Customers
                {
                    IdClient = readerRow.GetInt32("id_client"),
                    CustomerName = readerRow.GetString("name_Client"),
                    ClientLastName = readerRow.GetString("last_name_client"),
                    ClientMaternalSurname = readerRow.GetString("mothers_last_name_client"),
                    CustomerEmail = readerRow.GetString("email_client"),
                    CustomerGender = readerRow.GetString("gender_client"),
                    CustomerCivilStatus = readerRow.GetString("civil_status_client"),
                    CustomerAddress = readerRow.GetString("address_employee_client"),
                    DniClient = readerRow.GetInt32("dni_client"),
                    PhoneClient = readerRow.GetInt32("phone_client"),
                    CustomerRegistrationDate = readerRow.GetDateTime("registration_date_client")
                });
            }
            connection.Close();
            readerRow.Close();

            return listing;
        }

        public List<E_Customers> SearchCustomer(string search)
        {
            //leemos los datos de la base de datos
            SqlDataReader readerRow;

            SqlCommand cmd = new SqlCommand("SP_search_customers", connection);

            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            cmd.Parameters.AddWithValue("@search", search);

            readerRow = cmd.ExecuteReader();

            List<E_Customers> listnig = new List<E_Customers>();

            while (readerRow.Read())
            {
                listnig.Add(new E_Customers
                {
                    IdClient = readerRow.GetInt32(0),
                    CustomerName = readerRow.GetString("name_Client"),
                    ClientLastName = readerRow.GetString("last_name_client"),
                    ClientMaternalSurname = readerRow.GetString("mothers_last_name_client"),
                    CustomerEmail = readerRow.GetString("email_client"),
                    CustomerGender = readerRow.GetString("gender_client"),
                    CustomerCivilStatus = readerRow.GetString("civil_status_client"),
                    CustomerAddress = readerRow.GetString("address_employee_client"),
                    DniClient = readerRow.GetInt32("dni_client"),
                    PhoneClient = readerRow.GetInt32("phone_client"),
                    CustomerRegistrationDate = readerRow.GetDateTime("registration_date_client")
                });
            }
            connection.Close();
            readerRow.Close();

            return listnig;

        }

        public void InsertCustomer(E_Customers _customer)
        {
            SqlCommand cmd = new SqlCommand("SP_create_customers", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            cmd.Parameters.AddWithValue("@name_Client", _customer.CustomerName);
            cmd.Parameters.AddWithValue("@last_name_client", _customer.ClientLastName);
            cmd.Parameters.AddWithValue("@mothers_last_name_client", _customer.ClientMaternalSurname);
            cmd.Parameters.AddWithValue("@dni_client", _customer.DniClient);
            cmd.Parameters.AddWithValue("@email_client", _customer.CustomerEmail);
            cmd.Parameters.AddWithValue("@phone_client", _customer.PhoneClient);
            cmd.Parameters.AddWithValue("@civil_status_client", _customer.CustomerCivilStatus);
            cmd.Parameters.AddWithValue("@gender_client", _customer.CustomerGender);
            cmd.Parameters.AddWithValue("@address_employee_client", _customer.CustomerAddress);
            cmd.Parameters.AddWithValue("@registration_date_client", _customer.CustomerRegistrationDate);

            cmd.ExecuteNonQuery();
            connection.Close();

        }
        public void UpdateCustomer(E_Customers _customer)
        {
            SqlCommand cmd = new SqlCommand("SP_update_customers", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            cmd.Parameters.AddWithValue("@id_client", _customer.IdClient);
            cmd.Parameters.AddWithValue("@name_Client", _customer.CustomerName);
            cmd.Parameters.AddWithValue("@last_name_client", _customer.ClientLastName);
            cmd.Parameters.AddWithValue("@mothers_last_name_client", _customer.ClientMaternalSurname);
            cmd.Parameters.AddWithValue("@dni_client", _customer.DniClient);
            cmd.Parameters.AddWithValue("@email_client", _customer.CustomerEmail);
            cmd.Parameters.AddWithValue("@phone_client", _customer.PhoneClient);
            cmd.Parameters.AddWithValue("@civil_status_client", _customer.CustomerCivilStatus);
            cmd.Parameters.AddWithValue("@gender_client", _customer.CustomerGender);
            cmd.Parameters.AddWithValue("@address_employee_client", _customer.CustomerAddress);
            cmd.Parameters.AddWithValue("@registration_date_client", _customer.CustomerRegistrationDate);

            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteCustomer(int _employees)
        {
            SqlCommand cmd = new SqlCommand("SP_delete_customers", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            cmd.Parameters.AddWithValue("@id_client", _employees);

            cmd.ExecuteReader();
            connection.Close();
        }

        //metodo que se encarga de traer el nombre, apellido, direccion y dni del cliente
        //de la base de datos para llenar estos campos en la vista de ventas
        public List<E_Customers> SearchClientDNI(int search)
        {
            SqlDataReader readerRow;

            SqlCommand cmd = new SqlCommand("SP_show_employees_id_name_lastname_lastnamemother", connection);

            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            //enviamos el parametro de la busqueda
            cmd.Parameters.AddWithValue("@search", search);
            //asignamos el cmd a leerFila para que lea la ejecucion de las filas
            readerRow = cmd.ExecuteReader();
            //creamos una lista con los registro registro  
            List<E_Customers> listing = new List<E_Customers>();

            while (readerRow.Read())
            {
                //llenamos la lista con los datos de la base de datos
                listing.Add(new E_Customers
                {
                    CustomerName = readerRow.GetString("name_Client"),
                    ClientLastName = readerRow.GetString("last_name_client"),
                    IdClient = readerRow.GetInt32("id_client"),
                    DniClient = readerRow.GetInt32("dni_client"),
                    CustomerAddress = readerRow.GetString("address_employee_client"),
                });
            }
            connection.Close();
            readerRow.Close();

            return listing;

        }

    }
}
