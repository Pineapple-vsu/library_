using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library.Entity
{
    [Table("Book_Copy")]
    public class BookCopy
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Book")]
        [Column("Book_Id")]
        public int BookId { get; set; }

        [Required]
        [ForeignKey("Status")]
        [Column("Status_Id")]
        public int StatusId { get; set; }

        public Book? Book { get; set; }
        public BookStatus? Status { get; set; }
    }
}
