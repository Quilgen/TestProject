using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using A19029.Services.Framework.Executor;

namespace Service.Library
{
    public class DataResponse  
    {
        public int PageCount { get; set; }

        public List<BookDTO> Books { get; set; }

        public List<Category> Categories { get; set; }

        public List<AuthorDTO> Authors { get; set; }

    }
}