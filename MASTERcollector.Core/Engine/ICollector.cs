using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTERcollector.Engine
{
    public interface ICollector: IDisposable
    {
        bool IsCollecting { get; }

        /// <summary>
        /// Start to collect 
        /// This MUST be a synchroniaed method.
        /// </summary>
        void Collect();

        void Pause();
        void Stop(bool isSyncCall = false);
    }
}
