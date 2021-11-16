using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Descrption { get; set; }

        #region Navigation properties
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Book> Books { get; set; }
        #endregion
    }

}
