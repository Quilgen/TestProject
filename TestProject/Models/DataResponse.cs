using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
	public class DataResponse
	{

		public int PageCount { get; set; }

		public List<BookDTO> Books { get; set; }

		public List<Category> Categories { get; set; }

		public List<AuthorDTO> Authors { get; set; }
	}
}
