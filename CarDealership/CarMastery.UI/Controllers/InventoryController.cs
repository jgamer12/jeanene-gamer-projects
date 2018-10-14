using CarMastery.Data.Factories;
using CarMastery.Models.Queries;
using CarMastery.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMastery.UI.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        [HttpGet]
        public ActionResult New()
        {
            var model = new InventoryQueryViewModel();

            model.MinPriceSelectList = Utilities.PriceDropDownListUtility.PriceDropDownList();
            model.MaxPriceSelectList = Utilities.PriceDropDownListUtility.PriceDropDownList();
            model.MinYearSelectList = Utilities.YearDropDownListUtility.YearDropDownList();
            model.MaxYearSelectList = Utilities.YearDropDownListUtility.YearDropDownList();

            return View(model);             
        }

        [HttpGet]
        public ActionResult Used()
        {
            var model = new InventoryQueryViewModel();

            model.MinPriceSelectList = Utilities.PriceDropDownListUtility.PriceDropDownList();
            model.MaxPriceSelectList = Utilities.PriceDropDownListUtility.PriceDropDownList();
            model.MinYearSelectList = Utilities.YearDropDownListUtility.YearDropDownList();
            model.MaxYearSelectList = Utilities.YearDropDownListUtility.YearDropDownList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var repo = InventoryRepositoryFactory.GetRepository();
            VehicleSearchResult model = repo.GetVehicleDetails(id);

            TempData["VIN"] = model.VehicleVIN;

            return View(model);
        }

    }
}