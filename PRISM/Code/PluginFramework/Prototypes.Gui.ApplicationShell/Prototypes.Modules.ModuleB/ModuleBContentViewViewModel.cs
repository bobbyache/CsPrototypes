using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototypes.Gui.Infrastucture;

namespace Prototypes.Modules.ModuleB
{
    public class ModuleBContentViewViewModel : IModuleBContentViewViewModel
    {
        public IView View { get; set; }

        public ModuleBContentViewViewModel(IModuleBContentView view)
        {
            View = view;
            View.ViewModel = this;
        }
    }
}
