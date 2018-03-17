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
        public string Plate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Company { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }
    }
}
