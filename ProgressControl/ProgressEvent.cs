using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hollyathome.Web.UI
{
    public class ProgressEvent
    {
        private string progressKey;
        private int total;
        private int count;

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

        public ProgressEvent(string progressKey, int total, int count)
        {
            this.total = total;
            this.count = count;
            this.progressKey = progressKey;
        }

        public override string ToString()
        {
            return String.Format("{{'Key':'{0}', 'Total':{1}, 'Count':{2}}}", progressKey, total, count);
        }
    }
}
