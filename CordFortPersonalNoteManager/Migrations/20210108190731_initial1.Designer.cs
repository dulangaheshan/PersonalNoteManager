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
    [Migration("20210108190731_initial1")]
    partial class initial1
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

                    b.HasData(
                        new
                        {
                            NoteId = 1L,
                            Content = "TestContent1",
                            DateCreated = new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsArchived = false,
                            Title = "Test1",
                            UserID = 1L
                        },
                        new
                        {
                            NoteId = 2L,
                            Content = "TestContent2",
                            DateCreated = new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsArchived = false,
                            Title = "Test2",
                            UserID = 2L
                        },
                        new
                        {
                            NoteId = 3L,
                            Content = "TestContent2",
                            DateCreated = new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsArchived = false,
                            Title = "Test3",
                            UserID = 1L
                        });
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
