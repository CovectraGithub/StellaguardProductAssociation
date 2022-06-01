using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StellaguardProductAssociation.Models;
using System.Web.Routing;


namespace StellaguardProductAssociation.DAL
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            //httpContext.Session["UserId"] = "1";
            var userId = Convert.ToString(httpContext.Session["UserId"]);
            if (!string.IsNullOrEmpty(userId))
            {
                //using (var context = new SqlContext())
                //{
                //var userRole = (from u in context.Users
                //                join r in context.Roles on u.RoleId equals r.Id
                //                where u.UserId == userId
                //                select new
                //                {
                //                    r.Name
                //                }).FirstOrDefault();
                var userRole = Convert.ToString(httpContext.Session["RoleName"]);

                    foreach (var role in allowedroles)
                    {
                        if (role == userRole) return true;
                    }
            }
            //  }


            return authorize;
        }

        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //    filterContext.Result = new RedirectToRouteResult(
        //       new RouteValueDictionary
        //       {
        //            { "controller", "Home" },
        //            { "action", "UnAuthorized" }
        //       });
        //}
    }
}  
