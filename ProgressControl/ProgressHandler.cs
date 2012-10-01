using Hollyathome.Web.UI;
using System;
using System.Web;
using System.Web.SessionState;

namespace Hollyathome.Web
{
    public class ProgressHandler : IHttpHandler, IReadOnlySessionState
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            bool first = true;

            context.Response.Write("[");

            if (context.Session != null && !String.IsNullOrEmpty(context.Session.SessionID))
            {
                foreach (ProgressEvent e in ProgressControl.GetEvents(context.Session.SessionID))
                {
                    if (first)
                    {
                        context.Response.Write(e.ToString());
                        first = false;
                    }
                    else
                    {
                        context.Response.Write(", " + e.ToString());
                    }
                }
            }
            
            context.Response.Write("]");
        }

        #endregion
    }
}
