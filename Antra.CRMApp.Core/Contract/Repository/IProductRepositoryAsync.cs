using Antra.CRMApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Contract.Repository
{
    public interface IProductRepositoryAsync:IRepositoryAsync<Product>
    {

        Task<IEnumerable<Product>> GetTop10ProductsInStocksAsync();
    }
}
