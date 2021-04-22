using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaNegocio
{

    /*
      creamos los metodos de tipo list para la comunicacion entre las capas
     * de negocio con la capa de datos
      */
    public class N_Departments
    {
        //instanciamos la clase de la capaDatos
        D_Departments objDepartment = new D_Departments();

        public List<E_Departments> ShowDepartments(string search) 
        {
            return objDepartment.ShowDepartments(search);
        }
        public void InsertDepartment(E_Departments _department)
        {
            objDepartment.InsertDepartment(_department);
        }
        public void UpdateDepartment(E_Departments _department)
        {
            objDepartment.UpdateDepartment(_department);
        }
        public void DeleteDepartment(E_Departments _department)
        {

            objDepartment.DeleteDepartment(_department);
        }
    }
}
