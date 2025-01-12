using AutoMapper;
using AnaBellaApp.ProductAPI.Data.ValueObjects;
using AnaBellaApp.ProductAPI.Model;

namespace AnaBellaApp.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
                config.CreateMap<CategoryVO, Category>();
                config.CreateMap<Category, CategoryVO>();
            });
            return mappingConfig;
        }
    }
}
