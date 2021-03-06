using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Core.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        #region Navigation properties
        public ICollection<Book> Books { get; set; }
        #endregion
    }
}
