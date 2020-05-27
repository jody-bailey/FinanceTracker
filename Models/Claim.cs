using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Models
{
    [Table("Claims")]
    public class Claim
    {
        [Key]
        public int ClaimId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ReferenceNum { get; set; }
        public string RequestType { get; set; }
        public string WorkLocation { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime ClaimDate { get; set; }
        public bool ClaimantLiable { get; set; }

    }
}
