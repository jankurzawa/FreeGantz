﻿// <auto-generated />
using System;
using FreeGantz.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FreeGantz.Data.Migrations
{
    [DbContext(typeof(FreeGantzContext))]
    partial class FreeGantzContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FreeGantz.Data.Entries.Credentials", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Credentials");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ab5034b7-dd76-4a08-a56e-5012d8b2c388"),
                            Email = "admin",
                            Login = "admin",
                            Password = "admin"
                        },
                        new
                        {
                            Id = new Guid("92c293a4-3fbc-4b4a-9a83-0c2ff4687f8d"),
                            Email = "dupa",
                            Login = "dupa",
                            Password = "dupa"
                        });
                });

            modelBuilder.Entity("FreeGantz.Data.Entries.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameOfClient")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ReservationHour")
                        .HasColumnType("int");

                    b.Property<Guid>("TableId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dc1a65b8-5bcf-4d03-84dd-d88e9b93e00e"),
                            CustomerEmail = "Maniek@gmail.com",
                            Day = new DateTime(2022, 7, 22, 19, 26, 22, 412, DateTimeKind.Local).AddTicks(6009),
                            NameOfClient = "Marian Walikoński",
                            ReservationHour = 15,
                            TableId = new Guid("0edf6c34-ae84-4620-9f8b-e8ea1c52b5ab")
                        },
                        new
                        {
                            Id = new Guid("a9645ecf-0d3a-488b-b4b2-257accccb8f4"),
                            CustomerEmail = "Wyrw@op.pl",
                            Day = new DateTime(2022, 7, 22, 19, 26, 22, 412, DateTimeKind.Local).AddTicks(6071),
                            NameOfClient = "Gniewomira Wyrwichujska",
                            ReservationHour = 20,
                            TableId = new Guid("2368fb38-a47d-4683-95a9-daa5a5ee16b9")
                        });
                });

            modelBuilder.Entity("FreeGantz.Data.Entries.Table", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7c41d004-47e7-42a4-9e30-bb53da264c13"),
                            Description = "small table in front of the window",
                            Size = 1
                        },
                        new
                        {
                            Id = new Guid("47ac1cde-36b6-456b-b76e-78133af83b94"),
                            Description = "charming table perfect for couples",
                            Size = 2
                        },
                        new
                        {
                            Id = new Guid("bfd3051a-06d1-4668-b8b8-49f3590a26f1"),
                            Description = "triangular table next to the toilet",
                            Size = 3
                        },
                        new
                        {
                            Id = new Guid("83eb4b02-3050-4890-a351-c64edaad9b5d"),
                            Description = "A table at the entrance, provides an additional poking experience",
                            Size = 4
                        },
                        new
                        {
                            Id = new Guid("32bdff0d-5f4f-4079-8486-aa8a21267abf"),
                            Description = "A slightly hidden table for noisy groups",
                            Size = 5
                        },
                        new
                        {
                            Id = new Guid("c3f7e0ea-3159-42f4-8088-562d181b664e"),
                            Description = "large outdoor table near the kitchen",
                            Size = 6
                        },
                        new
                        {
                            Id = new Guid("70ec1cae-e563-439c-86cc-db9d6c2e3774"),
                            Description = "a large table in the middle of the premises",
                            Size = 7
                        },
                        new
                        {
                            Id = new Guid("5518d460-a1c5-4013-a233-e8029c550e67"),
                            Description = "special table in the basement",
                            Size = 8
                        });
                });

            modelBuilder.Entity("FreeGantz.Data.Entries.Reservation", b =>
                {
                    b.HasOne("FreeGantz.Data.Entries.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("FreeGantz.Data.Entries.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
