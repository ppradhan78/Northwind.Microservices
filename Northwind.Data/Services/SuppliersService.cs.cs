using Northwind.Data.BusinessObject;
using Northwind.Data.DTOs;
using Northwind.Data.Infrastructure.Constants;
using Northwind.Data.Infrastructure.Validations;
using Northwind.Data.Models.Base;

namespace Northwind.Data.Services
{
    public class SuppliersService : ISuppliersService
    {
        #region Global Variable(s)
        ISuppliersBo _suppliersBo;
        #endregion
        public SuppliersService(ISuppliersBo suppliersBo)
        {
            _suppliersBo= suppliersBo;
        }
        public async Task<SupplierDto> GetByIdAsync(int Id)
        {
            Validations.ValidateId(Id, Messages.InputIdRequired);
            return await _suppliersBo.GetByIdAsync(Id);
        }

        public async Task<List<SupplierDto>> GetListAsync()
        {
            return await _suppliersBo.GetListAsync();
        }

        public async Task<BaseOutputModel> SaveAsync(SupplierDto Input)
        {
            ValidateSuppliersInsert(Input);
            return await _suppliersBo.SaveAsync(Input);
        }

        public async Task<BaseOutputModel> UpdateAsync(SupplierDto Input)
        {
            ValidateSuppliersUpdate(Input);
            return await _suppliersBo.UpdateAsync(Input);
        }

        private static void ValidateSuppliersInsert(SupplierDto Input)
        {
            Validations.ValidateIsNotNull(Input, Messages.InputDataRequired);

            Validations.ValidateText(Input.CompanyName, Messages.CompanyNameRequired);
        }
        private static void ValidateSuppliersUpdate(SupplierDto Input)
        {
            Validations.ValidateIsNotNull(Input, Messages.InputDataRequired);
            Validations.ValidateId(Input.SupplierID, Messages.InputIdRequired);
            Validations.ValidateText(Input.CompanyName, Messages.CompanyNameRequired);
        }
    }
}
