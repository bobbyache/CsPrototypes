using PluginContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
    public class PluginService<TPlugin> : IPluginService<TPlugin>
         where TPlugin : class
    {
        //private CompositionContainer _container;

        public List<TPlugin> LoadPlugins(string pluginDirectory)
        {
            List<TPlugin> pluginList = new List<TPlugin>();

            var pluginSubDirectories = Directory.EnumerateDirectories(pluginDirectory);

            foreach (var pluginSubDirectory in pluginSubDirectories)
            {
                pluginList.AddRange(LoadPlugin(pluginSubDirectory));
            }

            return pluginList;
        }

        private List<TPlugin> LoadPlugin(string pluginDirectory)
        {
            CompositionContainer _container = null;

            List<TPlugin> instances = new List<TPlugin>();
            try
            {
                if (_container != null)
                {
                    (_container.Catalog as DirectoryCatalog).Refresh();
                    instances = _container.GetExportedValues<TPlugin>().ToList();
                }
                else
                {
                    DirectoryCatalog catalog = new DirectoryCatalog(pluginDirectory);
                    _container = new CompositionContainer(catalog);
                    instances = _container.GetExportedValues<TPlugin>().ToList();
                }

                return instances;
            }
            catch (ImportCardinalityMismatchException)//when no contract implementation
            {
                return instances;
            }
            catch (ReflectionTypeLoadException)//when wrong contract implementation
            {
                return instances;
            }
            catch (FileNotFoundException)//
            {
                return instances;
            }
            catch (Exception ex)
            {
                throw new FormatException("Load of MEF file failed.", ex);
            }
        }

    }
}
