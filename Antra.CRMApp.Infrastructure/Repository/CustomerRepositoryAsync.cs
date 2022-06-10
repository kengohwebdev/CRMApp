using Antra.CRMApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Infrastructure.Data;

namespace Antra.CRMApp.Infrastructure.Repository
{
    public class CustomerRepositoryAsync : BaseRepository<Customer>, ICustomerRepositoryAsync
    {
      
        public CustomerRepositoryAsync(CrmDbContext _dbContext) : base(_dbContext)
        {
          
        }
    }
}
