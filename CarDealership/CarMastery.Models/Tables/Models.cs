using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Tables
{
    public class Models
    {
        public int ModelId { get; set; }
        public int MakeId { get; set; }
        public string UserId { get; set; }
        public string ModelDescription { get; set; }
        public DateTime ModelDateAdded { get; set; }
    }
}

