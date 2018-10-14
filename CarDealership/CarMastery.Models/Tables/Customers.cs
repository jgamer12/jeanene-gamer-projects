using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Tables
{
    public class Customers
    {
        public int CustomerId { get; set; }
        public string StateId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerStreet1 { get; set; }
        public string CustomerStreet2 { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerZipCode { get; set; }
    }
}
