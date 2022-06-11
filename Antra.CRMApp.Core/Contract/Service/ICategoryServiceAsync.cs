using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Contract.Service
{
    public interface ICategoryServiceAsync
    {
        Task<IEnumerable<CategoryModel>> GetAllAsync();
        Task<int> AddCategoryAsync(CategoryModel model);
        Task<CategoryModel> GetByIdAsync(int id);
        Task<CategoryModel> GetCategoryForEditAsync(int id);
        Task<int> UpdateCategoryAsync(CategoryModel category);
        Task<int> DeleteCategoryAsync(int id);


    }
}
