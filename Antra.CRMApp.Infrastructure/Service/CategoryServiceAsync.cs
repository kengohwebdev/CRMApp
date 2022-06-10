﻿using Antra.CRMApp.Core.Contract.Repository;
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

        public async Task<int> AddCategoryAsync(CategoryModel model)
            {
                Category category = new Category();
                category.Name = model.Name;
                return await categoryRepositoryAsync.InsertAsync(category);
            }

            public async Task<IEnumerable<CategoryModel>> GetAllAsync()
            {
                var collection = await categoryRepositoryAsync.GetAllAsync();
                if (collection != null)
                {
                    List<CategoryModel> categoryModels = new List<CategoryModel>();
                    foreach (var item in collection)
                    {
                        CategoryModel model = new CategoryModel();
                        model.Name = item.Name;
                        model.Id = item.Id;
                        model.Description=item.Description;
                    
                        categoryModels.Add(model);
                    }
                    return categoryModels;
                }
                return null;
            }
        }
    }
