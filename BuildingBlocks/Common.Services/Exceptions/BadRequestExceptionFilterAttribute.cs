using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Exceptions
{
    public class BadRequestExceptionFilterAttribute: IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (context.Exception is BadRequestException httpResponseException)
            {
                context.Result = new ObjectResult(httpResponseException.Message)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };

                context.ExceptionHandled = true;
            }
        }
    }
   
}
