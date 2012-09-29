using Hollyathome.Web.UI;
using System;
using System.Web;

namespace Hollyathome.Web
{
    public class ProgressHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //write your handler implementation here.
            context.Response.Write("[");
            bool first = true;
            foreach(ProgressEvent e in ProgressControl.GetEvents(context.Request.QueryString["k"]))
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
            context.Response.Write("]");
        }

        #endregion
    }
}
