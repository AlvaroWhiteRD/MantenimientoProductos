using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaNegocio
{
    public class N_SalesConcepts
    {
        /*
        creamos los metodos de tipo list para la comunicacion entre las capas
       * de negocio con la capa de datos
     */

        //instanciamos la clase de la capaDatos 
        D_SalesConcepts objSalesConcepts = new D_SalesConcepts();

        
        public void GenerarateSaleConceptInsert(List<E_SalesConcepts> _salesConcept)
        {
           objSalesConcepts.GenerarateSaleConceptInsert(_salesConcept);
        }
    }
}
