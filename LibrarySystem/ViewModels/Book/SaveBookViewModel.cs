using LibrarySystem.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.ViewModels.Book
{
    public class SaveBookViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 1")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Author")]
        public int AuthorId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "SubCategory")]
        public int SubCategoryId { get; set; }

        public SelectList Authors { get; set; }
        public SelectList Categories { get; set; }
        public SelectList SubCategories { get; set; }
    }
}
