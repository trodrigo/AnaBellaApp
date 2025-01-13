﻿namespace AnaBellaApp.Web.Models.Store
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public string ImageURL { get; set; }
    }
}
