using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRSViewerPrototType.Repositories
{
    public class WeightVsLimitScheduleRepository
    {
        private DataSet _dataSet;


        private string connectionString = "";
        public string ReportName => "BreachHistoryReportLayout.rpx";

        public WeightVsLimitScheduleRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable Get()
        {
            if (_dataSet == null)
                throw new ApplicationException(
                    "The report has not been generated yet. Generate the report with the applicable criteria before calling this method.");
            return _dataSet.Tables["Default"];
        }


        public void Generate()
        {
            _dataSet = new DataSet();

            using (var sqlConnection = new SqlConnection(connectionString))
            using (var commandBuilder = new StoredProcedureCommandBuilder("sp_WeightVsLimitScheduleReport", sqlConnection))
            using (var dataAdapter = new SqlDataAdapter(commandBuilder.Command))
            {
                commandBuilder.AddParameter<int?>("@SessionId", 521);
                commandBuilder.AddParameter<int?>("@RuleId", null);
                commandBuilder.AddParameter<string>("@RuleIdList", null);
                commandBuilder.AddParameter<int?>("@RuleGroupId", null);
                commandBuilder.AddParameter<int?>("@PortfolioId", null);

                dataAdapter.Fill(_dataSet);

                _dataSet.Tables[0].TableName = "Default";
                //_dataSet.Tables[1].TableName = "BreachResults";
                //_dataSet.Tables[2].TableName = "BreachComments";
            }
        }
    }
}
