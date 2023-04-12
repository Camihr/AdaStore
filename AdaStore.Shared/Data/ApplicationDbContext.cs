using AdaStore.Shared.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdaStore.Shared.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Relation between updates provider supplies and budgets

            //builder.Entity<ProviderUpdatesToBudget>().HasKey(g => new { g.ProviderId, g.BudgetId });

            //builder.Entity<ProviderUpdatesToBudget>()
            //    .HasOne(g => g.Budget)
            //    .WithMany(g => g.ProviderUpdatesToBudgets)
            //    .HasForeignKey(g => g.BudgetId);

            //builder.Entity<ProviderUpdatesToBudget>()
            //    .HasOne(g => g.Provider)
            //    .WithMany(g => g.ProviderUpdatesToBudgets)
            //    .HasForeignKey(g => g.ProviderId);

            // Relation between products and orders

           

            // Query filters

           // builder.Entity<Provider>().HasQueryFilter(p => !p.IsDeleted);
       
        }

        ///public DbSet<User> Users { get; set; }
    }
}
