using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Crypto.Generators;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

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
        [Required]
        [JsonIgnore]
        [Column("People_Password")]
        public string PasswordHash { get; set; } = string.Empty;

        // Это свойство используется для приёма открытого пароля от клиента, затем хешируется
        [NotMapped]
        public string Password
        {
            // Геттер возвращает пустую строку — нам не нужно отдавать пароль клиенту
            get => string.Empty;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(value);
                }
            }
        }

        [ForeignKey("Role")]
        [Column("People_Role_Id")]
        public int RoleId { get; set; }

        public Role? Role { get; set; }
    }
}
