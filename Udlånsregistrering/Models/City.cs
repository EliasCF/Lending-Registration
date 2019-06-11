using System.ComponentModel.DataAnnotations;

namespace Udlånsregistrering.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string City_Name { get; set; }
    }
}
