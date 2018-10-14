using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMastery.UI.Utilities
{
    public static class YearDropDownListUtility
    {
        public static IEnumerable<SelectListItem> YearDropDownList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Text="2019", Value = "2019"},
                new SelectListItem{Text="2018", Value = "2018"},
                new SelectListItem{Text="2017", Value = "2017"},
                new SelectListItem{Text="2016", Value = "2016"},
                new SelectListItem{Text="2015", Value = "2015"},
                new SelectListItem{Text="2014", Value = "2014"},
                new SelectListItem{Text="2013", Value = "2013"},
                new SelectListItem{Text="2012", Value = "2012"},
                new SelectListItem{Text="2011", Value = "2011"},
                new SelectListItem{Text="2010", Value = "2010"},
                new SelectListItem{Text="2009", Value = "2009"},
                new SelectListItem{Text="2008", Value = "2008"},
                new SelectListItem{Text="2007", Value = "2007"},
                new SelectListItem{Text="2006", Value = "2006"},
                new SelectListItem{Text="2005", Value = "2005"},
                new SelectListItem{Text="2004", Value = "2004"},
                new SelectListItem{Text="2003", Value = "2003"},
                new SelectListItem{Text="2002", Value = "2002"},
                new SelectListItem{Text="2001", Value = "2001"}
            };
        }
    }
}