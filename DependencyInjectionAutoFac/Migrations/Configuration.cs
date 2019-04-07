namespace DependencyInjectionAutoFac.Migrations
{
    using DependencyInjectionAutoFac.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DependencyInjectionAutoFac.Models.DependencyInjectionAutoFacContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DependencyInjectionAutoFac.Models.DependencyInjectionAutoFacContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Users.AddOrUpdate(
              p => p.UserName,
              new User
              {
                  UserName = "sdhakal",
                  Password = "12345678",
                  FirstName = "Suman",
                  LastName = "Dhakal",
                  About = "Hello, I am Suman Dhakal!",
                  RememberMe = true,
                  Gender = "Male"
              });

        }
    }
}
