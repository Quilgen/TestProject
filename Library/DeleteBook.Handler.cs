using A19029.Services.Framework.Executor;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Library
{
    partial class DeleteBook : IRequestHandler<DeleteBookRequest, DeleteBookResponse>
    {
        #pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<DeleteBookResponse> Handle(DeleteBookRequest aRequest, CancellationToken aCancellationToken)
        #pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return await ProcessCommand(aRequest, aCancellationToken);
        }
    }
}
