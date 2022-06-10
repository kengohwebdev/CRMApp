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
        public CustomerServiceAsync(ICustomerRepositoryAsync _cust)
        {
            customerRepositoryAsync = _cust;
        }

        public async Task<int> AddCustomerAsync(CustomerRequestModel customer)
        {
            Customer cust = new Customer();
            cust.Address = customer.Address;
            cust.RegionId = customer.RegionId;
            cust.City = customer.City;
            cust.Country = customer.Country;
            cust.Name = customer.Name;
            cust.Phone = customer.Phone;
            cust.PostalCode = customer.PostalCode;
            cust.Title = customer.Title;
            cust.Region = customer.Region;
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
                    model.Phone = item.Phone;
                    model.Title = item.Title;
                    model.Address = item.Address;
                    model.City = item.City;
                    model.Name = item.Name;
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
                model.Phone = item.Phone;
                model.Title = item.Title;
                model.Address = item.Address;
                model.City = item.City;
                model.Name = item.Name;
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
                model.Id = item.Id;
                model.Phone = item.Phone;
                model.Title = item.Title;
                model.Address = item.Address;
                model.City = item.City;
                model.Name = item.Name;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateCustomerAsync(CustomerRequestModel customer)
        {
            Customer cust = new Customer();
            cust.Address = customer.Address;
            cust.RegionId = customer.RegionId;
            cust.City = customer.City;
            cust.Country = customer.Country;
            cust.Name = customer.Name;
            cust.Phone = customer.Phone;
            cust.PostalCode = customer.PostalCode;
            cust.Title = customer.Title;
            cust.Region = customer.Region;
            return await customerRepositoryAsync.InsertAsync(cust);
        }
    }
}
