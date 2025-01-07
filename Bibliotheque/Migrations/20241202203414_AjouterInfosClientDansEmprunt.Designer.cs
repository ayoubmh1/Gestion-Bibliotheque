﻿// <auto-generated />
using System;
using Bibliotheque.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bibliotheque.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241202203414_AjouterInfosClientDansEmprunt")]
    partial class AjouterInfosClientDansEmprunt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bibliotheque.Models.Achat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateAchat")
                        .HasColumnType("datetime2");

                    b.Property<int>("LivreId")
                        .HasColumnType("int");

                    b.Property<double>("Montant")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("LivreId");

                    b.ToTable("Achats");
                });

            modelBuilder.Entity("Bibliotheque.Models.Emprunt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClientCin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientNom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateEmprunt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRetourEffective")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRetourPrevue")
                        .HasColumnType("datetime2");

                    b.Property<int>("LivreId")
                        .HasColumnType("int");

                    b.Property<bool>("Retourne")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LivreId");

                    b.ToTable("Emprunts");
                });

            modelBuilder.Entity("Bibliotheque.Models.Livre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnneePublication")
                        .HasColumnType("int");

                    b.Property<string>("Auteur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Categorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CheminImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DisponiblePourAchat")
                        .HasColumnType("bit");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.Property<int>("QuantiteDisponible")
                        .HasColumnType("int");

                    b.Property<int>("QuantiteTotale")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Livres");
                });

            modelBuilder.Entity("Bibliotheque.Models.Achat", b =>
                {
                    b.HasOne("Bibliotheque.Models.Livre", "Livre")
                        .WithMany()
                        .HasForeignKey("LivreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livre");
                });

            modelBuilder.Entity("Bibliotheque.Models.Emprunt", b =>
                {
                    b.HasOne("Bibliotheque.Models.Livre", "Livre")
                        .WithMany()
                        .HasForeignKey("LivreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livre");
                });
#pragma warning restore 612, 618
        }
    }
}