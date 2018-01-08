using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MASTERcollector.Plugin
{
    public class PluginManager
    {
        #region Fields

        private List<Database.Entities.Plugin> _pluginList = new List<Database.Entities.Plugin>();

        #endregion


        #region Contructor

        internal PluginManager()
        {
        }

        #endregion

        #region Private Function

        private void Initialize()
        {
            //Load plugin configuration from database.
            using (var context = Framework.GetInstance().Database.GetCurrentContext())
            {
                context.EnumPluginsInfo((index, pluginInfo) =>
                {
                    _pluginList.Add(pluginInfo);
                });
            }

            //Preload all plugin.
            //Create plugin instance.

        }

        private IPlugin LoadPluginInstance(Database.Entities.Plugin pluginInfo)
        {
            string pluginDllPath = Framework.GetInstance().GetPluginDllPath(pluginInfo);

            var assambly = Assembly.LoadFrom(pluginDllPath);

            var pluginInstance = assambly.CreateInstance(pluginInfo.PluginClassPath) as IPlugin;

            return pluginInstance;

        }

        #endregion
    }
}
