using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tamirhane.Core.Models
{
    public class User : GenericTable
    {
        [Required]
        [MaxLength(100)]
        [DisplayName("Ad")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Soyad")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Tel { get; set; }

    }
}