using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configurations
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("Telefone");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(p => p.ContatoId).HasColumnType("INT").IsRequired();
            builder.Property(p => p.DDD).HasColumnType("INT").IsRequired();
            builder.Property(p => p.NumeroTelefone).HasColumnType("VARCHAR(20)").IsRequired();

            builder.HasOne(p => p.Contato)
                .WithMany(c => c.Telefones)
                .HasPrincipalKey(c => c.Id);

            builder.HasOne(p => p.Ddd)
                .WithMany(c=> c.Telefones)
                .HasPrincipalKey(c => c.Id);

        }
    }
}
