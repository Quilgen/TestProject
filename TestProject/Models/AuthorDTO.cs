using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
	public class AuthorDTO // Úpravy modelů by měly být v extension metodách nebo v kontroleru
	{
		public int AuthorId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName => String.Join(" ", FirstName, LastName);
		public ICollection<BookDTO> Books { get; set; }
	}
}
