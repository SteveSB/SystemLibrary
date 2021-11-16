using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.ViewModels.SubCategory
{
    public class SaveSubCategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public SelectList Categories { get; set; }
    }
}
