using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Library
{
	public partial class DeleteBook
	{
		private readonly BookContext mBookContext;

		public DeleteBook(BookContext aBookContext)  //Dependency Injection databáze
		{
			mBookContext = aBookContext;
		}

		public async Task<DeleteBookResponse> ProcessCommand(DeleteBookRequest aRequest, CancellationToken aCancellationToken)
		{  //Smazání knihy
			var lResponse = new DeleteBookResponse();

			var book = await mBookContext.Books.FindAsync(aRequest.Id);
			
			mBookContext.Books.Remove(book); // Smazání knihy z databáze
			await mBookContext.SaveChangesAsync(); // Uložení zmìn v databázi

			lResponse.Message = "Book has been deleted";
			lResponse.Success = true;

			return lResponse;
		}
	}
}
