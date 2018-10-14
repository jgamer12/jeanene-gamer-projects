using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CarMastery.UI.Models;
using CarMastery.UI.Models.Identity;
using CarMastery.Data.Factories;
using System.Net;

namespace CarMastery.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            var usersRepo = UsersRepositoryFactory.GetRepository();
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            // attempt to load the user with this password
            AppUser user = userManager.Find(model.UserName, model.Password);

            // user will be null if the password or user name is bad
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");

                return View(model);
            }
            else if (usersRepo.GetUserById(user.Id).Role == "Disabled")
            {
                ModelState.AddModelError("", "Your account has been disabled.  Please contact your system administrator.");

                return View(model);
            }
            else
            {
                // successful login, set up their cookies and send them on their way
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);

                return RedirectToAction("Index", "Home");
            }
        }

        //
        // GET: /Manage/ChangePassword
        [Authorize(Roles = "Admin,Sales")]
        public ActionResult ChangePassword()
        {
            var model = new ChangePasswordViewModel();

            return View(model);
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles ="Admin,Sales")]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            var usersRepo = UsersRepositoryFactory.GetRepository();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
                var user = userManager.FindByEmail(User.Identity.Name);

                if (model.NewPassword != null)
                {
                    user.PasswordHash = userManager.PasswordHasher.HashPassword(model.NewPassword);
                    var passwordResult = userManager.Update(user);
                    if (!passwordResult.Succeeded)
                        AddErrors(passwordResult);
                    else
                        RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }


        //
        //POST /Account/Logoff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
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