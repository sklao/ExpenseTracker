using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Models
{
    public class ExpenseTrackerContext : DbContext
    {
        public ExpenseTrackerContext(DbContextOptions<ExpenseTrackerContext> options)
        : base(options)
        {
        }

        public DbSet<ExpenseItem> ExpenseItems { get; set; }

        //public DbSet<ExpenseTrackerContext> PaymentMethods { get; set; }
    }
}
