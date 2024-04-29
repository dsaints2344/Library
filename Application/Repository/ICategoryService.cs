using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface ICategoryService
    {
        public Task<CategoryModel> CreateCategory(CategoryModel category);
        public Task<CategoryModel> GetCategory(int id);
        public Task<List<CategoryModel>> GetAllCategories();
    }
}
