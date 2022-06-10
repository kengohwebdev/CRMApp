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
        Task<IEnumerable<VendorModel>> GetAllAsync();
        Task<int> AddVendorAsync(VendorModel model);
    }
}
