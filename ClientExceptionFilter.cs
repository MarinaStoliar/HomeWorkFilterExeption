using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterExeption
{
  
    public class ClientExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ILogger<ClientExceptionFilter> logger;

        public ClientExceptionFilter(ILogger<ClientExceptionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception != null)
            {
                logger.LogError(context.Exception, "Exception handled");
                context.ExceptionHandled = true;
            }

            logger.LogInformation("Цей запит не може бути оброблено");
        }
    }
}
