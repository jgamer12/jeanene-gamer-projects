using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Tables
{
    public class Makes
    {
        public int MakeId { get; set; }
        public string UserId { get; set; }
        public string MakeDescription { get; set; }
        public DateTime MakeDateAdded { get; set; }
    }
}
