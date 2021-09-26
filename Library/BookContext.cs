using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Library
{
	public class BookContext : DbContext
	{
		public BookContext(DbContextOptions<BookContext> options) : base(options)
		{

		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Author> Authors { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Author>()
				.HasMany(a => a.Books)
				.WithOne(b => b.Author);

			modelBuilder.Entity<Book>().HasData(  // Prvotní naplnění databáze testovacími daty
				new Book
				{
					BookId = 1,
					Title = "Základy Sociologie 1",
					AuthorId = 1,
					ReleaseDate = 2009
				},
				new Book
				{
					BookId = 2,
					Title = "Sad Roste Sám",
					AuthorId = 1,
					ReleaseDate = 2012
				},
				new Book
				{
					BookId = 3,
					Title = "Zahrádkář",
					AuthorId = 10,
					ReleaseDate = 2009
				},
				new Book
				{
					BookId = 4,
					Title = "Příručka zálesáka",
					AuthorId = 2,
					ReleaseDate = 1994
				},
				new Book
				{
					BookId = 5,
					Title = "Ruština pro Samouky",
					AuthorId = 3,
					ReleaseDate = 1928
				},
				new Book
				{
					BookId = 6,
					Title = "Pendragon",
					AuthorId = 4,
					ReleaseDate = 1999
				},
				new Book
				{
					BookId = 7,
					Title = "Bible",
					AuthorId = 6,
					ReleaseDate = 2001
				},
				new Book
				{
					BookId = 8,
					Title = "Stařec a moře",
					AuthorId = 7,
					ReleaseDate = 1995
				},
				new Book
				{
					BookId = 9,
					Title = "Vojna a Mír",
					AuthorId = 8,
					ReleaseDate = 1920
				},
				new Book
				{
					BookId = 10,
					Title = "Harry Potter",
					AuthorId = 9,
					ReleaseDate = 2003
				}
			);

			modelBuilder.Entity<Category>().HasData(
				new Category
				{
					CategoryId = 1,
					CategoryName = "Educational"
				},
				new Category
				{
					CategoryId = 2,
					CategoryName = "Encyclopedia"
				},
				new Category
				{
					CategoryId = 3,
					CategoryName = "Fiction"
				},
				new Category
				{
					CategoryId = 4,
					CategoryName = "Religion"
				},
				new Category
				{
					CategoryId = 5,
					CategoryName = "Sci-Fi"
				},
				new Category
				{
					CategoryId = 6,
					CategoryName = "Fantasy"
				},
				new Category
				{
					CategoryId = 7,
					CategoryName = "Hobby"
				}
			);

			modelBuilder.Entity<Author>().HasData(
				new Author
				{
					AuthorId = 1,
					FirstName = "VP",
					LastName = "SSSR"
				},
				new Author
				{
					AuthorId = 2,
					FirstName = "Lukáš",
					LastName = "Vjargan"
				},
				new Author
				{
					AuthorId = 3,
					FirstName = "Naděžda",
					LastName = "Ivanovna"
				},
				new Author
				{
					AuthorId = 4,
					FirstName = "Emet",
					LastName = "Stirling"
				},
				new Author
				{
					AuthorId = 5,
					FirstName = "William",
					LastName = "Shakespear"
				},
				new Author
				{
					AuthorId = 6,
					FirstName = "Globální",
					LastName = "Prediktor"
				},
				new Author
				{
					AuthorId = 7,
					FirstName = "Ernst",
					LastName = "Hemingway"
				},
				new Author
				{
					AuthorId = 8,
					FirstName = "Lev Nikolajevič",
					LastName = "Tolstoj"
				},
				new Author
				{
					AuthorId = 9,
					FirstName = "J. K.",
					LastName = "Rowling"
				},
				new Author
				{
					AuthorId = 10,
					FirstName = "Bedřich",
					LastName = "Trávníček"
				}
			);
		}
	}
}
