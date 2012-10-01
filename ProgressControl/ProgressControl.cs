using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Web;

namespace Hollyathome.Web.UI
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:ProgressControl runat=server></{0}:ProgressControl>")]
    [Designer(typeof(ProgressControlDesigner))]
    public class ProgressControl : WebControl
    {
        private static List<ProgressEvent> progressEvents = new List<ProgressEvent>();
        private string sessionId;
        
        protected override void OnInit(EventArgs e)
        {
            sessionId = HttpContext.Current.Session.SessionID;
            base.OnInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            
            string scriptUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "Hollyathome.Web.UI.js.ProgressControl.js");
            Page.ClientScript.RegisterClientScriptInclude("Hollyathome.Web.UI.js.ProgressControl.js", scriptUrl);
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.Write("<div id='" + this.ClientID + "' style='width:100%;'>");
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.Write("</div>");
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), this.ClientID, "progressControls.push('" + this.ClientID + "')", true);
            if (String.IsNullOrEmpty(this.CssClass))
            {
                output.Write(String.Format(
                    "<div style='background-color:{0};height:10px;width:0%;'></div>",
                    this.BackColor)
                );
            }
            else
            {
                output.Write(String.Format(
                    "<div class='{0}' style='width:0%;'></div>",
                    this.CssClass)
                );
            }
        }

        public static IEnumerable<ProgressEvent> GetEvents(string sessionId)
        {
            List<ProgressEvent> results = progressEvents.Where(e => e.SessionId == sessionId).ToList();
            foreach(ProgressEvent e in results)
            {
                progressEvents.Remove(e);
            }

            return results;
         }

        public void AddEvent(int total, int count)
        {
            if (!String.IsNullOrEmpty(sessionId))
            {
                progressEvents.Add(new ProgressEvent(this.sessionId, this.ClientID, total, count));
            }
        }
    }
}
