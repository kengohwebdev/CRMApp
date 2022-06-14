using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antra.CRMApp.Infrastructure.Service;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;

namespace CRMApp.UnitTests
{
    [TestClass]
    public class CRMAppServiceUnitTest
    {

        private ProductServiceAsync _sut;

        [TestMethod]
        public async Task TestTop10ProductsInStocksFromFakeData()
        {
            //SUT system under test ShipperServiceAsync =>GetById

            var products = await _sut.GetTop10ProductsInStockAsync();

            Assert.IsNotNull(products);
        }
    }


    public class MockCRMAppRepository : IProductRepositoryAsync
    {
        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetTop10ProductsInStocksAsync()
        {
            _products = new List<Product>

          /*  List<Product> products = new List<Product>();
            products.Add(new Product() { Id = 1, Name = "Laptop", UnitsInStock = 10, UnitPrice = 2000 });
            products.Add(new Product() { Id = 2, Name = "Iphone", UnitsInStock = 20, UnitPrice = 1000 });
            products.Add(new Product() { Id = 3, Name = "Samsung Galaxy", UnitsInStock = 30, UnitPrice = 900 });
            products.Add(new Product() { Id = 4, Name = "Chair", UnitsInStock = 40, UnitPrice = 120 });
            products.Add(new Product() { Id = 5, Name = "Table", UnitsInStock = 50, UnitPrice = 250 });
         
            return products;*/
        } 

        }

        public Task<int> InsertAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}