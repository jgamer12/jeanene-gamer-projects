using CarMastery.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarMastery.UI.Models
{
    public class InventoryReportViewModel
    {
        public IEnumerable<InventoryReport> NewInventoryReport { get; set; }
        public IEnumerable<InventoryReport> UsedInventoryReport { get; set; }
    }
}