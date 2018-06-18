using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prototypes.Gui.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototypes.Modules.ModuleB
{
    //[Module(ModuleName = "Module A", OnDemand = true)]
    [Module(ModuleName = "Module B")]
    public class ModuleBModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public ModuleBModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            ////throw new NotImplementedException();

            //// simply because one could wish to have a list of items insteaad of a single control in a view.
            //// in this case the ToolbarRegion is a ItemsControl rather than a ContentControl.
            //IRegion region = _regionManager.Regions[RegionNames.ToolbarRegion];
            //region.Add(_container.Resolve<ToolbarView>());

            ////can add more
            ////region.Add(_container.Resolve<ToolbarView>());
            ////region.Add(_container.Resolve<ToolbarView>());
            ////region.Add(_container.Resolve<ToolbarView>());
            ////region.Add(_container.Resolve<ToolbarView>());

            //_regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ToolbarView));
            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentView));

            _container.RegisterType<ToolbarView>();
            _container.RegisterType<IModuleBContentView, ContentView>();
            _container.RegisterType<IModuleBContentViewViewModel, ModuleBContentViewViewModel>();
            //_container.RegisterType<IModuleBContentView, ContentView>();
            //_container.RegisterType<IModuleBContentViewViewModel, ModuleBContentViewViewModel>();

            _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ToolbarView));
            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(IModuleBContentView));

            var vm = _container.Resolve<IModuleBContentView>();
            _regionManager.Regions[RegionNames.ContentRegion].Add(vm);
        }
    }
}
