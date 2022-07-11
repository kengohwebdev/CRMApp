using Antra.CRMApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Identity;

namespace Antra.CRMApp.Core.Contract.Repository
{
    public interface IAccountRepositoryAsync : IRepositoryAsync<SignupModel>
    {
        Task<IdentityResult> SignUpAsync(SignupModel model);
        Task<SignInResult> SignIn(LoginModel login);
    }
}