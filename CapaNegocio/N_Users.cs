using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaNegocio
{
    public class N_Users
    {

        D_Users objUser = new D_Users();

        public E_Users LoginValidate(string user, string password)
        {
            return objUser.LoginValidate(user,password);
        }
        public int UpdatePassword(int id, string password)
        {
            return objUser.UpdatePassword( id, password);
        }

    }
}
