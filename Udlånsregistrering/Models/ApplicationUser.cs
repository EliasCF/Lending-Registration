using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udlånsregistrering.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string CPR_Number { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public bool Is_Blacklisted { get; set; }

        [ForeignKey("Class")]
        public int ClassId { get; set; }
        public Class Class { get; set; }
        
        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }

        [ForeignKey("Zip_Code")]
        public int Zip_CodeId { get; set; }
        public Zip_Code Zip_Code { get; set; }
    }
}
