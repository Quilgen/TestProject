using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using A19029.Services.Framework.Executor;

namespace Service.Library
{
    public class ListCategoriesResponse  
    {
        public List<Category> Categories { get; set; }

    }
}