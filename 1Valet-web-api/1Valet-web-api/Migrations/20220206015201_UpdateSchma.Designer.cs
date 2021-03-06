// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _1Valet_web_api.Models;

namespace _1Valet_web_api.Migrations
{
    [DbContext(typeof(DbContextClass))]
    [Migration("20220206015201_UpdateSchma")]
    partial class UpdateSchma
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevicesTypes", b =>
                {
                    b.Property<Guid>("DevicesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TypesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DevicesId", "TypesId");

                    b.HasIndex("TypesId");

                    b.ToTable("DevicesTypes");
                });

            modelBuilder.Entity("_1Valet_web_api.Models.Devices", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<string>("DeviceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceUsage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("_1Valet_web_api.Models.Types", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("DevicesTypes", b =>
                {
                    b.HasOne("_1Valet_web_api.Models.Devices", null)
                        .WithMany()
                        .HasForeignKey("DevicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_1Valet_web_api.Models.Types", null)
                        .WithMany()
                        .HasForeignKey("TypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
