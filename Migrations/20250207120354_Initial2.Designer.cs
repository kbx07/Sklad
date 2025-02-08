﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sklad.Components.Data;

#nullable disable

namespace Sklad.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250207120354_Initial2")]
    partial class Initial2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Sklad.Components.Models.Condition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Condition");
                });

            modelBuilder.Entity("Sklad.Components.Models.ExactLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ExactLocation");
                });

            modelBuilder.Entity("Sklad.Components.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Sklad.Components.Models.Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Borrowed")
                        .HasColumnType("boolean");

                    b.Property<string>("Borrower")
                        .HasColumnType("text");

                    b.Property<int?>("ConditionId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("ExactLocationId")
                        .HasColumnType("integer");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text");

                    b.Property<int?>("LocationId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Tags")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ConditionId");

                    b.HasIndex("ExactLocationId");

                    b.HasIndex("LocationId");

                    b.ToTable("Tool");
                });

            modelBuilder.Entity("Sklad.Components.Models.Tool", b =>
                {
                    b.HasOne("Sklad.Components.Models.Condition", "Condition")
                        .WithMany("Tools")
                        .HasForeignKey("ConditionId");

                    b.HasOne("Sklad.Components.Models.ExactLocation", "ExactLocation")
                        .WithMany("Tools")
                        .HasForeignKey("ExactLocationId");

                    b.HasOne("Sklad.Components.Models.Location", "Location")
                        .WithMany("Tools")
                        .HasForeignKey("LocationId");

                    b.Navigation("Condition");

                    b.Navigation("ExactLocation");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Sklad.Components.Models.Condition", b =>
                {
                    b.Navigation("Tools");
                });

            modelBuilder.Entity("Sklad.Components.Models.ExactLocation", b =>
                {
                    b.Navigation("Tools");
                });

            modelBuilder.Entity("Sklad.Components.Models.Location", b =>
                {
                    b.Navigation("Tools");
                });
#pragma warning restore 612, 618
        }
    }
}
