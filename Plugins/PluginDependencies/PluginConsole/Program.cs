﻿using PluginContract;
using PluginManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PluginService<IPlugin> pluginService = new PluginService<IPlugin>();
            string pluginDirectory = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Plugins");

            List<IPlugin> plugins = pluginService.LoadPlugins(pluginDirectory, PluginDirectoryScanningBehaviour.RootFolder);

            foreach (IPlugin plugin in plugins)
            {
                Console.WriteLine($"{plugin.Name} says: {plugin.SayHelloTo("ME")}");
            }

            Console.ReadLine();
        }
    }
}
