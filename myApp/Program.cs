using Microsoft.Extensions.Primitives;
using System.Text;
using myApp.entities;

WebApplicationBuilder builder = WebApplication.CreateBuilder();
builder.Configuration.AddJsonFile("config/Library.json");
builder.Configuration.AddJsonFile("config/Profile.json");
var app = builder.Build();


app.Map("/Library", async (HttpContext context) =>
{
    string greetings = "Welcome to my library";
    StringBuilder sb = new StringBuilder();

    sb.Append("<div style='text-align: center; font-weight: bold; margin-bottom: 20px;'>");
    sb.Append($"<h1>{greetings}</h1>");
    sb.Append("</div>");

    sb.Append("<div style='text-align: center;'>");
    sb.Append("<a href='/Library'>Library</a> | ");
    sb.Append("<a href='/Library/Books'>Books</a> | ");
    sb.Append("<a href='/Profile/'>Profile</a>");
    sb.Append("</div>");

    await context.Response.WriteAsync(sb.ToString());
});

app.Map("/Library/Books", async (HttpContext context, IConfiguration appConfig) =>
{
    Book[] books = appConfig.GetSection("library:books").Get<Book[]>();
    StringBuilder sb = new StringBuilder();
    sb.Append("<div style='max-width: 800px; margin: 0 auto;'>");

    if (books.Length > 0)
    {
        sb.Append("<table style='width: 100%; border-collapse: collapse;'>");
        sb.Append("<tr>" +
            "<th style='padding: 8px; border: 1px solid #ccc; text-align: left; background-color: #f2f2f2;'>Name of book</th>" +
            "<th style='padding: 8px; border: 1px solid #ccc; text-align: left; background-color: #f2f2f2;'>Author</th>" +
            "<th style='padding: 8px; border: 1px solid #ccc; text-align: left; background-color: #f2f2f2;'>Pages</th>" +
            "</tr>");

        foreach (var item in books)
        {
            sb.Append("<tr>" +
            $"<td style='padding: 8px; border: 1px solid #ccc; text-align: left;'>{item.Name}</td>" +
            $"<td style='padding: 8px; border: 1px solid #ccc; text-align: left;'>{item.Author}</td>" +
            $"<td style='padding: 8px; border: 1px solid #ccc; text-align: left;'>{item.Pages}</td>" +
            "</tr>");
        }

        sb.Append("</table>");
    }
    else
    {
        sb.Append("<p>No books available.</p>");
    }

    sb.Append("<div style='text-align: center;'>");
    sb.Append("<a href='/Library'>Library</a> | ");
    sb.Append("<a href='/Library/Books'>Books</a> | ");
    sb.Append("<a href='/Profile/'>Profile</a>");
    sb.Append("</div>");

    sb.Append("</div>");
    await context.Response.WriteAsync(sb.ToString());
});
app.Map("/Profile/{id:int?}", async (int? id, HttpContext context, IConfiguration appConfig) =>
{
    User[] users = appConfig.GetSection("profile:users").Get<User[]>();
    StringBuilder sb = new StringBuilder();
    sb.Append("<div style='max-width: 800px; margin: 0 auto;'>");

    if (id.HasValue && users != null && id.Value >= 0 && id.Value < users.Length)
    {
        sb.Append("<table style='width: 100%; border-collapse: collapse;'>" +
        "<tr>" +
        "<th style='padding: 8px; border: 1px solid #ccc; text-align: left; background-color: #f2f2f2;'>Name</th>" +
        "<th style='padding: 8px; border: 1px solid #ccc; text-align: left; background-color: #f2f2f2;'>Age</th>" +
        "<th style='padding: 8px; border: 1px solid #ccc; text-align: left; background-color: #f2f2f2;'>Gender</th>" +
        "</tr>" +
        "<tr>" +
        $"<td style='padding: 8px; border: 1px solid #ccc; text-align: left;'>{users[id.Value].Name}</td>" +
        $"<td style='padding: 8px; border: 1px solid #ccc; text-align: left;'>{users[id.Value].Age}</td>" +
        $"<td style='padding: 8px; border: 1px solid #ccc; text-align: left;'>{users[id.Value].Gender}</td>" +
        "</tr>" +
        "</table>");

        // Navigation links for other user profiles
        sb.Append("<div style='text-align: center;'>");
        for (int i = 0; i < users.Length; i++)
        {
            if (i == id.Value)
            {
                sb.Append($"<span>{users[i].Name}</span> | ");
            }
            else
            {
                sb.Append($"<a href='/Profile/{i}'>{users[i].Name}</a> | ");
            }
        }
        sb.Append("</div>");
    }
    else
    {
        sb.Append("<table style='width: 100%; border-collapse: collapse;'>" +
        "<tr>" +
        "<th style='padding: 8px; border: 1px solid #ccc; text-align: left; background-color: #f2f2f2;'>Name</th>" +
        "<th style='padding: 8px; border: 1px solid #ccc; text-align: left; background-color: #f2f2f2;'>Identity</th>" +
        "</tr>" +
        "<tr>" +
        $"<td style='padding: 8px; border: 1px solid #ccc; text-align: left;'>{context.User}</td>" +
        $"<td style='padding: 8px; border: 1px solid #ccc; text-align: left;'>{context.User.Identity}</td>" +
        "</tr>" +
        "</table>");

        // Navigation links for user profiles
        sb.Append("<div style='text-align: center;'>");
        for (int i = 0; i < users.Length; i++)
        {
            sb.Append($"<a href='/Profile/{i}'>{users[i].Name}</a> | ");
        }
        sb.Append("</div>");
    }

    sb.Append("<div style='text-align: center; margin-top: 15px;'>");
    sb.Append("<a href='/Library'>Library</a> | ");
    sb.Append("<a href='/Library/Books'>Books</a> | ");
    sb.Append("<a href='/Profile/'>Profile</a>");
    sb.Append("</div>");

    sb.Append("</div>");
    await context.Response.WriteAsync(sb.ToString());
});




app.Map("/", async context =>
{
    StringBuilder sb = new StringBuilder();
    sb.Append("<div style='text-align: center;'>");
    sb.Append("<a href='/Library'>Library</a> | ");
    sb.Append("<a href='/Library/Books'>Books</a> | ");
    sb.Append("<a href='/Profile/'>Profile</a>");
    sb.Append("</div>");
    await context.Response.WriteAsync(sb.ToString());
});


app.Run();
