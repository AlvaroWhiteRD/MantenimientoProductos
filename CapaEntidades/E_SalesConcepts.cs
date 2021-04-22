using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class E_SalesConcepts
    {
        private int idConcept, idProduct, idSale;
        private decimal amount, salePrice;

        public int IdConcept { get => idConcept; set => idConcept = value; }
        public int IdProduct { get => idProduct; set => idProduct = value; }
        public int IdSale { get => idSale; set => idSale = value; }
        public decimal Amount { get => amount; set => amount = value; }
        public decimal SalePrice { get => salePrice; set => salePrice = value; }
    }
}
