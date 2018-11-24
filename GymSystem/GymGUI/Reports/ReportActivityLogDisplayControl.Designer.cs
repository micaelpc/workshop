namespace VolunteerManagementGUI.Reports
{
    partial class ReportActivityLogDisplayControl
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelNumOfActivities = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewActivities = new System.Windows.Forms.DataGridView();
            this.startDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumOfVolunteers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timingTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activityTimingFinishDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceActivities = new System.Windows.Forms.BindingSource(this.components);
            this.dateTimePickerFinishDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceActivities)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNumOfActivities
            // 
            this.labelNumOfActivities.AutoSize = true;
            this.labelNumOfActivities.Location = new System.Drawing.Point(87, 16);
            this.labelNumOfActivities.Name = "labelNumOfActivities";
            this.labelNumOfActivities.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelNumOfActivities.Size = new System.Drawing.Size(13, 13);
            this.labelNumOfActivities.TabIndex = 42;
            this.labelNumOfActivities.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 16);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "כמות פעילויות:";
            // 
            // dataGridViewActivities
            // 
            this.dataGridViewActivities.AllowUserToAddRows = false;
            this.dataGridViewActivities.AllowUserToDeleteRows = false;
            this.dataGridViewActivities.AllowUserToOrderColumns = true;
            this.dataGridViewActivities.AutoGenerateColumns = false;
            this.dataGridViewActivities.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewActivities.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewActivities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActivities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.startDateDataGridViewTextBoxColumn,
            this.endDateDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.NumOfVolunteers,
            this.descriptionDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn,
            this.timingTypeDataGridViewTextBoxColumn,
            this.activityTimingFinishDateDataGridViewTextBoxColumn,
            this.ID});
            this.dataGridViewActivities.DataSource = this.bindingSourceActivities;
            this.dataGridViewActivities.Location = new System.Drawing.Point(12, 36);
            this.dataGridViewActivities.MultiSelect = false;
            this.dataGridViewActivities.Name = "dataGridViewActivities";
            this.dataGridViewActivities.ReadOnly = true;
            this.dataGridViewActivities.RowHeadersVisible = false;
            this.dataGridViewActivities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewActivities.Size = new System.Drawing.Size(577, 215);
            this.dataGridViewActivities.TabIndex = 40;
            this.dataGridViewActivities.DoubleClick += new System.EventHandler(this.dataGridViewActivities_DoubleClick);
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            this.startDateDataGridViewTextBoxColumn.HeaderText = "זמן התחלה";
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            this.startDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            this.endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            this.endDateDataGridViewTextBoxColumn.HeaderText = "זמן סיום";
            this.endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            this.endDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "סוג";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // NumOfVolunteers
            // 
            this.NumOfVolunteers.HeaderText = "כמות מתנדבים";
            this.NumOfVolunteers.Name = "NumOfVolunteers";
            this.NumOfVolunteers.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "תיאור";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "מיקום";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            this.locationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timingTypeDataGridViewTextBoxColumn
            // 
            this.timingTypeDataGridViewTextBoxColumn.DataPropertyName = "TimingType";
            this.timingTypeDataGridViewTextBoxColumn.HeaderText = "מחזוריות";
            this.timingTypeDataGridViewTextBoxColumn.Name = "timingTypeDataGridViewTextBoxColumn";
            this.timingTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // activityTimingFinishDateDataGridViewTextBoxColumn
            // 
            this.activityTimingFinishDateDataGridViewTextBoxColumn.DataPropertyName = "ActivityTimingFinishDate";
            this.activityTimingFinishDateDataGridViewTextBoxColumn.HeaderText = "תאריך סיום";
            this.activityTimingFinishDateDataGridViewTextBoxColumn.Name = "activityTimingFinishDateDataGridViewTextBoxColumn";
            this.activityTimingFinishDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // bindingSourceActivities
            // 
            this.bindingSourceActivities.DataSource = typeof(VolunteerManagementBL.Entities.Activity);
            // 
            // dateTimePickerFinishDate
            // 
            this.dateTimePickerFinishDate.CustomFormat = "dd-MM-yy";
            this.dateTimePickerFinishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFinishDate.Location = new System.Drawing.Point(224, 10);
            this.dateTimePickerFinishDate.Name = "dateTimePickerFinishDate";
            this.dateTimePickerFinishDate.Size = new System.Drawing.Size(82, 20);
            this.dateTimePickerFinishDate.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 16);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "תאריך סיום:";
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.CustomFormat = "dd-MM-yy";
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(412, 10);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(82, 20);
            this.dateTimePickerStartDate.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(500, 16);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "תאריך התחלה:";
            // 
            // ReportActivityLogDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.Controls.Add(this.labelNumOfActivities);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewActivities);
            this.Controls.Add(this.dateTimePickerFinishDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.label3);
            this.Name = "ReportActivityLogDisplayControl";
            this.Size = new System.Drawing.Size(600, 260);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceActivities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNumOfActivities;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewActivities;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinishDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource bindingSourceActivities;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumOfVolunteers;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timingTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn activityTimingFinishDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}
