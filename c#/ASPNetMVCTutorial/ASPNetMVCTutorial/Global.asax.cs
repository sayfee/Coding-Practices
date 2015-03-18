using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmployeeDirectory
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
              "Default",
              "{controller}/{action}/{id}",
              new
              {
                  controller = "Employee",
                  action = "index",
                  id = UrlParameter.Optional
              }
          );
           
            routes.MapRoute(
              "Details",
              "{controller}/{action}/{id}",
              new
              {
                  controller = "Users",
                  action = "Details",
                  id = UrlParameter.Optional
              }
          );
            routes.MapRoute(
              "Edit",
              "{controller}/{action}/{id}",
              new
              {
                  controller = "Users",
                  action = "Edit",
                  id = UrlParameter.Optional
              }
          );
             

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

    }
}