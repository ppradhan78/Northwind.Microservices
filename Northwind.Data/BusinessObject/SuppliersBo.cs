using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Northwind.Data.Data;
using Northwind.Data.DTOs;
using Northwind.Data.Entities;
using Northwind.Data.Infrastructure.Constants;
using Northwind.Data.Models.Base;

namespace Northwind.Data.BusinessObject
{
    public class SuppliersBo : ISuppliersBo
    {
        #region Global Variable(s)
        private readonly ApplicationDbContext _ctx;
        private IMapper _mappr;
        #endregion

        public SuppliersBo(ApplicationDbContext ctx, IMapper mappr)
        {
            _ctx = ctx;
            _mappr = mappr;
        }
        public async Task<SupplierDto> GetByIdAsync(int Id)
        {
            var output = await _ctx.Suppliers.FirstOrDefaultAsync(x => x.SupplierID == Id);
            return _mappr.Map<SupplierDto>(output);
        }

        public async Task<List<SupplierDto>> GetListAsync()
        {
            var output = await _ctx.Suppliers.ToListAsync();
            return _mappr.Map<List<SupplierDto>>(output);
        }

        public async Task<BaseOutputModel> SaveAsync(SupplierDto Input)
        {
           var save= _mappr.Map<Suppliers>(Input);
            _ctx.Suppliers.Add(save);
            await _ctx.SaveChangesAsync();
            return new BaseOutputModel { IsSuccess = true, Message =  Messages.SuppliersSave };
        }

        public async Task<BaseOutputModel> UpdateAsync(SupplierDto Input)
        {
            var output = await _ctx.Suppliers.FirstOrDefaultAsync(x => x.SupplierID == Input.SupplierID);
            if (output != null)
            {
                output.Address = Input.Address;
                output.Phone = Input.Phone;
                output.Fax = Input.Fax;
                output.City = Input.City;
                output.Region = Input.Region;
                output.CompanyName = Input.CompanyName;
                output.ContactName = Input.ContactName;
                output.ContactTitle = Input.ContactTitle;
                output.HomePage = Input.HomePage;
                output.Country = Input.Country;
                output.PostalCode = Input.PostalCode;
                await _ctx.SaveChangesAsync();
                return new BaseOutputModel { IsSuccess = true, Message = Messages.SuppliersUpdate };
            }
            return new BaseOutputModel
            {
                IsSuccess = false,
                Message = $"Supplier with ID {Input.SupplierID} not found.",
            };

        }
    }
}
