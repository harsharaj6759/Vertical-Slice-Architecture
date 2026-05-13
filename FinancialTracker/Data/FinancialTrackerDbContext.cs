using FinancialTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinancialTracker.Data
{
    public class FinancialTrackerDbContext : DbContext
    {
        public FinancialTrackerDbContext(DbContextOptions<FinancialTrackerDbContext> options) : base(options)
        {

        }

        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Global query filter for soft deletes
            modelBuilder.Entity<Expense>().HasQueryFilter(e => !e.IsDeleted);
        }
    }
}