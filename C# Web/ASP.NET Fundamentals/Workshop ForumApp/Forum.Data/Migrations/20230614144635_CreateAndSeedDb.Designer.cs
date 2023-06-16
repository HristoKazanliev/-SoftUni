﻿// <auto-generated />
using System;
using Forum.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForumApp.Data.Migrations
{
    [DbContext(typeof(ForumDbContext))]
    [Migration("20230614144635_CreateAndSeedDb")]
    partial class CreateAndSeedDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Forum_App.Data.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("86be1ca6-b399-4058-98d1-648441c5c17e"),
                            Content = "My first post will be about performing CRUD operations in MVC. It's so much fun!",
                            Title = "My First Post"
                        },
                        new
                        {
                            Id = new Guid("f7027461-f7bb-46ac-bab3-c908bf92499a"),
                            Content = "This is my second post. CRUD operations in mVC are getting more and more interesting!",
                            Title = "My Second Post"
                        },
                        new
                        {
                            Id = new Guid("85620fb0-50bc-4d36-99d9-119bb12b64c4"),
                            Content = "Hello there! I'm getting better and better with the CRUD operations in MVC. Stay tuned!",
                            Title = "My third Post"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}