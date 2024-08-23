using FinSpotAPI.Domain.Models.Operations;
using FinSpotAPI.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinSpotAPI.Domain
{
    public class FinSpotContext : DbContext
    {
        public FinSpotContext(DbContextOptions<FinSpotContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("main");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
