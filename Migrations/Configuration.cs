namespace FinanceTracker.Migrations
{
    using FinanceTracker.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinanceTracker.Models.FinanceDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FinanceTracker.Models.FinanceDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            
            if (!context.Centers.Any())
            {
                List<Center> centers = new List<Center>();
                centers.Add(new Center { Name = "AFRC" });
                centers.Add(new Center { Name = "ARC" });
                centers.Add(new Center { Name = "GRC" });
                centers.Add(new Center { Name = "GSFC" });
                centers.Add(new Center { Name = "HQ" });
                centers.Add(new Center { Name = "JSC" });
                centers.Add(new Center { Name = "KSC" });
                centers.Add(new Center { Name = "LARC" });
                centers.Add(new Center { Name = "MSFC" });
                centers.Add(new Center { Name = "NSSC" });
                centers.Add(new Center { Name = "SSC" });
                centers.Add(new Center { Name = "UNKNOWN" });

                try
                {
                    foreach (var center in centers)
                    {
                        context.Centers.AddOrUpdate(center);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Employee employee = new Employee
            {
                FirstName = "Jody",
                LastName = "Bailey",
                CenterId = 10,
                SSN = "123-45-6789"
            };
            
            if (!context.Employees.Any())
            {
                try
                {
                    context.Employees.AddOrUpdate(employee);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            if (!context.Claims.Any())
            {
                try
                {
                    context.Claims.AddOrUpdate(new Claim
                    {
                        ReferenceNum = 6571354,
                        Employee = employee,
                        RequestType = "Initial Claim",
                        StatusDate = DateTime.Today,
                        ClaimDate = DateTime.Today,
                        WorkLocation = "WE9867234 - VA",
                        ClaimantLiable = true
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
