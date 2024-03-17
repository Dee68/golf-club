﻿// <auto-generated />
using System;
using GolfClub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GolfClub.Migrations
{
    [DbContext(typeof(GolfDbContext))]
    [Migration("20240306180555_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GolfClub.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GolferId")
                        .HasColumnType("int");

                    b.Property<int>("Player1GolferId")
                        .HasColumnType("int");

                    b.Property<int>("Player1Handicap")
                        .HasColumnType("int");

                    b.Property<int>("Player2GolferId")
                        .HasColumnType("int");

                    b.Property<int>("Player2Handicap")
                        .HasColumnType("int");

                    b.Property<int>("Player3GolferId")
                        .HasColumnType("int");

                    b.Property<int>("Player3Handicap")
                        .HasColumnType("int");

                    b.Property<int>("Player4GolferId")
                        .HasColumnType("int");

                    b.Property<int>("Player4Handicap")
                        .HasColumnType("int");

                    b.Property<DateTime>("TeeTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GolferId");

                    b.HasIndex("Player1GolferId");

                    b.HasIndex("Player2GolferId");

                    b.HasIndex("Player3GolferId");

                    b.HasIndex("Player4GolferId");

                    b.ToTable("Booking", (string)null);
                });

            modelBuilder.Entity("GolfClub.Models.Golfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("Handicap")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Golfer", (string)null);
                });

            modelBuilder.Entity("GolfClub.Models.Booking", b =>
                {
                    b.HasOne("GolfClub.Models.Golfer", "Golfer")
                        .WithMany("Bookings")
                        .HasForeignKey("GolferId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GolfClub.Models.Golfer", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1GolferId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GolfClub.Models.Golfer", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2GolferId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GolfClub.Models.Golfer", "Player3")
                        .WithMany()
                        .HasForeignKey("Player3GolferId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GolfClub.Models.Golfer", "Player4")
                        .WithMany()
                        .HasForeignKey("Player4GolferId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Golfer");

                    b.Navigation("Player1");

                    b.Navigation("Player2");

                    b.Navigation("Player3");

                    b.Navigation("Player4");
                });

            modelBuilder.Entity("GolfClub.Models.Golfer", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
