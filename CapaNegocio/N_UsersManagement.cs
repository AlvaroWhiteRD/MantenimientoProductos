using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaNegocio
{
    public class N_UsersManagement
    {
        //instanciamos la clase de la capaDatos 
        D_UsersManagement objUserManagement = new D_UsersManagement();

        public List<E_UsersManagement> ShowUsers()
        {
            return objUserManagement.ShowUsers();
        }
        public void InsertUser(E_UsersManagement entitiesUser)
        {
            objUserManagement.InsertUser(entitiesUser);
        }
        public void UpdateUser(E_UsersManagement entitiesUser)
        {
            objUserManagement.UpdateUser(entitiesUser);
        }
        public void DeleteUser(int idUser)
        {
            objUserManagement.DeleteUser(idUser);
        }
    }
}
