using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
//using System.Windows.

namespace CapaDatos
{
    public class D_Users
    {
        //realizamos la conexion a la base de datos.
        //conectar viene de la conexion del App.config
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public E_Users LoginValidate(string user, string password)
        {

            //le pasamos el procedimiento almacenado con el que vamos a trabajar
            SqlCommand cmd = new SqlCommand("SP_login_user_access", connection);
            //le expecificamos que es un procedimiento y un texto plano
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();

            cmd.Parameters.AddWithValue("@user_name", user);
            cmd.Parameters.AddWithValue("@password", password);

            SqlDataReader dataReader = cmd.ExecuteReader();

            E_Users users = null;

            if (dataReader.Read())
            {
                users = new E_Users();

                users.IdUser = int.Parse(dataReader["id_user"].ToString());
                users.IdRol = int.Parse(dataReader["id_rol"].ToString());
                //users.IdEmployee = int.Parse(dataReader["id_employee"].ToString());
                users.UserName = dataReader["user_name"].ToString();
                users.EmployeeName = dataReader[3].ToString();
                users.LastName = dataReader[4].ToString();
                users.Emaill = dataReader[5].ToString();

            }
            connection.Close();
            return users;

        }
        //metodo que se encarga de actualizar el password.
        public int UpdatePassword(int id, string password)
        {

            string sqlUpdate = "UPDATE users SET password=@password WHERE id_user=@id";
            //"UPDATE users SET password=@password WHERE id_user=@id"
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlUpdate, connection);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@id", id);

            int cant;
            cant = cmd.ExecuteNonQuery();
            connection.Close();
            return cant;
        }
    }
}
