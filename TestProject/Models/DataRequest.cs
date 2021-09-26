using System.Collections.Generic;
using TestProject.Models;

namespace TestProject.Controllers
{
	public class DataRequest
	{

		public string SearchPhrase { get; set; }

		public int CurrentPage { get; set; }		
	}
}