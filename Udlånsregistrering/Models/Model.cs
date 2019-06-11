using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udlånsregistrering.Models
{
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model_Name { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
