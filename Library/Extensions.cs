using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Service.Library
{
	public static class Extensions
	{
		public static BookDTO AsBookDTO(this Book book)
		{  //  Konverze Book > BookDTO
			return new BookDTO
			{
				BookId = book.BookId,
				Title = book.Title,
				AuthorId = book.AuthorId,
				AuthorFullName = String.Join(" ", book.Author.FirstName, book.Author.LastName),
				Categories = book.Categories,
				CategoryId = book.Categories?.Select(aR => aR.CategoryId).ToArray(),
				CategoryNames = book.Categories != null ? String.Join(", ", book.Categories.Select(aR => aR.CategoryName)) : null,
				ReleaseDate = book.ReleaseDate
			};
		}

		public static Book AsBook(this BookDTO book)
		{  //  Konverze BookDTO > Book
			return new Book
			{
				BookId = book.BookId,
				Title = book.Title,
				AuthorId = book.AuthorId,
				Categories = book.Categories,
				ReleaseDate = book.ReleaseDate
			};
		}

		public static AuthorDTO AsAuthorDTO(this Author author)
		{  //  Konverze Author > AuthorDTO
			return new AuthorDTO
			{
				AuthorId = author.AuthorId,
				FirstName = author.FirstName,
				LastName = author.LastName,
				FullName = String.Join(" ", author.FirstName, author.LastName),
				Books = author.Books.Select(b => b.AsBookDTO()).ToList()
			};
		}

		public static Author AsAuthor(this AuthorDTO author)
		{  //  Konverze AuthorDTO > Author
			return new Author
			{
				AuthorId = author.AuthorId,
				FirstName = author.FirstName,
				LastName = author.LastName,
				Books = author.Books?.Select(b => b.AsBook()).ToList()
			};
		}

		public static IQueryable<GetBookResponse> ProjectToResponse(this IQueryable<Book> aBooks)
		{  //  Konverze Book > BookDTO pro načtení detailu knihy
			return aBooks.Select(aR => new GetBookResponse()
			{
				BookId = aR.BookId,
				Title = aR.Title,
				AuthorId = aR.AuthorId,
				Categories = aR.Categories,
				ReleaseDate = aR.ReleaseDate,
				CategoryId = aR.Categories.Select(aCategory => aCategory.CategoryId).ToArray(),
				CategoryNames = String.Join(", ", aR.Categories.Select(aR => aR.CategoryName))
			});
		}

		public static IServiceCollection AddMediatR(this IServiceCollection aServices, Assembly[] assemblies)
		{  //  MediatR => Interní metoda Argutecu
			List<Assembly> lAssemblies = new List<Assembly>();
			lAssemblies.Add(Assembly.GetExecutingAssembly());
			var lLocalAssemblies = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
			string[] lArray = lLocalAssemblies.Select(aR
				=> AssemblyName.GetAssemblyName(aR).FullName).ToArray();
			lAssemblies.AddRange(lLocalAssemblies.Select(aR
				=> AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(aR))));

			return aServices.AddMediatR(lAssemblies.ToArray());
		}
	}
}
