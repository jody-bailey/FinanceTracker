using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Models
{
    [Table("Centers")]
    public class Center
    {
        [Key]
        public int CenterId { get; set; }
        [Index("IX_CenterName", IsUnique = true)]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
