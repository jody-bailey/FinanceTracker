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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        [Required]
        public int ClaimId { get; set; }
        [ForeignKey("ClaimId")]
        public Claim Claim { get; set; }
        public DateTime DueDate { get; set; }
        public decimal AmountPaid { get; set; }
        public int Quarter { get; set; }

    }
}
