using FinanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.DataAccess
{
    public class DBHelper
    {
        public static bool Insert<T>(T item) where T : class
        {
            bool result = false;

            using (FinanceDBContext context = new FinanceDBContext())
            {
                try
                {
                    context.Set<T>().Add(item);
                    int numRows = context.SaveChanges();
                    result = numRows > 0 ? true : false;
                } catch (Exception ex)
                {
                    result = false;
                    Console.WriteLine(ex.Message);
                }
                
            }

            return result;
        }

        public static bool InsertClaim(Claim claim)
        {
            bool result = false;

            using (var db = new FinanceDBContext())
            {
                claim.EmployeeId = claim.Employee.EmployeeId;
                claim.Employee = null;
                db.Claims.Add(claim);
                int numRows = db.SaveChanges();
                if (numRows > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool InsertEmployee(Employee employee)
        {
            bool result = false;

            using (var db = new FinanceDBContext())
            {
                employee.Center = null;
                db.Employees.Add(employee);
                int numRows = db.SaveChanges();

                if (numRows > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool Delete<T>(T item) where T : class
        {
            bool result = false;

            using (FinanceDBContext context = new FinanceDBContext())
            {
                try
                {
                    context.Set<T>().Remove(item);
                    int numRows = context.SaveChanges();
                    result = numRows > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    result = false;
                    Console.WriteLine(ex.Message);
                }

            }

            return result;
        }

        public static void UpdateClaim(Claim claim)
        {
            using (FinanceDBContext db = new FinanceDBContext())
            {
                try
                {
                    Claim oldClaim = db.Claims.SingleOrDefault(c => c.ClaimId == claim.ClaimId);
                    if (oldClaim != null)
                    {
                        oldClaim.ClaimantLiable = claim.ClaimantLiable;
                        oldClaim.ClaimDate = claim.ClaimDate;
                        oldClaim.EmployeeId = claim.EmployeeId;
                        oldClaim.ReferenceNum = claim.ReferenceNum;
                        oldClaim.RequestType = claim.RequestType;
                        oldClaim.StatusDate = claim.StatusDate;
                        oldClaim.WorkLocation = claim.WorkLocation;
                        UpdateEmployee(claim.Employee);
                        db.SaveChanges();
                    } else
                    {
                        InsertEmployee(claim.Employee);
                        InsertClaim(claim);
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }

        public static void UpdateEmployee(Employee employee)
        {
            using (FinanceDBContext db = new FinanceDBContext())
            {
                try
                {
                    Employee oldEmployee = db.Employees.SingleOrDefault(e => e.EmployeeId == employee.EmployeeId);
                    if (oldEmployee != null)
                    {
                        oldEmployee.EmployeeId = employee.EmployeeId;
                        oldEmployee.CenterId = employee.CenterId;
                        oldEmployee.FirstName = employee.FirstName;
                        oldEmployee.LastName = employee.LastName;
                        oldEmployee.SSN = employee.SSN;
                        db.SaveChanges();
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static List<Claim> GetClaims()
        {
            List<Claim> claims = new List<Claim>();

            using (FinanceDBContext db = new FinanceDBContext())
            {
                try
                {
                    claims = db.Claims.Include("Employee").ToList();
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return claims;
        }

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (FinanceDBContext db = new FinanceDBContext())
            {
                try
                {
                    employees = db.Employees.Include("Center").ToList();
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return employees;
        }

        public static List<Payment> GetPayments()
        {
            List<Payment> payments = new List<Payment>();

            using (FinanceDBContext db = new FinanceDBContext())
            {
                try
                {
                    payments = db.Payments.Include("Claim.Employee").ToList();
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return payments;
        }

        public static void UpdatePayment(Payment payment)
        {
            using (FinanceDBContext db = new FinanceDBContext())
            {
                Payment oldPayment = db.Payments.SingleOrDefault(p => p.PaymentId == payment.PaymentId);

                if (oldPayment != null)
                {
                    oldPayment.PaymentId = payment.PaymentId;
                    oldPayment.ClaimId = payment.ClaimId;
                    oldPayment.DueDate = payment.DueDate;
                    oldPayment.Quarter = payment.Quarter;
                    oldPayment.AmountPaid = payment.AmountPaid;
                }
            }
        }

        public static List<Center> GetCenters()
        {
            List<Center> centers = new List<Center>();

            using (var db = new FinanceDBContext())
            {
                centers.AddRange(db.Centers.ToList());
            }

            return centers;
        }
    }
}
