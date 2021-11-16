using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.ViewModels.Author
{
    public class SaveAuthorViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [StringLength(50)]
        public string Name { get; set; }

    }
}
