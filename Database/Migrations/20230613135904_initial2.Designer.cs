﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using praktika.Database;

#nullable disable

namespace praktika.Migrations
{
    [DbContext(typeof(PraktikaContext))]
    [Migration("20230613135904_initial2")]
    partial class initial2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("praktika.Domain.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Areas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Голосіївський"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Дарницький"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Деснянський"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Дніпровський"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Печерський"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Оболонський"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Подільський"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Солом'янський"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Святошинський"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Шевченкивський"
                        });
                });

            modelBuilder.Entity("praktika.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
