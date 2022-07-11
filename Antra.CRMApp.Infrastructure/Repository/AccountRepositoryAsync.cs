using Antra.CRMApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Infrastructure.Data;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Identity;

namespace Antra.CRMApp.Infrastructure.Repository
{
    public class AccountRepositoryAsync : BaseRepository<SignupModel>, IAccountRepositoryAsync
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountRepositoryAsync(CrmDbContext _dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : base(_dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> SignIn(LoginModel login)
        {
            return await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);
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