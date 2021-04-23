using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaNegocio
{
    public class N_Sales
    {
        /*
        creamos los metodos de tipo list para la comunicacion entre las capas
       * de negocio con la capa de datos
     */

        //instanciamos la clase de la capaDatos 
        D_Sales objSales = new D_Sales();

        public int GenerarateSalesInsert(E_Sales _sales)
        {
           return objSales.GenerarateSaleInsert(_sales);
        }
     

    }
}
