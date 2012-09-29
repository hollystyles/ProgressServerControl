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
    public class ProgressControlDesigner : CompositeControlDesigner
    {
        public override void Initialize(System.ComponentModel.IComponent component)
        {

            System.Diagnostics.Debug.Write("Initialze ProgressControlDesigner");

            base.Initialize(component);
        }
        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);

            IWebApplication webApp = Component.Site.GetService(typeof(IWebApplication)) as IWebApplication;
            if (webApp != null)
            {
                Configuration config = webApp.OpenWebConfiguration(true);
                ConfigurationSectionGroup systemWebServer = config.GetSectionGroup("system.webServer");
                HttpHandlersSection handlersSection = systemWebServer.Sections["handlers"] as HttpHandlersSection;
                
                if (handlersSection == null)
                {
                    handlersSection = new HttpHandlersSection();
                    systemWebServer.Sections.Add("httpHandlers", handlersSection);
                    
                }
                
                bool handlerExists = false;

                if(handlersSection.Handlers.Count > 0)
                {
                    foreach(HttpHandlerAction action in handlersSection.Handlers)
                    {
                        if(action.Type == "Hollyathome.Web.ProgressHandler, Hollyathome.Web")
                        {
                            handlerExists = true;
                            break;
                        }
                    }
                }

                if(!handlerExists)
                {
                    HttpHandlerAction progressHandlerAction = new HttpHandlerAction(
                        "*.progress", "Hollyathome.Web.ProgressHandler, Hollyathome.Web", "*");
                    handlersSection.Handlers.Add(progressHandlerAction);
                }

                config.Save(ConfigurationSaveMode.Modified, false);

            }
        }
    }
}
