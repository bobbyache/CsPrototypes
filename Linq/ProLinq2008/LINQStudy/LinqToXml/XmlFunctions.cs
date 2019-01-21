using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace LINQStudy.LinqToXml
{
    public class XmlFunctions
    {
        public static void SimpleXmlCreation()
        {
            XElement xBookParticipants = new XElement("BookParticipants",
                new XElement("BookParticipant",
                    new XAttribute("type", "Author"),
                    new XElement("FirstName", "Joe"),
                    new XElement("LastName", "Rattz")),
                new XElement("BookParticipant",
                    new XAttribute("type", "Editor"),
                    new XElement("FirstName", "Ewan"),
                    new XElement("LastName", "Buckingham")));

            Console.WriteLine(xBookParticipants.ToString());
            //Console.WriteLine(xBookParticipants.ToString());
        }

        public static void SaveCarInventory()
        {
            XElement doc = new XElement("Inventory", new XElement("Car", new XAttribute("ID", "1000"),
                                            new XElement("PetName", "Jimbo"),
                                            new XElement("Color", "Red"),
                                            new XElement("Make", "Ford")
                                         )
                            );
            doc.Save("InventoryWithLINQ.xml");
        }

        public static void CreateFullXDocument()
        {
            // Lookup C# parameter arrays: Allows an array of parameters
            // XDocument constructor uses this ability.
            XDocument inventoryDoc =
            new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Current Inventory of cars!"),
                new XProcessingInstruction("xml-stylesheet",
                    "href='MyStyles.css' title='Compact' type='text/css'"),
                new XElement("Inventory",
                    new XElement("Car", new XAttribute("ID", "1"),
                        new XElement("Color", "Green"),
                        new XElement("Make", "BMW"),
                        new XElement("PetName", "Stan")
                    ),
                    new XElement("Car", new XAttribute("ID", "2"),
                        new XElement("Color", "Pink"),
                        new XElement("Make", "Yugo"),
                        new XElement("PetName", "Melvin")
                    )
                )
            );
            // Save to disk.
            Console.WriteLine(inventoryDoc.ToString());
            //inventoryDoc.Save("C:\\SimpleInventory.xml");
        }

        public static void CreateRootAndChildren()
        {
            XElement inventoryDoc =
            new XElement("Inventory",
            new XComment("Current Inventory of cars!"),
                new XElement("Car", new XAttribute("ID", "1"),
                    new XElement("Color", "Green"),
                    new XElement("Make", "BMW"),
                    new XElement("PetName", "Stan")
                ),
                new XElement("Car", new XAttribute("ID", "2"),
                    new XElement("Color", "Pink"),
                    new XElement("Make", "Yugo"),
                    new XElement("PetName", "Melvin")
                )
            );

            Console.WriteLine(inventoryDoc.ToString());
            //// Save to disk.
            //inventoryDoc.Save("SimpleInventory.xml");
        }

        public static void MakeXElementFromArray()
        {
            // Create an anonymous array of anonymous types.
            var people = new[] {
                new { FirstName = "Mandy", Age = 32},
                new { FirstName = "Andrew", Age = 40 },
                new { FirstName = "Dave", Age = 41 },
                new { FirstName = "Sara", Age = 31}
            };

            XElement peopleDoc = new XElement("People",
                from c in people
                select
                    new XElement("Person", new XAttribute("Age", c.Age),
                    new XElement("FirstName", c.FirstName))
                );

            Console.WriteLine(peopleDoc);
        }

        public static void MakeXElementFromArray2()
        {
            // Create an anonymous array of anonymous types.
            var people = new[] {
                new { FirstName = "Mandy", Age = 32},
                new { FirstName = "Andrew", Age = 40 },
                new { FirstName = "Dave", Age = 41 },
                new { FirstName = "Sara", Age = 31}
                };

            var arrayDataAsXElements = from c in people
                                       select
                                        new XElement("Person",
                                            new XAttribute("Age", c.Age),
                                            new XElement("FirstName", c.FirstName));

            XElement peopleDoc = new XElement("People", arrayDataAsXElements);
            Console.WriteLine(peopleDoc);
        }

        public static void ParseAndLoadExistingXml()
        {
            // Build an XElement from string.
            string myElement =
                @"<Car ID ='3'>
                    <Color>Yellow</Color>
                    <Make>Yugo</Make>
                </Car>";

            XElement newElement = XElement.Parse(myElement);
            Console.WriteLine(newElement);
            Console.WriteLine();

            // Load the SimpleInventory.xml file.
            XDocument myDoc = XDocument.Load("SimpleInventory.xml");
            Console.WriteLine(myDoc);
        }

        public static void NamespacedElement()
        {
            //XNamespace nameSpace = "http://www.linqdev.com";
            //XElement xBookParticipants = new XElement(nameSpace + "BookParticipants");

            //// it is not even necessary to create a namespace object!
            //XElement xBookParticipants2 = new XElement("{http://www.linqdev.com}" + "BookParticipants");


            XNamespace nameSpace = "http://ww.linqdev.com";
            XElement xBookParticipants =
                new XElement(nameSpace + "BookParticipants",
                    new XElement(nameSpace + "BookParticipant",
                        new XAttribute("type", "Author"),
                        new XElement(nameSpace + "FirstName", "Joe"),
                        new XElement(nameSpace + "LastName", "Rattz")),
                    new XElement(nameSpace + "BookParticipant",
                        new XAttribute("type", "Editor"),
                        new XElement(nameSpace + "FirstName", "Ewan"),
                        new XElement(nameSpace + "LastName", "Buckingham")));

            Console.WriteLine(xBookParticipants.ToString());
            Console.WriteLine("");

            // specifying namespace prefixes...
            XNamespace nameSpace2 = "http://www.linqdev.com";
            XElement xBookParticipants2 =
                new XElement(nameSpace2 + "BookParticipants",
                    new XAttribute(XNamespace.Xmlns + "linqdev", nameSpace2),
                    new XElement(nameSpace2 + "BookParticipant"));

            Console.WriteLine(xBookParticipants2.ToString());
        }

        public static void NodeValueExtractionOptions()
        {
            // output node xml using explicit ToString()
            XElement name = new XElement("Name", "Joe");
            Console.WriteLine(name.ToString());

            // output node xml using implicit ToString()
            XElement name2 = new XElement("Person", new XElement("FirstName", "Joe"), new XElement("LastName", "Rattz"));
            Console.WriteLine(name2);

            // -- VALUE ONLY - Cast operators enable the following --

            //output only the value by casting type to string.
            XElement name3 = new XElement("Name", "Joe");
            Console.WriteLine(name3);
            Console.WriteLine((string)name3);

            //output the value by casting to other types.
            XElement count = new XElement("Count", 12);
            Console.WriteLine(count);
            Console.WriteLine((int)count);

            XElement smoker = new XElement("Smoker", false);
            Console.WriteLine(smoker);
            Console.WriteLine((bool)smoker);


            XElement pi = new XElement("Pi", 3.1415926535);
            Console.WriteLine(pi);
            Console.WriteLine((double)pi);

        }

        public static void TheHalloweenProblem()
        {

            // P.204 Pro LINQ 2008 (PDF P.228) - for more detail
            //The problem is basically any problem that occurs by changing data that is 
            //being iterated over that affects the iteration

            // This code creates one manifestation of the halloween problem.
            XDocument xDocument = new XDocument(
                new XElement("BookParticipants",
                    new XElement("BookParticipant",
                        new XAttribute("type", "Author"),
                        new XElement("FirstName", "Joe"),
                        new XElement("LastName", "Rattz")),
                    new XElement("BookParticipant",
                        new XAttribute("type", "Editor"),
                        new XElement("FirstName", "Ewan"),
                        new XElement("LastName", "Buckingham"))));


            IEnumerable<XElement> elements = xDocument.Element("BookParticipants").Elements("BookParticipant");
            foreach (XElement element in elements)
                Console.WriteLine("Source element: {0} : value = {1}", element.Name, element.Value);

            foreach (XElement element in elements)
            {
                // iterates once only!
                Console.WriteLine("Removing {0} = {1} ...", element.Name, element.Value);
                element.Remove();
            }

            // Only one got removed !!!
            Console.WriteLine(xDocument);
        }

        public static void AvoidTheHalloweenProblem()
        {
            XDocument xDocument = new XDocument(
                new XElement("BookParticipants",
                    new XElement("BookParticipant",
                        new XAttribute("type", "Author"),
                        new XElement("FirstName", "Joe"),
                        new XElement("LastName", "Rattz")),
                    new XElement("BookParticipant",
                        new XAttribute("type", "Editor"),
                        new XElement("FirstName", "Ewan"),
                        new XElement("LastName", "Buckingham"))));

            IEnumerable<XElement> elements = xDocument.Element("BookParticipants").Elements("BookParticipant");
            foreach (XElement element in elements)
                Console.WriteLine("Source element: {0} : value = {1}", element.Name, element.Value);


            // Avoid the problem by caching ToArray()...
            foreach (XElement element in elements.ToArray())
            {
                Console.WriteLine("Removing {0} = {1} ...", element.Name, element.Value);
                element.Remove();
            }

            Console.WriteLine(xDocument);
        }

        public static void CreateProcessingInstructions()
        {
            XDocument xDocument = new XDocument(
                new XProcessingInstruction("BookCataloger", "out-of-print"),
                new XElement("BookParticipants",
                    new XElement("BookParticipant",
                        new XProcessingInstruction("ParticipantDeleter", "delete"),
                        new XElement("FirstName", "Joe"),
                        new XElement("LastName", "Rattz"))));

            Console.WriteLine(xDocument);
        }

        public static void CreateProcessingInstructionAfter()
        {
            XDocument xDocument =
                new XDocument(new XElement("BookParticipants",
                    new XElement("BookParticipant",
                        new XElement("FirstName", "Joe"),
                        new XElement("LastName", "Rattz"))));

            XProcessingInstruction xPI1 = new XProcessingInstruction("BookCataloger",
                "out-of-print");
            xDocument.AddFirst(xPI1);

            XProcessingInstruction xPI2 = new XProcessingInstruction("ParticipantDeleter",
                "delete");

            XElement outOfPrintParticipant = xDocument
                .Element("BookParticipants")
                .Elements("BookParticipant")
                .Where(e => ((string)((XElement)e).Element("FirstName")) == "Joe"
                && ((string)((XElement)e).Element("LastName")) == "Rattz")
                .Single<XElement>();

            outOfPrintParticipant.AddFirst(xPI2);
            Console.WriteLine(xDocument);
        }

        public static void DeferredExecutionWithStreamingElement()
        {
            string[] names = { "John", "Paul", "George", "Pete" };

            //xNames fully created.
            XElement xNames = new XElement("Beatles",
                                        from n in names
                                        select new XElement("Name", n));

            // obviously changing the array value now, will not affect xNames
            // and xNames hasn't been enumerated yet.
            names[3] = "Ringo";
            Console.WriteLine(xNames);

            Console.WriteLine("Ringo has not replaced Pete in the output");
            Console.WriteLine("");



            string[] names2 = { "John", "Paul", "George", "Pete" };

            XStreamingElement xNames2 = new XStreamingElement("Beatles",
                from n in names2
                select new XElement("Name", n));

            names2[3] = "Ringo";
            Console.WriteLine(xNames2);

            Console.WriteLine("Ringo has replaced Pete!");
        }

        public static void CreateATextNode()
        {
            XText xName = new XText("Joe");
            XElement xFirstName = new XElement("FirstName", xName);
            Console.WriteLine(xFirstName);
        }

        public static void CreateCData()
        {
            XElement xErrorMessage = new XElement("HTMLMessage",
                new XCData("<H1>Invalid user id or password.</H1>"));
            Console.WriteLine(xErrorMessage);
        }

        public static void SavingDocumentsAndElements()
        {
            // can also use XDocument
            XElement bookParticipants =
                new XElement("BookParticipants",
                    new XElement("BookParticipant",
                        new XAttribute("type", "Author"),
                        new XAttribute("experience", "first-time"),
                        new XAttribute("language", "English"),
                        new XElement("FirstName", "Rob"),
                        new XElement("LastName", "Blake")));

            bookParticipants.Save("bookParticipants.xml");
        }

        public static void LoadingDocumentsAndElements()
        {
            // can also load from XElement
            XDocument xDocument = XDocument.Load("bookparticipants.xml",
                LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);

            Console.WriteLine(xDocument);

            XElement firstName = xDocument.Descendants("FirstName").First();

            // FirstName output is listed at position 4 although it's in position three.
            // this is because the document declaration is omitted from the output.
            Console.WriteLine("FirstName Line:{0} - Position:{1}",
                ((IXmlLineInfo)firstName).LineNumber, ((IXmlLineInfo)firstName).LineNumber);

            Console.WriteLine("FirstName Base URI:{0}", firstName.BaseUri);
        }

        public static void ParseStringToXmlElement()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><BookParticipants>" +
                "<BookParticipant type=\"Author\" experience=\"first-time\" language=" +
                "\"English\"><FirstName>Joe</FirstName><LastName>Rattz</LastName>" +
                "</BookParticipant></BookParticipants>";

            XElement xElement = XElement.Parse(xml);
            Console.WriteLine(xElement);
        }

        public static void XmlTraversalSingle()
        {
            // I will use this to store a reference to one of the elements in the XML tree.
            XElement firstParticipant;

            XDocument xDocument = new XDocument(
                new XDeclaration("1.0", "UTF-8", "yes"),
                new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
                new XProcessingInstruction("BookCataloger", "out-of-print"),
                // Notice on the next line that I am saving off a reference to the first
                // BookParticipant element.
                new XElement("BookParticipants", firstParticipant =
                    new XElement("BookParticipant",
                        new XAttribute("type", "Author"),
                        new XElement("FirstName", "Joe"),
                        new XElement("LastName", "Rattz")),
                    new XElement("BookParticipant",
                        new XAttribute("type", "Editor"),
                        new XElement("FirstName", "Ewan"),
                        new XElement("LastName", "Buckingham"))));

            //Console.WriteLine((string)(firstParticipant.NextNode as XElement));

            Console.WriteLine(firstParticipant.NextNode);
            Console.WriteLine(firstParticipant.NextNode.PreviousNode);
            Console.WriteLine(firstParticipant.PreviousNode == null ? "null" : "not null");
            Console.WriteLine(firstParticipant.Document);
            Console.WriteLine(firstParticipant.Parent);

            Console.WriteLine(firstParticipant.Element("FirstName"));

            //Console.WriteLine(xDocument);
        }

        public static void XmlTraversalMultiple()
        {
            // I will use this to store a reference to one of the elements in the XML tree.
            XElement firstParticipant;

            XDocument xDocument = new XDocument(
                new XDeclaration("1.0", "UTF-8", "yes"),
                new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
                new XProcessingInstruction("BookCataloger", "out-of-print"),
                // Notice on the next line that I am saving off a reference to the first
                // BookParticipant element.
                new XElement("BookParticipants", firstParticipant =
                    new XElement("BookParticipant",
                        new XAttribute("type", "Author"),
                        new XElement("FirstName", "Joe"),
                        new XElement("LastName", "Rattz")),
                    new XElement("BookParticipant",
                        new XAttribute("type", "Editor"),
                        new XElement("FirstName", "Ewan"),
                        new XElement("LastName", "Buckingham"))));

            foreach (XNode node in firstParticipant.Nodes())
                Console.WriteLine(node);


        }

        public static void XmlTraversalMultiple2()
        {
            // I will use this to store a reference to one of the elements in the XML tree.
            XElement firstParticipant;

            XDocument xDocument = new XDocument(
                new XDeclaration("1.0", "UTF-8", "yes"),
                new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
                new XProcessingInstruction("BookCataloger", "out-of-print"),

                // Notice on the next line that I am saving off a reference to the first
                // BookParticipant element.
                new XElement("BookParticipants", firstParticipant =
                    new XElement("BookParticipant",
                        new XComment("This is a new author."),
                        new XProcessingInstruction("AuthorHandler", "new"),
                        new XAttribute("type", "Author"),
                        new XElement("FirstName", "Joe"),
                        new XElement("LastName", "Rattz")),
                    new XElement("BookParticipant",
                        new XAttribute("type", "Editor"),
                        new XElement("FirstName", "Ewan"),
                        new XElement("LastName", "Buckingham"))));

            foreach (XNode node in firstParticipant.Nodes())
                Console.WriteLine(node);

            Console.WriteLine();

            foreach (XNode node in firstParticipant.Nodes().OfType<XElement>())
                Console.WriteLine(node);

            Console.WriteLine();

            foreach (XElement element in firstParticipant.Elements())
                Console.WriteLine(element);

            foreach (XElement element in firstParticipant.Elements("FirstName"))
                Console.WriteLine(element);

            Console.WriteLine();

            foreach (XNode node in firstParticipant.Nodes().OfType<XComment>())
                Console.WriteLine(node);

            Console.WriteLine();

            foreach (XAttribute attr in firstParticipant.Attributes())
                Console.WriteLine(attr);

        }


        public static void XmlTraversalUpDownRecursive()
        {
            // I will use this to store a reference to one of the elements in the XML tree.
            XElement firstParticipant;

            XDocument xDocument = new XDocument(
                new XDeclaration("1.0", "UTF-8", "yes"),
                new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
                new XProcessingInstruction("BookCataloger", "out-of-print"),

                // Notice on the next line that I am saving off a reference to the first
                // BookParticipant element.
                new XElement("BookParticipants", firstParticipant =
                    new XElement("BookParticipant",
                        new XComment("This is a new author."),
                        new XProcessingInstruction("AuthorHandler", "new"),
                        new XAttribute("type", "Author"),
                        new XElement("FirstName",
                            new XText("Joe"),
                            new XElement("NickName", "Joey")),
                        new XElement("LastName", "Rattz")),
                    new XElement("BookParticipant",
                        new XAttribute("type", "Editor"),
                        new XElement("FirstName", "Ewan"),
                        new XElement("LastName", "Buckingham"))));

            //foreach (XElement element in firstParticipant.Element("FirstName").Element("NickName").Ancestors())
            //    Console.WriteLine(element.Name);

            //foreach (XElement element in firstParticipant.Element("FirstName").Element("NickName").AncestorsAndSelf())
            //    Console.WriteLine(element.Name);

            foreach (XElement element in firstParticipant.Descendants())
                Console.WriteLine(element.Name);

            //foreach (XElement element in firstParticipant.DescendantsAndSelf())
            //    Console.WriteLine(element.Name);

        }

        public static void XmlTraversalForwardBack()
        {
            // I will use this to store a reference to one of the elements in the XML tree.
            XElement firstParticipant;

            XDocument xDocument = new XDocument(
                new XDeclaration("1.0", "UTF-8", "yes"),
                new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
                new XProcessingInstruction("BookCataloger", "out-of-print"),

                // Notice on the next line that I am saving off a reference to the first
                // BookParticipant element.
                new XElement("BookParticipants",
                    new XComment("Begin of List"),
                    firstParticipant = new XElement("BookParticipant",
                        new XComment("This is a new author."),
                        new XProcessingInstruction("AuthorHandler", "new"),
                        new XAttribute("type", "Author"),
                        new XElement("FirstName",
                            new XText("Joe"),
                            new XElement("NickName", "Joey")),
                        new XElement("LastName", "Rattz")),
                    new XElement("BookParticipant",
                        new XAttribute("type", "Editor"),
                        new XElement("FirstName", "Ewan"),
                        new XElement("LastName", "Buckingham")),
                    new XComment("End of List")));


            foreach (XNode node in firstParticipant.NodesAfterSelf())
                Console.WriteLine(node);

            foreach (XNode node in firstParticipant.NodesBeforeSelf())
                Console.WriteLine(node);

            foreach (XElement element in firstParticipant.ElementsAfterSelf())
                Console.WriteLine(element);

            foreach (XElement element in firstParticipant.ElementsBeforeSelf())
                Console.WriteLine(element);

        }
    }
}
