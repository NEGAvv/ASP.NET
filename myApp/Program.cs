using Microsoft.Extensions.Primitives;
using myApp.Classes;
using myApp.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddTransient<ICalcService, CalcService>()
    .AddTransient<IDayTimeService, DayTimeService>();

var app = builder.Build();



app.MapPost("/calculate", async context => {
    IDayTimeService? dayTimeService = app.Services.GetService<IDayTimeService>();
    ICalcService? calcService = app.Services.GetService<ICalcService>();
    var form = await context.Request.ReadFormAsync();
    var number1 = int.Parse(form["number1"]);
    var number2 = int.Parse(form["number2"]);
    var operation = form["operation"];
    float result = 0;

    switch (operation)
    {
        case "+":
            result = calcService.Add(number1, number2);
            break;
        case "-":
            result = calcService.Subtract(number1, number2);
            break;
        case "*":
            result = calcService.Multiply(number1, number2);
            break;
        case "/":
            result = calcService.Divide(number1, number2);
            break;
    }
    var sb = new StringBuilder();
    sb.Append($"<html lang=\"en\">" +
        $"<head>" +
        $"<meta charset=\"UTF-8\">" +
        $"   <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\"" +
        $"    <title>Calculate and day time services</title>" +
        $"<style>" +
        $"   body {{" +
        $"        display: flex;      " +
        $"  flex-direction: column;  " +
        $"     align-items: center;       " +
        $" justify-content: center;    " +
        $"    height: 100vh;    " +
        $"   margin: 0;   " +
        $" }}   " +
        $" .container {{   " +
        $"     display: flex;    " +
        $"    flex-direction: column;    " +
        $"    align-items: center;   " +
        $" }}   " +
        $" .input-group {{" +
        $" display: flex;" +
        $"      flex-direction: row;" +
        $"       align-items: center;" +
        $"      justify-content: space-between;" +
        $"    }}" +
        $"    input[type=\"number\"], select {{" +
        $"      margin: 5px 10px;" +
        $"    }}" +
        $"    input[type=\"number\"] {{" +
        $"       width: fit-content;" +
        $"   }}" +
        $"  button {{" +
        $"       margin-top: 10px;" +
        $"      background-color: #22B14C;" +
        $"    }}" +
        $"   .square {{" +
        $"      width: 100px;" +
        $"       height: 100px;" +
        $"       background-color: {dayTimeService.GetDayBackColor()};" +
        $"        display: flex;" +
        $"       align-items: center;" +
        $"       justify-content: center;" +
        $"       margin-top: 20px;" +
        $"    }}" +
        $"    .circle {{" +
        $"       width: 50px;" +
        $"      height: 50px;" +
        $"      background-color: {dayTimeService.GetDayFrontColor()};" +
        $"      border-radius: 50%;" +
        $"      display: flex;" +
        $"      align-items: center;" +
        $"       justify-content: center;" +
        $"   }}" +
        $"   p {{" +
        $"      margin-top: 10px;" +
        $"  }}" +
        $"</style>" +
        $"</head>" +
        $"<body>" +
        $"<div class=\"container\">" +
        $"<p>Result:{result}</p>" +
        $"    <a href=\"\\\">Return</a>" +
        $"</div>" +
        $"<div class=\"square\">" +
        $"   <div class=\"circle\"></div>" +
        $"</div>" +
        $"<p>{dayTimeService.GetDayTimePhrase()}</p>" +
        $"</body>" +
        $"</html>");
    await context.Response.WriteAsync(sb.ToString());
});

app.MapGet("/", async context =>
{
    IDayTimeService? dayTimeService = app.Services.GetService<IDayTimeService>();
    var sb = new StringBuilder();
    sb.Append($"<html lang=\"en\">" +
        $"<head>" +
        $"<meta charset=\"UTF-8\">" +
        $"   <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\"" +
        $"    <title>Calculate and day time services</title>" +
        $"<style>" +
        $"   body {{" +
        $"        display: flex;      " +
        $"  flex-direction: column;  " +
        $"     align-items: center;       " +
        $" justify-content: center;    " +
        $"    height: 100vh;    " +
        $"   margin: 0;   " +
        $" }}   " +
        $" .container {{   " +
        $"     display: flex;    " +
        $"    flex-direction: column;    " +
        $"    align-items: center;   " +
        $" }}   " +
        $" .input-group {{" +
        $" display: flex;" +
        $"      flex-direction: row;" +
        $"       align-items: center;" +
        $"      justify-content: space-between;" +
        $"    }}" +
        $"    input[type=\"number\"], select {{" +
        $"      margin: 5px 10px;" +
        $"    }}" +
        $"    input[type=\"number\"] {{" +
        $"       width: fit-content;" +
        $"   }}" +
        $"  button {{" +
        $"       margin-top: 10px;" +
        $"      background-color: #22B14C;" +
        $"    }}" +
        $"  form {{" +
        $"     display: flex;    " +
        $"    flex-direction: column;    " +
        $"    align-items: center;   " +
        $"    }}" +
        $"   .square {{" +
        $"      width: 100px;" +
        $"       height: 100px;" +
        $"       background-color: {dayTimeService.GetDayBackColor()};" +
        $"        display: flex;" +
        $"       align-items: center;" +
        $"       justify-content: center;" +
        $"       margin-top: 20px;" +
        $"    }}" +
        $"    .circle {{" +
        $"       width: 50px;" +
        $"      height: 50px;" +
        $"      background-color: {dayTimeService.GetDayFrontColor()};" +
        $"      border-radius: 50%;" +
        $"      display: flex;" +
        $"      align-items: center;" +
        $"       justify-content: center;" +
        $"   }}" +
        $"   p {{" +
        $"      margin-top: 10px;" +
        $"  }}" +
        $"</style>" +
        $"</head>" +
        $"<body>" +
        $"<div class=\"container\">" +    
        $"<form action=\"/calculate\" method=\"post\">" +
        $"   <div class=\"input-group\">" +
        $"     <input required name=\"number1\" type=\"number\" placeholder=\"Input first number\">" +
        $"       <select required name=\"operation\">" +
        $"           <option value=\"+\">+</option>" +
        $"           <option value=\"-\">-</option>" +
        $"           <option value=\"*\">*</option>" +
        $"          <option value=\"/\">/</option>" +
        $"       </select>" +
        $"      <input required name=\"number2\" type=\"number\" placeholder=\"Input second number\">" +
        $"   </div>" +
        $"    <button type=\"submit\">Submit</button>" +  
        $"</form>" +
        $"</div>" +
        $"<div class=\"square\">" +
        $"   <div class=\"circle\"></div>" +
        $"</div>" +
        $"<p>{dayTimeService.GetDayTimePhrase()}</p>" +
        $"</body>" +
        $"</html>");
    await context.Response.WriteAsync(sb.ToString());

});

 

app.Run();
