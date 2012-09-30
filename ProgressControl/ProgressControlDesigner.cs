using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;

namespace Hollyathome.Web.UI
{
    public class ProgressControlDesigner : ControlDesigner
    {
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            //IWebApplication webApp = this.GetService(typeof(IWebApplication)) as IWebApplication;
            //Configuration config = webApp.OpenWebConfiguration(true);
            //config.SectionGroups.Add("system.webServer", new ConfigurationSectionGroup());
            //config.Save();
            
            base.Initialize(component);
        }

        public override string GetDesignTimeHtml()
        {
            IWebApplication webApp = this.GetService(typeof(IWebApplication)) as IWebApplication;
            if(webApp != null)
            {
                Configuration config = webApp.OpenWebConfiguration(true);
            }
            return base.GetDesignTimeHtml();
        }
    }
}
