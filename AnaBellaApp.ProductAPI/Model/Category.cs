using AnaBellaApp.ProductAPI.Model.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnaBellaApp.ProductAPI.Model
{
    [Table("category")]
    public class Category : BaseEntity
    {
        public Category() {}

        public Category(string name, string description = "")
        {
            this.Name = name;
            this.Description = description;
        }

        [Column("name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column("description")]
        [StringLength(500)]
        public string? Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
