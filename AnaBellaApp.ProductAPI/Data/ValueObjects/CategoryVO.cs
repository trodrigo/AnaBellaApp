using AnaBellaApp.ProductAPI.Model;

namespace AnaBellaApp.ProductAPI.Data.ValueObjects
{
    public class CategoryVO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
