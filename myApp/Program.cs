using Microsoft.Extensions.Primitives;
using System.Text;

WebApplicationBuilder builder = WebApplication.CreateBuilder();
var app = builder.Build();


app.Use(async (context, next) =>
{
    try
    {
        await next.Invoke();
    }
    catch (Exception ex)
    {
        var log = new StringBuilder();
        log.AppendLine($"Error: {ex}");
        log.AppendLine($"Request Path: {context.Request.Path}");
        log.AppendLine($"Request Method: {context.Request.Method}");

        if (context.Request.HasFormContentType && context.Request.Form.Any())
        {
            foreach (var form in context.Request.Form)
            {
                log.AppendLine($"Form Data: {form.Key} = {form.Value}");
            }
        }

        await File.WriteAllTextAsync("errorlog.txt", log.ToString());
        throw;
    }
});

app.MapGet("/", async context =>
{
    StringBuilder sb = new StringBuilder();

    sb.Append("<html><body>" +
        "<form method=\"post\" action=\"/setcookie\">" +
        "<label for=\"value\">Value:</label>" +
        "<input type=\"text\" id=\"value\" name=\"value\"><br>" +
        "<label for=\"expiration\">Date and time of an expiration:</label>" +
        "<input type=\"datetime-local\" id=\"expiration\" name=\"expiration\"><br>" +
        "<input type=\"submit\" value=\"Submit\">" +
        "</form>" +
        "</body></html>"
        );
        
    await context.Response.WriteAsync(sb.ToString());
});

app.MapPost("/setcookie", async context =>
{
    StringBuilder sb = new StringBuilder();
    var value = context.Request.Form["value"];
    var expirationString = context.Request.Form["expiration"];
    sb.Append("<html><body>");
    if (DateTime.Parse(expirationString) < DateTime.Now)
    {
        sb.Append($"<p>Value \"{value}\" was not saved in Cookies, because it was expired.</p>");
        await context.Response.WriteAsync(sb.ToString());
        throw new Exception();
    }
    if (DateTime.TryParse(expirationString, out DateTime expiration))
    {
        context.Response.Cookies.Append("MyCookie", value, new CookieOptions
        {
            Expires = expiration
        });
        sb.Append("Value is in Cookies." + "<a href='/checkcookie/'>Check Cookie</a>");
    }
    else
    {
        sb.Append("Error with date");
        throw new Exception();
    }
    sb.Append("</body></html>");
    await context.Response.WriteAsync(sb.ToString());
});

app.MapGet("/checkcookie", async context =>
{
    StringBuilder sb = new StringBuilder();

    var myCookie = context.Request.Cookies["MyCookie"];
    sb.Append("<html><body>");

    if (!string.IsNullOrEmpty(myCookie))
    {
        sb.Append($"Value in Cookies: {myCookie}");
    }
    else
    {
        sb.Append("Value doesn't found in Cookies");
    }
    sb.Append("</body></html>");
    await context.Response.WriteAsync(sb.ToString());
});

app.Run();
