using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Library
{
	public partial class UpsertBook
	{
		private readonly BookContext mBookContext;

		public UpsertBook(BookContext aBookContext)  //Dependency Injection datab�ze
		{
			this.mBookContext = aBookContext;
		}

		public async Task<UpsertBookResponse> ProcessCommand(UpsertBookRequest aRequest, CancellationToken aCancellationToken)
		{  // Na�ten� knihy do datab�ze 
			Book lDbBook = null;
			UpsertBookResponse lResponse = new UpsertBookResponse();

			if (aRequest.Record.BookId == 0)  // Nov�
			{
				lDbBook = new Book();
				mBookContext.Books.Add(lDbBook);

				lDbBook.Title = aRequest.Record.Title;
				lDbBook.AuthorId = aRequest.Record.AuthorId;
				lDbBook.Categories = aRequest.Record.Categories;
				lDbBook.ReleaseDate = aRequest.Record.ReleaseDate;

				lResponse.Message = "Book has been created";
			}
			else // Edit
			{
				lDbBook = mBookContext.Books.Include(aR => aR.Categories).FirstOrDefault(aR => aR.BookId == aRequest.Record.BookId);

				lDbBook.Title = aRequest.Record.Title;
				lDbBook.AuthorId = aRequest.Record.AuthorId;
				foreach (var cat in aRequest.Record.Categories)  // Napln�n� pole kategori� v datab�zi
				{
					if (lDbBook.Categories.All(lC => lC.CategoryId != cat.CategoryId))
						lDbBook.Categories.Add(cat);
				}
				foreach (var lDb in lDbBook.Categories)  // Odstran�n� p�ebyte�n�ch kategori� v datab�zi
				{
					if (aRequest.Record.Categories.All(dbBook => dbBook.CategoryId != lDb.CategoryId))
						lDbBook.Categories.Remove(lDb);
				}
				lDbBook.ReleaseDate = aRequest.Record.ReleaseDate;

				lResponse.Message = "Book has been edited";
			}
			await mBookContext.SaveChangesAsync();  // Ulo�en� zm�n v datab�zi

			lResponse.Success = true;

			return lResponse;
		}
	}
}
