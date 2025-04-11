using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library.Entity
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Column("Book_Name")]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Isbn { get; set; } = string.Empty;
        [Required]
        public string Genre { get; set; } = string.Empty;
        [Required]
        [Column("Book_Description")]
        public string Description { get; set; } = string.Empty;
    }
}
