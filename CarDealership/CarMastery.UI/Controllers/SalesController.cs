using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarMastery.Data.Factories;
using CarMastery.Models.Queries;
using CarMastery.Models.Tables;
using CarMastery.UI.Models;
using CarMastery.UI.Utilities;

namespace CarMastery.UI.Controllers
{
    [Authorize(Roles = "Sales")]
    public class SalesController : Controller
    {
        // GET: Sales
        [HttpGet]
        public ActionResult Index()
        {
            var model = new InventoryQueryViewModel();

            model.MinPriceSelectList = Utilities.PriceDropDownListUtility.PriceDropDownList();
            model.MaxPriceSelectList = Utilities.PriceDropDownListUtility.PriceDropDownList();
            model.MinYearSelectList = Utilities.YearDropDownListUtility.YearDropDownList();
            model.MaxYearSelectList = Utilities.YearDropDownListUtility.YearDropDownList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Purchase(int id)
        {
            var model = new PurchaseVehicleViewModel();
            var inventoryRepo = InventoryRepositoryFactory.GetRepository();
            var statesRepo = StatesRepositoryFactory.GetRepository();
            var financingRepo = FinancingRepositoryFactory.GetRepository();

            model.Vehicle = inventoryRepo.GetVehicleDetails(id);
            model.Customer = new Customers();
            model.Sale = new Sales();
            model.States = new SelectList(statesRepo.GetAllStates(), "StateId", "StateId");
            model.Financing = new SelectList(financingRepo.GetAllFinancing(), "FinancingId", "FinancingDescription");

            return View(model);
        }

        [HttpPost]
        public ActionResult Purchase(PurchaseVehicleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = VehicleRepositoryFactory.GetRepository();
                var customerRepo = CustomersRepositoryFactory.GetRepository();
                var salesRepo = SalesRepositoryFactory.GetRepository();
                var vehiclesRepo = VehicleRepositoryFactory.GetRepository();

                Vehicles vehicleToEdit = new Vehicles();

                try
                {
                    customerRepo.AddCustomer(model.Customer);

                    Sales addSale = new Sales();
                    addSale.CustomerId = model.Customer.CustomerId;
                    addSale.VehicleId = model.Vehicle.VehicleId;
                    addSale.FinancingId = model.Sale.FinancingId;
                    addSale.UserId = AuthorizeUtilities.GetUserId(this);
                    addSale.SaleAmount = model.Sale.SaleAmount;                    
                    addSale.SaleDate = DateTime.Now;

                    salesRepo.AddSale(addSale);

                    vehicleToEdit = vehiclesRepo.SelectVehicle(model.Vehicle.VehicleId);
                    vehicleToEdit.VehicleIsFeatured = false;
                    vehiclesRepo.UpdateVehicle(vehicleToEdit);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var inventoryRepo = InventoryRepositoryFactory.GetRepository();
                var statesRepo = StatesRepositoryFactory.GetRepository();
                var financingRepo = FinancingRepositoryFactory.GetRepository();

                model.Vehicle = inventoryRepo.GetVehicleDetails(model.Vehicle.VehicleId);
                model.States = new SelectList(statesRepo.GetAllStates(), "StateId", "StateId");
                model.Financing = new SelectList(financingRepo.GetAllFinancing(), "FinancingId", "FinancingDescription");

                return View(model);
            }
        }
    }
}