using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Hollyathome.Web.UI
{
    public class ProgressEvent
    {
        private string sessionId;
        private string progressKey;
        private int total;
        private int count;

        public string SessionId
        {
            get
            {
                return sessionId;
            }
        }

        public string ProgressKey
        {
            get
            {
                return progressKey;
            }
        }

        public int Total
        {
            get
            {
                return total;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public ProgressEvent(string sessionId, string progressKey, int total, int count)
        {
            this.total = total;
            this.count = count;
            this.progressKey = progressKey;
            this.sessionId = sessionId;
        }

        public override string ToString()
        {
            return String.Format("{{'Key':'{0}', 'Total':{1}, 'Count':{2}}}", progressKey, total, count);
        }
    }
}
