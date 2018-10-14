using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMastery.UI.Models
{
    public class InventoryQueryViewModel
    {
        public IEnumerable<SelectListItem> MinPriceSelectList { get; set; }
        public IEnumerable<SelectListItem> MaxPriceSelectList { get; set; }
        public IEnumerable<SelectListItem> MinYearSelectList { get; set; }
        public IEnumerable<SelectListItem> MaxYearSelectList { get; set; }
    }
}