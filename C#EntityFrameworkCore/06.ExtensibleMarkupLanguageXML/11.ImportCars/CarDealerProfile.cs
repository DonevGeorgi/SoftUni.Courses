using AutoMapper;
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
            CreateMap<ImportCustomersDTO,Customer>();
            CreateMap<ImportCarsDTO, Car>();
        }
    }
}
