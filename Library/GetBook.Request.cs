using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using A19029.Services.Framework.Executor;

namespace Service.Library
{
    public class GetBookRequest : IExecutorRequest<GetBookResponse>
    {
        public int Id { get; set; }

    }
}