using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Import Maps
            CreateMap<ImportSuppliersDTO, Supplier>();
            CreateMap<ImportPartsDTO, Part>();
            CreateMap<ImportCustomersDTO, Customer>();
            CreateMap<ImportCarsDTO, Car>();
            CreateMap<ImportSalesDTO, Sale>();

            //Export Maps
            CreateMap<Car, ExportCarsWhitDistance>();
            CreateMap<Car, ExportCarsFromMakeBMW>();
            CreateMap<Supplier, ExportLocalSuppliers>()
                .ForMember(d => d.PartsCount, opt =>
                opt.MapFrom(s => s.Parts.Count));
            CreateMap<Car, ExportCarsWhitParts>()
             .ForMember(d => d.CarParts, opt =>
                opt.MapFrom(s => s.PartsCars
                    .Select(pc => pc.Part)
                    .OrderByDescending(p => p.Price)
                    .ToArray()));
            CreateMap<Part, ExportPartsForCars>();
            CreateMap<Customer, ExportTotalSalesBuCustomer>()
                .ForMember(d => d.BoughtCars, opt =>
                opt.MapFrom(s => s.Sales.Any()));
                
        }
    }
}
