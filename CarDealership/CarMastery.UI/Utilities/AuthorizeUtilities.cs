using CarMastery.UI.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMastery.UI.Utilities
{
    public class AuthorizeUtilities
    {
        public static string GetUserId(Controller controller)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(new GuildCarsDbContext()));
            var user = userMgr.FindByName(controller.User.Identity.Name);
            return user.Id;
        }
    }
}