using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TestAppForBinary.DB;

namespace TestAppForBinary.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20170801111513_CreateDB")]
    partial class CreateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestAppForBinary.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BodyStyle");

                    b.Property<string>("Class");

                    b.Property<int>("Manufacturer");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("TestAppForBinary.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GenDirector");

                    b.Property<string>("HoldingCompany");

                    b.Property<string>("Name");

                    b.Property<string>("WebSite");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });
        }
    }
}
