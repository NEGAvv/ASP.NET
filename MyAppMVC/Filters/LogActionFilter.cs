using Microsoft.AspNetCore.Mvc.Filters;

namespace MyAppMVC.Filters
{
    public class LogActionFilter : Attribute,IActionFilter
    {
        private static string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "action_log.txt");
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            string controllerName = context.RouteData.Values["controller"].ToString();
            string actionName = context.RouteData.Values["action"].ToString();
            string timeOfCreating = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logMessage = $"{timeOfCreating} - Controller: {controllerName}, Action: {actionName}";


            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }


    }
}
