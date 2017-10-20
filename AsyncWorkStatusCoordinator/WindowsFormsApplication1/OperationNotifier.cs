using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class OperationNotifier
    {
        private static Dictionary<string, Operation> operationDictionary = new Dictionary<string, Operation>();

        private class Operation
        {
            public string Identifier { get; set; }
            public List<IAsyncStateNotifiable> interestedEntities = new List<IAsyncStateNotifiable>();
            public bool Working { get; set; }
            public List<IAsyncStateNotifiable> InterestedEntities
            {
                get { return interestedEntities; }
            }
        }

        public static void Register(string identifier, IAsyncStateNotifiable interestedEntity)
        {
            Operation operation = null;

            if (operationDictionary.ContainsKey(identifier))
                operation = operationDictionary[identifier];
            else
            {
                operation = new Operation();
                operation.Identifier = identifier;
                operationDictionary.Add(identifier, operation);
            }
            operation.InterestedEntities.Add(interestedEntity);
        }

        public static void Unregister(string identifier, IAsyncStateNotifiable interestedEntity)
        {
            if (operationDictionary.ContainsKey(identifier))
            {
                Operation operation = operationDictionary[identifier];
                operation.InterestedEntities.Remove(interestedEntity);

                if (operation.InterestedEntities.Count == 0)
                    operationDictionary.Remove(operation.Identifier);
            }
        }

        public static void StartWork(string identifier)
        {
            if (operationDictionary.ContainsKey(identifier))
            {
                Operation operation = operationDictionary[identifier];
                operation.Working = true;
                foreach (IAsyncStateNotifiable interestedEntity in operation.InterestedEntities)
                    interestedEntity.StartWork(operation.Identifier);
            }
        }

        public static void FinishAllWork()
        {
            foreach (Operation operation in operationDictionary.Values)
            {
                if (operation.Working)
                {
                    foreach (IAsyncStateNotifiable interestedEntity in operation.InterestedEntities)
                        interestedEntity.FinishWork(operation.Identifier);
                    operation.Working = false;
                }
            }
        }


        public static void FinishWork(string identifier)
        {
            if (operationDictionary.ContainsKey(identifier))
            {
                Operation operation = operationDictionary[identifier];
                operation.Working = false;
                foreach (IAsyncStateNotifiable interestedEntity in operation.InterestedEntities)
                    interestedEntity.FinishWork(operation.Identifier);
            }
        }
    }
}
