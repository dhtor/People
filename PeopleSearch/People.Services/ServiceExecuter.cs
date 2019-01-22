using People.Common;
using People.Common.Exceptions;
using System;
using System.Threading.Tasks;

namespace People.Services
{
    public interface IServiceExecuter
    {
        Task<Response<T>> Execute<TRequestContext, TParam, T>(TRequestContext requestContext,
            ServiceDelegate<TRequestContext, TParam, T> serviceMethod, TParam parameter) where TRequestContext : RequestContext;

        Task<Response<T>> Execute<TRequestContext, T>(TRequestContext requestContext,
            ServiceDelegateParameterless<TRequestContext, T> serviceMethod) where TRequestContext : RequestContext;

    }

    public delegate Task<TResponse> ServiceDelegate<TRequestContext, in TParam, TResponse>(TRequestContext requestContext, TParam parameter) where TRequestContext : RequestContext;
    public delegate Task<TResponse> ServiceDelegateParameterless<TRequestContext, TResponse>(TRequestContext requestContext) where TRequestContext : RequestContext;

    public class ServiceExecuter : IServiceExecuter
    {
        public async Task<Response<T>> Execute<TRequestContext, TParam, T>(TRequestContext requestContext,
            ServiceDelegate<TRequestContext, TParam, T> serviceMethod, TParam parameter) where TRequestContext : RequestContext
        {
            try
            {
                var response = new Response<T>();
                response.Result = await serviceMethod.Invoke(requestContext, parameter);
                return response;
            }
            catch (Exception ex)
            {
                return GetErrorResponse<Response<T>>(requestContext, ex);
            }
        }

        public async Task<Response<T>> Execute<TRequestContext, T>(TRequestContext requestContext,
            ServiceDelegateParameterless<TRequestContext, T> serviceMethod) where TRequestContext : RequestContext
        {
            try
            {
                var response = new Response<T>();
                response.Result = await serviceMethod.Invoke(requestContext);
                return response;
            }
            catch (Exception ex)
            {
                return GetErrorResponse<Response<T>>(requestContext, ex);
            }
        }


        protected TResponse GetErrorResponse<TResponse>(RequestContext requestContext, Exception ex)
            where TResponse : Response, new()
        {
            var MessageResponse = new TResponse();

            var informativeException = ex as InformativeException;
            var failedValidationException = ex as FailedValidationException;
            var errorException = ex as ErrorException;

            if (informativeException != null)
                MessageResponse.Information = informativeException.Message;
            else if (failedValidationException != null)
                MessageResponse.FailedValidation = failedValidationException.Message;
            else
            {
                MessageResponse.Error = ex.Message;
            }

            return MessageResponse;
        }

    }
}
