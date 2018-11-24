namespace VolunteerManagementGUI.Reports
{
    partial class ReportVolunteerActivityLogDisplayControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewActivityByTime = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewActivityByType = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxVolunteerList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivityByTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivityByType)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewActivityByTime
            // 
            this.dataGridViewActivityByTime.AllowUserToAddRows = false;
            this.dataGridViewActivityByTime.AllowUserToDeleteRows = false;
            this.dataGridViewActivityByTime.AllowUserToOrderColumns = true;
            this.dataGridViewActivityByTime.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewActivityByTime.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewActivityByTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActivityByTime.Location = new System.Drawing.Point(331, 56);
            this.dataGridViewActivityByTime.MultiSelect = false;
            this.dataGridViewActivityByTime.Name = "dataGridViewActivityByTime";
            this.dataGridViewActivityByTime.ReadOnly = true;
            this.dataGridViewActivityByTime.RowHeadersVisible = false;
            this.dataGridViewActivityByTime.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewActivityByTime.Size = new System.Drawing.Size(258, 197);
            this.dataGridViewActivityByTime.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 30);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(228, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "כמות פעילויות בשנה האחרונה בחתך חודש:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 30);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(259, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "כמות פעילויות בשנה האחרונה בחתך סוג פעילות:";
            // 
            // dataGridViewActivityByType
            // 
            this.dataGridViewActivityByType.AllowUserToAddRows = false;
            this.dataGridViewActivityByType.AllowUserToDeleteRows = false;
            this.dataGridViewActivityByType.AllowUserToOrderColumns = true;
            this.dataGridViewActivityByType.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewActivityByType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewActivityByType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActivityByType.Location = new System.Drawing.Point(22, 56);
            this.dataGridViewActivityByType.MultiSelect = false;
            this.dataGridViewActivityByType.Name = "dataGridViewActivityByType";
            this.dataGridViewActivityByType.ReadOnly = true;
            this.dataGridViewActivityByType.RowHeadersVisible = false;
            this.dataGridViewActivityByType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewActivityByType.Size = new System.Drawing.Size(258, 197);
            this.dataGridViewActivityByType.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 3);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "בחר מתנדב:";
            // 
            // comboBoxVolunteerList
            // 
            this.comboBoxVolunteerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVolunteerList.FormattingEnabled = true;
            this.comboBoxVolunteerList.Location = new System.Drawing.Point(146, 0);
            this.comboBoxVolunteerList.Name = "comboBoxVolunteerList";
            this.comboBoxVolunteerList.Size = new System.Drawing.Size(181, 21);
            this.comboBoxVolunteerList.TabIndex = 41;
            // 
            // ReportVolunteerActivityLogDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.Controls.Add(this.comboBoxVolunteerList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewActivityByType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewActivityByTime);
            this.Name = "ReportVolunteerActivityLogDisplayControl";
            this.Size = new System.Drawing.Size(600, 260);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivityByTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivityByType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewActivityByTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewActivityByType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxVolunteerList;
    }
}
