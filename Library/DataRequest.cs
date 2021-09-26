using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using A19029.Services.Framework.Executor;

namespace Service.Library
{
    public class DataRequest  
    {
        public int CurrentPage { get; set; }

        public string SearchPhrase { get; set; }

    }
}