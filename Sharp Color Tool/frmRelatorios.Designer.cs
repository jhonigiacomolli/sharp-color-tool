namespace Sharp_Color_Tool
{
    partial class frmRelatorios
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
            this.AgendamentosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Database_AgendamentosDataSet = new Sharp_Color_Tool.Database_AgendamentosDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.AgendamentosTableAdapter = new Sharp_Color_Tool.Database_AgendamentosDataSetTableAdapters.AgendamentosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.AgendamentosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Database_AgendamentosDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // AgendamentosBindingSource
            // 
            this.AgendamentosBindingSource.DataMember = "Agendamentos";
            this.AgendamentosBindingSource.DataSource = this.Database_AgendamentosDataSet;
            // 
            // Database_AgendamentosDataSet
            // 
            this.Database_AgendamentosDataSet.DataSetName = "Database_AgendamentosDataSet";
            this.Database_AgendamentosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet_Agendamentos";
            reportDataSource1.Value = this.AgendamentosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sharp_Color_Tool.rlt_TintasEntregues.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(691, 561);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomPercent = 120;
            // 
            // AgendamentosTableAdapter
            // 
            this.AgendamentosTableAdapter.ClearBeforeFill = true;
            // 
            // frmRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 561);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRelatorios";
            this.Text = "frmRelatorios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRelatorios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AgendamentosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Database_AgendamentosDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource AgendamentosBindingSource;
        private Database_AgendamentosDataSet Database_AgendamentosDataSet;
        private Database_AgendamentosDataSetTableAdapters.AgendamentosTableAdapter AgendamentosTableAdapter;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}