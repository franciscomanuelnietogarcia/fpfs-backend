using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Entities
{
    public class UserItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Contraseña { get; set; }

        [Required]
        public string Rol { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderItem>? OrderItem { get; set; } //один пользователь может быть во многих заказах


    }
}
