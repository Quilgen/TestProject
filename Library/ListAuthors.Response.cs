using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using A19029.Services.Framework.Executor;

namespace Service.Library
{
    public class ListAuthorsResponse  
    {
        public List<AuthorDTO> Authors { get; set; }

    }
}