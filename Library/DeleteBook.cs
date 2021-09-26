using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Library
{
	public partial class DeleteBook
	{
		private readonly BookContext mBookContext;

		public DeleteBook(BookContext aBookContext)  //Dependency Injection datab�ze
		{
			mBookContext = aBookContext;
		}

		public async Task<DeleteBookResponse> ProcessCommand(DeleteBookRequest aRequest, CancellationToken aCancellationToken)
		{  //Smaz�n� knihy
			var lResponse = new DeleteBookResponse();

			var book = await mBookContext.Books.FindAsync(aRequest.Id);
			
			mBookContext.Books.Remove(book); // Smaz�n� knihy z datab�ze
			await mBookContext.SaveChangesAsync(); // Ulo�en� zm�n v datab�zi

			lResponse.Message = "Book has been deleted";
			lResponse.Success = true;

			return lResponse;
		}
	}
}
