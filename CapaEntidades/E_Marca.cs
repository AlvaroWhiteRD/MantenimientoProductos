using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidad
{
   public class E_Marca
    {
        private int _idMarca;
        private string _codigoMarca;
        private string _nombreMarca;
        private string _descripcionMarca;

        public int IdMarca { get => _idMarca; set => _idMarca = value; }
        public string CodigoMarca { get => _codigoMarca; set => _codigoMarca = value; }
        public string NombreMarca { get => _nombreMarca; set => _nombreMarca = value; }
        public string DescripcionMarca { get => _descripcionMarca; set => _descripcionMarca = value; }
    }
}
