using ExpenseApprovalSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseApprovalSystem.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<User> Users { get; set; }   
    }
}
