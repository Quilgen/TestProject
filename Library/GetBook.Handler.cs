using A19029.Services.Framework.Executor;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Library
{
    partial class GetBook : IRequestHandler<GetBookRequest, GetBookResponse>
    {
        #pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<GetBookResponse> Handle(GetBookRequest aRequest, CancellationToken aCancellationToken)
        #pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return await ProcessCommand(aRequest, aCancellationToken);
        }
    }
}
