using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using A19029.Services.Framework.Executor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Library;

namespace TestProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LibraryController : ControllerBase
	{
		private readonly BookContext _context;
        private readonly Executor mExecutor;  // Proprietní systém Argutecu

		public LibraryController(BookContext context, Executor aExecutor) // Dependency Injection
		{
			_context = context;
			this.mExecutor = aExecutor;
		}

		//// GET: api/Library
		//[HttpPost("list")]  ==> Implementováno v service
		//public ActionResult<DataResponse> GetBooks([FromBody] DataRequest aRequest)  // 1. nahrání dat a načtení z databázo přes BE do FE
		//{
		//	DataResponse dataResponse = new DataResponse();

		//	dataResponse.Categories = _context.Categories.ToList();
		//	dataResponse.Authors = _context.Authors.Select(author => author.AsAuthorDTO()).ToList();

		//	var books = _context.Books
		//		.Where(book
		//			=> String.IsNullOrWhiteSpace(aRequest.SearchPhrase)
		//			|| book.Title.Contains(aRequest.SearchPhrase));

		//	dataResponse.Books = books.Skip((aRequest.CurrentPage) * 10)
		//		.Take(10)
		//		.Include(aR => aR.Categories)
		//        .Select(book => book.AsBookDTO()).ToList();

		//	dataResponse.PageCount = (((books.Count() - 1) / 10) + 1);

		//	return dataResponse;
		//}

		//[HttpGet("categories")]  // Pro získání Kategorií z DB  ==> Implementováno v service
		//public ActionResult<List<Category>> GetCategories()
		//{
		//	var categories = _context.Categories.ToList();
		//	return categories;
		//}


		//// GET: api/Library/5  ==> Implementováno v service
		//[HttpGet("{id}")]
		//public async Task<ActionResult<BookDTO>> GetBook(int id)  // Nahrání detailu knihy
		//{
		//	//= await _context.Books.FindAsync(id);
		//	var book = await _context.Books.Include(aR => aR.Categories).Include(aR => aR.Author).FirstOrDefaultAsync(aR => aR.BookId == id); //.Select(book => book.AsBookDTO()).SingleOrDefaultAsync(b => b.Id == id); x- nutné přidat include Authors ?

		//	if (book == null)
		//	{
		//		return NotFound();
		//	}

		//	return book.AsBookDTO();
		//}

		//// POST: api/Library
		//// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		//[HttpPost(Name = "PostBook")]
		////[ResponseType(typeof(BookDTO))]  ==> Implementováno v service

		//public async Task<ActionResult<BookDTO>> PostBook(BookDTO book)  // Editace knihy nebo vytvoření nové
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}

		//	Book lDbBook = null;

		//	if (book.BookId == 0)  // Nová
		//	{
		//		lDbBook = new Book();
		//		_context.Books.Add(lDbBook);

		//		lDbBook.Title = book.Title;
		//		lDbBook.AuthorId = book.AuthorId;
		//		//lDbBook.Author = book.Author.AsAuthor();
		//		lDbBook.Categories = book.Categories;
		//		lDbBook.ReleaseDate = book.ReleaseDate;
		//	}
		//	else // Edit
		//	{
		//		lDbBook = _context.Books.Include(aR => aR.Categories).FirstOrDefault(aR => aR.BookId == book.BookId);

		//		lDbBook.Title = book.Title;
		//		lDbBook.AuthorId = book.AuthorId;
		//		//lDbBook.Author = book.Author.AsAuthor();
		//		foreach (var cat in book.Categories)
		//		{
		//			if (lDbBook.Categories.All(lC => lC.CategoryId != cat.CategoryId))
		//				lDbBook.Categories.Add(cat);
		//		}
		//		foreach (var lDb in lDbBook.Categories)
		//		{
		//			if (book.Categories.All(dbBook => dbBook.CategoryId != lDb.CategoryId))
		//				lDbBook.Categories.Remove(lDb);
		//		}
		//		lDbBook.ReleaseDate = book.ReleaseDate;
		//	}
		//	await _context.SaveChangesAsync();

		//	return Ok();
		//}

		//// DELETE: api/Library/5
		//[HttpDelete("{id}")]
		//public async Task<IActionResult> DeleteBook(int id)  // Smazání knihy
		//{
		//	var book = await _context.Books.FindAsync(id);
		//	if (book == null)
		//	{
		//		return NotFound();
		//	}

		//	_context.Books.Remove(book);
		//	await _context.SaveChangesAsync();

		//	return Ok();
		//}

		//private bool BookExists(int id)
		//{
		//	return _context.Books.Any(e => e.BookId == id);
		//}

		#region Service *
        #region Command DeleteBook
        [HttpDelete("{aID}")]
        public async Task<DeleteBookResponse> DeleteBook(        
        int aId)
            => await mExecutor.Send(new DeleteBookRequest()
            {
                Id = aId
            });
        #endregion

		#region Command InsertAuthor
        [HttpPost("author")]
        public async Task<InsertAuthorResponse> InsertAuthor(        
        [FromBody] AuthorDTO aRecord)
            => await mExecutor.Send(new InsertAuthorRequest()
            {
                Record = aRecord
            });
        #endregion

        #region Command UpsertBook
        [HttpPost("book")]
        public async Task<UpsertBookResponse> UpsertBook(        
        [FromBody] BookDTO aRecord)
            => await mExecutor.Send(new UpsertBookRequest()
            {
                Record = aRecord
            });
        #endregion

        #region Command ListCategories
        [HttpGet("list-categories")]
        public async Task<ListCategoriesResponse> ListCategories()
                    => await mExecutor.Send(new ListCategoriesRequest()
            {
            });
        #endregion

        #region Command ListAuthors
        [HttpGet("list-authors")]
        public async Task<ListAuthorsResponse> ListAuthors()
                    => await mExecutor.Send(new ListAuthorsRequest()
            {
            });
        #endregion

        #region Command ListBooks
        [HttpGet("list-books/{aCurrentPage}/{aSearchPhrase?}")]
        public async Task<ListBooksResponse> ListBooks(        
        int aCurrentPage,
        string aSearchPhrase)
            => await mExecutor.Send(new ListBooksRequest()
            {
                CurrentPage = aCurrentPage,
                SearchPhrase = aSearchPhrase
            });
        #endregion

        #region Command GetBook
        [HttpGet("{aID}")]
        public async Task<GetBookResponse> GetBook(        
        int aId)
            => await mExecutor.Send(new GetBookRequest()
            {
                Id = aId
            });
        #endregion

        #endregion

	}
}
