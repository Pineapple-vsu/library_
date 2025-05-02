using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace library.Entity
{
    [Table("History")]
    public class History
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("BookCopy")]
        [Column("Copy_Id")]
        public int CopyId { get; set; }

        [Required]
        [ForeignKey("People")]
        [Column("People_Id")]
        public int PeopleId { get; set; }

        [Required]
        [Column("History_Start_Date")]
        public DateTime StartDate { get; set; }

        [Column("History_End_Date")]
        public DateTime EndDate { get; set; }

        [Column("Return_Date")]
        public DateTime? ReturnDate { get; set; }

        public BookCopy? Copy { get; set; }
        public People? People { get; set; }
    }
}
