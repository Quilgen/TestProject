using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Library
{
	public partial class ListBooks
	{
		private readonly BookContext mBookContext;

		public ListBooks(BookContext aBookContext)  // Dependency Injection datab�ze
		{
			this.mBookContext = aBookContext;
		}
		public async Task<ListBooksResponse> ProcessCommand(ListBooksRequest aRequest, CancellationToken aCancellationToken)
		{   // Na�ten� kn�ek z datab�ze, 1. na�ten� cel�ch dat
			var lResponse = new ListBooksResponse();

			// Na�ten� kategori� z datab�ze
			lResponse.Categories = await mBookContext.Categories.ToListAsync();  
			// Na�ten� autor� z datab�ze
			lResponse.Authors = await mBookContext.Authors.Include(aR => aR.Books).Select(author => author.AsAuthorDTO()).ToListAsync(); 

			var books = mBookContext.Books  // Na�ten� v�ech vyhled�van�ch kn�ek z datab�ze
				.Where(book
					=> String.IsNullOrWhiteSpace(aRequest.SearchPhrase)
					|| book.Title.Contains(aRequest.SearchPhrase));

			lResponse.Books = books  // Na�ten� po�adovan�ch kn�ek z datab�ze
					.OrderBy(aR => aR.Title)
					.Skip((aRequest.CurrentPage) * 10)
					.Take(10)
					.Include(aR => aR.Categories)
					.Select(book => book.AsBookDTO()).ToList();

			lResponse.PageCount = (((books.Count() - 1) / 10) + 1); // Zji�t�n� po�tu str�nek tabulky

			return lResponse;
		}
	}
}
