using System.Data;

namespace SsrsViewer
{
    public interface IReportRenderer
    {
        string ReportPath { get; }

        void AddDataSet(string dataSetName, DataTable dataTable);
        void Render();
    }
}