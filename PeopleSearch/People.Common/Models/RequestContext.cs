using System.Threading;

namespace People.Common
{
    public class RequestContext
    {
        public CancellationToken CancelationToken { get; set; }
    }
}
