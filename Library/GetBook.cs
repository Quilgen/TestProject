using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Library
{
	public partial class GetBook
	{
		private readonly BookContext mBookContext;

		public GetBook(BookContext aBookContext)  //Dependency Injection databáze
		{
			mBookContext = aBookContext;
		}

		public async Task<GetBookResponse> ProcessCommand(GetBookRequest aRequest, CancellationToken aCancellationToken)
		{  //Naètení detailu knihy
			var book = await mBookContext.Books
				.Where(aR => aR.BookId == aRequest.Id)
				.ProjectToResponse()  // Extension metoda
				.SingleAsync();

			//book.CategoryId = book.Categories?.Select(aR => aR.CategoryId).ToArray();  => Nepotøebné, obojí provedeno v Extension metodì ProjectToResponse()
			//book.CategoryNames = book.Categories != null ? String.Join(", ", book.Categories.Select(aR => aR.CategoryName)) : null;

			return book;
		}
	}
}
