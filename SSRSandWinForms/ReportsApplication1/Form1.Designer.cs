namespace ReportsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SPC_DEV_H4CIDataSet = new ReportsApplication1.SPC_DEV_H4CIDataSet();
            this.sp_BreachHistoryReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_BreachHistoryReportTableAdapter = new ReportsApplication1.SPC_DEV_H4CIDataSetTableAdapters.sp_BreachHistoryReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SPC_DEV_H4CIDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_BreachHistoryReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sp_BreachHistoryReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportsApplication1.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(682, 386);
            this.reportViewer1.TabIndex = 0;
            // 
            // SPC_DEV_H4CIDataSet
            // 
            this.SPC_DEV_H4CIDataSet.DataSetName = "SPC_DEV_H4CIDataSet";
            this.SPC_DEV_H4CIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_BreachHistoryReportBindingSource
            // 
            this.sp_BreachHistoryReportBindingSource.DataMember = "sp_BreachHistoryReport";
            this.sp_BreachHistoryReportBindingSource.DataSource = this.SPC_DEV_H4CIDataSet;
            // 
            // sp_BreachHistoryReportTableAdapter
            // 
            this.sp_BreachHistoryReportTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 386);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SPC_DEV_H4CIDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_BreachHistoryReportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_BreachHistoryReportBindingSource;
        private SPC_DEV_H4CIDataSet SPC_DEV_H4CIDataSet;
        private SPC_DEV_H4CIDataSetTableAdapters.sp_BreachHistoryReportTableAdapter sp_BreachHistoryReportTableAdapter;
    }
}

