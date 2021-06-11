using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VVBWeb.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IWebHostEnvironment _environment;
        public CustomExceptionFilter(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public override void OnException(ExceptionContext context)
        {
            if (_environment.IsDevelopment())
            {
                return;
            }
            else if (context.Exception.GetType().Name == "SqlException")
            {
                context.Result = new ViewResult { ViewName = "DatabaseError" };
            }
        }
    }
}
