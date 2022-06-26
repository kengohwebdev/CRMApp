using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Infrastructure.Service
{
    public class CategoryServiceAsync : ICategoryServiceAsync
    {
        private readonly ICategoryRepositoryAsync categoryRepositoryAsync;
     
        public CategoryServiceAsync(ICategoryRepositoryAsync _categoryRepositoryAsync)
        {
            categoryRepositoryAsync = _categoryRepositoryAsync;
    
        }

        public async Task<int> AddCategoryAsync(CategoryModel category)
        {
            Category cat = new Category();
            cat.Id = category.Id;
            cat.Name = category.Name;
            cat.Description = category.Description;
            return await categoryRepositoryAsync.InsertAsync(cat);
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            return await categoryRepositoryAsync.DeleteAsync(id);
        }
        public async Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            var collection = await categoryRepositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<CategoryModel> result = new List<CategoryModel>();
                foreach (var item in collection)
                {
                    CategoryModel model = new CategoryModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.Description = item.Description;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<CategoryModel> GetByIdAsync(int id)
        {
            var item = await categoryRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                CategoryModel model = new CategoryModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Description = item.Description;
                return model;
            }
            return null;
        }

        public async Task<CategoryModel> GetCategoryForEditAsync(int id)
        {
            var item = await categoryRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                CategoryModel model = new CategoryModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Description = item.Description;
                return model;
            }
            return null;
        }


        public async Task<int> UpdateCategoryAsync(CategoryModel category)
        {
            Category cat = new Category();
            cat.Id = category.Id;
            cat.Name = category.Name;
            cat.Description = category.Description;
            return await categoryRepositoryAsync.UpdateAsync(cat);
        }

    
    }
}
