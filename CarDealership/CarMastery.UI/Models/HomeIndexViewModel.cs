using CarMastery.Models.Queries;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarMastery.UI.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Specials> SpecialsList { get; set; }
        public IEnumerable<FeaturedVehicleShortItem> FeaturedVehicles { get; set; }
    }
}