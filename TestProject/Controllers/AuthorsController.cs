using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Library;

namespace TestProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{
		private readonly BookContext _context;

		public AuthorsController(BookContext context)
		{
			_context = context;
		}

		//// GET: api/Authors -> Pro získání Autorů z DB  ==> Implementováno v service
		//[HttpGet]
		//public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
		//{
		//	var authors = await _context.Authors.Select(author => author.AsAuthorDTO()).ToListAsync();
		//	return authors;
		//}

		// GET: api/Authors/5
		//[HttpGet("{id}")]
		//public async Task<ActionResult<AuthorDTO>> GetAuthor(int id)  // Nepoužito
		//{
		//	var author = await _context.Authors.FindAsync(id);
		//
		//	if (author == null)
		//	{
		//		return NotFound();
		//	}
		//
		//	return author.AsAuthorDTO();
		//}

		// PUT: api/Authors/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		//[HttpPut("{id}")]
		//public async Task<IActionResult> PutAuthor(int id, Author author)   // Nepoužito
		//{
		//	if (id != author.AuthorId)
		//	{
		//		return BadRequest();
		//	}
		//
		//	_context.Entry(author).State = EntityState.Modified;
		//
		//	try
		//	{
		//		await _context.SaveChangesAsync();
		//	}
		//	catch (DbUpdateConcurrencyException)
		//	{
		//		if (!AuthorExists(id))
		//		{
		//			return NotFound();
		//		}
		//		else
		//		{
		//			throw;
		//		}
		//	}
		//
		//	return NoContent();
		//}

		// POST: api/Authors
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		//[HttpPost]
		//public async Task<ActionResult<AuthorDTO>> PostAuthor(AuthorDTO author)  ==> Implementováno v service
		//{
		//	_context.Authors.Add(author.AsAuthor());
		//	await _context.SaveChangesAsync();

		//	return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, author);
		//}

		// DELETE: api/Authors/5
		//[HttpDelete("{id}")]
		//public async Task<IActionResult> DeleteAuthor(int id)
		//{
		//	var author = await _context.Authors.FindAsync(id);
		//	if (author == null)
		//	{
		//		return NotFound();
		//	}
		//
		//	_context.Authors.Remove(author);
		//	await _context.SaveChangesAsync();
		//
		//	return Ok();
		//}

		private bool AuthorExists(int id)
		{
			return _context.Authors.Any(e => e.AuthorId == id);
		}
	}
}
