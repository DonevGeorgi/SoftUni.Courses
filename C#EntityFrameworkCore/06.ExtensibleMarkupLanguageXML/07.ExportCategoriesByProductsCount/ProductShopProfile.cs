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
            CreateMap<User, ExportedSoldProducts>();
            CreateMap<Product, ExportProductNamePrice>();
            CreateMap<Category, ExportCategoryByProductsCount>()
                .ForMember(c => c.Count, mf => mf.MapFrom(c => c.CategoryProducts.Count()))
                .ForMember(ap => ap.AveragePrice,mf => mf.MapFrom(c => c.CategoryProducts.Average(x => x.Product.Price)))
                .ForMember(tr => tr.TotalRevenue,mf => mf.MapFrom(c => c.CategoryProducts.Sum(x => x.Product.Price)));
        }
    }
}
