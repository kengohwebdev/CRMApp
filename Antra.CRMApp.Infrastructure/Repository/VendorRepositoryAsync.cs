using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Antra.CRMApp.Infrastructure.Repository
{
    public class VendorRepositoryAsync : BaseRepository<Vendor>, IVendorRepositoryAsync
    {
        public VendorRepositoryAsync(CrmDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
