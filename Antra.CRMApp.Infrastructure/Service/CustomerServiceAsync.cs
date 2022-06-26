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
    public class CustomerServiceAsync : ICustomerServiceAsync
    {
        private readonly ICustomerRepositoryAsync customerRepositoryAsync;
        private readonly IRegionRepositoryAsync regionRepositoryAsync;
        public CustomerServiceAsync(ICustomerRepositoryAsync _cust, IRegionRepositoryAsync regionRepositoryAsync)
        {
            customerRepositoryAsync = _cust;
            this.regionRepositoryAsync = regionRepositoryAsync; 
        }

        public async Task<int> AddCustomerAsync(CustomerRequestModel customer)
        {
            Customer cust = new Customer();
            cust.Name = customer.Name;
            cust.Title = customer.Title;
            cust.Address = customer.Address;
            cust.City = customer.City;
            cust.RegionId = customer.RegionId;
            cust.PostalCode = customer.PostalCode;
            cust.Country = customer.Country;
            cust.Phone = customer.Phone;
              
            return await customerRepositoryAsync.InsertAsync(cust);
        }

        public async Task<int> DeleteCustomerAsync(int id)
        {
            return await customerRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAllAsync()
        {
            var collection = await customerRepositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<CustomerResponseModel> result = new List<CustomerResponseModel>();
                foreach (var item in collection)
                {
                    CustomerResponseModel model = new CustomerResponseModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.City = item.City;
                    model.Address = item.Address;
                    model.Title = item.Title;
                    model.Phone = item.Phone;
                    model.PostalCode = item.PostalCode;
                    model.Country = item.Country;

                    var c = await regionRepositoryAsync.GetByIdAsync(item.RegionId);
                    model.Region = new RegionModel() { Name = c.Name };
                    model.RegionName = c.Name;



                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<CustomerResponseModel> GetByIdAsync(int id)
        {
            var item = await customerRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                CustomerResponseModel model = new CustomerResponseModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.City = item.City;
                model.Address = item.Address;
                model.Title = item.Title;
                model.Phone = item.Phone;
                return model;
            }
            return null;
        }

        public async Task<CustomerRequestModel> GetCustomerForEditAsync(int id)
        {
            var item = await customerRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                CustomerRequestModel model = new CustomerRequestModel();
                model.Id =item.Id;
                model.Address = item.Address;
                model.RegionId = item.RegionId;
                model.City = item.City;
                model.Country = item.Country;
                model.Name = item.Name;
                model.Phone = item.Phone;
                model.PostalCode = item.PostalCode;
                model.Title = item.Title;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateCustomerAsync(CustomerRequestModel customer)
        {
            Customer cust = new Customer();
            cust.Id = customer.Id;
            cust.Name = customer.Name;
            cust.Title = customer.Title;
            cust.Address = customer.Address;
            cust.City = customer.City;
            cust.RegionId = customer.RegionId;
            cust.PostalCode = customer.PostalCode;
            cust.Country = customer.Country;
            cust.Phone = customer.Phone;
           
            return await customerRepositoryAsync.UpdateAsync(cust);
        }
    }
}
