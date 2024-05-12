using Meus_Contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace Meus_Contatos.Data;

public class ContatoContext : DbContext
{

    public ContatoContext(DbContextOptions<ContatoContext> opts) : base(opts)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        /*  builder.Entity<DDD>()
              .HasKey(ddd => new { ddd.ID, ddd.CodigoDDD });

          builder.Entity<DDD>()
              .HasOne(ddd => ddd.Estado)
              .WithMany(estado => estado.DDDs)
              .HasForeignKey(ddd => ddd.EstadoId);

          builder.Entity<Estado>()
              .HasKey(estado => new { estado.Id, estado.IdRegiao });

          builder.Entity<Telefone>()
              .HasKey(telefone => new { telefone.Id, telefone.Contato });

          builder.Entity<Contato>()
              .HasKey(contato => new { contato.Id, contato.Usuario });

          builder.Entity<Contato>()
              .HasOne(contato => contato.Usuario)
              .WithMany(usuario => usuario.)
              .HasForeignKey(contato => contato.UsuarioId);
        */
        builder.Entity<Telefone>()
         .HasKey(telefone => new { telefone.Id, telefone.Contato });

        builder.Entity<Telefone>()
        .HasOne(telefone => telefone.Contato)
        .WithMany(contato => contato.Telefones)
        .HasForeignKey(telefone => telefone.ContatoId);

        builder.Entity<Contato>()
            .HasMany(contato => contato.Telefones)
            .WithOne(telefone => telefone.Contato)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Contato> Contatos { get; set; }
    public DbSet<Telefone> Telefones { get; set; }
    public DbSet<Regiao> Regioes { get; set; }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<DDD> DDDs { get; set; }
}

