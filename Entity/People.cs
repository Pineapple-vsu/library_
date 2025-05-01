using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace library.Entity
{
    public class People
    {

        [Required]
        public int Id { get; set; }
        [Required]
        [Column("People_Name")]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        [Column("People_Address")]
        public string Address { get; set; } = string.Empty;

        [ForeignKey("Role")]
        [Column("People_Role_Id")]
        public int RoleId { get; set; }

        public Role? Role { get; set; }
    }
}
