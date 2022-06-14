using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Infrastructure.Repository
{
    public class ProductRepositoryAsync : BaseRepository<Product>, IProductRepositoryAsync
    {
        CrmDbContext context;
        public ProductRepositoryAsync(CrmDbContext _dbContext) : base(_dbContext)
        {
            context =_dbContext;
        }

        public async Task<IEnumerable<Product>> GetTop10ProductsInStocksAsync()
        {
            return await context.Product.OrderByDescending(x => x.UnitsInStock).Take(10).ToListAsync();

        }
    }
}
