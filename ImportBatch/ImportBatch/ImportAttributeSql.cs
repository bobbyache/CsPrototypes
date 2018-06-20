using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportBatch
{
    public enum OperationType
    {
        Insert,
        Update
    }

    public class ImportAttributeSql
    {
        public string GetImportAttributesSQL(string importDatabase, string[] columns, string type, OperationType operationType)
        {
            return
                "SELECT " +
                "	attributeType.IdKey as [AttributeTypeId], " +
                "	unpvt.[InstanceId] as [InstanceId], " +
                "	unpvt.SourceValue as [ValueBool] " +
                "FROM " +
                "( " +
                "	SELECT " +
                "		IdKey as [InstanceId], " +

                GetSelectList(columns, type) + Environment.NewLine +

                "	FROM " +
                "		[vw_compliance_export_instrument] " +
                ") mod_inst " +
                "UNPIVOT " +
                "( " +
                "	 SourceValue " +
                "	 for SourceFieldName in " +
                "	 ( " +

                GetPivotList(columns) + Environment.NewLine +

                "	 ) " +
                ") unpvt " +
                "JOIN Mappings m on m.FieldName = unpvt.SourceFieldName " +
                $"JOIN [{importDatabase}].[dbo].[AttributeType] attributeType on attributeType.Name = m.AttributeTypeName " +
                "LEFT JOIN [AttributeValue] av ON av.[AttributeTypeId] = attributeType.IdKey AND av.[InstanceId] = unpvt.[InstanceId] " +
                "WHERE " +
                (operationType == OperationType.Update ? "	av.IdKey is NOT NULL" : " av.IdKey is null");
        }

        private string DblQuotedText(string text)
        {
            return "" + text + "";
        }

        private string GetSelectList(string[] columns, string type)
        {
            return string.Join(",", columns.Select(c => $"CAST({c} as {type}) {c}"));
        }

        private string GetPivotList(string[] columns)
        {
            return string.Join(",", columns.Select(c => $"		{c}"));
        }
    }
}
