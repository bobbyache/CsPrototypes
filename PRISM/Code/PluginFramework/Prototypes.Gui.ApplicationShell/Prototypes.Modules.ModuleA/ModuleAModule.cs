using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prototypes.Gui.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototypes.Modules.ModuleA
{
    //[Module(ModuleName = "Module A", OnDemand = true)]
    //[ModuleDependency("Module B")]
    [Module(ModuleName = "Module A")]
    public class ModuleAModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public ModuleAModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //throw new NotImplementedException();

            // simply because one could wish to have a list of items insteaad of a single control in a view.
            // in this case the ToolbarRegion is a ItemsControl rather than a ContentControl.
            IRegion region = _regionManager.Regions[RegionNames.ToolbarRegion];
            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());

            _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ToolbarView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentView));
        }
    }
}
