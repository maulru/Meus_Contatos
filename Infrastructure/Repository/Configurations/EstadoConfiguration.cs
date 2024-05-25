using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configurations
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("Estado");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(p => p.RegiaoId).HasColumnType("INT").IsRequired();
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(50)").IsRequired();

            builder.HasOne(p => p.Regiao)
                .WithMany(c => c.Estados)
                .HasPrincipalKey(c => c.Id)
                .HasForeignKey(c => c.RegiaoId);
        }
    }
}
