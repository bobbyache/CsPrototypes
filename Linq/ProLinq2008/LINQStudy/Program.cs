using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQStudy.LinqToObjects;
using LINQStudy.LinqToObjects.Code;
using LINQStudy.LinqToSql;
using LINQStudy.LinqToXml;
using LINQStudy.ThinkYouCanLinq;

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

            //XmlFunctions.XmlTraversalUpDownRecursive();
            //XmlFunctions.XmlTraversalForwardBack();


            ////-------------------------------------------------
            //// Think you can linq
            ////-------------------------------------------------

            //JoinGroupByJoin.InnerJoin();
            //JoinGroupByJoin.GroupJoin();
            //JoinGroupByJoin.ToLookup();
            //JoinGroupByJoin.LeftOuterJoin();
            //LinqGenerators.GenerateRandomNumbers();

            // --------------------------------------------------

            //string path = "base/../subfolder/childfolder";
            //var parts = path.Split(new char[] { '/' });
            //var result = parts.SkipWhile(p => p != "..").Skip(1);

            //foreach (var part in result)
            //{
            //    Console.WriteLine(part);
            //}

            //LinqSetOperators.ExceptSetOperator();
            LinqSetOperators.ExceptSetOperatorWithEqualityComparer();

            Console.ReadKey();
        }
    }
}
