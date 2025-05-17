using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CPROG3_APP.Models;    
using CPROG3_APP.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CPROG3_APP.Data
{
public class CPROG3_APPDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Expense> Expenses { get; set; }

    public CPROG3_APPDbContext(DbContextOptions<CPROG3_APPDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

            // Optional: Customize table names if needed
            builder.Entity<Expense>().ToTable("Expenses");
        }
    }
}