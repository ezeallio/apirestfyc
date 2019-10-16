using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace APIRestNetCore.Middlewares
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private IHostingEnvironment _env;
        public MyMiddleware(RequestDelegate next,IHostingEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async  Task Invoke(HttpContext context)
        {
            var path = $"{_env.ContentRootPath}//Logs//log.txt";
            if (!File.Exists(path))
            {
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(path))
                {
                    file.WriteLine($"Request: {context.Request.Path} - Fecha: {DateTime.Now}");
                    await _next(context);
                    file.WriteLine($"Respuesta: {context.Response.StatusCode}");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"Request: {context.Request.Path} - Fecha: {DateTime.Now}");
                    await _next(context);
                    sw.WriteLine($"Respuesta: {context.Response.StatusCode}");
                }
            }
        }
    }
}
