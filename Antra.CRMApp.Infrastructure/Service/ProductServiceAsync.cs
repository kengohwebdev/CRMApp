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
    public class ProductServiceAsync : IProductServiceAsync
    {
        private readonly IProductRepositoryAsync productRepositoryAsync;
        public ProductServiceAsync(IProductRepositoryAsync _productRepositoryAsync)
        {
           productRepositoryAsync = _productRepositoryAsync;
        }

       

        public async Task<int> AddProductAsync(ProductRequestModel product)
        {
            Product pro = new Product();
            pro.Name = product.Name;
            pro.VendorId = product.VendorId;
            pro.CategoryId = product.CategoryId;
            pro.QuantityPerUnit = product.QuantityPerUnit;
            pro.UnitPrice = product.UnitPrice;
            pro.UnitsInStock = product.UnitsInStock;
            pro.UnitsOnOrder = product.UnitsOnOrder;
            pro.ReorderLevel= product.ReorderLevel;
            pro.Discontinued = product.Discontinued;
            return await productRepositoryAsync.InsertAsync(pro);
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            return await productRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllAsync()
        {
            var collection = await productRepositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<ProductResponseModel> result = new List<ProductResponseModel>();
                foreach (var item in collection)
                {
                    ProductResponseModel model = new ProductResponseModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.VendorId = item.VendorId;
                    model.CategoryId = item.CategoryId;
                    model.QuantityPerUnit = item.QuantityPerUnit;
                    model.UnitPrice = item.UnitPrice;
                    model.UnitsInStock = item.UnitsInStock;
                    model.UnitsOnOrder = item.UnitsOnOrder;
                    model.ReorderLevel = item.ReorderLevel;
                    model.Discontinued = item.Discontinued;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<ProductResponseModel> GetByIdAsync(int id)
        {
            var item = await productRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                ProductResponseModel model = new ProductResponseModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.VendorId = item.VendorId;
                model.CategoryId = item.CategoryId;
                model.QuantityPerUnit = item.QuantityPerUnit;
                model.UnitPrice = item.UnitPrice;
                model.UnitsInStock = item.UnitsInStock;
                model.UnitsOnOrder = item.UnitsOnOrder;
                model.ReorderLevel = item.ReorderLevel;
                model.Discontinued = item.Discontinued;
                return model;
            }
            return null;
        }

        public async Task<ProductRequestModel> GetProductForEditAsync(int id)
        {
            var item = await productRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                ProductRequestModel model = new ProductRequestModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.VendorId = item.VendorId;
                model.CategoryId = item.CategoryId;
                model.QuantityPerUnit = item.QuantityPerUnit;
                model.UnitPrice = item.UnitPrice;
                model.UnitsInStock = item.UnitsInStock;
                model.UnitsOnOrder = item.UnitsOnOrder;
                model.ReorderLevel = item.ReorderLevel;
                model.Discontinued = item.Discontinued;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateProductAsync(ProductRequestModel product)
        {
            Product pro = new Product();
            pro.Id = product.Id;
            pro.Name = product.Name;
            pro.VendorId = product.VendorId;
            pro.CategoryId = product.CategoryId;
            pro.QuantityPerUnit = product.QuantityPerUnit;
            pro.UnitPrice = product.UnitPrice;
            pro.UnitsInStock = product.UnitsInStock;
            pro.UnitsOnOrder = product.UnitsOnOrder;
            pro.ReorderLevel = product.ReorderLevel;
            pro.Discontinued = product.Discontinued;
            return await productRepositoryAsync.UpdateAsync(pro);
        }

   
    }
}
