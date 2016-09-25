using NLog;
using System;
using System.Web;

namespace NCD_Web.Modules
{
    public class LogModule : IHttpModule
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public String ModuleName => "LogModule";
        
        // In the Init function, register for HttpApplication 
        // events by adding your handlers.
        public void Init(HttpApplication application)
        {
            application.BeginRequest +=
                (new EventHandler(this.Application_BeginRequest));
        }

        private void Application_BeginRequest(Object source,
             EventArgs e)
        {
            //logging requests to web
            //logger.Info();
        }

        public void Dispose() { }
    }
}