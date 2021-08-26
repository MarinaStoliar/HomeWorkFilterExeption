using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterExeption
{
    public class DateFilterAttribute : ActionFilterAttribute
    {
        private DateTime _fromDt;
        private DateTime _dtTo;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _fromDt = Convert.ToDateTime(context.HttpContext.Request.Query["dtFrom"]);
            _dtTo = Convert.ToDateTime(context.HttpContext.Request.Query["dtTo"]);

            context.HttpContext.Response.StatusCode = 400;
            var errorStr = $"{nameof(_fromDt)} < {nameof(_dtTo)}";
            context.HttpContext.Response.Headers.Add("Error", new string[] { errorStr });
        }
    }
}
