using System;
using System.Collections.Generic;
using System.Text;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class N_Employees
    {
        /* 
            creamos los metodos de tipo list para la comunicacion entre las capas
           * de negocio con la capa de datos
        */
         
        //instanciamos la clase de la capaDatos 
        D_Employees objEmployee = new D_Employees();

        public List<E_Employees> ShowEmployee()
        {
            return objEmployee.ShowEmployee();
        }
        public List<E_Employees> SearchEmployee(string search)
        {
            return objEmployee.SearchEmployee(search);
        }
        public void InsertEmployee(E_Employees _employees)
        {
            objEmployee.InsertEmployee(_employees);
        }
        public void UpdateEmployee(E_Employees _employees)
        {
            objEmployee.UpdateEmployee(_employees);
        }
        public void DeleteEmployee(int _employees)
        {
            objEmployee.DeleteEmployee(_employees);
        }
        public List<E_Employees> ShowEmployeeFullNameID()
        {
            return objEmployee.ShowEmployeeFullNameID();
        }
    }
}
