using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using A19029.Services.Framework.Executor;

namespace Service.Library
{
    public class Author  
    {
        public int AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Book> Books { get; set; }

    }
}