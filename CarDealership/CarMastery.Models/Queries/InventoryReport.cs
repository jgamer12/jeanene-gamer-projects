using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Queries
{
    public class InventoryReport
    {
        public int VehicleYear { get; set; }
        public string MakeDescription { get; set; }
        public string ModelDescription { get; set; }
        public int Count { get; set; }
        public decimal StockValue { get; set; }
    }
}
