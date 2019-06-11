using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Udlånsregistrering.Models
{
    public class Loaned_Computer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Computer")]
        public int ComputerId { get; set; }
        public Computer Computer { get; set; }

        [Required]
        public DateTime Loaned_Date { get; set; }

        [Required]
        public DateTime LoanExpiration_Date { get; set; }
    }
}
