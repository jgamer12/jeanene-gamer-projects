using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPI.Models.EF
{
    public class Director
    {
        public int DirectorID { get; set; }
        public string DirectorFirstName { get; set; }
        public string DirectorLastName { get; set; }
    }
}
