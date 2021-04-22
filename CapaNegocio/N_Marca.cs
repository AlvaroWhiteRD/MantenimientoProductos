
using System;
using System.Collections.Generic;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    /*
      creamos los metodos de tipo list para la comunicacion entre las capas
     * de negocio con la capa de datos
      */
    public class N_Marca
    {
        //instanciamos la clase de la capaDatos
        D_Marca objMarca = new D_Marca();

        public List<E_Marca> ListarMarcas(string buscar)
        {
            return objMarca.ListarMarcas(buscar);
        } 
        public void InsertarMarca(E_Marca marca)
        {
            objMarca.InsertarMarca(marca);
        }
        public void EditarMarca(E_Marca marca)
        {
            objMarca.EditarMarca(marca);
        }
        public void EliminarMarca(E_Marca marca) {

            objMarca.EliminarMarca(marca);
        }
    }
}
