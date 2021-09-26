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

		public GetBook(BookContext aBookContext)  //Dependency Injection datab�ze
		{
			mBookContext = aBookContext;
		}

		public async Task<GetBookResponse> ProcessCommand(GetBookRequest aRequest, CancellationToken aCancellationToken)
		{  //Na�ten� detailu knihy
			var book = await mBookContext.Books
				.Where(aR => aR.BookId == aRequest.Id)
				.ProjectToResponse()  // Extension metoda
				.SingleAsync();

			//book.CategoryId = book.Categories?.Select(aR => aR.CategoryId).ToArray();  => Nepot�ebn�, oboj� provedeno v Extension metod� ProjectToResponse()
			//book.CategoryNames = book.Categories != null ? String.Join(", ", book.Categories.Select(aR => aR.CategoryName)) : null;

			return book;
		}
	}
}
