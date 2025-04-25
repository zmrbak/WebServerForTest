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
                var url = $"The url is :{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}{context.Request.Path}{context.Request.QueryString}\n";
                return url;
            });
            app.Run();
        }
    }
}
