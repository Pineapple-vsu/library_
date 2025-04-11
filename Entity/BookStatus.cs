using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library.Entity
{
    [Table("Book_Status")]
    public class BookStatus
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Column("Status_Name")]
        public string Name { get; set; } = string.Empty;
    }
}
