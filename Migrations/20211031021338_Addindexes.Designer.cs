﻿// <auto-generated />
using System;
using CastillePCRTestManagement.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CastillePCRTestManagement.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20211031021338_Addindexes")]
    partial class Addindexes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CastillePCRTestManagement.Models.BookingInformation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CancelledStatus")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ResultDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TestType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookingDate");

                    b.HasIndex("Location");

                    b.HasIndex("BookingDate", "Location");

                    b.HasIndex("Id", "CancelledStatus");

                    b.HasIndex("BookingDate", "Location", "FirstName", "LastName");

                    b.ToTable("BookingInformation");
                });

            modelBuilder.Entity("CastillePCRTestManagement.Models.BookingMaster", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("Space")
                        .HasColumnType("bigint");

                    b.Property<long>("UsedSpace")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Date");

                    b.HasIndex("Location");

                    b.HasIndex("Date", "Location");

                    b.ToTable("BookingMaster");
                });

            modelBuilder.Entity("CastillePCRTestManagement.Models.Locations", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Location");

                    b.ToTable("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
