using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class D_SalesConcepts
    {
        //realizamos la conexion a la base de datos. 
        //conectar viene de la conexion del App.config
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public void GenerarateSaleConceptInsert(E_SalesConcepts _salesConcept)
        {
            SqlCommand cmd = new SqlCommand("SP_generate_sale_concept", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            cmd.Parameters.AddWithValue("@amount", _salesConcept.Amount);
            cmd.Parameters.AddWithValue("@id_product", _salesConcept.IdProduct);
            cmd.Parameters.AddWithValue("@id_sale", _salesConcept.IdSale);
            cmd.Parameters.AddWithValue("@sale_concepts", _salesConcept.SalePrice);

            cmd.ExecuteNonQuery();
            connection.Close();    


        }
    }
}
