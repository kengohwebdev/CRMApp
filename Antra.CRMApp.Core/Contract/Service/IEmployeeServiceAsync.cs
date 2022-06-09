using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Contract.Service
{
    public interface IEmployeeServiceAsync
    {
        Task<IEnumerable<EmployeeResponseModel>> GetAllAsync();
        Task<int> AddEmployeeAsync(EmployeeRequestModel employee);
        Task<EmployeeResponseModel> GetByIdAsync(int id);
        Task<EmployeeRequestModel> GetEmployeeForEditAsync(int id);
        Task<int> UpdateEmployeeAsync(EmployeeRequestModel employee);
        Task<int> DeleteEmployeeAsync(int id);
    }
}
