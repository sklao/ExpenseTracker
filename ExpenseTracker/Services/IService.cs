using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Services
{
    interface IService<T>
    {
        Task<IEnumerable<T>> ReadAllAsync();
        Task<T> GetAsync(int id);
        Task<int> CreateAsync(T item);
        Task<int> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);

    }
}
