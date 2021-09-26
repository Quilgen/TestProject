﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Service.Library;

namespace Service.Library.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20210729103440_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.Property<int>("BooksBookId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoriesCategoryId")
                        .HasColumnType("integer");

                    b.HasKey("BooksBookId", "CategoriesCategoryId");

                    b.HasIndex("CategoriesCategoryId");

                    b.ToTable("BookCategory");
                });

            modelBuilder.Entity("Service.Library.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            FirstName = "VP",
                            LastName = "SSSR"
                        },
                        new
                        {
                            AuthorId = 2,
                            FirstName = "Lukáš",
                            LastName = "Vjargan"
                        },
                        new
                        {
                            AuthorId = 3,
                            FirstName = "Naděžda",
                            LastName = "Ivanovna"
                        },
                        new
                        {
                            AuthorId = 4,
                            FirstName = "Emet",
                            LastName = "Stirling"
                        },
                        new
                        {
                            AuthorId = 5,
                            FirstName = "William",
                            LastName = "Shakespear"
                        },
                        new
                        {
                            AuthorId = 6,
                            FirstName = "Globální",
                            LastName = "Prediktor"
                        },
                        new
                        {
                            AuthorId = 7,
                            FirstName = "Ernst",
                            LastName = "Hemingway"
                        },
                        new
                        {
                            AuthorId = 8,
                            FirstName = "Lev Nikolajevič",
                            LastName = "Tolstoj"
                        },
                        new
                        {
                            AuthorId = 9,
                            FirstName = "J. K.",
                            LastName = "Rowling"
                        },
                        new
                        {
                            AuthorId = 10,
                            FirstName = "Bedřich",
                            LastName = "Trávníček"
                        });
                });

            modelBuilder.Entity("Service.Library.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("ReleaseDate")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorId = 1,
                            ReleaseDate = 2009,
                            Title = "Základy Sociologie 1"
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 1,
                            ReleaseDate = 2012,
                            Title = "Sad Roste Sám"
                        },
                        new
                        {
                            BookId = 3,
                            AuthorId = 10,
                            ReleaseDate = 2009,
                            Title = "Zahrádkář"
                        },
                        new
                        {
                            BookId = 4,
                            AuthorId = 2,
                            ReleaseDate = 1994,
                            Title = "Příručka zálesáka"
                        },
                        new
                        {
                            BookId = 5,
                            AuthorId = 3,
                            ReleaseDate = 1928,
                            Title = "Ruština pro Samouky"
                        },
                        new
                        {
                            BookId = 6,
                            AuthorId = 4,
                            ReleaseDate = 1999,
                            Title = "Pendragon"
                        },
                        new
                        {
                            BookId = 7,
                            AuthorId = 6,
                            ReleaseDate = 2001,
                            Title = "Bible"
                        },
                        new
                        {
                            BookId = 8,
                            AuthorId = 7,
                            ReleaseDate = 1995,
                            Title = "Stařec a moře"
                        },
                        new
                        {
                            BookId = 9,
                            AuthorId = 8,
                            ReleaseDate = 1920,
                            Title = "Vojna a Mír"
                        },
                        new
                        {
                            BookId = 10,
                            AuthorId = 9,
                            ReleaseDate = 2003,
                            Title = "Harry Potter"
                        });
                });

            modelBuilder.Entity("Service.Library.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Educational"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Encyclopedia"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Fiction"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Religion"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Sci-Fi"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Fantasy"
                        },
                        new
                        {
                            CategoryId = 7,
                            CategoryName = "Hobby"
                        });
                });

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.HasOne("Service.Library.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Service.Library.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Service.Library.Book", b =>
                {
                    b.HasOne("Service.Library.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Service.Library.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
