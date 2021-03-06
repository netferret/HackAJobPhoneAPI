﻿// <auto-generated />
using HAJ.PhoneAPI.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HAJ.PhoneAPI.Domain.Migrations
{
    [DbContext(typeof(PhoneContext))]
    [Migration("20190518102917_AddHouseNameNumber")]
    partial class AddHouseNameNumber
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HAJ.PhoneAPI.Domain.PhoneBookUsers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("HouseNameNumber");

                    b.Property<string>("Number");

                    b.Property<string>("Postcode");

                    b.Property<string>("Street");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("PhoneBookUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
