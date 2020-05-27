using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Models
{
    [Table("Payments")]
    public class Payment
    {
        public int PaymentId { get; set; }
        public int ClaimId { get; set; }
        public Claim Claim { get; set; }
        public DateTime DueDate { get; set; }
        public decimal AmountPaid { get; set; }
        public int Quarter { get; set; }

    }
}
