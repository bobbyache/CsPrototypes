using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ArtifactDrop
{
    public static class DropTargetCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand("Close", "Close", typeof(DropTargetCommands)
            ,
            new InputGestureCollection()
        {
            new KeyGesture(Key.F4, ModifierKeys.Alt),
            new KeyGesture(Key.Q, ModifierKeys.Control, "Crl + Q")
        }
        );
    }
}
