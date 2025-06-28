using AspNetCoreIQ2025.Data.SimpleModels;
using AutoMapper;
using Northwind.Data.DTOs;
using Northwind.Data.Entities;

namespace Northwind.Data.Mappers
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<SuppliersModel, SupplierDto>();
            CreateMap<SupplierDto, SuppliersModel>();
            CreateMap<Suppliers, SupplierDto>();
            CreateMap<SupplierDto, Suppliers>();
        }
    }
}
