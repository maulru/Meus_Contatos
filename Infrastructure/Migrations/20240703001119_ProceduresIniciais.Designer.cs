﻿// <auto-generated />
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240703001119_ProceduresIniciais")]
    partial class ProceduresIniciais
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entity.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Contato", (string)null);
                });

            modelBuilder.Entity("Core.Entity.DDD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)")
                        .HasColumnName("Codigo");

                    b.Property<int>("RegiaoId")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("RegiaoId");

                    b.ToTable("DDD", (string)null);
                });

            modelBuilder.Entity("Core.Entity.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Estado", (string)null);
                });

            modelBuilder.Entity("Core.Entity.Regiao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EstadoId")
                        .HasColumnType("INT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Regiao", (string)null);
                });

            modelBuilder.Entity("Core.Entity.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContatoId")
                        .HasColumnType("INT");

                    b.Property<int>("DDDId")
                        .HasColumnType("INT");

                    b.Property<string>("NumeroTelefone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("NumeroTelefone");

                    b.HasKey("Id");

                    b.HasIndex("ContatoId");

                    b.HasIndex("DDDId");

                    b.ToTable("Telefone", (string)null);
                });

            modelBuilder.Entity("Core.Entity.DDD", b =>
                {
                    b.HasOne("Core.Entity.Regiao", "Regiao")
                        .WithMany("DDDs")
                        .HasForeignKey("RegiaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Regiao");
                });

            modelBuilder.Entity("Core.Entity.Regiao", b =>
                {
                    b.HasOne("Core.Entity.Estado", "Estado")
                        .WithMany("Regioes")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Core.Entity.Telefone", b =>
                {
                    b.HasOne("Core.Entity.Contato", "Contato")
                        .WithMany("Telefones")
                        .HasForeignKey("ContatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entity.DDD", "DDD")
                        .WithMany("Telefones")
                        .HasForeignKey("DDDId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Contato");

                    b.Navigation("DDD");
                });

            modelBuilder.Entity("Core.Entity.Contato", b =>
                {
                    b.Navigation("Telefones");
                });

            modelBuilder.Entity("Core.Entity.DDD", b =>
                {
                    b.Navigation("Telefones");
                });

            modelBuilder.Entity("Core.Entity.Estado", b =>
                {
                    b.Navigation("Regioes");
                });

            modelBuilder.Entity("Core.Entity.Regiao", b =>
                {
                    b.Navigation("DDDs");
                });
#pragma warning restore 612, 618
        }
    }
}
