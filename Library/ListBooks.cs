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

		public ListBooks(BookContext aBookContext)  // Dependency Injection databáze
		{
			this.mBookContext = aBookContext;
		}
		public async Task<ListBooksResponse> ProcessCommand(ListBooksRequest aRequest, CancellationToken aCancellationToken)
		{   // Naètení knížek z databáze, 1. naètení celých dat
			var lResponse = new ListBooksResponse();

			// Naètení kategorií z databáze
			lResponse.Categories = await mBookContext.Categories.ToListAsync();  
			// Naètení autorù z databáze
			lResponse.Authors = await mBookContext.Authors.Include(aR => aR.Books).Select(author => author.AsAuthorDTO()).ToListAsync(); 

			var books = mBookContext.Books  // Naètení všech vyhledávaných knížek z databáze
				.Where(book
					=> String.IsNullOrWhiteSpace(aRequest.SearchPhrase)
					|| book.Title.Contains(aRequest.SearchPhrase));

			lResponse.Books = books  // Naètení požadovaných knížek z databáze
					.OrderBy(aR => aR.Title)
					.Skip((aRequest.CurrentPage) * 10)
					.Take(10)
					.Include(aR => aR.Categories)
					.Select(book => book.AsBookDTO()).ToList();

			lResponse.PageCount = (((books.Count() - 1) / 10) + 1); // Zjištìní poètu stránek tabulky

			return lResponse;
		}
	}
}
