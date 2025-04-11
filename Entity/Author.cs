using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library.Entity
{
    public class Author
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Column("Author_Name")]
        public string Name { get; set; } = string.Empty;
    }
}
