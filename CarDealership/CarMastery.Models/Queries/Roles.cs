using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Queries
{
    public class Roles
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Discriminator { get; set; }
    }
}
