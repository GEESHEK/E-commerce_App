﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240626190927_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("API.Entities.Calibre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Calibres");
                });

            modelBuilder.Entity("API.Entities.CaseMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Material")
                        .IsUnique();

                    b.ToTable("CaseMaterials");
                });

            modelBuilder.Entity("API.Entities.Crystal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Material")
                        .IsUnique();

                    b.ToTable("Crystals");
                });

            modelBuilder.Entity("API.Entities.Dial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Colour")
                        .IsUnique();

                    b.ToTable("Dials");
                });

            modelBuilder.Entity("API.Entities.MovementType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("MovementTypes");
                });

            modelBuilder.Entity("API.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WatchId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PublicId")
                        .IsUnique();

                    b.HasIndex("Url")
                        .IsUnique();

                    b.HasIndex("WatchId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("API.Entities.PowerReserve", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Duration")
                        .IsUnique();

                    b.ToTable("PowerReserves");
                });

            modelBuilder.Entity("API.Entities.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("WatchId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WatchId")
                        .IsUnique();

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("API.Entities.StrapBraceletMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Material")
                        .IsUnique();

                    b.ToTable("StrapBraceletMaterials");
                });

            modelBuilder.Entity("API.Entities.Watch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("integer");

                    b.Property<int>("CalibreId")
                        .HasColumnType("integer");

                    b.Property<int>("CaseMaterialId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<int>("CrystalId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("DateAdded")
                        .HasColumnType("date");

                    b.Property<int>("DialId")
                        .HasColumnType("integer");

                    b.Property<bool>("Lume")
                        .HasColumnType("boolean");

                    b.Property<int>("MovementTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OtherSpecifications")
                        .HasColumnType("text");

                    b.Property<int>("PowerReserveId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StrapBraceletMaterialId")
                        .HasColumnType("integer");

                    b.Property<int>("WatchCaseMeasurementsId")
                        .HasColumnType("integer");

                    b.Property<int>("WatchTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("WaterResistanceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CalibreId");

                    b.HasIndex("CaseMaterialId");

                    b.HasIndex("CrystalId");

                    b.HasIndex("DialId");

                    b.HasIndex("MovementTypeId");

                    b.HasIndex("PowerReserveId");

                    b.HasIndex("Reference")
                        .IsUnique();

                    b.HasIndex("StrapBraceletMaterialId");

                    b.HasIndex("WatchCaseMeasurementsId");

                    b.HasIndex("WatchTypeId");

                    b.HasIndex("WaterResistanceId");

                    b.ToTable("Watches");
                });

            modelBuilder.Entity("API.Entities.WatchCaseMeasurements", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Diameter")
                        .HasColumnType("double precision");

                    b.Property<double>("Length")
                        .HasColumnType("double precision");

                    b.Property<double>("LugWidth")
                        .HasColumnType("double precision");

                    b.Property<double>("Thickness")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("Diameter", "Length", "LugWidth", "Thickness")
                        .IsUnique();

                    b.ToTable("WatchCaseMeasurements");
                });

            modelBuilder.Entity("API.Entities.WatchType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("WatchTypes");
                });

            modelBuilder.Entity("API.Entities.WaterResistance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Resistance")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Resistance")
                        .IsUnique();

                    b.ToTable("WaterResistances");
                });

            modelBuilder.Entity("API.Entities.Photo", b =>
                {
                    b.HasOne("API.Entities.Watch", "Watch")
                        .WithMany("Photos")
                        .HasForeignKey("WatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Watch");
                });

            modelBuilder.Entity("API.Entities.Stock", b =>
                {
                    b.HasOne("API.Entities.Watch", "Watch")
                        .WithOne("Stock")
                        .HasForeignKey("API.Entities.Stock", "WatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Watch");
                });

            modelBuilder.Entity("API.Entities.Watch", b =>
                {
                    b.HasOne("API.Entities.Brand", "Brand")
                        .WithMany("Watches")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Calibre", "Calibre")
                        .WithMany("Watches")
                        .HasForeignKey("CalibreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.CaseMaterial", "CaseMaterial")
                        .WithMany("Watches")
                        .HasForeignKey("CaseMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Crystal", "Crystal")
                        .WithMany("Watches")
                        .HasForeignKey("CrystalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Dial", "Dial")
                        .WithMany("Watches")
                        .HasForeignKey("DialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.MovementType", "MovementType")
                        .WithMany("Watches")
                        .HasForeignKey("MovementTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.PowerReserve", "PowerReserve")
                        .WithMany("Watches")
                        .HasForeignKey("PowerReserveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.StrapBraceletMaterial", "StrapBraceletMaterial")
                        .WithMany("Watches")
                        .HasForeignKey("StrapBraceletMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.WatchCaseMeasurements", "WatchCaseMeasurements")
                        .WithMany("Watches")
                        .HasForeignKey("WatchCaseMeasurementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.WatchType", "WatchType")
                        .WithMany("Watches")
                        .HasForeignKey("WatchTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.WaterResistance", "WaterResistance")
                        .WithMany("Watches")
                        .HasForeignKey("WaterResistanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Calibre");

                    b.Navigation("CaseMaterial");

                    b.Navigation("Crystal");

                    b.Navigation("Dial");

                    b.Navigation("MovementType");

                    b.Navigation("PowerReserve");

                    b.Navigation("StrapBraceletMaterial");

                    b.Navigation("WatchCaseMeasurements");

                    b.Navigation("WatchType");

                    b.Navigation("WaterResistance");
                });

            modelBuilder.Entity("API.Entities.Brand", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("API.Entities.Calibre", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("API.Entities.CaseMaterial", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("API.Entities.Crystal", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("API.Entities.Dial", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("API.Entities.MovementType", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("API.Entities.PowerReserve", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("API.Entities.StrapBraceletMaterial", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("API.Entities.Watch", b =>
                {
                    b.Navigation("Photos");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("API.Entities.WatchCaseMeasurements", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("API.Entities.WatchType", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("API.Entities.WaterResistance", b =>
                {
                    b.Navigation("Watches");
                });
#pragma warning restore 612, 618
        }
    }
}
