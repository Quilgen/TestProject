using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using A19029.Services.Framework.Executor;

namespace Service.Library
{
    public class DeleteBookResponse  
    {
        public bool Success { get; set; }

        public string Message { get; set; }

    }
}