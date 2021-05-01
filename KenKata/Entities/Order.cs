using System;
using System.Collections.Generic;

#nullable disable

namespace KenKata.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();            
        }

        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string StreetAddress { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal OrderTotal { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }        
    }
}
