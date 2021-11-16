using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.ViewModels.Category
{
    public class SaveCategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public SelectList SubCategories { get; set; }
    }
}
