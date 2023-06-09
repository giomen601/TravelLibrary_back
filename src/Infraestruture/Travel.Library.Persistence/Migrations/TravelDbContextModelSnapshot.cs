﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Travel.Library.Persistence.DbContext;

#nullable disable

namespace Travel.Library.Persistence.Migrations
{
    [DbContext(typeof(TravelDbContext))]
    partial class TravelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Travel.Library.Domain.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Lastname = "Author One",
                            Name = "First Name"
                        },
                        new
                        {
                            Id = 2,
                            Lastname = "Author Two",
                            Name = "Second Name"
                        });
                });

            modelBuilder.Entity("Travel.Library.Domain.Entities.AuthorBook", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("AuthorsBooks");

                    b.HasData(
                        new
                        {
                            AuthorsId = 1,
                            BookId = 1
                        },
                        new
                        {
                            AuthorsId = 2,
                            BookId = 1
                        },
                        new
                        {
                            AuthorsId = 2,
                            BookId = 2
                        });
                });

            modelBuilder.Entity("Travel.Library.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PublishersId")
                        .HasColumnType("int");

                    b.Property<string>("Synopsis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PublishersId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PublishersId = 1,
                            Synopsis = "First book test synopsis",
                            Title = "First book"
                        },
                        new
                        {
                            Id = 2,
                            PublishersId = 3,
                            Synopsis = "Second book test synopsis",
                            Title = "Second book"
                        });
                });

            modelBuilder.Entity("Travel.Library.Domain.Entities.Publishers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("HouseLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HouseLocation = "Location test one",
                            Name = "First publisher"
                        },
                        new
                        {
                            Id = 2,
                            HouseLocation = "Location test two",
                            Name = "Second publisher test"
                        },
                        new
                        {
                            Id = 3,
                            HouseLocation = "Location test three",
                            Name = "Third publisher test"
                        });
                });

            modelBuilder.Entity("Travel.Library.Domain.Entities.Author", b =>
                {
                    b.HasOne("Travel.Library.Domain.Entities.Book", null)
                        .WithMany("Authors")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("Travel.Library.Domain.Entities.AuthorBook", b =>
                {
                    b.HasOne("Travel.Library.Domain.Entities.Author", "Authors")
                        .WithMany("AuthorsBooks")
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travel.Library.Domain.Entities.Book", "Books")
                        .WithMany("AuthorsBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Authors");

                    b.Navigation("Books");
                });

            modelBuilder.Entity("Travel.Library.Domain.Entities.Book", b =>
                {
                    b.HasOne("Travel.Library.Domain.Entities.Publishers", "Publishers")
                        .WithMany()
                        .HasForeignKey("PublishersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publishers");
                });

            modelBuilder.Entity("Travel.Library.Domain.Entities.Author", b =>
                {
                    b.Navigation("AuthorsBooks");
                });

            modelBuilder.Entity("Travel.Library.Domain.Entities.Book", b =>
                {
                    b.Navigation("Authors");

                    b.Navigation("AuthorsBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
