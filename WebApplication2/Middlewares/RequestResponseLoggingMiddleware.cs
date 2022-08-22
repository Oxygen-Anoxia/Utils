using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _loggerHelper;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> loggerHelper)
        {
            _next = next;
            _loggerHelper = loggerHelper;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //First, get the incoming request
            await FormatRequest(httpContext.Request);
            await _next(httpContext);
            //Format the response from the server
            //await FormatResponse(httpContext.Response);
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            //This line allows us to set the reader for the request back at the beginning of its stream.
            request.EnableBuffering();

            //We now need to read the request stream.  First, we create a new byte[] with the same length as the request stream...
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            //...Then we copy the entire request stream into the new buffer.
            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            //We convert the byte[] into a string using UTF8 encoding...
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            _loggerHelper.LogInformation(bodyAsText);

            //..and finally, assign the read body back to the request body, which is allowed because of EnableRewind()
            //request.Body = body;
            request.Body.Position = 0;

            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            //We need to read the response stream from the beginning...
            response.Body.Position = 0;

            //...and copy it into a string
            string text = await new StreamReader(response.Body).ReadToEndAsync();

            //We need to reset the reader for the response so that the client can read it.
            response.Body.Position = 0;

            //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
            return $"{response.StatusCode}: {text}";
        }
    }
}
