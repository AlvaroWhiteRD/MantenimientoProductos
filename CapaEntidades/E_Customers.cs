using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class E_Customers
    {
        private int idClient, dniClient, phoneClient;
        private string customerName, clientLastName, clientMaternalSurname,  customerEmail, customerGender, customerCovilStatus, customerAddress;
        private DateTime customerRegistrationDate;

        public int IdClient { get => idClient; set => idClient = value; }
        public int DniClient { get => dniClient; set => dniClient = value; }
        public int PhoneClient { get => phoneClient; set => phoneClient = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string ClientLastName { get => clientLastName; set => clientLastName = value; }
        public string ClientMaternalSurname { get => clientMaternalSurname; set => clientMaternalSurname = value; }
        public string CustomerEmail { get => customerEmail; set => customerEmail = value; }
        public string CustomerGender { get => customerGender; set => customerGender = value; }
        public string CustomerCivilStatus { get => customerCovilStatus; set => customerCovilStatus = value; }
        public string CustomerAddress { get => customerAddress; set => customerAddress = value; }
        public DateTime CustomerRegistrationDate { get => customerRegistrationDate; set => customerRegistrationDate = value; }
    }
}
