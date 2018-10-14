namespace CarMastery.UI.Migrations
{
    using CarMastery.UI.Models.Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarMastery.UI.Models.Identity.GuildCarsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarMastery.UI.Models.Identity.GuildCarsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Load the user and role managers with our custom models
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            // Have we loaded roles already?
            if (roleMgr.RoleExists("Admin"))
                return;
            if (roleMgr.RoleExists("Sales"))
                return;
            if (roleMgr.RoleExists("Disabled"))
                return;

            // Create the new roles
            roleMgr.Create(new AppRole() { Name = "Admin" });
            roleMgr.Create(new AppRole() { Name = "Sales" });
            roleMgr.Create(new AppRole() { Name = "Disabled" });

            // Create the default user
            var user1 = new AppUser()
            {
                FirstName = "Test",
                LastName = "Adminseed",
                Email = "adminseed@test.com",
                UserName = "adminseed@test.com"
            };

            var user2 = new AppUser()
            {
                FirstName = "Test",
                LastName = "Salesseed",
                Email = "salesseed@test.com",
                UserName = "salesseed@test.com"
            };

            // Create the user with the manager class
            userMgr.Create(user1, "testing123!");
            userMgr.Create(user2, "testing123!");

            // Add the user to the appropriate role
            userMgr.AddToRole(user1.Id, "Admin");
            userMgr.AddToRole(user2.Id, "Sales");

        }
    }
}
