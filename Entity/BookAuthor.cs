using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace library.Entity
{
    [Table("Book_Author")]
    public class BookAuthor
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Book")]
        [Column("Book_Id")]
        public int BookId { get; set; }

        [Required]
        [ForeignKey("Author")]
        [Column("Author_Id")]
        public int AuthorId { get; set; }

        public Book? Book { get; set; }
        public Author? Author { get; set; }
    }
}
