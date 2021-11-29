using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using ExceptionFilterAttribute = System.Web.Http.Filters.ExceptionFilterAttribute;

namespace PartnerAPI.CustomExceptions
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            string errMsg = string.Empty;
            HttpStatusCode statusCode = HttpStatusCode.NotFound;

            if (context.Exception is NotImplementedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented)
                {
                    Content = new StringContent(String.Format("Function not implemented.")),
                    ReasonPhrase = String.Format("Unknown function.")
                };
            }
            else if(context.Exception is ArgumentNullException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(String.Format("There is no record found.")),
                    ReasonPhrase = String.Format("Data not found for name.")
                };
            }
            else
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(String.Format("Internal server error.")),
                    ReasonPhrase = String.Format("Contact admin.")
                };
            }

            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(errMsg),
                ReasonPhrase = "From Exception Filter"
            };
        }
    }
}
