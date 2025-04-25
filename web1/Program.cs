using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting.Server;

namespace web1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthorization();

            var app = builder.Build();
            app.UseAuthorization();
            app.MapGet("/{*path}", (HttpContext context) =>
            {
                // 获取服务器实际监听的地址和端口
                var serverAddresses = context.RequestServices.GetRequiredService<IServer>().Features
                    .Get<IServerAddressesFeature>()?.Addresses;
                var serverPorts = serverAddresses != null ? $"Server Listening Ports: {string.Join(", ", serverAddresses)}\n" : "";
                return $"{serverPorts}\n";


                //var url = $"The URL is: {context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}{context.Request.Path}{context.Request.QueryString}\n";
                //var headers = new System.Text.StringBuilder("Request Headers:\n");

                //// 遍历所有请求头并格式化输出
                //foreach (var header in context.Request.Headers)
                //{
                //    headers.AppendLine($"{header.Key}: {header.Value}");
                //}

                //return $"{serverPorts}{url}\n{headers}";
            });
            app.Run();
        }
    }
}
