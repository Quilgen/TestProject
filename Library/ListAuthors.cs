using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Library
{
	public partial class ListAuthors
	{
		private readonly BookContext mBookContext;

		public ListAuthors(BookContext aBookContext)  //Dependency Injection datab�ze
		{
			this.mBookContext = aBookContext;
		}
		public async Task<ListAuthorsResponse> ProcessCommand(ListAuthorsRequest aRequest, CancellationToken aCancellationToken)
		{  // Na�ten� autor� z datab�ze
			ListAuthorsResponse lResponse = new ListAuthorsResponse();
			lResponse.Authors = await mBookContext.Authors.Include(aR => aR.Books).Select(a => a.AsAuthorDTO()).ToListAsync();

			return lResponse;
		}
	}
}
