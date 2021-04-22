using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class E_Departments
    {
        private string nameDepartment;
        private int idDepartment;

        public string NameDepartment { get => nameDepartment; set => nameDepartment = value; }
        public int IdDepartment { get => idDepartment; set => idDepartment = value; }
    }
}
