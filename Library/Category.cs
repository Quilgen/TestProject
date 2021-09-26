using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using A19029.Services.Framework.Executor;

namespace Service.Library
{
    public class Category  
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}