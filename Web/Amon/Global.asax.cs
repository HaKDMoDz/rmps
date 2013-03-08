using System;
using System.Web.Routing;

namespace Amon
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            RegisterRoutes(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码

        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。

        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            var def = new RouteValueDictionary(new { user = "demo" });
            var reg = new RouteValueDictionary(new { user = "\\w+" });

            // Register a route for Page/{User}
            routes.MapPageRoute(
               "user-page", // Route name
               "w/{user}", // Route URL
               "~/Pv.aspx", // Web page to handle route
               true,
               def,
               reg
            );
            // Register a route for Page/{User}
            routes.MapPageRoute(
               "user-card", // Route name
               "c/{user}", // Route URL
               "~/Cv.aspx", // Web page to handle route
               true,
               def,
               reg
            );
            // Register a route for Page/{User}
            routes.MapPageRoute(
               "user-imgs", // Route name
               "p/{user}", // Route URL
               "~/Id.aspx", // Web page to handle route
               true,
               def,
               reg
            );
        }
    }
}
