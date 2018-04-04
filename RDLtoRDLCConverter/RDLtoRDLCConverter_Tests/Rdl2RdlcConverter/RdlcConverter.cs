using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Rdl2RdlcConverter
{
    internal class RdlcConverter
    {
        private XNamespace xmlns = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/reportdefinition";
        private XNamespace xmlns_rd = "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner";

        private string TargetFilePath(string targetFile, string targetFolder = null)
        {
            if (!string.IsNullOrWhiteSpace(targetFolder))
                return Path.Combine(targetFolder, Path.GetFileNameWithoutExtension(targetFile) + ".rdlc");
            else
                return Path.Combine(Path.GetDirectoryName(targetFile), Path.GetFileNameWithoutExtension(targetFile) + ".rdlc");
        }

        public void Convert(string targetFile, string targetFolder = null)
        {
            if (Path.GetExtension(targetFile).ToLower() != ".rdl")
                throw new InvalidRdlFileException("The file extension is not recognised by the converter.");

            string outputFilePath = TargetFilePath(targetFile, targetFolder);
            File.Copy(targetFile, outputFilePath, true);

            XDocument document = XDocument.Load(outputFilePath);

            XElement[] dataSets = GetDataSetElements(document);

            foreach (XElement dataSet in dataSets)
            {
                var dataSource = dataSet.Element(xmlns + "Query").Element(xmlns + "DataSourceName").Value;
                XElement fieldsElement = dataSet.Element(xmlns + "Fields");

                dataSet.RemoveNodes();

                XElement queryElement = new XElement(xmlns + "Query",
                    new XElement(xmlns + "DataSourceName", dataSource),
                    new XElement(xmlns + "CommandText", @"/* Local Query */")
                    );

                //dataSet.Add(new XElement(xmlns + "DataSourceName", dataSource));
                //dataSet.Add(new XElement(xmlns + "CommandText", @"/* Local Query */"));
                dataSet.Add(queryElement);
                dataSet.Add(fieldsElement);
            }

            XElement[] dataSources = GetDataSourceElements(document);

            foreach (XElement dataSource in dataSources)
            {
                string name = dataSource.FirstAttribute.Value;
                string id = GetDataSourceId(document, name);

                

                dataSource.RemoveNodes();
                

                dataSource.Add(new XElement(xmlns + "ConnectionProperties",
                    new XElement(xmlns + "DataProvider", "System.Data.DataSet"),
                    new XElement(xmlns + "ConnectString", "/* Local Connection */")
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
