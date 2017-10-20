using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public interface IAsyncStateNotifiable
    {
        void StartWork(string operationIdentifier);
        void FinishWork(string operationIdentifer);
    }

    public class AsyncWorkingControlBehaviour
    {
        public bool EnabledWhenWorking { get; set; }
        public bool EnabledWhenComplete { get; set; }
        public bool VisibleWhenWorking { get; set; }
        public bool VisibleWhenComplete { get; set; }
    }

    public class AlmControlStateNotificationCoordinator : ControlStateNotificationCoordinator
    {
        // Here you would use ControlState
    }

    public class ControlStateNotificationCoordinator : IAsyncStateNotifiable
    {
        protected List<IAsyncStateNotifiable> interestedEntities = new List<IAsyncStateNotifiable>();
        protected Dictionary<Control, AsyncWorkingControlBehaviour> controlDictionary = new Dictionary<Control, AsyncWorkingControlBehaviour>();

        public void RegisterInterface(IAsyncStateNotifiable interestedEntity)
        {
            interestedEntities.Add(interestedEntity);
        }

        public void UnregisterInterface(IAsyncStateNotifiable interestedEntity)
        {
            interestedEntities.Remove(interestedEntity);
        }

        public void RegisterControl(Control control)
        {
            RegisterControl(control, new AsyncWorkingControlBehaviour { EnabledWhenWorking = false, EnabledWhenComplete = true, VisibleWhenWorking = true, VisibleWhenComplete = true } );
        }

        public void RegisterControl(Control control, AsyncWorkingControlBehaviour workingControlBehaviour)
        {
            this.controlDictionary.Add(control, workingControlBehaviour);
        }

        public void UnregisterControl(Control control)
        {
            this.controlDictionary.Remove(control);
        }

        public void StartWork(string identifier)
        {
            foreach (IAsyncStateNotifiable interestedEntity in interestedEntities)
                interestedEntity.StartWork("");
            foreach (Control control in controlDictionary.Keys)
            {
                control.Enabled = controlDictionary[control].EnabledWhenWorking;
                control.Visible = controlDictionary[control].VisibleWhenWorking;
            }
        }

        public void FinishWork(string identifier)
        {
            foreach (IAsyncStateNotifiable interestedEntity in interestedEntities)
                interestedEntity.FinishWork("");

            foreach (Control control in controlDictionary.Keys)
            {
                control.Enabled = controlDictionary[control].EnabledWhenComplete;
                control.Visible = controlDictionary[control].VisibleWhenComplete;
            }
        }
    }
}
