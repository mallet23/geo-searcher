using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GeoSearcher.Infrastructure
{
    public class JsonExceptionMiddleware
    {
        public const string DefaultErrorMessage = "A server error occurred.";

        private readonly IWebHostEnvironment _env;
        private readonly JsonSerializer _serializer;

        public JsonExceptionMiddleware(IWebHostEnvironment env)
        {
            _env = env;

            _serializer = new JsonSerializer
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex == null) return;

            var error = new JsonError();

            if (_env.IsDevelopment())
            {
                error.Message = ex.Message;
                error.Details = ex.StackTrace;
            }
            else
            {
                error.Message = DefaultErrorMessage;
                error.Details = ex.Message;
            }

            context.Response.ContentType = "application/json";

            await using var writer = new StreamWriter(context.Response.Body);
            _serializer.Serialize(writer, error);
            await writer.FlushAsync().ConfigureAwait(false);
        }

        private class JsonError
        {
            public string Message { get; set; }
            public string Details { get; set; }
        }
    }
}