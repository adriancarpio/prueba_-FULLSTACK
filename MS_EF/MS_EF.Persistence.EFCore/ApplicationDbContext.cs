using Microsoft.EntityFrameworkCore;
using MS_EF.Domain.Entity;
using MS_EF.Persistence.EFCore.Configurations;

namespace MS_EF.Persistence.EFCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<Input> Inputs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FormConfiguration.Configurar(modelBuilder);
            InputConfiguration.Configurar(modelBuilder);
        }

    }
}
