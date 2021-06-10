﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VVBData.Models;

namespace VVBData.Migrations
{
    [DbContext(typeof(VVBDbContext))]
    [Migration("20210607122846_allentities")]
    partial class allentities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VVBData.Models.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("InVoorraad")
                        .HasColumnType("int");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Titel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotaalVerhuurd")
                        .HasColumnType("int");

                    b.Property<int>("UitVoorraad")
                        .HasColumnType("int");

                    b.HasKey("FilmId");

                    b.HasIndex("GenreId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("VVBData.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreNaam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("VVBData.Models.Klant", b =>
                {
                    b.Property<int>("KlantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumLid")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gemeente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HuurAantal")
                        .HasColumnType("int");

                    b.Property<string>("KlantStat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Lidgeld")
                        .HasColumnType("bit");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Straat_Nr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KlantId");

                    b.ToTable("Klanten");
                });

            modelBuilder.Entity("VVBData.Models.Verhuring", b =>
                {
                    b.Property<int>("VerhuurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("KlantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("VerhuurDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("VerhuurId");

                    b.HasIndex("FilmId");

                    b.HasIndex("KlantId");

                    b.ToTable("Verhuringen");
                });

            modelBuilder.Entity("VVBData.Models.Film", b =>
                {
                    b.HasOne("VVBData.Models.Genre", "Genre")
                        .WithMany("Films")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("VVBData.Models.Verhuring", b =>
                {
                    b.HasOne("VVBData.Models.Film", "Film")
                        .WithMany("Verhuringen")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VVBData.Models.Klant", "Klant")
                        .WithMany("Verhuringen")
                        .HasForeignKey("KlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Klant");
                });

            modelBuilder.Entity("VVBData.Models.Film", b =>
                {
                    b.Navigation("Verhuringen");
                });

            modelBuilder.Entity("VVBData.Models.Genre", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("VVBData.Models.Klant", b =>
                {
                    b.Navigation("Verhuringen");
                });
#pragma warning restore 612, 618
        }
    }
}