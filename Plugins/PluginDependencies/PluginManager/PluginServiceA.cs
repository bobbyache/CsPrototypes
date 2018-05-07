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
        public List<TPlugin> LoadPlugins(string pluginDirectory, PluginDirectoryScanningBehaviour pluginScanningBehaviour)
        {
            if (pluginScanningBehaviour == PluginDirectoryScanningBehaviour.PluginSubDirectories)
                return LoadSubDirectoryPlugins(Directory.EnumerateDirectories(pluginDirectory));
            else
                return LoadDirectoryPlugins(pluginDirectory);
        }

        private List<TPlugin> LoadDirectoryPlugins(string pluginDirectory)
        {
            List<TPlugin> instances = new List<TPlugin>();

            try
            {
                CompositionContainer _container = null;

                DirectoryCatalog catalog = new DirectoryCatalog(pluginDirectory);
                _container = new CompositionContainer(catalog);
                instances.AddRange(_container.GetExportedValues<TPlugin>().ToList());

                return instances;
            }
            catch (ImportCardinalityMismatchException) //when no contract implementation
            {
                return instances;
            }
            catch (ReflectionTypeLoadException) //when wrong contract implementation
            {
                return instances;
            }
            catch (FileNotFoundException) //
            {
                return instances;
            }
            catch (Exception ex)
            {
                throw new FormatException("Load plugins failed.", ex);
            }
        }

        private List<TPlugin> LoadSubDirectoryPlugins(IEnumerable<string> pluginSubDirectories)
        {
            List<TPlugin> instances = new List<TPlugin>();

            try
            {
                CompositionContainer _container = null;

                foreach (string subDirectory in pluginSubDirectories)
                {
                    DirectoryCatalog catalog = new DirectoryCatalog(subDirectory);
                    _container = new CompositionContainer(catalog);
                    instances.AddRange(_container.GetExportedValues<TPlugin>().ToList());
                }

                return instances;
            }
            catch (ImportCardinalityMismatchException) //when no contract implementation
            {
                return instances;
            }
            catch (ReflectionTypeLoadException) //when wrong contract implementation
            {
                return instances;
            }
            catch (FileNotFoundException) //
            {
                return instances;
            }
            catch (Exception ex)
            {
                throw new FormatException("Load plugins failed.", ex);
            }
        }

    }
}
