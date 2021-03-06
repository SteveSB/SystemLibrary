using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Core.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        #region Navigation properties
        public ICollection<SubCategory> SubCategories { get; set; }
        #endregion
    }
}
