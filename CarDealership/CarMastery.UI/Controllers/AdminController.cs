using CarMastery.Data.Factories;
using CarMastery.Models.Queries;
using CarMastery.Models.Tables;
using CarMastery.UI.App_Start;
using CarMastery.UI.Models;
using CarMastery.UI.Models.Identity;
using CarMastery.UI.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static CarMastery.UI.App_Start.IdentityConfig;

namespace CarMastery.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Makes()
        {
            var model = new MakesViewModel();
            var repo = MakesRepositoryFactory.GetRepository();

            model.MakesList = repo.GetAllMakes().ToList();
            model.MakeToAdd = new Makes();
            return View(model);
        }

        [HttpPost]
        public ActionResult Makes(MakesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = MakesRepositoryFactory.GetRepository();

                try
                {
                    Makes make = new CarMastery.Models.Tables.Makes();
                    make.MakeDescription = model.MakeToAdd.MakeDescription;
                    make.UserId = AuthorizeUtilities.GetUserId(this);
                    make.MakeDateAdded = DateTime.Now;

                    repo.AddMake(make);

                    return RedirectToAction("Makes");
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

        [HttpGet]
        public ActionResult Models()
        {
            var model = new ModelsViewModel();
            var repo = ModelsRepositoryFactory.GetRepository();
            var makesRepo = MakesRepositoryFactory.GetRepository();

            model.ModelsList = repo.GetAllModels().ToList();
            model.ModelToAdd = new CarMastery.Models.Tables.Models();
            model.Makes = new SelectList(makesRepo.GetAllMakes(), "MakeId", "MakeDescription");

            return View(model);
        }

        [HttpPost]
        public ActionResult Models(ModelsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = ModelsRepositoryFactory.GetRepository();

                try
                {
                    CarMastery.Models.Tables.Models addModel = new CarMastery.Models.Tables.Models();
                    addModel.UserId = AuthorizeUtilities.GetUserId(this);
                    addModel.ModelDateAdded = DateTime.Now;
                    addModel.ModelDescription = model.ModelToAdd.ModelDescription;
                    addModel.MakeId = model.ModelToAdd.MakeId;

                    repo.AddModel(addModel);

                    return RedirectToAction("Models");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var makesRepo = MakesRepositoryFactory.GetRepository();
                model.Makes = new SelectList(makesRepo.GetAllMakes(), "MakeId", "MakeDescription");
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Specials()
        {
            {
                var repo = SpecialsRepositoryFactory.GetRepository();
                var model = new SpecialsViewModel();

                model.SpecialsList = repo.GetAllSpecials().ToList();
                model.SpecialToAdd = new Specials();

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Specials(SpecialsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = SpecialsRepositoryFactory.GetRepository();

                try
                {
                    Specials special = new Specials();
                    special.SpecialTitle = model.SpecialToAdd.SpecialTitle;
                    special.SpecialDescription = model.SpecialToAdd.SpecialDescription;

                    repo.AddSpecial(special);

                    return RedirectToAction("Specials");
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

        [HttpGet]
        public ActionResult DeleteSpecial(int id)
        {
            {
                var repo = SpecialsRepositoryFactory.GetRepository();

                Specials model = repo.GetSpecialById(id);

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult DeleteSpecial(Specials special)
        {
            if (ModelState.IsValid)
            {
                var repo = SpecialsRepositoryFactory.GetRepository();

                try
                {

                    repo.DeleteSpecial(special.SpecialId);

                    return RedirectToAction("Specials");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return RedirectToAction("Specials");
            }
        }

        [HttpGet]
        public ActionResult Users()
        {
            {
                var repo = UsersRepositoryFactory.GetRepository();
                var model = new UserReportViewModel();

                model.UsersReportList = repo.GetAllUsers().ToList();

                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Vehicles()
        {
            var model = new InventoryQueryViewModel();

            model.MinPriceSelectList = Utilities.PriceDropDownListUtility.PriceDropDownList();
            model.MaxPriceSelectList = Utilities.PriceDropDownListUtility.PriceDropDownList();
            model.MinYearSelectList = Utilities.YearDropDownListUtility.YearDropDownList();
            model.MaxYearSelectList = Utilities.YearDropDownListUtility.YearDropDownList();

            return View(model);
        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
            {
                var model = new AddVehiclesViewModel();
                var makesRepo = MakesRepositoryFactory.GetRepository();
                var modelsRepo = ModelsRepositoryFactory.GetRepository();
                var vehicleTypesRepo = VehicleTypesRepositoryFactory.GetRepository();
                var bodyStylesRepo = BodyStylesRepositoryFactory.GetRepository();
                var transmissionsRepo = TransmissionsRepositoryFactory.GetRepository();
                var bodyColorsRepo = BodyColorsRepositoryFactory.GetRepository();
                var interiorColorsRepo = InteriorColorsRepositoryFactory.GetRepository();

                model.Makes = makesRepo.GetAllMakes();
                model.VehicleType = new SelectList(vehicleTypesRepo.GetAllVehicleTypes(), "VehicleTypeId", "VehicleTypeDescription");
                model.BodyStyle = new SelectList(bodyStylesRepo.GetAllBodyStyles(), "BodyStyleId", "BodyStyleDescription");
                model.Transmission = new SelectList(transmissionsRepo.GetAllTransmissions(), "TransmissionId", "TransmissionDescription");
                model.BodyColor = new SelectList(bodyColorsRepo.GetAllBodyColors(), "BodyColorId", "BodyColorDescription");
                model.InteriorColor = new SelectList(interiorColorsRepo.GetAllInteriorColors(), "InteriorColorId", "InteriorColorDescription");
                model.VehicleToAdd = new Vehicles();

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult AddVehicle(AddVehiclesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = VehicleRepositoryFactory.GetRepository();

                try
                {
                    if (model.PictureUpload != null && model.PictureUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");
                        var nextId = repo.GetNextVehicleId().ToString();
                        var filePath = Path.Combine(savepath, "inventory-" + nextId + ".PNG");

                        model.PictureUpload.SaveAs(filePath);
                        model.VehicleToAdd.VehiclePicture = Path.GetFileName(filePath);
                    }

                    repo.AddVehicle(model.VehicleToAdd);

                    return RedirectToAction("EditVehicle", new { id = model.VehicleToAdd.VehicleId });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var makesRepo = MakesRepositoryFactory.GetRepository();
                var modelsRepo = ModelsRepositoryFactory.GetRepository();
                var vehicleTypesRepo = VehicleTypesRepositoryFactory.GetRepository();
                var bodyStylesRepo = BodyStylesRepositoryFactory.GetRepository();
                var transmissionsRepo = TransmissionsRepositoryFactory.GetRepository();
                var bodyColorsRepo = BodyColorsRepositoryFactory.GetRepository();
                var interiorColorsRepo = InteriorColorsRepositoryFactory.GetRepository();

                model.Makes = makesRepo.GetAllMakes();
                model.VehicleType = new SelectList(vehicleTypesRepo.GetAllVehicleTypes(), "VehicleTypeId", "VehicleTypeDescription");
                model.BodyStyle = new SelectList(bodyStylesRepo.GetAllBodyStyles(), "BodyStyleId", "BodyStyleDescription");
                model.Transmission = new SelectList(transmissionsRepo.GetAllTransmissions(), "TransmissionId", "TransmissionDescription");
                model.BodyColor = new SelectList(bodyColorsRepo.GetAllBodyColors(), "BodyColorId", "BodyColorDescription");
                model.InteriorColor = new SelectList(interiorColorsRepo.GetAllInteriorColors(), "InteriorColorId", "InteriorColorDescription");

                return View(model);
            }
        }

        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            {
                var model = new EditVehiclesViewModel();
                var vehiclesRepo = VehicleRepositoryFactory.GetRepository();
                var makesRepo = MakesRepositoryFactory.GetRepository();
                var modelsRepo = ModelsRepositoryFactory.GetRepository();
                var vehicleTypesRepo = VehicleTypesRepositoryFactory.GetRepository();
                var bodyStylesRepo = BodyStylesRepositoryFactory.GetRepository();
                var transmissionsRepo = TransmissionsRepositoryFactory.GetRepository();
                var bodyColorsRepo = BodyColorsRepositoryFactory.GetRepository();
                var interiorColorsRepo = InteriorColorsRepositoryFactory.GetRepository();

                model.VehicleToEdit = vehiclesRepo.SelectVehicle(id);
                model.Makes = makesRepo.GetAllMakes();
                model.SelectedMake = makesRepo.GetMakeForModel(model.VehicleToEdit.ModelId).MakeId;
                model.VehicleType = new SelectList(vehicleTypesRepo.GetAllVehicleTypes(), "VehicleTypeId", "VehicleTypeDescription");
                model.BodyStyle = new SelectList(bodyStylesRepo.GetAllBodyStyles(), "BodyStyleId", "BodyStyleDescription");
                model.Transmission = new SelectList(transmissionsRepo.GetAllTransmissions(), "TransmissionId", "TransmissionDescription");
                model.BodyColor = new SelectList(bodyColorsRepo.GetAllBodyColors(), "BodyColorId", "BodyColorDescription");
                model.InteriorColor = new SelectList(interiorColorsRepo.GetAllInteriorColors(), "InteriorColorId", "InteriorColorDescription");

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult EditVehicle(EditVehiclesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = VehicleRepositoryFactory.GetRepository();

                try
                {

                    var oldVehicle = repo.SelectVehicle(model.VehicleToEdit.VehicleId);
                    if (model.ReplacePicture != null && model.ReplacePicture.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");
                        var vehicleId = model.VehicleToEdit.VehicleId.ToString();
                        var filePath = Path.Combine(savepath, "inventory-" + vehicleId + ".PNG");

                        model.ReplacePicture.SaveAs(filePath);
                        model.VehicleToEdit.VehiclePicture = Path.GetFileName(filePath);
                    }
                    else
                    {
                        model.VehicleToEdit.VehiclePicture = oldVehicle.VehiclePicture;
                    }

                    repo.UpdateVehicle(model.VehicleToEdit);

                    return RedirectToAction("Vehicles");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var vehiclesRepo = VehicleRepositoryFactory.GetRepository();
                var makesRepo = MakesRepositoryFactory.GetRepository();
                var modelsRepo = ModelsRepositoryFactory.GetRepository();
                var vehicleTypesRepo = VehicleTypesRepositoryFactory.GetRepository();
                var bodyStylesRepo = BodyStylesRepositoryFactory.GetRepository();
                var transmissionsRepo = TransmissionsRepositoryFactory.GetRepository();
                var bodyColorsRepo = BodyColorsRepositoryFactory.GetRepository();
                var interiorColorsRepo = InteriorColorsRepositoryFactory.GetRepository();

                model.VehicleToEdit = vehiclesRepo.SelectVehicle(model.VehicleToEdit.VehicleId);
                model.Makes = makesRepo.GetAllMakes();
                model.VehicleType = new SelectList(vehicleTypesRepo.GetAllVehicleTypes(), "VehicleTypeId", "VehicleTypeDescription");
                model.BodyStyle = new SelectList(bodyStylesRepo.GetAllBodyStyles(), "BodyStyleId", "BodyStyleDescription");
                model.Transmission = new SelectList(transmissionsRepo.GetAllTransmissions(), "TransmissionId", "TransmissionDescription");
                model.BodyColor = new SelectList(bodyColorsRepo.GetAllBodyColors(), "BodyColorId", "BodyColorDescription");
                model.InteriorColor = new SelectList(interiorColorsRepo.GetAllInteriorColors(), "InteriorColorId", "InteriorColorDescription");

                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteVehicle(int id)
        {
            {
                var repo = VehicleRepositoryFactory.GetRepository();

                Vehicles model = repo.SelectVehicle(id);

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult DeleteVehicle(Vehicles vehicle)
        {
            if (ModelState.IsValid)
            {
                var repo = VehicleRepositoryFactory.GetRepository();

                try
                {

                    var savepath = Server.MapPath("~/Images");
                    var vehicleId = vehicle.VehicleId.ToString();
                    var filePath = Path.Combine(savepath, "inventory-" + vehicleId + ".PNG");
                    if (System.IO.File.Exists(filePath))
                        System.IO.File.Delete(filePath);

                    repo.DeleteVehicle(vehicle.VehicleId);

                    return RedirectToAction("Vehicles");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return RedirectToAction("Vehicles");
            }
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            {
                var model = new AddUserViewModel();
                var usersRepo = UsersRepositoryFactory.GetRepository();

                model.Roles = new SelectList(usersRepo.GetAllRoles(), "Id", "Name");

                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(AddUserViewModel model)
        {
            var usersRepo = UsersRepositoryFactory.GetRepository();

            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
                //var authManager = HttpContext.GetOwinContext().Authentication;


                var user = new AppUser { FirstName = model.FirstName, LastName = model.LastName, UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var currentUser = userManager.FindByName(user.UserName);
                    var selectedValue = usersRepo.GetRoleNameForId(model.SelectedRole).Name;

                    var roleresult = userManager.AddToRole(currentUser.Id, selectedValue);

                    return RedirectToAction("Users", "Admin");
                }
                AddErrors(result);
            }

            model.Roles = new SelectList(usersRepo.GetAllRoles(), "Id", "Name");
            return View(model);
        }

        [HttpGet]
        public ActionResult EditUser(string id)
        {
            {
                var model = new EditUserViewModel();
                var usersRepo = UsersRepositoryFactory.GetRepository();
                var userToEdit = usersRepo.GetUserById(id);

                model.FirstName = userToEdit.FirstName;
                model.LastName = userToEdit.LastName;
                model.Email = userToEdit.Email;
                model.SelectedRole = userToEdit.RoleId;
                model.Roles = new SelectList(usersRepo.GetAllRoles(), "Id", "Name", model.SelectedRole);
                model.UserId = id;
                model.OldRole = userToEdit.RoleId;

                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(EditUserViewModel model)
        {
            var usersRepo = UsersRepositoryFactory.GetRepository();

            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();

                var user = userManager.FindById(model.UserId);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.Email;
                user.Email = model.Email;

                var result = userManager.Update(user);

                if (result.Succeeded)
                {
                    if (model.OldRole != model.SelectedRole)
                    {
                        var oldSelectedValue = usersRepo.GetRoleNameForId(model.OldRole).Name;
                        userManager.RemoveFromRole(model.UserId, oldSelectedValue);

                        var selectedValue = usersRepo.GetRoleNameForId(model.SelectedRole).Name;
                        userManager.AddToRole(model.UserId, selectedValue);
                    }

                    if ( model.Password != null)
                    {
                        user.PasswordHash = userManager.PasswordHasher.HashPassword(model.Password);
                        var passwordResult = userManager.Update(user);
                        if (!passwordResult.Succeeded)
                            AddErrors(passwordResult);
                        else
                            RedirectToAction("Users", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Users", "Admin");
                    }
                    return RedirectToAction("Users", "Admin");
                }                
                AddErrors(result);
            }

            model.Roles = new SelectList(usersRepo.GetAllRoles(), "Id", "Name");
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}


