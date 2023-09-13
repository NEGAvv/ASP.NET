using ASP.NET_LR1;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

builder.Configuration.
    AddJsonFile("configuration/Google.json").
    AddXmlFile("configuration/Apple.xml").
    AddIniFile("configuration/Microsoft.ini").
    AddJsonFile("configuration/Person.json");

app.Map("/task1", (IConfiguration config) =>
{
    var companies = config.GetSection("Company");
    var name = " ";
    var amount = 0;

    foreach (var company in companies.GetChildren())
    {
        var currentName = company.Key;
        var currentAmount = int.Parse(company.GetSection("amount").Value);
        if (currentAmount > amount)
        {
            amount = currentAmount;
            name = currentName;
        }
    }
    return $"The company is {name} and the max amount among others is {amount}";
});

app.Map("/task2", (IConfiguration config) =>
{
    var person = config.GetSection("Person");
    var name = person.GetSection("name").Value;
    var age = person.GetSection("age").Value;
    var hometown = person.GetSection("hometown").Value;
    return $"My name is {name}, i'm {age} years old and my hometown is {hometown}";
});

app.Run();
