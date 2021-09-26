using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using A19029.Services.Framework.Executor;

namespace Service.Library
{
    public class DeleteBookRequest : IExecutorRequest<DeleteBookResponse>
    {
        public int Id { get; set; }

    }
}