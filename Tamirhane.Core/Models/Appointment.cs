using System;
using System.ComponentModel.DataAnnotations;

namespace Tamirhane.Core.Models
{
    public class Appointment : GenericTable
    {
        /// <summary>
        /// Car Information
        /// </summary>
        [Required]
        public virtual Car Car { get; set; }

        /// <summary>
        /// Appointment Time
        /// </summary>
        [Required]
        public DateTime DateTime { get; set; }
    }
}
