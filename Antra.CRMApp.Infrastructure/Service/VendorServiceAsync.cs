using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Infrastructure.Service
{
    public class VendorServiceAsync : IVendorServiceAsync
    {
        private readonly IVendorRepositoryAsync vendorRepositoryAsync;
        public VendorServiceAsync(IVendorRepositoryAsync _vendorRepositoryAsync)
        {
            vendorRepositoryAsync = _vendorRepositoryAsync;
        }

        
    }
}
