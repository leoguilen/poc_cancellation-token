using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace Sample.Api.Filters
{
    internal class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public ExceptionFilter(ILoggerFactory loggerFactory) =>
            _logger = loggerFactory.CreateLogger<ExceptionFilter>();

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is OperationCanceledException)
            {
                _logger.LogError("Request was cancelled");
                context.ExceptionHandled = true;
                context.Result = new ObjectResult(null)
                {
                    StatusCode = 499,
                    Value = new
                    {
                        title = context.Exception.GetType().Name,
                        message = "Request was cancelled",
                        code = 499,
                    }
                };
            }
        }
    }
}
