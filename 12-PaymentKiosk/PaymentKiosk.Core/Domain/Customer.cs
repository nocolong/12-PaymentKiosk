using PaymentKiosk.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentKiosk.Core
{
    public class Customer
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public Address ShippingAddress { get; set; }
    }
}
