namespace shopsystem
{
    partial class lastresort
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.mercyDataSet2 = new shopsystem.mercyDataSet2();
            this.stocks4BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stocks4TableAdapter = new shopsystem.mercyDataSet2TableAdapters.stocks4TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.mercyDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocks4BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.stocks4BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "shopsystem.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(921, 293);
            this.reportViewer1.TabIndex = 0;
            // 
            // mercyDataSet2
            // 
            this.mercyDataSet2.DataSetName = "mercyDataSet2";
            this.mercyDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stocks4BindingSource
            // 
            this.stocks4BindingSource.DataMember = "stocks4";
            this.stocks4BindingSource.DataSource = this.mercyDataSet2;
            // 
            // stocks4TableAdapter
            // 
            this.stocks4TableAdapter.ClearBeforeFill = true;
            // 
            // lastresort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 293);
            this.Controls.Add(this.reportViewer1);
            this.Name = "lastresort";
            this.Text = "lastresort";
            this.Load += new System.EventHandler(this.lastresort_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mercyDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocks4BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource stocks4BindingSource;
        private mercyDataSet2 mercyDataSet2;
        private mercyDataSet2TableAdapters.stocks4TableAdapter stocks4TableAdapter;
    }
}