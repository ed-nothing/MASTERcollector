using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTERcollector.Plugin
{
    public interface IPlugin
    {
        Guid Identity { get; }

        void Install(PluginContext context);

        void Uninstall();

        void Load(PluginContext context);
        
        void Unload();

        Engine.ICollector CreateCollector(Engine.CollectTaskContext context);

    }
}
                 