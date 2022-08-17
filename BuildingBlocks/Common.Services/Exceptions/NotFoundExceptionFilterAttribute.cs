using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Common.Services.Exceptions
{
    public class NotFoundExceptionFilterAttribute : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
           if (context == null)
                throw new ArgumentNullException("context");
            if (context.Exception is NotFoundException httpResponseException)
            {
                context.Result = new ObjectResult(httpResponseException.Message)
                {
                    StatusCode = (int)HttpStatusCode.NotFound
                };

                context.ExceptionHandled = true;
            }
        }
    }

}
