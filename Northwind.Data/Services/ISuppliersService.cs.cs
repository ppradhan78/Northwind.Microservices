using Northwind.Data.DTOs;
using Northwind.Data.Models.Base;

namespace Northwind.Data.Services
{
    public interface ISuppliersService
    {
        public Task<List<SupplierDto>> GetListAsync();
        public Task<SupplierDto> GetByIdAsync(int Id);
        public Task<BaseOutputModel> SaveAsync(SupplierDto Input);
        public Task<BaseOutputModel> UpdateAsync(SupplierDto Input);
    }
}
