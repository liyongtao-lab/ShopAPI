﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopAPI.Models;

namespace ShopAPI.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20210320120845_1.0")]
    partial class _10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopAPI.Models.Grade", b =>
                {
                    b.Property<int>("Gid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Gid");

                    b.ToTable("grades");
                });

            modelBuilder.Entity("ShopAPI.Models.Student", b =>
                {
                    b.Property<int>("Sid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Gsid")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Sid");

                    b.ToTable("students");
                });
#pragma warning restore 612, 618
        }
    }
}
