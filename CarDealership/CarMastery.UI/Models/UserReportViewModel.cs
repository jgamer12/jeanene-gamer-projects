using CarMastery.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarMastery.UI.Models
{
    public class UserReportViewModel
    {
        public IEnumerable<UsersRole> UsersReportList { get; set; }
    }
}