using System.Collections.Generic;

namespace PluginContract
{
    public interface IPluginService<TPlugin> where TPlugin : class
    {
        List<TPlugin> LoadPlugins(string pluginDirectory);
    }
}