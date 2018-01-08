namespace Library.Migrations.ApplicationUsersMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"ApplicationUsersMigrations";
        }

        protected override void Seed(Library.Models.ApplicationDbContext context)
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

            var manager =
              new UserManager<ApplicationUser>(
                  new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            //create roles
            roleManager.Create(new IdentityRole { Name = "Librarian" });
            roleManager.Create(new IdentityRole { Name = "Member" });

            //seeding two applicationUsers
            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {
                UserName = "einstein.albert@itsligo.ie",
                Email = "einstein.albert@itsligo.ie",
                PasswordHash = new PasswordHasher().HashPassword("ITSligo$1")
            });

            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {
                UserName = "blogs.joe@itsligo.ie",
                Email = "blogs.joe@itsligo.ie",
                PasswordHash = new PasswordHasher().HashPassword("ITSligo$2")
            });

            //asign roles to users
            ApplicationUser librarian = manager.FindByEmail("einstein.albert@itsligo.ie");
            if (librarian != null)
            {
                manager.AddToRoles(librarian.Id, new string[] { "Librarian" });
            }
            else
            {
                throw new Exception { Source = "Did not find user" };
            }

            ApplicationUser member = manager.FindByEmail("blogs.joe@itsligo.ie");
            if (member != null)
            {
                manager.AddToRoles(member.Id, new string[] { "Member" });
            }
            else
            {
                throw new Exception { Source = "Did not find user" };
            }
        }
    }
}
