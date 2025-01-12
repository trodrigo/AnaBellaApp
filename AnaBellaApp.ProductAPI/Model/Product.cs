using AnaBellaApp.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnaBellaApp.ProductAPI.Model
{
    [Table("product")]
    public class Product : BaseEntity
    {
        public Product() {}

        public Product(string name, decimal price, long categoryId)
        {
            this.Name = name;
            this.Price = price;
            this.CategoryId = categoryId;
        }

        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column("price")]
        [Required]
        [Range(1,10000)]
        public decimal Price { get; set; }

        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }

        // Foreign key for Category
        [Column ("category_id")]
        public long CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Column("image_url")]
        [StringLength(300)]
        public string? ImageURL { get; set; }
    }
}
