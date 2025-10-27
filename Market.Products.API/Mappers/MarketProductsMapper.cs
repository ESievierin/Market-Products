using AutoMapper;
using Market.Products.BLL.DTO;
using Market.Products.DAL.DbModels;

namespace Market.Products.API.Mappers
{
    public sealed class MarketProductsMapper : Profile
    {
        public MarketProductsMapper()
        {
            CreateMap<CategoryDbModel, CategoryDto>();
            CreateMap<ProductDbModel, ProductDto>().ReverseMap();
            CreateMap<ManufacturerDbModel, ManufacturerDto>();
            CreateMap<ProductDbModel, ShortProductDto>();
            CreateMap<CreateProductDto, ProductDto>();
        }
    }
}
