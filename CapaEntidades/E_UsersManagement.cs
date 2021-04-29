using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class E_UsersManagement
    {
        private int idRol, idEmployee,idUser;
        private string userName, password;
        private string nameEmployee, lastName, mothersLastName, rolUser;

        public int IdRol { get => idRol; set => idRol = value; }
        public int IdEmployee { get => idEmployee; set => idEmployee = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string NameEmployee { get => nameEmployee; set => nameEmployee = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string MothersLastName { get => mothersLastName; set => mothersLastName = value; }
        public int IdUser { get => idUser; set => idUser = value; }
        public string RolUser { get => rolUser; set => rolUser = value; }
    }
}
