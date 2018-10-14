using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMastery.UI.Utilities
{
    public static class PriceDropDownListUtility
    {
        public static IEnumerable<SelectListItem> PriceDropDownList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Text="10000", Value = "$10,000"},
                new SelectListItem{Text="20000", Value = "$20,000"},
                new SelectListItem{Text="30000", Value = "$30,000"},
                new SelectListItem{Text="40000", Value = "$40,000"},
                new SelectListItem{Text="50000", Value = "$50,000"},
                new SelectListItem{Text="60000", Value = "$60,000"},
                new SelectListItem{Text="70000", Value = "$70,000"},
                new SelectListItem{Text="80000", Value = "$80,000"},
                new SelectListItem{Text="90000", Value = "$90,000"},

            };
        }
    }
}