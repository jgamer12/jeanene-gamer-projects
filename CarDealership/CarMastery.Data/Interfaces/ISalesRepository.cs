using CarMastery.Models.Queries;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Interfaces
{
    public interface ISalesRepository
    {
        IEnumerable<SalesReport> GetSalesForReport(SalesReportSearchParameters parameters);
        void AddSale(Sales sale);
        IEnumerable<Sales> GetAllSales();
    }
}
