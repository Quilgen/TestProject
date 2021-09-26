using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Library
{
	public partial class InsertAuthor
	{
		private readonly BookContext mBookContext;

		public InsertAuthor(BookContext aBookContext) //Dependency Injection databáze
		{
			this.mBookContext = aBookContext;
		}

		public async Task<InsertAuthorResponse> ProcessCommand(InsertAuthorRequest aRequest, CancellationToken aCancellationToken)
		{  // Vytvoøení nového autora
			InsertAuthorResponse lResponse = new InsertAuthorResponse();

			mBookContext.Authors.Add(aRequest.Record.AsAuthor());  //Pøidání záznamu do databáze
			await mBookContext.SaveChangesAsync();  // Uložení zmìn v databázi

			lResponse.Message = "Author has been added";
			lResponse.Success = true;

			return lResponse;
			//return CreatedAtAction("GetAuthor", new { id = aRequest.Record.AuthorId }, aRequest.Record);  => nepotøebné
		}
	}
}
