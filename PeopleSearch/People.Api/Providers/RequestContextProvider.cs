using People.Common;
using System.Threading;

namespace People.Api.Providers
{
    public interface IRequestContextProvider
    {
        RequestContext Get(CancellationToken cancellationToken);
    }

    public class RequestContextProvider : IRequestContextProvider
    {
        public RequestContext Get(CancellationToken cancellationToken)
        {
            return new RequestContext {  CancelationToken = cancellationToken };
        }
    }
}
