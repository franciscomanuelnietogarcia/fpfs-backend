using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateExpiration { get; set; }
        public int TotalPrice { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual UserItem Users { get; set; }
        public virtual ICollection<ProductOrder>? ProductOrder { get; set; }
        

    }
}
