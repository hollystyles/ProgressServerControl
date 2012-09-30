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
            System.Diagnostics.Debugger.Launch();
            IWebApplication webApp = Component.Site.GetService(typeof(IWebApplication)) as IWebApplication;
            Configuration config = webApp.OpenWebConfiguration(true);
            config.SectionGroups.Add("system.webServer", new ConfigurationSectionGroup());
            config.Save();
            
            base.Initialize(component);
        }
    }
}
