using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Contract.Repository
{
    public interface IAccountRepositoryAsync:IRepositoryAsync<SignupModel>
    {
        Task<IdentityResult> SignUpAsync(SignupModel model); 
    }
}
