using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
	public class BookDTO // Úpravy modelů by měly být v extension metodách nebo v kontroleru
	{

		public int BookId { get; set; }

		public string Title { get; set; }

		public int AuthorId { get; set; }

		public ICollection<Category> Categories { get; set; }

		public int[] CategoryId => Categories?.Select(aR => aR.CategoryId).ToArray();

		public string CategoryNames	{ get { return Categories!= null? String.Join(", ", Categories.Select(aR => aR.CategoryName)): null; } }

		public int ReleaseDate { get; set; }
	}
}
