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
        public Genre Genre { get; set; } 
        [Required]
        [Column("Book_Description")]
        public string Description { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
    }
}
