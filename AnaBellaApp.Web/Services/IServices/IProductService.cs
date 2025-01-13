﻿using AnaBellaApp.Web.Models.Store;

namespace AnaBellaApp.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> FindAllProducts();
        Task<ProductViewModel> FindProductById(long id);
        Task<ProductViewModel> CreateProduct(ProductViewModel model);
        Task<ProductViewModel> UpdateProduct(ProductViewModel model);
        Task<bool> DeleteProductById(long id);
    }
}
