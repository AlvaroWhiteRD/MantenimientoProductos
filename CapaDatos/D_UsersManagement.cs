using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace CapaDatos
{
    public class D_UsersManagement
    {
        //realizamos la conexion a la base de datos. 
        //conectar viene de la conexion del App.config
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_UsersManagement> ShowUsers()
        {
            SqlDataReader readerRow;

            SqlCommand cmd = new SqlCommand("SP_show_new_user", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            //asignamos el cmd a leerFila para que lea la ejecucion de las filas
            readerRow = cmd.ExecuteReader();
            //creamos una lista de registro E_UsersManagement
            List<E_UsersManagement> listing = new List<E_UsersManagement>();

            while (readerRow.Read())
            {
                listing.Add(new E_UsersManagement
                {
                    IdUser = readerRow.GetInt32("id_user"),
                    UserName = readerRow.GetString("user_name"),
                    IdRol = readerRow.GetInt32("id_rol"),
                    IdEmployee = readerRow.GetInt32("id_employee"),
                    NameEmployee = readerRow.GetString(4),
                    LastName = readerRow.GetString(5),
                    MothersLastName = readerRow.GetString(6),
                    RolUser = readerRow.GetString("rol")


                });
            }
            connection.Close();
            readerRow.Close();

            return listing;

        }

        public void InsertUser(E_UsersManagement entitiesUser)
        {
            string password = EncryptPassword.GetSHA256("123456789");

            SqlCommand cmd = new SqlCommand("SP_create_new_user", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            cmd.Parameters.AddWithValue("@user_name",entitiesUser.UserName);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@id_rol", entitiesUser.IdRol);
            cmd.Parameters.AddWithValue("@id_employee", entitiesUser.IdEmployee);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateUser(E_UsersManagement entitiesUser)
        {
            string password = EncryptPassword.GetSHA256("123456789");

            SqlCommand cmd = new SqlCommand("SP_update_user", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            cmd.Parameters.AddWithValue("@user_name", entitiesUser.UserName);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@id_rol", entitiesUser.IdRol);
            cmd.Parameters.AddWithValue("@id_employee", entitiesUser.IdEmployee);
            cmd.Parameters.AddWithValue("@id_user", entitiesUser.IdUser);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteUser(int idUser)
        {
            SqlCommand cmd = new SqlCommand("SP_delete_user", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            cmd.Parameters.AddWithValue("@id_user", idUser);
            cmd.ExecuteReader();
            connection.Close();


        }
      


    }
}
