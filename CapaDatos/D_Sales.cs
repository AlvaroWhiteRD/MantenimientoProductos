using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class D_Sales
    {
        //realizamos la conexion a la base de datos. 
        //conectar viene de la conexion del App.config
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public int GenerarateSaleInsert(E_Sales _sales)
        {
            //llamamos el procedimiento almacenado para para la venta
            SqlCommand cmd = new SqlCommand("SP_generate_sale", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            //enviamos los parametros de la venta.
            cmd.Parameters.AddWithValue("@date_of_sale", _sales.DateOfSale);
            cmd.Parameters.AddWithValue("@total", _sales.Total);
            cmd.Parameters.AddWithValue("@id_user", _sales.IdUser);
            cmd.Parameters.AddWithValue("@id_client", _sales.IdClient);

            //ejecutamos la sentencia 
            //cmd.ExecuteNonQuery();
           
            int idSale;
            try 
            {
                //recibimos el ultimo ID insertado en la base de datos.
                //para ello se uso desde el procediemiento almacenado SELECT SCOPE_IDENTITY()
                idSale = Convert.ToInt32( cmd.ExecuteScalar());

            }
            catch (Exception)
            {

                idSale = 0;

            }
            connection.Close();
            return idSale;
        }

    }
}
