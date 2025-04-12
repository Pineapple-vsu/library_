using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library.Entity
{
    [Table("People_Role")]
    public class Role
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Column("Role_Name")]
        public string Name { get; set; } = string.Empty;
    }
}
