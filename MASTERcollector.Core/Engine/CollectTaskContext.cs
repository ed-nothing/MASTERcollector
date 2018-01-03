using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTERcollector.Engine
{
    public class CollectTaskContext
    {
        
        public Database.IIsolatedStorage Storage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Logger Logger
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void UpdateStatus(CollectTaskStatus newStatus)
        {

        }

    }
}
