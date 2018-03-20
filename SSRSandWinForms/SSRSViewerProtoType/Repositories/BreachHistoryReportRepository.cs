using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRSViewerPrototType.Repositories
{
    public class BreachHistoryReportRepository
    {
        private DataSet _dataSet;


        private string connectionString = "";
        public string ReportName => "BreachHistoryReportLayout.rpx";

        public BreachHistoryReportRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable GetBreachHistoryResults()
        {
            if (_dataSet == null)
                throw new ApplicationException(
                    "The report has not been generated yet. Generate the report with the applicable criteria before calling this method.");
            return _dataSet.Tables["Default"];
        }

        public DataView GetBreachHistoryResultsByBreachId(int breachId)
        {
            if (_dataSet == null)
                throw new ApplicationException(
                    "The report has not been generated yet. Generate the report with the applicable criteria before calling this method.");

            var results = from row in _dataSet.Tables["BreachResults"].AsEnumerable()
                          where row.Field<int>("BreachId") == breachId
                          select row;

            var dataView = results.AsDataView();
            return dataView;
        }

        public DataView GetBreachHistoryCommentsByBreachId(int breachId)
        {
            if (_dataSet == null)
                throw new ApplicationException(
                    "The report has not been generated yet. Generate the report with the applicable criteria before calling this method.");

            var results = from row in _dataSet.Tables["BreachComments"].AsEnumerable()
                          where row.Field<int>("BreachId") == breachId
                          select row;

            var dataView = results.AsDataView();
            return dataView;
        }

        public void Generate()
        {
            _dataSet = new DataSet();

            using (var sqlConnection = new SqlConnection(connectionString))
            using (var commandBuilder = new StoredProcedureCommandBuilder("sp_BreachHistoryReport", sqlConnection))
            using (var dataAdapter = new SqlDataAdapter(commandBuilder.Command))
            {
                commandBuilder.AddParameter("@StartDate", DateTime.Parse("2018-01-01"));
                commandBuilder.AddParameter("@EndDate", DateTime.Parse("2018-03-30"));
                commandBuilder.AddParameter<int?>("@BucketFilterType", 1);
                commandBuilder.AddParameter<int?>("@ProcessingResult", 3);
                commandBuilder.AddParameter<int?>("@BreachStatus", null);
                commandBuilder.AddParameter<int?>("@ContextType", null);
                commandBuilder.AddParameter<int?>("@RuleId", null);
                commandBuilder.AddParameter<string>("@RuleIdList", null);
                commandBuilder.AddParameter<int?>("@RuleGroupId", null);
                commandBuilder.AddParameter<string>("@RuleGroupIdList", null);
                commandBuilder.AddParameter<int?>("@RuleContextId", null);
                commandBuilder.AddParameter<int?>("@PortfolioId", null);
                commandBuilder.AddParameter<string>("@PortfolioIdList", null);
                commandBuilder.AddParameter<int?>("@PortfolioContextId", null);
                commandBuilder.AddParameter<int?>("@CompositeId", null);
                commandBuilder.AddParameter<string>("@CompositeIdList", null);
                commandBuilder.AddParameter<int?>("@AggregateTypeId", null);
                commandBuilder.AddParameter<string>("@AggregateIdList", null);
                commandBuilder.AddParameter<int?>("@AggregateId", null);
                commandBuilder.AddParameter("@IncludeInstrumentDerivatives", false);
                commandBuilder.AddParameter("@IncludeNoAggregates", false);

                dataAdapter.Fill(_dataSet);

                _dataSet.Tables[0].TableName = "Default";
                _dataSet.Tables[1].TableName = "BreachResults";
                _dataSet.Tables[2].TableName = "BreachComments";
            }
        }
    }
}
