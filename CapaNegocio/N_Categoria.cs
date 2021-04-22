using System;
using System.Collections.Generic;
using System.Text;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    
    //Esta clase se comunicaca con la capaDatos y la capaEntidades 
    public class N_Categoria
    {
        //instanciamos la clase de la capaDatos
        D_Categoria objDato = new D_Categoria();

        /*
         creamos los metodos de tipo list para la comunicacion entre las capas
        * de negocio con la capa de datos
         */
        public List<E_Categoria> ListandoCategoria(string buscar)
        {
            return objDato.ListarCategorias(buscar);
        }

        public void InsertarCategoria(E_Categoria categoria)
        {
            objDato.InsertarCategoria(categoria);
        }

        public void EditandoCategoria(E_Categoria categoria)
        {
            objDato.EditarCategoria(categoria);
        }
        public void EliminandoCategoria(E_Categoria categoria)
        {
            objDato.EliminarCategoria(categoria);
        }
    }

}
