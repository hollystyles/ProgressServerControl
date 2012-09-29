using Hollyathome.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
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