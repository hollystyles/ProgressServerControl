Progress Control

Use to visualy display progress of long running server-side tasks.

aspx
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProgressControlExampleWeb.Default" %>
<%@ Register Assembly="Hollyathome.Web" Namespace="Hollyathome.Web.UI" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:ProgressControl ID="progress1" runat="server" />
    </div>
    </form>
</body>
</html>

aspx.cs
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProgressControlExampleWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i <= 10; i++)
                {
                    ProgressControl.AddEvent(
                        new ProgressEvent(
                            progress1.ClientID, 10, i));
                    
                    Thread.Sleep(1000);
                }
            }); 
        }
    }
}

web.config
  <system.webServer>
    <handlers>
      <add name="ProgressHandler" verb="GET" path="*.progress" type="Hollyathome.Web.ProgressHandler, Hollyathome.Web"/>
    </handlers>
  </system.webServer>

