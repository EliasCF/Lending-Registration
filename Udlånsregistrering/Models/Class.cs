using System.ComponentModel.DataAnnotations;

namespace Udlånsregistrering.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Class_Name { get; set; }
    }
}
