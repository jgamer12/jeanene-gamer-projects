using CarMastery.Data.Factories;
using CarMastery.Models.Tables;
using CarMastery.UI.Models;
using CarMastery.UI.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMastery.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {

            var model = new HomeIndexViewModel();

            var repo1 = SpecialsRepositoryFactory.GetRepository();
            var repo2 = InventoryRepositoryFactory.GetRepository();

            model.SpecialsList = repo1.GetAllSpecials().ToList();
            model.FeaturedVehicles = repo2.GetFeaturedVehicles().ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Specials()
        {
            var model = SpecialsRepositoryFactory.GetRepository().GetAllSpecials();
            return View(model);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            var model = new ContactViewModel();
            var repo = ContactUsRepositoryFactory.GetRepository();

            model.ContactToAdd = new ContactUs();
            if (TempData["VIN"] != null)
                model.ContactToAdd.ContactUsMessage = "VIN #:  " + TempData["VIN"].ToString();
            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = ContactUsRepositoryFactory.GetRepository();

                try
                {
                    repo.AddContact(model.ContactToAdd);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return View(model);
            }
        }



    }
}