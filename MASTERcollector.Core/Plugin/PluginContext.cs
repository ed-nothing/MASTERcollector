using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTERcollector.Plugin
{
    /// <summary>
    /// Context for specified plugin.
    /// The framework will create unique PluginContext instance for every plugin while first load into the memory.
    /// And the unique PlugihContext instance is accessable during the whole plugin life-cycle.
    /// You can make copies of the reference to the unique PluginContext instance.
    /// </summary>
    public class PluginContext
    {
    }
}
