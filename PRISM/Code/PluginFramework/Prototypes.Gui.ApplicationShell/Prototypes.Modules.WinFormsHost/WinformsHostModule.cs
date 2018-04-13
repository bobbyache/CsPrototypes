using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prototypes.Gui.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototypes.Modules.WinFormsHost
{
    [Module(ModuleName = "Winforms Host")]
    public class WinformsHostModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public WinformsHostModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }
        public void Initialize()
        {
            //throw new NotImplementedException();

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
