using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tamirhane.Core.Models
{
    public class Car : GenericTable
    {
        /// <summary>
        /// Client Information
        /// </summary>
        [Required]
        public virtual User User { get; set; }

        /// <summary>
        /// Car Information
        /// </summary>
        [Required]
        [MaxLength(15)]
        [DisplayName("Plaka")]
        public string Plate { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Marka")]
        public string Company { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        [DisplayName("Yıl")]
        public int Year { get; set; }
    }
}
