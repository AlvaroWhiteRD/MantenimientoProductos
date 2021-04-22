using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class E_Employees
    {
        private int idEmployee,dni,phone,idDepartment;
        private string nameEmployee, mothersLastName, lastName,email,civilStatus,sex, addressEmployee,department;
        private DateTime dateOfAdmission;

        public int IdEmployee { get => idEmployee; set => idEmployee = value; }
        public int Dni { get => dni; set => dni = value; }
        public int Phone { get => phone; set => phone = value; }
        public int IdDepartment { get => idDepartment; set => idDepartment = value; }
        public string NameEmployee { get => nameEmployee; set => nameEmployee = value; }
        public string MothersLastName { get => mothersLastName; set => mothersLastName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string CivilStatus { get => civilStatus; set => civilStatus = value; }
        public string Sex { get => sex; set => sex = value; }
        public string AddressEmployee { get => addressEmployee; set => addressEmployee = value; }
        public DateTime DateOfAdmission { get => dateOfAdmission; set => dateOfAdmission = value; }
        public string Department { get => department; set => department = value; }
    }
}
