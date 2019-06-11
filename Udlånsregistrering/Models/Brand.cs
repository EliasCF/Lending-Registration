using System.ComponentModel.DataAnnotations;

namespace Udlånsregistrering.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Brand_Name { get; set; }
    }
}
