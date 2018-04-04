using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Rdl2RdlcConverter
{
    public class RdlcConverter
    {
        private XNamespace xmlns = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/reportdefinition";
        private XNamespace xmlns_rd = "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner";

        public void Convert(string filePath)
        {
            if (Path.GetExtension(filePath).ToLower() != ".rdl")
                throw new InvalidRdlFileException("The file extension is not recognised by the converter.");

            string outputFilePath = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + ".rdlc");
            File.Copy(filePath, outputFilePath);

            XDocument document = XDocument.Load(outputFilePath);

            XElement[] dataSets = GetDataSetElements(document);

            foreach (XElement dataSet in dataSets)
            {
                var dataSource = dataSet.Element(xmlns + "Query").Element(xmlns + "DataSourceName").Value;
                dataSet.RemoveNodes();
                dataSet.Add(new XElement("DataSourceName", dataSource));
                dataSet.Add(new XElement("CommandText", @"/* Local Query */"));
            }

            XElement[] dataSources = GetDataSourceElements(document);

            foreach (XElement dataSource in dataSources)
            {
                string name = dataSource.FirstAttribute.Value;
                string id = GetDataSourceId(document, name);

                dataSource.RemoveNodes();

                dataSource.Add(new XElement("ConnectionProperties",
                    new XElement("DataProvider", "System.Data.DataSet"),
                    new XElement("ConnectString", "/* Local Connection */")
                ),
                new XElement(
                    xmlns_rd + "DataSourceID", id
                ));
            }

            document.Save(outputFilePath);
        }

        internal XElement[] GetDataSetElements(XDocument document)
        {
            var dataSets = document.Element(xmlns + "Report").Element(xmlns + "DataSets").Elements(xmlns + "DataSet").ToArray();
            return dataSets;
        }

        internal XElement[] GetDataSourceElements(XDocument document)
        {
            var dataSources = document.Element(xmlns + "Report").Element(xmlns + "DataSources").Elements(xmlns + "DataSource").ToArray();
            return dataSources;
        }

        internal string GetDataSourceId(XDocument document, string dataSourceName)
        {
            var dataSources = document.Element(xmlns + "Report").Element(xmlns + "DataSources").Elements(xmlns + "DataSource").ToArray();
            return dataSources.Where(r => r.FirstAttribute.Value == dataSourceName).Single().Element(xmlns_rd + "DataSourceID").Value;
        }
    }
}
