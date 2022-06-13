using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Contract.Service
{
    public interface IVendorServiceAsync
    {
        Task<IEnumerable<VendorResponseModel>> GetAllAsync();
        Task<int> AddVendorAsync(VendorRequestModel vendor);
        Task<VendorResponseModel> GetByIdAsync(int id);
        Task<VendorRequestModel> GetVendorForEditAsync(int id);
        Task<int> UpdateVendorAsync(VendorRequestModel vendor);
        Task<int> DeleteVendorAsync(int id);
    }
}
