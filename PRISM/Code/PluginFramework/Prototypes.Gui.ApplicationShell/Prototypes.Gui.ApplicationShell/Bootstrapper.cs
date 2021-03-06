﻿using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Modularity;

/*
 * 
 * IMPORTANT NOTE: IN ORDER FOR THIS TO ACTUALLY WORK, YOU NEED TO COPY YOUR MODULES TO A
 * "MODULES" SUB DIRECTORY IN YOUR MAIN APPS BIN DIRECTORY.
 * 
 * The WinForms stuff also requires you to add two projects:
 * 
 * 1. Input.dll
 * 2. WinformsHost.dll.
 * 
 * 
 * */

namespace Prototypes.Gui.ApplicationShell
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            base.CreateShell();
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            //return base.CreateModuleCatalog();
            return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
        }
    }
}
