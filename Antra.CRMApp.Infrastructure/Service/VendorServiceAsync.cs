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
        private readonly IRegionRepositoryAsync regionRepositoryAsync;
        public VendorServiceAsync(IVendorRepositoryAsync _vendorRepositoryAsync, IRegionRepositoryAsync _regionRepositoryAsync)
        {
            vendorRepositoryAsync = _vendorRepositoryAsync;
            regionRepositoryAsync = _regionRepositoryAsync;
        }


        public async Task<int> AddVendorAsync(VendorRequestModel model)
        {
            Vendor ven = new Vendor();
            ven.Name = model.Name;
            ven.Country = model.Country;
            ven.Mobile = model.Mobile;
            ven.EmailId = model.EmailId;
            ven.City = model.City;
            ven.IsActive = model.IsActive;
            ven.RegionId = model.RegionId;
            

            return await vendorRepositoryAsync.InsertAsync(ven);
        }

        public async Task<IEnumerable<VendorResponseModel>> GetAllAsync()
        {
            var collection = await vendorRepositoryAsync.GetAllAsync();
            if (collection != null)
            {


                List<VendorResponseModel> vendorModels = new List<VendorResponseModel>();
                foreach (var item in collection)
                {
                    VendorResponseModel model = new VendorResponseModel();
                    
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.City = item.City;
                    model.Country = item.Country;
                    model.IsActive = item.IsActive;
                    model.Mobile =  item.Mobile;
                    model.EmailId = item.EmailId;
                    model.RegionId = item.RegionId;

                    var r = await regionRepositoryAsync.GetByIdAsync(item.RegionId);
                    model.Region = new RegionModel() { Name = r.Name };
                    model.RegionName = r.Name;

                    vendorModels.Add(model);
                }
                return vendorModels;
            }
            return null;
        }
        public async Task<VendorResponseModel> GetByIdAsync(int id)
        {
            var item = await vendorRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                VendorResponseModel model = new VendorResponseModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.City = item.City;
                model.Country = item.Country;
                model.IsActive = item.IsActive;
                model.Mobile = item.Mobile;
                model.EmailId = item.EmailId;
                model.RegionId = item.RegionId;
                return model;
            }
            return null;
        }

        public async Task<VendorRequestModel> GetVendorForEditAsync(int id)
        {
            var item = await vendorRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                VendorRequestModel model = new VendorRequestModel();
                model.Name = item.Name;
                model.Id = item.Id;
                model.EmailId = item.EmailId;
                model.City = item.City;
                model.Country = item.Country;
                model.IsActive = item.IsActive;
                model.Mobile = item.Mobile;
                model.RegionId = item.RegionId;
                return model;
            }
            return null;
        }

       
        public async Task<int> DeleteVendorAsync(int id)
        {
            return await vendorRepositoryAsync.DeleteAsync(id);
        }

        public async Task<int> UpdateVendorAsync(VendorRequestModel model)
        {
            Vendor ven = new Vendor();
            ven.Name = model.Name;
            ven.Country = model.Country;
            ven.Mobile = model.Mobile;
            ven.EmailId = model.EmailId;
            ven.Id = model.Id;
            ven.City = model.City;
            ven.IsActive = model.IsActive;
            ven.RegionId = model.RegionId;
            return await vendorRepositoryAsync.UpdateAsync(ven);
        }
    }
}