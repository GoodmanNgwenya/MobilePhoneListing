namespace MobilePhoneListing.Migrations.Identity
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MobilePhoneListing.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MobilePhoneListing.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Identity";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("Guest"))
                roleManager.Create(new IdentityRole("Guest"));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (userManager.FindByEmail("admin@mobilelisting.com") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "admin@mobilelisting.com",
                    UserName = "admin@mobilelisting.com",
                };
                var result = userManager.Create(user, "admin_123");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Admin");
            }

            if (userManager.FindByEmail("guest@mobilelisting.com") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "guest@mobilelisting.com",
                    UserName = "guest@mobilelisting.com",
                };
                var result = userManager.Create(user, "guest_123");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Guest");
            }
        }
    }
}
