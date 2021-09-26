using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Library
{
	public partial class ListCategories
	{
		private readonly BookContext mBookContext;

		public ListCategories(BookContext aBookContext)  //Dependency Injection datab�ze
		{
			this.mBookContext = aBookContext;
		}
		public async Task<ListCategoriesResponse> ProcessCommand(ListCategoriesRequest aRequest, CancellationToken aCancellationToken)
		{  // Na�ten� kategori� z datab�ze
			ListCategoriesResponse lResponse = new ListCategoriesResponse();
			lResponse.Categories = await mBookContext.Categories.ToListAsync();

			return lResponse;
		}
	}
}
