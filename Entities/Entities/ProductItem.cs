using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Entities.Entities
{
    public class ProductItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [Required]
        public string? CourseName { get; set; }
        public string? CourseTeacher { get; set; }

        [Required]
        public int CourseTime { get; set; }
        public string? CoverURL { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProductOrder>? ProductOrder { get; set; }

    }

}
