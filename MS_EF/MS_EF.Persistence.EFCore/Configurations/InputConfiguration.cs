using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS_EF.Domain.Entity;

namespace MS_EF.Persistence.EFCore.Configurations
{
    public static class InputConfiguration
    {
        public static void Configurar(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Input>(entity =>
            {
                entity.ToTable("inputs");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

                entity.Property(e => e.FormId)
                .HasColumnName("form_id")
                .IsRequired();

                entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.Type)
                .HasColumnName("type")
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(e => e.Required)
                .HasColumnName("required")
                .IsRequired();

                entity.HasOne(e => e.Form)
                .WithMany(f => f.Inputs)
                .HasForeignKey(e => e.FormId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
