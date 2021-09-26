using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using A19029.Services.Framework.Executor;

namespace Service.Library
{
    public class BookDTO  
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public string AuthorFullName { get; set; }

        public List<Category> Categories { get; set; }

        public int[] CategoryId { get; set; }

        public string CategoryNames { get; set; }

        public int ReleaseDate { get; set; }

    }
}