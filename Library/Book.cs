using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using A19029.Services.Framework.Executor;

namespace Service.Library
{
    public class Book  
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public List<Category> Categories { get; set; }

        public int ReleaseDate { get; set; }

    }
}