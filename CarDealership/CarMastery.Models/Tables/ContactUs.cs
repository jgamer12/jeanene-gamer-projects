using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Tables
{
    public class ContactUs
    {
        public int ContactUsId { get; set; }
        public string ContactUsFirstName { get; set; }
        public string ContactUsLastName { get; set; }
        public string ContactUsEmail { get; set; }
        public string ContactUsPhone { get; set; }
        public string ContactUsMessage { get; set; }
    }
}
