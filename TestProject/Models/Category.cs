using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
	public class Category
	{
		public int CategoryId { get; set; }

		public string CategoryName { get; set; }

		[JsonIgnore] // Nutné pro many to many propojení => databáze/program by volaly spojení do nekonečna (snake property)
		public ICollection<Book> Books { get; set; }
	}
}
