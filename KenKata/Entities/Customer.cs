using System;
using System.Collections.Generic;

#nullable disable

namespace KenKata.Entities
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNr { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
    }
}
