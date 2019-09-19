using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NexusSaaS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NexusSaaS.MiddleWare
{
    public class CheckAuthenticationMiddleWare
    {
        private readonly RequestDelegate _next;

        public CheckAuthenticationMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Session.GetString("loggedInUser") != null)
            {
                var loggedInUser = JsonConvert.DeserializeObject<UserModel>(context.Session.GetString("loggedInUser"));
                if (loggedInUser.RoleNames.Contains("admin"))
                {
                    await _next(context);
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    await context.Response.WriteAsync("You don't have permission to view this page");
                }
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Please login with an authorized account to view this page");
            }
        }
    }
}
