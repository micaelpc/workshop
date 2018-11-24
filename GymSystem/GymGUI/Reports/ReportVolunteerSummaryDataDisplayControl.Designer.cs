namespace VolunteerManagementGUI.Reports
{
    partial class ReportVolunteerSummaryDataDisplayControl
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
            this.comboBoxVolunteerAttribute = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewVolunteersSummaryData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVolunteersSummaryData)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxVolunteerAttribute
            // 
            this.comboBoxVolunteerAttribute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVolunteerAttribute.FormattingEnabled = true;
            this.comboBoxVolunteerAttribute.Location = new System.Drawing.Point(270, 8);
            this.comboBoxVolunteerAttribute.Name = "comboBoxVolunteerAttribute";
            this.comboBoxVolunteerAttribute.Size = new System.Drawing.Size(181, 21);
            this.comboBoxVolunteerAttribute.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(457, 11);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "בחר מאפיין של מתנדב:";
            // 
            // dataGridViewVolunteersSummaryData
            // 
            this.dataGridViewVolunteersSummaryData.AllowUserToAddRows = false;
            this.dataGridViewVolunteersSummaryData.AllowUserToDeleteRows = false;
            this.dataGridViewVolunteersSummaryData.AllowUserToOrderColumns = true;
            this.dataGridViewVolunteersSummaryData.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewVolunteersSummaryData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewVolunteersSummaryData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVolunteersSummaryData.Location = new System.Drawing.Point(13, 35);
            this.dataGridViewVolunteersSummaryData.MultiSelect = false;
            this.dataGridViewVolunteersSummaryData.Name = "dataGridViewVolunteersSummaryData";
            this.dataGridViewVolunteersSummaryData.ReadOnly = true;
            this.dataGridViewVolunteersSummaryData.RowHeadersVisible = false;
            this.dataGridViewVolunteersSummaryData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVolunteersSummaryData.Size = new System.Drawing.Size(575, 222);
            this.dataGridViewVolunteersSummaryData.TabIndex = 44;
            // 
            // ReportVolunteerSummaryDataDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.Controls.Add(this.dataGridViewVolunteersSummaryData);
            this.Controls.Add(this.comboBoxVolunteerAttribute);
            this.Controls.Add(this.label3);
            this.Name = "ReportVolunteerSummaryDataDisplayControl";
            this.Size = new System.Drawing.Size(600, 260);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVolunteersSummaryData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxVolunteerAttribute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewVolunteersSummaryData;
    }
}
