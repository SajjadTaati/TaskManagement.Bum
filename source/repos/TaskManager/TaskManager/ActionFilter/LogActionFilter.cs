using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.Metrics;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.ActionFilter
{
    public class LogActionFilter:ActionFilterAttribute
    {
        private readonly ApplicationDbContext _contex;

        public LogActionFilter(ApplicationDbContext contex)
        {
            _contex = contex;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
         
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Guid? userId = null;

            // گرفتن UserId از Claims
            var user = context.HttpContext.User;
            if (user.Identity != null && user.Identity.IsAuthenticated)
            {
                var claim = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                if (claim != null)
                {
                    userId = Guid.Parse(claim.Value);
                }
            }

            var log = new RequestLog
            {
                UserId =userId.ToString(),
                Method = context.ActionDescriptor.RouteValues["action"],
                Controller =context.ActionDescriptor.RouteValues["controller"],
                Ip = context.HttpContext.Connection.RemoteIpAddress?.ToString(),
                Path=context.HttpContext.Request.Path,
                Timestamp = DateTime.Now
            };

            _contex.RequestLogs.Add(log);
            _contex.SaveChanges();

        }
    }
}
