﻿// <auto-generated />
using GestaoDeUsinas.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestaoDeUsinas.Migrations
{
    [DbContext(typeof(GestaoDeUsinasContext))]
    [Migration("20210626014832_SeedFornecedores")]
    partial class SeedFornecedores
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GestaoDeUsinas.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "SOLARIAN"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "FUTURA"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "CENTRAL GERADORA FAZENDA MODELO"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "NOVA MUNDO"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "SOLARE"
                        },
                        new
                        {
                            Id = 6,
                            Nome = "UNISOL"
                        });
                });

            modelBuilder.Entity("GestaoDeUsinas.Models.Usina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("int");

                    b.Property<string>("UCusina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Usinas");
                });

            modelBuilder.Entity("GestaoDeUsinas.Models.Usina", b =>
                {
                    b.HasOne("GestaoDeUsinas.Models.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });
#pragma warning restore 612, 618
        }
    }
}
