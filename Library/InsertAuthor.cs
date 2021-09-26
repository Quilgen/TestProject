using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Library
{
	public partial class InsertAuthor
	{
		private readonly BookContext mBookContext;

		public InsertAuthor(BookContext aBookContext) //Dependency Injection datab�ze
		{
			this.mBookContext = aBookContext;
		}

		public async Task<InsertAuthorResponse> ProcessCommand(InsertAuthorRequest aRequest, CancellationToken aCancellationToken)
		{  // Vytvo�en� nov�ho autora
			InsertAuthorResponse lResponse = new InsertAuthorResponse();

			mBookContext.Authors.Add(aRequest.Record.AsAuthor());  //P�id�n� z�znamu do datab�ze
			await mBookContext.SaveChangesAsync();  // Ulo�en� zm�n v datab�zi

			lResponse.Message = "Author has been added";
			lResponse.Success = true;

			return lResponse;
			//return CreatedAtAction("GetAuthor", new { id = aRequest.Record.AuthorId }, aRequest.Record);  => nepot�ebn�
		}
	}
}
