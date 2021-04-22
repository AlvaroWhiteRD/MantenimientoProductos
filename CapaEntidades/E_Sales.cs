using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class E_Sales
    {
        private int idSale, idUser, idClient;
        private string codeSale;
        private decimal total;
        private DateTime dateOfSale;

        public int IdSale { get => idSale; set => idSale = value; }
        public int IdUser { get => idUser; set => idUser = value; }
        public int IdClient { get => idClient; set => idClient = value; }
        public string CodeSale { get => codeSale; set => codeSale = value; }
        public decimal Total { get => total; set => total = value; }
        public DateTime DateOfSale { get => dateOfSale; set => dateOfSale = value; }
    }
}
