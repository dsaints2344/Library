
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

        public async Task<CategoryModel> CreateCategory(CategoryModel category)
        {
            var newCategory = _mapper.Map<Domain.Category>(category);

            var categoryExists = await _dbContext.Categories.AnyAsync(c => c.Name.ToLower() == category.Name.ToLower());
            if (categoryExists)
            {
                throw new DbUpdateException($"Category with name {category.Name} already exists");
            }

            _dbContext.Categories.Add(newCategory);

            try 
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException e) 
            {
                throw new DbUpdateException(e.Message);
            }

            return category;
        }

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            var categories = await _dbContext.Categories
                .ProjectTo<CategoryModel>(_mapper.ConfigurationProvider).ToListAsync();
            
            return categories;
        }

        public async Task<CategoryModel> GetCategory(int id)
        {
            var category = await _dbContext.Categories.Where(c => c.Id == id)
                .ProjectTo<CategoryModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (category == null)
            {
                throw new Exception($"Category with ID {id} not found");
            }
            return category;
        }
    }
}
