
using Application.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Category
{
    public class CategoryService: ICategoryService
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryService(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<CategoryModel> CreateCategory(CategoryModel category)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            var categories = await _dbContext.Categories
                .ProjectTo<CategoryModel>(_mapper.ConfigurationProvider).ToListAsync();
            

            return categories;
        }

        public Task<CategoryModel> GetCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
