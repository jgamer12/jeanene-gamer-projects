using CarMastery.Data.Factories;
using CarMastery.Data.Interfaces;
using CarMastery.Models.Queries;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.SampleData
{
    public class SalesRepositorySampleData : ISalesRepository
    {
        public static List<Sales> _Sales = new List<Sales>
        {
            new Sales
            { SaleId = 1, CustomerId = 1, VehicleId = 4, FinancingId = 1, UserId = "11111111-1111-1111-1111-111111111111", SaleAmount = 10500, SaleDate = DateTime.Parse("2018-04-25 00:00:00.0000000")},
            new Sales
            { SaleId = 2, CustomerId = 2, VehicleId = 5, FinancingId = 2, UserId = "11111111-1111-1111-1111-111111111111", SaleAmount = 72000, SaleDate = DateTime.Parse("2018-05-25 00:00:00.0000000")},
            new Sales
            { SaleId = 3, CustomerId = 3, VehicleId = 10, FinancingId = 3, UserId = "11111111-1111-1111-1111-111111111111", SaleAmount = 27500, SaleDate = DateTime.Parse("2018-06-25 00:00:00.0000000")},
            new Sales
            { SaleId = 4, CustomerId = 4, VehicleId = 11, FinancingId = 2, UserId = "11111111-1111-1111-1111-111111111111", SaleAmount = 16500, SaleDate = DateTime.Parse("2018-07-25 00:00:00.0000000")},
            new Sales
            { SaleId = 5, CustomerId = 1, VehicleId = 100000, FinancingId = 1, UserId = "22222222-2222-2222-2222-222222222222", SaleAmount = 10000, SaleDate = DateTime.Parse("2018-01-25 00:00:00.0000000")},
            new Sales
            { SaleId = 6, CustomerId = 2, VehicleId = 100001, FinancingId = 2, UserId = "22222222-2222-2222-2222-222222222222", SaleAmount = 20000, SaleDate = DateTime.Parse("2018-04-25 00:00:00.0000000")},
            new Sales
            { SaleId = 7, CustomerId = 3, VehicleId = 100002, FinancingId = 3, UserId = "22222222-2222-2222-2222-222222222222", SaleAmount = 35000, SaleDate = DateTime.Parse("2018-05-25 00:00:00.0000000")},
            new Sales
            { SaleId = 8, CustomerId = 4, VehicleId = 100003, FinancingId = 2, UserId = "22222222-2222-2222-2222-222222222222", SaleAmount = 45000, SaleDate = DateTime.Parse("2018-06-25 00:00:00.0000000")},
            new Sales
            { SaleId = 9, CustomerId = 1, VehicleId = 100004, FinancingId = 1, UserId = "33333333-3333-3333-3333-333333333333", SaleAmount = 30000, SaleDate = DateTime.Parse("2017-12-30 00:00:00.0000000")},
            new Sales
            { SaleId = 10, CustomerId = 2, VehicleId = 100005, FinancingId = 2, UserId = "33333333-3333-3333-3333-333333333333", SaleAmount = 60000, SaleDate = DateTime.Parse("2018-01-25 00:00:00.0000000")},
            new Sales
            { SaleId = 11, CustomerId = 3, VehicleId = 100006, FinancingId = 3, UserId = "33333333-3333-3333-3333-333333333333", SaleAmount = 42000, SaleDate = DateTime.Parse("2018-02-25 00:00:00.0000000")},
            new Sales
            { SaleId = 12, CustomerId = 4, VehicleId = 100007, FinancingId = 2, UserId = "33333333-3333-3333-3333-333333333333", SaleAmount = 28000, SaleDate = DateTime.Parse("2018-07-25 00:00:00.0000000")},
            new Sales
            { SaleId = 13, CustomerId = 4, VehicleId = 100008, FinancingId = 2, UserId = "33333333-3333-3333-3333-333333333333", SaleAmount = 75000, SaleDate = DateTime.Parse("2018-04-25 00:00:00.0000000")}
        };


        public static List<SalesUserIdAndName> _Users = new List<SalesUserIdAndName>
        {
            new SalesUserIdAndName
                { UserId = "11111111-1111-1111-1111-111111111111", UserName = "Test Salesuser1" },
            new SalesUserIdAndName
                { UserId = "22222222-2222-2222-2222-222222222222", UserName = "Test Salesuser2" },
            new SalesUserIdAndName
                { UserId = "33333333-3333-3333-3333-333333333333", UserName = "Test Salesuser3" }
        };

        public void AddSale(Sales sale)
        {
            sale.SaleId = _Sales.Max(m => m.SaleId) + 1;
            _Sales.Add(sale);
        }

        public IEnumerable<Sales> GetAllSales()
        {
            List<Sales> list = new List<Sales>();

            foreach (var sale in _Sales)
            {
                Sales currentRow = new Sales();

                currentRow.SaleId = sale.SaleId;
                currentRow.CustomerId = sale.CustomerId;
                currentRow.VehicleId = sale.VehicleId;
                currentRow.FinancingId = sale.FinancingId;
                currentRow.UserId = sale.UserId;
                currentRow.SaleAmount = sale.SaleAmount;
                currentRow.SaleDate = sale.SaleDate;

                list.Add(currentRow);
            }
            return list;
        }

        public IEnumerable<SalesReport> GetSalesForReport(SalesReportSearchParameters parameters)
        {
            var fromDate = Convert.ToDateTime("01/01/2000");
            var toDate = Convert.ToDateTime("01/31/2999");

            if (!DateTime.TryParse(parameters.FromDate, out fromDate))
                fromDate = Convert.ToDateTime("01/01/2000");

            if (!DateTime.TryParse(parameters.ToDate, out toDate))
                toDate = Convert.ToDateTime("01/31/2999");

            if (string.IsNullOrEmpty(parameters.UserId))
            {
                var result = from s in _Sales
                             where s.SaleDate >= fromDate && s.SaleDate <= toDate
                             group s by new
                             {
                                 s.UserId

                             } into sr
                             select new SalesReport()
                             {
                                 UserId = sr.Key.UserId,
                                 UserName = _Users.FirstOrDefault(u => u.UserId == sr.Key.UserId).UserName,
                                 TotalSalesFormatted = sr.Sum(s => s.SaleAmount).ToString("c0"),
                                 TotalSales = sr.Sum(s => s.SaleAmount),
                                 TotalVehicles = sr.Count()
                             };

                var newInventoryReport = result.OrderByDescending(s => s.TotalSales);

                return newInventoryReport;
            }
            else
            {
                var result = from s in _Sales
                             where s.SaleDate >= fromDate && s.SaleDate <= toDate && s.UserId == parameters.UserId
                             group s by new
                             {
                                 s.UserId
                             } into sr
                             select new SalesReport()
                             {
                                 UserId = sr.Key.UserId,
                                 UserName = _Users.FirstOrDefault(u => u.UserId == sr.Key.UserId).UserName,
                                 TotalSalesFormatted = sr.Sum(s => s.SaleAmount).ToString("c0"),
                                 TotalSales = sr.Sum(s => s.SaleAmount),
                                 TotalVehicles = sr.Count()
                             };
                var newInventoryReport = result.OrderByDescending(s => s.TotalSales);

                return newInventoryReport;
            }
        }
    }
}
