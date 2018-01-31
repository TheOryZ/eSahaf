using eSahaf_DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eSahaf_Presantation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            using (eSahafDbContext ent = new eSahafDbContext())
            {
                ent.Database.CreateIfNotExists();
            }
        }
    }
}
