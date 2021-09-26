using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject
{
	public static class Extensions  // Základní rozšiřující metody pro původní Controller
	{
		public static BookDTO AsBookDTO(this Book book)
		{
			return new BookDTO
			{
				BookId = book.BookId,
				Title = book.Title,
				AuthorId = book.AuthorId,
				Categories = book.Categories,
				ReleaseDate = book.ReleaseDate
			};
		}

		public static Book AsBook(this BookDTO book)
		{
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
		{
			return new AuthorDTO
			{
				AuthorId = author.AuthorId,
				FirstName = author.FirstName,
				LastName = author.LastName,
				Books = author.Books.Select(b => b.AsBookDTO()).ToList()
			};
		}

		public static Author AsAuthor(this AuthorDTO author)
		{
			return new Author
			{
				AuthorId = author.AuthorId,
				FirstName = author.FirstName,
				LastName = author.LastName,
				Books = author.Books.Select(b => b.AsBook()).ToList()
			};
		}

		public static IServiceCollection AddMediatR(this IServiceCollection aServices)
		{
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
