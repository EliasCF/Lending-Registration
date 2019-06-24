using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udlånsregistrering.Models
{
    public class Computer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Computer_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("Mouse")]
        public int MouseId { get; set; }
        public Mouse Mouse { get; set; }

        [ForeignKey("Model")]
        public int ModelId { get; set; }
        public Model Model { get; set; }
    }
}
