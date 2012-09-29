using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

namespace Hollyathome.Web.UI
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:ProgressControl runat=server></{0}:ProgressControl>")]
    [Designer(typeof(ProgressControlDesigner))]
    public class ProgressControl : WebControl
    {
        private static List<ProgressEvent> progressEvents = new List<ProgressEvent>();
        
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null)? "<div style='background-color:green;height:10px;width:0%;'></div>" : s);
            }
 
            set
            {
                ViewState["Text"] = value;
            }
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
            
            output.Write(Text);
        }

        public static IEnumerable<ProgressEvent> GetEvents(string key)
        {
            List<ProgressEvent> results = progressEvents.Where(e => e.ProgressKey == key).ToList();
            foreach(ProgressEvent e in results)
            {
                progressEvents.Remove(e);
            }

            return results;
         }

        public static void AddEvent(ProgressEvent e)
        {
            progressEvents.Add(e);
        }
    }
}
