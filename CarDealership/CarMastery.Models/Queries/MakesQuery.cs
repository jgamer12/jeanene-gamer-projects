using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Queries
{
    public class MakesQuery
    {
        public int MakeId { get; set; }
        public string MakeDescription { get; set; }
        public DateTime MakeDateAdded { get; set; }
        public string UserName { get; set; }
    }
}
