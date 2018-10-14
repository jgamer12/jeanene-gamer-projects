using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarMastery.UI.Models.Identity
{
    public class GuildCarsDbContext : IdentityDbContext<AppUser>
    {
        public GuildCarsDbContext() : base("DefaultConnection")
        {

        }
    }
}