using CarMastery.UI.Models;
using CarMastery.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMastery.UI.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Inventory()
        {
            {
                var repo = InventoryRepositoryFactory.GetRepository();
                var model = new InventoryReportViewModel();

                model.NewInventoryReport = repo.CreateNewInventoryReport().ToList();
                model.UsedInventoryReport = repo.CreateUsedInventoryReport().ToList();

                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Sales()
        {
            var repo = UsersRepositoryFactory.GetRepository();

            return View(repo.GetAllSalesUsers());
        }
    }
}