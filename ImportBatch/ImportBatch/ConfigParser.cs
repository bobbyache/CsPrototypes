using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ImportBatch
{
    public interface IMappableTable
    {
        string TableName { get; }
        string SourceViewName { get; }
        bool BulkCopy { get; }
        bool Enabled { get; }
    }

    public class MappableTable : IMappableTable
    {
        public string TableName { get; set; }
        public string SourceViewName { get; set; }
        public bool BulkCopy { get; set; }
        public bool Enabled { get; set; }

        public MappableTable(string tableName, string sourceViewName, bool bulkCopy, bool enabled)
        {
            this.TableName = tableName;
            this.SourceViewName = sourceViewName;
            this.BulkCopy = bulkCopy;
            this.Enabled = enabled;
        }
    }

    public class ConfigParser
    {
        private XDocument document;
        public string FilePath { get; private set; }
        public string[] TableNames
        {
            get
            {
                return document
                    .Element("importConfiguration")
                    .Element("Tables")
                    .Elements("Table")
                    .Attributes("table-name").Select(a => a.Value).ToArray();
            }
        }

        public string[] Attributes
        {
            get
            {
                return document
                    .Element("importConfiguration")
                    .Element("Attributes")
                    .Elements("Attribute")
                    .Attributes("attribute-table-name").Select(a => a.Value).ToArray();
            }
        }

        public string[] Classifications
        {
            get
            {
                return document
                    .Element("importConfiguration")
                    .Element("Classifications")
                    .Elements("Classification")
                    .Attributes("classification-type-name").Select(a => a.Value).ToArray();
            }
        }

        internal IMappableTable[] GetMappableTables()
        {
            return document
                .Element("importConfiguration")
                .Element("Tables")
                .Elements("Table")
                .Select(t => new MappableTable(t.Attribute("table-name").Value,
                    t.Attribute("source-view-name").Value,
                    bool.Parse(t.Attribute("bulk-copy").Value),
                    bool.Parse(t.Attribute("enabled").Value))).ToArray();
                ;
        }

        public ConfigParser(string filePath)
        {
            FilePath = filePath;
        }

        public void Parse()
        {
            document = XDocument.Load(FilePath);

            //TableNames = GetTableNames();
        }
    }
}
