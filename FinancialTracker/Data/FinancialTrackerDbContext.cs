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
    }
}