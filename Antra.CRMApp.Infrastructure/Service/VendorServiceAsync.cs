using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
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

      
        public async Task<int> AddVendorAsync(VendorModel model)
        {
            Vendor ven = new Vendor();
            ven.Name = model.Name;
            ven.Country = model.Country;
            ven.Mobile = model.Mobile;
            ven.EmailId = model.EmailId;
            ven.Id = model.Id;
            ven.City = model.City;
            ven.IsActive = model.IsActive;
            

            return await vendorRepositoryAsync.InsertAsync(ven);
        }

        public async Task<IEnumerable<VendorModel>> GetAllAsync()
        {
            var collection = await vendorRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<VendorModel> vendorModels = new List<VendorModel>();
                foreach (var item in collection)
                {
                    VendorModel model = new VendorModel();
                    model.Name = item.Name;
                    model.Id = item.Id;
                    model.EmailId = item.EmailId;
                    model.City = item.City;
                    model.Country = item.Country;
                    model.IsActive = item.IsActive;
                    model.Mobile =  item.Mobile;
                    vendorModels.Add(model);
                }
                return vendorModels;
            }
            return null;
        }


        public async Task<VendorModel> GetVendorForEditAsync(int id)
        {
            var item = await vendorRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                VendorModel model = new VendorModel();
                model.Name = item.Name;
                model.Id = item.Id;
                model.EmailId = item.EmailId;
                model.City = item.City;
                model.Country = item.Country;
                model.IsActive = item.IsActive;
                model.Mobile = item.Mobile;
                return model;
            }
            return null;
        }

        public async Task<VendorModel> GetByIdAsync(int id)
        {
            var item = await vendorRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                VendorModel model = new VendorModel();
                model.Name = item.Name;
                model.Id = item.Id;
                model.EmailId = item.EmailId;
                model.City = item.City;
                model.Country = item.Country;
                model.IsActive = item.IsActive;
                model.Mobile = item.Mobile;
                return model;
            }
            return null;
        }
        public async Task<int> DeleteVendorAsync(int id)
        {
            return await vendorRepositoryAsync.DeleteAsync(id);
        }

        public async Task<int> UpdateVendorAsync(VendorModel model)
        {
            Vendor ven = new Vendor();
            ven.Name = model.Name;
            ven.Country = model.Country;
            ven.Mobile = model.Mobile;
            ven.EmailId = model.EmailId;
            ven.Id = model.Id;
            ven.City = model.City;
            ven.IsActive = model.IsActive;
            return await vendorRepositoryAsync.UpdateAsync(ven);
        }
    }
}