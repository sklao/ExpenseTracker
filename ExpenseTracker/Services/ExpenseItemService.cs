using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Services
{
    public class ExpenseItemService : IExpenseItemService
    {
        private readonly IExpenseItemRepository _expenseItemRepository;
        public ExpenseItemService(IExpenseItemRepository expenseItemRepository)
        {
            _expenseItemRepository = expenseItemRepository ?? throw new ArgumentNullException(nameof(expenseItemRepository));
        }

        public Task<IEnumerable<ExpenseItem>> ReadAllAsync()
        {
            return _expenseItemRepository.ReadAllAsync();
        }
        public Task<ExpenseItem> GetAsync(int id)
        {
            return _expenseItemRepository.GetAsync(id);
        }

        /// <summary>
        /// Add a new Expense Item to database.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> CreateAsync(ExpenseItem item)
        {
            int result = -1;
            if (_expenseItemRepository.GetAsync(item.Id).Result == null)
            {
                await _expenseItemRepository.CreateAsync(item);
                result = item.Id;
            }
            return result;
        }

        public async Task<int> UpdateAsync(ExpenseItem item)
        {
           return await _expenseItemRepository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _expenseItemRepository.DeleteAsync(id);
        }


        /// <summary>
        /// Get the last inserted Expense Item Id value.
        /// </summary>
        /// <returns></returns>
        private int GetLastPkId()
        {
            return _expenseItemRepository.GetLastPkId();
        }

    }
}
