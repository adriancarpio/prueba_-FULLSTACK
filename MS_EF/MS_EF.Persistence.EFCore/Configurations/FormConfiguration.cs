using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS_EF.Domain.Entity;

namespace MS_EF.Persistence.EFCore.Configurations
{
    public static class FormConfiguration
    {
        public static void Configurar(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Form>(entity =>
            {
                entity.ToTable("forms");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

                entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

                entity.HasMany(e => e.Inputs)
                .WithOne(i => i.Form)
                .HasForeignKey(i => i.FormId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
