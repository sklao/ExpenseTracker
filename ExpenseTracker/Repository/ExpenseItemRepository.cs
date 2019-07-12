using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    public class ExpenseItemRepository : IExpenseItemRepository
    {
        ExpenseTrackerContext _context;
        public ExpenseItemRepository(ExpenseTrackerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add new Expense Item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> CreateAsync(ExpenseItem item)
        {
            _context.ExpenseItems.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Show all Expense Item
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ExpenseItem>> ReadAllAsync()
        {
            if (_context.ExpenseItems.Count<ExpenseItem>() == 0)
            {
                throw new OverflowException("No Expense Items: Object " + nameof(ExpenseItem) );
            }
            return  Task.FromResult(_context.ExpenseItems.AsEnumerable<ExpenseItem>());

        }

        /// <summary>
        /// Get Expense Item by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ExpenseItem> GetAsync(int id)
        {
            Task<ExpenseItem> item = null;
            try
            {
                item =  _context.ExpenseItems.FindAsync(id);
                if (item.Result == null)
                    throw new ArgumentNullException("Invalid ExpenseItem of Id: " + id);
            }
            catch
            {
            }
            return await item;


        }

        public async Task<int> UpdateAsync(ExpenseItem item)
        {
            var expenseItemQuery = from ei in _context.ExpenseItems
                            where ei.Id == item.Id
                            select ei;

            var expenseItem = expenseItemQuery.First<ExpenseItem>();
            if (expenseItem != null)
            {
                expenseItem.Amount = item.Amount;
                expenseItem.Description = item.Description;
                expenseItem.Category = item.Category;

                _context.Update<ExpenseItem>(expenseItem);
                return await _context.SaveChangesAsync();
            }
            else
                return -1;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool result = false;
            var expenseItemQueryResult = from ei in _context.ExpenseItems
                                   where ei.Id == id
                                   select ei;

            var expenseItem = expenseItemQueryResult.First<ExpenseItem>();

            if (expenseItem != null)
            {
                _context.ExpenseItems.Remove(expenseItem);
                await _context.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Return the last Expense Item Id property value.
        /// </summary>
        /// <returns></returns>
        public int GetLastPkId()
        {
            int result = -1;
            if (_context.ExpenseItems.Count() > 0)
            {
                var lastItem = from item in _context.ExpenseItems
                             orderby item.Id descending
                             select item;

                result =  lastItem.First<ExpenseItem>().Id;
            }
            else
                result = -1;

            return result;
        }
    }
}
