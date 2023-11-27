﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlantApp.Data;

#nullable disable

namespace PlantApp.Migrations
{
    [DbContext(typeof(PlantContext))]
    [Migration("20231126204719_CreateInitial")]
    partial class CreateInitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlantApp.Models.Genus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genus");
                });

            modelBuilder.Entity("PlantApp.Models.Leaf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Leaf");
                });

            modelBuilder.Entity("PlantApp.Models.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenusId")
                        .HasColumnType("int");

                    b.Property<int>("LeafId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoilId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenusId");

                    b.HasIndex("LeafId");

                    b.HasIndex("SoilId");

                    b.ToTable("Plant");
                });

            modelBuilder.Entity("PlantApp.Models.Soil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Soil");
                });

            modelBuilder.Entity("PlantApp.Models.Plant", b =>
                {
                    b.HasOne("PlantApp.Models.Genus", "Genus")
                        .WithMany("Plants")
                        .HasForeignKey("GenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlantApp.Models.Leaf", "Leaf")
                        .WithMany("Plants")
                        .HasForeignKey("LeafId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlantApp.Models.Soil", "Soil")
                        .WithMany("Plants")
                        .HasForeignKey("SoilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genus");

                    b.Navigation("Leaf");

                    b.Navigation("Soil");
                });

            modelBuilder.Entity("PlantApp.Models.Genus", b =>
                {
                    b.Navigation("Plants");
                });

            modelBuilder.Entity("PlantApp.Models.Leaf", b =>
                {
                    b.Navigation("Plants");
                });

            modelBuilder.Entity("PlantApp.Models.Soil", b =>
                {
                    b.Navigation("Plants");
                });
#pragma warning restore 612, 618
        }
    }
}
