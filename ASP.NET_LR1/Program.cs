using ASP.NET_LR1;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

Company company = new Company { Title = "Google", Description = "Gooloogooloo" };

app.MapGet("/task1", () => { return $"Company title {company.Title}, and it's description {company.Description}"; });
app.MapGet("/task2", () => { 
    Random random = new Random();
    var ourNumber = random.Next(0, 101);
    return ourNumber;
    });
app.Use(async (context, next) => {
    var password = context.Request.Query["password"];
    if (password == "aboba")
    {
        await next();
    }
    else
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("You aren't allowed here");
    }
});

 

app.Run();
