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
    public class ProductServiceAsync : IProductServiceAsync
    {
        private readonly IProductRepositoryAsync productRepositoryAsync;
        public ProductServiceAsync(IProductRepositoryAsync _productRepositoryAsync)
        {
           productRepositoryAsync = _productRepositoryAsync;
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllAsync()
        {
            //var collection = await productRepositoryAsync.GetAllAsync();
            //if (collection != null)
            //{
            //    List<ProductResponseModel> lst = new List<ProductResponseModel>();
            //    foreach (var item in collection)
            //    {
            //        ProductResponseModel model = new ProductResponseModel();
            //    }
            //}
            return null;
        }
    }
}
