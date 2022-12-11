using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Exceptions
{
    public class UnauthorizedAccessExceptionFilterAttribute : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (context.Exception is UnauthorizedAccessException httpResponseException  )
            {
                context.Result = new ObjectResult(httpResponseException.Message)
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };

                context.ExceptionHandled = true;
            } 
           
        }
    }

}
