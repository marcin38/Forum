using Forum.Authorization;
using Forum.Controllers;
using Forum.Exceptions;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Forum
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static Dictionary<int, string> tokenDictionary = new Dictionary<int, string>();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies["f_user"];

            if (authCookie != null)
            {
                int id = int.Parse(authCookie.Values["Id"]);
                string name = authCookie.Values["Name"];
                string token = authCookie.Values["Token"];
                if (tokenDictionary.ContainsKey(id) && tokenDictionary[id] == token)
                {
                    CustomPrincipal newUser = new CustomPrincipal(id, name, token);
                    HttpContext.Current.User = newUser;
                }
                else
                {
                    authCookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(authCookie);
                }

            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception lastError = Server.GetLastError();
            Server.ClearError();

            int statusCode = 0;

            if (lastError.GetType() == typeof(HttpException))
            {
                statusCode = ((HttpException)lastError).GetHttpCode();
            }
            else if (lastError.GetType() == typeof(MyException))
            {
                statusCode = ((MyException)lastError).status;
            }
            else
            {
                statusCode = 500;
            }

            HttpContextWrapper contextWrapper = new HttpContextWrapper(this.Context);

            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Index");
            routeData.Values.Add("statusCode", statusCode);
            routeData.Values.Add("exception", lastError);


            IController controller = new ErrorController();

            RequestContext requestContext = new RequestContext(contextWrapper, routeData);

            controller.Execute(requestContext);
            Response.End();
        }
    }

}
