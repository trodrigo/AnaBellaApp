﻿namespace AnaBellaApp.Web.Models.Store
{
    public class CategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProductViewModel> Products { get; set; }
    }
}
