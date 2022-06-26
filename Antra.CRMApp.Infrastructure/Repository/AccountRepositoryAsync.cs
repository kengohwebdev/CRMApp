using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using Antra.CRMApp.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Infrastructure.Repository
{
    public class AccountRepositoryAsync : BaseRepository<SignupModel>, IAccountRepositoryAsync
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountRepositoryAsync(CrmDbContext _dbContext, UserManager<ApplicationUser> userManager) : base(_dbContext)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> SignUpAsync(SignupModel model)
        {
            ApplicationUser user = new ApplicationUser();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.EmailId;
            user.UserName = model.EmailId;
            return await _userManager.CreateAsync(user, model.Password);
        }
    }
}
