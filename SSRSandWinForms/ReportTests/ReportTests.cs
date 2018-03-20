using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SsrsViewer;
using System.IO;

namespace ReportTests
{
    [TestClass]
    public class ReportTests
    {
        [TestMethod]
        public void CategorizedAutoReport_When_Instantiated_Has_Correct_State()
        {
            CategorizedAutoReport report = new CategorizedAutoReport(ReportTypeEnum.WeightVsLimitSchedule, "PDF", "C:\\outputfolder\\file.pdf");

            Assert.AreEqual(report.OutputPath, "C:\\outputfolder\\file.pdf");
            Assert.AreEqual(report.OutputType, "PDF");
            Assert.AreEqual("WeightVsLimitSchedule.rdlc", Path.GetFileName(report.ReportPath));
        }

        [TestMethod]
        public void AutoReport_When_Instantiated_Has_Correct_State()
        {
            AutoReport report = new AutoReport("C:\\outputfolder\\WeightVsLimitSchedule.rdlc", "PDF", "C:\\outputfolder\\file.pdf");

            Assert.AreEqual(report.OutputPath, "C:\\outputfolder\\file.pdf");
            Assert.AreEqual(report.OutputType, "PDF");
            Assert.AreEqual("WeightVsLimitSchedule.rdlc", Path.GetFileName(report.ReportPath));
        }

        [TestMethod]
        public void CategorizedReportViewer_When_Instantiated_Has_Correct_State()
        {
            ReportViewer report = new ReportViewer();
            report.ReportPath = "C:\\outputfolder\\WeightVsLimitSchedule.rdlc";

            Assert.AreEqual("WeightVsLimitSchedule.rdlc", Path.GetFileName(report.ReportPath));
        }
    }
}
