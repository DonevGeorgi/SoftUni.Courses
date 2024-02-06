using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<ImportUserDTO, User>();
            CreateMap<ImportProductDTO, Product>();
            CreateMap<ImportCategoryDTO, Category>();
            CreateMap<ImportCategoriesProductsDTO, CategoryProduct>();
            CreateMap<Product, ExportProducttInRange>()
            .ForMember(d => d.BuyerName,
                        opt => opt.MapFrom(s => $"{s.Buyer.FirstName} {s.Buyer.LastName}"));
        }
    }
}
