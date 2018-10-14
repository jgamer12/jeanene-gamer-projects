using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Queries
{
    public class SalesReportSearchParameters
    {
        public string UserId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
