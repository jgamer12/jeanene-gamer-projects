using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Queries
{
    public class MakeModels
    {
        public int MakeId { get; set; }
        public string MakeDescription { get; set; }
        public int ModelId { get; set; }
        public string ModelDescription { get; set; }
        public DateTime ModelDateAdded { get; set; }
        public string UserName { get; set; }
    }
}
