using System.Collections.Generic;

namespace PluginContract
{
    public enum PluginDirectoryScanningBehaviour
    {
        RootFolder,
        PluginSubDirectories
    }

    public interface IPluginService<TPlugin> where TPlugin : class
    {
        List<TPlugin> LoadPlugins(string pluginDirectory, PluginDirectoryScanningBehaviour pluginScanningBehaviour);
    }
}