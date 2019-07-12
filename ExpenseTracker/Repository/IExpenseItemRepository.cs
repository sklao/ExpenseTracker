using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    public interface IExpenseItemRepository
    {
        Task<IEnumerable<ExpenseItem>> ReadAllAsync();
        Task<ExpenseItem> GetAsync(int id);
        Task<int> CreateAsync(ExpenseItem item);
        Task<int> UpdateAsync(ExpenseItem item);
        Task<bool> DeleteAsync(int id);
        int GetLastPkId();
    }
}
