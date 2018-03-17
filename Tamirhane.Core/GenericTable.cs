using System;
using System.ComponentModel.DataAnnotations;

namespace Tamirhane.Core
{
    public class GenericTable
    {
        /// <summary>
        /// private variables for creation and modification time
        /// </summary>
        private DateTime? dateCreated = null;
        private DateTime? dateModified = null;

        /// <summary>
        /// primary key
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Creation Time
        /// </summary>
        [Required]
        public DateTime DateCreated
        {
            get
            {
                return dateCreated.HasValue
                   ? dateCreated.Value
                   : DateTime.Now;
            }

            set { dateCreated = value; }
        }

        /// <summary>
        /// Modification Time
        /// </summary>
        [Required]
        public DateTime DateModified
        {
            get
            {
                return dateModified.HasValue
                   ? dateModified.Value
                   : DateTime.Now;
            }

            set { dateModified = value; }
        }
    }
}