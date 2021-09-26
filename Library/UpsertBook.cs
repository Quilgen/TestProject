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

		public UpsertBook(BookContext aBookContext)  //Dependency Injection databáze
		{
			this.mBookContext = aBookContext;
		}

		public async Task<UpsertBookResponse> ProcessCommand(UpsertBookRequest aRequest, CancellationToken aCancellationToken)
		{  // Naètení knihy do databáze 
			Book lDbBook = null;
			UpsertBookResponse lResponse = new UpsertBookResponse();

			if (aRequest.Record.BookId == 0)  // Nová
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
				foreach (var cat in aRequest.Record.Categories)  // Naplnìní pole kategorií v databázi
				{
					if (lDbBook.Categories.All(lC => lC.CategoryId != cat.CategoryId))
						lDbBook.Categories.Add(cat);
				}
				foreach (var lDb in lDbBook.Categories)  // Odstranìní pøebyteèných kategorií v databázi
				{
					if (aRequest.Record.Categories.All(dbBook => dbBook.CategoryId != lDb.CategoryId))
						lDbBook.Categories.Remove(lDb);
				}
				lDbBook.ReleaseDate = aRequest.Record.ReleaseDate;

				lResponse.Message = "Book has been edited";
			}
			await mBookContext.SaveChangesAsync();  // Uložení zmìn v databázi

			lResponse.Success = true;

			return lResponse;
		}
	}
}
