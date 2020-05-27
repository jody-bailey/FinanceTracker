using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CenterId { get; set; }
        public Center Center { get; set; }
        public string SSN { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
            set
            {
                string name = value.Trim();
                string[] nameParts = name.Split(' ');
                string firstName = "";
                string lastName = "";

                if (nameParts.Length > 0)
                {
                    firstName = nameParts[0];
                    lastName = "";
                    for (var i = 1; i < nameParts.Length; i++)
                    {
                        if (i == nameParts.Length-1)
                        {
                            lastName += nameParts[i];
                        } else
                        {
                            lastName += nameParts[i] + " ";
                        }
                        
                    }
                }

                FirstName = firstName;
                LastName = lastName;
                
            }
        }
    }
}
