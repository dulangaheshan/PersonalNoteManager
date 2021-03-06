﻿// <auto-generated />
using System;
using CordFortPersonalNoteManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CordFortPersonalNoteManager.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20210108185957_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CordFortPersonalNoteManager.Models.Note", b =>
                {
                    b.Property<long>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DocumentPath")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("NoteId");

                    b.HasIndex("UserID");

                    b.ToTable("note");
                });

            modelBuilder.Entity("CordFortPersonalNoteManager.Models.User", b =>
                {
                    b.Property<long>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserID");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserID = 1L,
                            UserName = "User_1"
                        },
                        new
                        {
                            UserID = 2L,
                            UserName = "User_1"
                        },
                        new
                        {
                            UserID = 3L,
                            UserName = "User_1"
                        });
                });

            modelBuilder.Entity("CordFortPersonalNoteManager.Models.Note", b =>
                {
                    b.HasOne("CordFortPersonalNoteManager.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
