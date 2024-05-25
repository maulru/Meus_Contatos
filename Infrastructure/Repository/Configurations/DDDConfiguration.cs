using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configurations
{
    internal class DDDConfiguration : IEntityTypeConfiguration<DDD>
    {
        public void Configure(EntityTypeBuilder<DDD> builder)
        {
            builder.ToTable("DDD");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.EstadoId).HasColumnType("INT").IsRequired();
            builder.Property(p => p.CodigoDDD).HasColumnType("INT").IsRequired();

            builder.HasOne(p => p.Estado)
                .WithMany(c => c.DDDs)
                .HasPrincipalKey(c => c.Id);
        }

    }
}
