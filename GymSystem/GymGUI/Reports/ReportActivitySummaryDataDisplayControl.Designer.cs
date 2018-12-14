namespace VolunteerManagementGUI.Reports
{
    partial class ReportActivitySummaryDataDisplayControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewSummaryData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSummaryData)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSummaryData
            // 
            this.dataGridViewSummaryData.AllowUserToAddRows = false;
            this.dataGridViewSummaryData.AllowUserToDeleteRows = false;
            this.dataGridViewSummaryData.AllowUserToOrderColumns = true;
            this.dataGridViewSummaryData.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSummaryData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSummaryData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSummaryData.Location = new System.Drawing.Point(12, 8);
            this.dataGridViewSummaryData.MultiSelect = false;
            this.dataGridViewSummaryData.Name = "dataGridViewSummaryData";
            this.dataGridViewSummaryData.ReadOnly = true;
            this.dataGridViewSummaryData.RowHeadersVisible = false;
            this.dataGridViewSummaryData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSummaryData.Size = new System.Drawing.Size(577, 245);
            this.dataGridViewSummaryData.TabIndex = 36;
            // 
            // ReportActivitySummaryDataDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.Controls.Add(this.dataGridViewSummaryData);
            this.Name = "ReportActivitySummaryDataDisplayControl";
            this.Size = new System.Drawing.Size(600, 260);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSummaryData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSummaryData;
    }
}
