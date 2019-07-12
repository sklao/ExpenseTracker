using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        ExpenseTrackerContext _context;
        public CategoryRepository(ExpenseTrackerContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Category>> ReadAllAsync()
        {
            if (_context.Categories.Count<Category>() == 0)
            {
                throw new OverflowException("No Category: Object " + nameof(Category));
            }
            return Task.FromResult(_context.Categories.AsEnumerable<Category>());

        }
        public async Task<Category> GetAsync(int id)
        {
            Task<Category> item = null;
            try
            {
                item = _context.Categories.FindAsync(id);
                if (item.Result == null)
                    throw new ArgumentNullException("Invalid ExpenseItem of Id: " + id);
            }
            catch
            {
            }
            return await item;


        }
        public async Task<int> CreateAsync(Category item) {
            _context.Categories.Add(item);
            return await _context.SaveChangesAsync();

        }
        public async Task<int> UpdateAsync(Category item)
        {
            var categoryQuery = from c in _context.Categories
                                   where c.Description == item.Description
                                   select c;

            var category = categoryQuery.First<Category>();
            if (category != null)
            {
                category.Description = item.Description;

                _context.Update<Category>(category);
                return await _context.SaveChangesAsync();
            }
            else
                return -1;

        }
        public async Task<bool> DeleteAsync(int id)
        {
            bool result = false;
            var categoryQueryResult = from c in _context.Categories
                                         where c.Id == id
                                         select c;

            var category = categoryQueryResult.First<Category>();

            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                result = true;
            }

            return result;

        }
    }
}
