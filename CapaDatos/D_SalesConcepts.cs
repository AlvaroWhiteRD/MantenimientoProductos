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
        //conectar viene de la conexion del App.config IEnumerable<D_SalesConcepts>
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public void GenerarateSaleConceptInsert(List<E_SalesConcepts> _salesConcept)
        {//el stock de los productos se actualiza en el momento de el insert a la tabla 
            //SalesConcepts. y se realiza en el mismo procedimiento almacenado.

            connection.Open();
            //creamos un foreach para insertar todos los productos en una venta
            foreach( E_SalesConcepts aux in _salesConcept)
            {
                //indicamos el procediento a usar
                SqlCommand cmd = new SqlCommand("SP_generate_sale_concept", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                //enviamos los parametros.
                cmd.Parameters.AddWithValue("@amount", aux.Amount);
                cmd.Parameters.AddWithValue("@id_product", aux.IdProduct);
                cmd.Parameters.AddWithValue("@id_sale", aux.IdSale);
                cmd.Parameters.AddWithValue("@sale_concepts", aux.SalePrice);
                cmd.ExecuteNonQuery();
            }
            connection.Close();    
        }
    }
}
