using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication4
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string path = Request.Url.LocalPath;
            if (!path.Contains(".asmx"))
            {
                if (path.Contains(@"/WebService.asmx/ChangeNewUser"))
                    Context.RewritePath(path.Replace("WebService.asmx/ChangeNewUser", "WebService.asmx?op=ChangeNewUser"));
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}