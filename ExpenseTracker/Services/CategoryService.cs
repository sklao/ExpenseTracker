using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Services
{
    public class CategoryService : IService<Category>
    {
        private readonly IRepository<CategoryRepository> _categoryRepository;
        public CategoryService(IRepository<CategoryRepository> categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        Task<IEnumerable<Category>> ReadAllAsync();
        Task<T> GetAsync(int id);
        Task<int> CreateAsync(T item);
        Task<int> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
    }
}
