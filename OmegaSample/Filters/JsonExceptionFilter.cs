using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OmegaSample.Models;

namespace OmegaSample.Filters
{
    /// <summary>
    /// Unexpected Exception Handling Resposne
    /// </summary>
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _env;
        public JsonExceptionFilter(IHostingEnvironment env)
        {
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            var _error = new ApiError();

            if (_env.IsDevelopment())
            {
                _error.Message = context.Exception.Message;
                _error.Detail = context.Exception.StackTrace;
            }
            else
            {
                _error.Message = "A server error occurred.";
                _error.Detail = context.Exception.Message;
            }

            context.Result = new ObjectResult(_error)
            {
                StatusCode = 500
            };
        }
    }
}
