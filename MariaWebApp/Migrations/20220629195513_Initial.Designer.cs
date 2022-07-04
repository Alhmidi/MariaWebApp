﻿// <auto-generated />
using System;
using MariaWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MariaWebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220629195513_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MariaWebApp.Models.Eintrag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EintragInhalt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Eintrag");
                });

            modelBuilder.Entity("MariaWebApp.Models.Organ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Beschreibung")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Land")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrganCategory")
                        .HasColumnType("int");

                    b.Property<string>("Ort")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PLZ")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Strasse")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefon")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("eMail")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Organ");
                });

            modelBuilder.Entity("MariaWebApp.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Bemerkung")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Land")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nachname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrganId")
                        .HasColumnType("int");

                    b.Property<string>("Ort")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PLZ")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PersonCategory")
                        .HasColumnType("int");

                    b.Property<string>("ProfilePictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Strasse")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefon")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Vorname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("eMail")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("OrganId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("MariaWebApp.Models.Person_Eintrag", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("EintragId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "EintragId");

                    b.HasIndex("EintragId");

                    b.ToTable("Person_Eintrag");
                });

            modelBuilder.Entity("MariaWebApp.Models.Person", b =>
                {
                    b.HasOne("MariaWebApp.Models.Organ", "Organ")
                        .WithMany("Personen")
                        .HasForeignKey("OrganId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organ");
                });

            modelBuilder.Entity("MariaWebApp.Models.Person_Eintrag", b =>
                {
                    b.HasOne("MariaWebApp.Models.Eintrag", "Einträge")
                        .WithMany("Personen_Einträge")
                        .HasForeignKey("EintragId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MariaWebApp.Models.Person", "Personen")
                        .WithMany("Personen_Einträge")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Einträge");

                    b.Navigation("Personen");
                });

            modelBuilder.Entity("MariaWebApp.Models.Eintrag", b =>
                {
                    b.Navigation("Personen_Einträge");
                });

            modelBuilder.Entity("MariaWebApp.Models.Organ", b =>
                {
                    b.Navigation("Personen");
                });

            modelBuilder.Entity("MariaWebApp.Models.Person", b =>
                {
                    b.Navigation("Personen_Einträge");
                });
#pragma warning restore 612, 618
        }
    }
}