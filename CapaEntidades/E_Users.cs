using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class E_Users
    {
        private int idUser,idRol,idEmployee;
        private string userName, password, nameEmployee, lastName,email;


        public int IdUser { get => idUser; set => idUser = value; }
        public int IdRol { get => idRol; set => idRol = value; }
        public int IdEmployee { get => idEmployee; set => idEmployee = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string EmployeeName { get => nameEmployee; set => nameEmployee = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Emaill { get => email; set => email = value; }
    }
}
