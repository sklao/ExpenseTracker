using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Models
{
    public class ExpenseTrackerContext : DbContext
    {
        
        public ExpenseTrackerContext(DbContextOptions<ExpenseTrackerContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder  modelBuilder)
        {
            modelBuilder.Entity<ExpenseItem>().HasKey(i => i.Id);
        }
        public DbSet<ExpenseItem> ExpenseItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<ExpenseTrackerContext> PaymentMethods { get; set; }
    }
}
