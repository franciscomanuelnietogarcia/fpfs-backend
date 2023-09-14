using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Entities.Entities
{
    public class ProductOrder
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Products")]
        public int CourseId { get; set; }

        [JsonIgnore]
        public virtual ProductItem Products { get; set; }

        [ForeignKey("Orders")]
        public int OrderId { get; set; }

        [JsonIgnore]
        public virtual OrderItem Orders { get; set; }





    }
}
