using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Reflection;
using System.IO;
using System.Data.SqlClient;

namespace SsrsViewer
{
    public partial class ReportViewer: UserControl
    {
        public ReportViewer()
        {
            InitializeComponent();
        }

        public void LoadReport()
        {

            // ***************************************************************************
            BreachHistoryReportRepository repository = new BreachHistoryReportRepository("server=ROB-LT;database=SPC_DEV_H4CI;Integrated Security=True;;Connection Reset=true;");
            repository.Generate();

            // or just use this reportViewer1 GUI control.
            //Microsoft.Reporting.WinForms.ReportViewer reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            //LocalReport localReport = reportViewer.LocalReport;

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Reports\Report1.rdlc");
            localReport.DataSources.Add(new ReportDataSource("DataSet1", repository.GetBreachHistoryResults()));

            byte[] data = localReport.Render("PDF");
            File.WriteAllBytes(@"C:\MyPDf.pdf", data);
            // ***************************************************************************
        }
    }

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


    public class StoredProcedureCommandBuilder : IDisposable
    {
        private bool _isDisposed;

        public SqlCommand Command { get; }

        public StoredProcedureCommandBuilder(string storedProcedureName, SqlConnection connection)
        {
            Command = new SqlCommand(storedProcedureName, connection) { CommandType = CommandType.StoredProcedure };
        }

        ~StoredProcedureCommandBuilder()
        {
            Dispose(false);
        }

        public void AddParameter<T>(string parameterName, T value)
        {
            var type = typeof(T);
            var databaseType = GetDatabaseType(type);
            var parameter = GetParameter(parameterName, databaseType, value);

            Command.Parameters.Add(parameter);
        }

        private static SqlParameter GetParameter(string parameterName, SqlDbType databaseType, object value)
        {
            var parameter = new SqlParameter(parameterName, databaseType) { Value = value ?? DBNull.Value };
            return parameter;
        }

        private static SqlDbType GetDatabaseType(Type type)
        {
            switch (type.Name)
            {
                case "System.String":
                    return SqlDbType.NVarChar;
                case "System.DateTime":
                    return SqlDbType.DateTime;
                case "System.Int32":
                    return SqlDbType.Int;
                default:
                    return SqlDbType.NVarChar;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    Command.Dispose();
                }
            }
            _isDisposed = true;
        }
    }
}
