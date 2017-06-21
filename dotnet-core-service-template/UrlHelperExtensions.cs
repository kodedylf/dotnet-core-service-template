using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace dotnet_core_service_template
{
    /// <summary>
    /// <see cref="IUrlHelper"/> extension methods.
    /// </summary>
    public static class UrlHelperExtensions
    {
        public static string AbsoluteAction(
        this IUrlHelper url,
        string actionName,
        string controllerName,
        object routeValues = null)
        {
            string scheme = url.ActionContext.HttpContext.Request.Scheme;
            return url.Action(actionName, controllerName, routeValues, scheme);
        }
    }

}
