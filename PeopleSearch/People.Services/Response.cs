namespace People.Services
{
    public class Response
    {
        public Response() { }

        public string Error;
        public string FailedValidation;
        public string Information;
    }

    public class Response<TResult> : Response
    {
        public Response() { }

        public TResult Result;
    }
}
