using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQStudy.LinqToObjects;
using LINQStudy.LinqToSql;
using LINQStudy.LinqToXml;

namespace LINQStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            ////-------------------------------------------------
            //// Link 2 Objects
            ////-------------------------------------------------
            //LinqSelect.BasicUsingWhere();
            //LinqSelect.ReturnAnonymousType();
            //LinqSelectMany.BasicSyntax();
            //LinqSelectMany.SelectEmployeeOptions();
            //LinqSelect.ReturnAnonymousType();

            //LinqPartitioning.BasicTake();
            //LinqPartitioning.EfficientTake();
            //LinqPartitioning.BasicConcat();
            //LinqPartitioning.ConcatWithoutConcat();
            //LinqPartitioning.BasicOrdering();
            //LinqPartitioning.OrderingWithIComparer();
            //LinqPartitioning.OrderDescendingWithIComparer();
            //LinqPartitioning.BasicOrderingThenBy();
            //LinqPartitioning.OrderingThenByWithIComparer();
            //LinqJoining.BasicJoin();
            //LinqJoining.BasicGroupJoin();
            //LinqGrouping.GroupBy();
            //LinqGrouping.GroupByNumberComparer();
            //LinqGrouping.GroupByDateTime();
            //LinqGrouping.GroupByNumberComparerAndDate();

            //LinqGrouping.GroupEmployeesByFirstLetter();
            ////-------------------------------------------------

            //// Link 2 SQL
            ////-------------------------------------------------
            //StandardOperations.InsertCustomer();
            //StandardOperations.InsertOrderUsingEntitySet();
            //StandardOperations.InsertAttachedOrder();
            //StandardOperations.SelectCustomersInLondon();
            //StandardOperations.SelectCustomerOrders();


            //StandardOperations.DeferredLoad();
            //StandardOperations.ImmediateLoad();
            //StandardOperations.ImmediateLoadMultiple();
            //StandardOperations.ImmediateLoadHierarchy();
            //StandardOperations.LoadWithFilterAndOrdering();

            //StandardOperations.InnerJoin();
            //StandardOperations.OuterJoinFlattened();

            //StandardOperations.UseOverrides();


            ////-------------------------------------------------

            //// Link 2 XML
            ////-------------------------------------------------
            //XmlFunctions.SimpleXmlCreation();
            //XmlFunctions.SaveCarInventory();
            //XmlFunctions.CreateFullXDocument();
            //XmlFunctions.MakeXElementFromArray();
            //XmlFunctions.MakeXElementFromArray2();
            //XmlFunctions.CreateRootAndChildren();

            //XmlFunctions.ParseAndLoadExistingXml();
            //XmlFunctions.NamespacedElement();

            //NodeValueExtraction
            //XmlFunctions.NodeValueExtractionOptions();
            
            //XmlFunctions.TheHalloweenProblem();
            //XmlFunctions.AvoidTheHalloweenProblem();

            //XmlFunctions.CreateProcessingInstructions();
            //XmlFunctions.CreateProcessingInstructionAfter();

            //XmlFunctions.DeferredExecutionWithStreamingElement();
            //XmlFunctions.CreateATextNode();
            //XmlFunctions.CreateCData();

            //XmlFunctions.SaveCarInventory();
            //XmlFunctions.SavingDocumentsAndElements();
            //XmlFunctions.LoadingDocumentsAndElements();

            //XmlFunctions.ParseStringToXmlElement();
           // XmlFunctions.XmlTraversalSingle();
            //XmlFunctions.XmlTraversalMultiple();
            //XmlFunctions.XmlTraversalMultiple2();

            XmlFunctions.XmlTraversalUpDownRecursive();
            //XmlFunctions.XmlTraversalForwardBack();

            Console.ReadKey();
        }
    }
}
