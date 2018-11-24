namespace VolunteerManagementGUI.Reports
{
    partial class ReportWorkDistributionDisplayControl
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
            this.labelNumOfVolunteers = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerFinishDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNumOfActivities = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelActiveVolunteerPercent = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelAverageActivitiesForVolunteer = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewVolunteers = new System.Windows.Forms.DataGridView();
            this.iDNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumOfActivities = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cellPhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.homePhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eMailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volunteerTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceVolunteersList = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVolunteers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVolunteersList)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNumOfVolunteers
            // 
            this.labelNumOfVolunteers.AutoSize = true;
            this.labelNumOfVolunteers.Location = new System.Drawing.Point(225, 266);
            this.labelNumOfVolunteers.Name = "labelNumOfVolunteers";
            this.labelNumOfVolunteers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelNumOfVolunteers.Size = new System.Drawing.Size(13, 13);
            this.labelNumOfVolunteers.TabIndex = 42;
            this.labelNumOfVolunteers.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 266);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "כמות מתנדבים:";
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
            // labelNumOfActivities
            // 
            this.labelNumOfActivities.AutoSize = true;
            this.labelNumOfActivities.Location = new System.Drawing.Point(441, 266);
            this.labelNumOfActivities.Name = "labelNumOfActivities";
            this.labelNumOfActivities.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelNumOfActivities.Size = new System.Drawing.Size(13, 13);
            this.labelNumOfActivities.TabIndex = 44;
            this.labelNumOfActivities.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(500, 266);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "סה\"כ פעילויות:";
            // 
            // labelActiveVolunteerPercent
            // 
            this.labelActiveVolunteerPercent.AutoSize = true;
            this.labelActiveVolunteerPercent.Location = new System.Drawing.Point(441, 300);
            this.labelActiveVolunteerPercent.Name = "labelActiveVolunteerPercent";
            this.labelActiveVolunteerPercent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelActiveVolunteerPercent.Size = new System.Drawing.Size(13, 13);
            this.labelActiveVolunteerPercent.TabIndex = 46;
            this.labelActiveVolunteerPercent.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(480, 300);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "% מתנדבים פעילים:";
            // 
            // labelAverageActivitiesForVolunteer
            // 
            this.labelAverageActivitiesForVolunteer.AutoSize = true;
            this.labelAverageActivitiesForVolunteer.Location = new System.Drawing.Point(225, 300);
            this.labelAverageActivitiesForVolunteer.Name = "labelAverageActivitiesForVolunteer";
            this.labelAverageActivitiesForVolunteer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelAverageActivitiesForVolunteer.Size = new System.Drawing.Size(13, 13);
            this.labelAverageActivitiesForVolunteer.TabIndex = 48;
            this.labelAverageActivitiesForVolunteer.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(259, 300);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(137, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "ממוצע פעילויות למתנדב:";
            // 
            // dataGridViewVolunteers
            // 
            this.dataGridViewVolunteers.AllowUserToAddRows = false;
            this.dataGridViewVolunteers.AllowUserToDeleteRows = false;
            this.dataGridViewVolunteers.AllowUserToOrderColumns = true;
            this.dataGridViewVolunteers.AutoGenerateColumns = false;
            this.dataGridViewVolunteers.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewVolunteers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewVolunteers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVolunteers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDNumberDataGridViewTextBoxColumn,
            this.firstnameDataGridViewTextBoxColumn,
            this.surnameDataGridViewTextBoxColumn,
            this.NumOfActivities,
            this.cellPhoneDataGridViewTextBoxColumn,
            this.homePhoneDataGridViewTextBoxColumn,
            this.eMailDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.volunteerTypeDataGridViewTextBoxColumn,
            this.birthdateDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn});
            this.dataGridViewVolunteers.DataSource = this.bindingSourceVolunteersList;
            this.dataGridViewVolunteers.Location = new System.Drawing.Point(13, 38);
            this.dataGridViewVolunteers.MultiSelect = false;
            this.dataGridViewVolunteers.Name = "dataGridViewVolunteers";
            this.dataGridViewVolunteers.ReadOnly = true;
            this.dataGridViewVolunteers.RowHeadersVisible = false;
            this.dataGridViewVolunteers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVolunteers.Size = new System.Drawing.Size(577, 215);
            this.dataGridViewVolunteers.TabIndex = 51;
            // 
            // iDNumberDataGridViewTextBoxColumn
            // 
            this.iDNumberDataGridViewTextBoxColumn.DataPropertyName = "IDNumber";
            this.iDNumberDataGridViewTextBoxColumn.HeaderText = "ת\"ז";
            this.iDNumberDataGridViewTextBoxColumn.Name = "iDNumberDataGridViewTextBoxColumn";
            this.iDNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDNumberDataGridViewTextBoxColumn.Width = 80;
            // 
            // firstnameDataGridViewTextBoxColumn
            // 
            this.firstnameDataGridViewTextBoxColumn.DataPropertyName = "Firstname";
            this.firstnameDataGridViewTextBoxColumn.HeaderText = "שם פרטי";
            this.firstnameDataGridViewTextBoxColumn.Name = "firstnameDataGridViewTextBoxColumn";
            this.firstnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // surnameDataGridViewTextBoxColumn
            // 
            this.surnameDataGridViewTextBoxColumn.DataPropertyName = "Surname";
            this.surnameDataGridViewTextBoxColumn.HeaderText = "שם משפחה";
            this.surnameDataGridViewTextBoxColumn.Name = "surnameDataGridViewTextBoxColumn";
            this.surnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // NumOfActivities
            // 
            this.NumOfActivities.HeaderText = "כמות פעילויות";
            this.NumOfActivities.Name = "NumOfActivities";
            this.NumOfActivities.ReadOnly = true;
            // 
            // cellPhoneDataGridViewTextBoxColumn
            // 
            this.cellPhoneDataGridViewTextBoxColumn.DataPropertyName = "CellPhone";
            this.cellPhoneDataGridViewTextBoxColumn.HeaderText = "טל\' נייד";
            this.cellPhoneDataGridViewTextBoxColumn.Name = "cellPhoneDataGridViewTextBoxColumn";
            this.cellPhoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.cellPhoneDataGridViewTextBoxColumn.Width = 80;
            // 
            // homePhoneDataGridViewTextBoxColumn
            // 
            this.homePhoneDataGridViewTextBoxColumn.DataPropertyName = "HomePhone";
            this.homePhoneDataGridViewTextBoxColumn.HeaderText = "טל\' בבית";
            this.homePhoneDataGridViewTextBoxColumn.Name = "homePhoneDataGridViewTextBoxColumn";
            this.homePhoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.homePhoneDataGridViewTextBoxColumn.Width = 80;
            // 
            // eMailDataGridViewTextBoxColumn
            // 
            this.eMailDataGridViewTextBoxColumn.DataPropertyName = "EMail";
            this.eMailDataGridViewTextBoxColumn.HeaderText = "אימייל";
            this.eMailDataGridViewTextBoxColumn.Name = "eMailDataGridViewTextBoxColumn";
            this.eMailDataGridViewTextBoxColumn.ReadOnly = true;
            this.eMailDataGridViewTextBoxColumn.Width = 120;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "כתובת";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // volunteerTypeDataGridViewTextBoxColumn
            // 
            this.volunteerTypeDataGridViewTextBoxColumn.DataPropertyName = "VolunteerType";
            this.volunteerTypeDataGridViewTextBoxColumn.HeaderText = "סוג";
            this.volunteerTypeDataGridViewTextBoxColumn.Name = "volunteerTypeDataGridViewTextBoxColumn";
            this.volunteerTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.volunteerTypeDataGridViewTextBoxColumn.Width = 120;
            // 
            // birthdateDataGridViewTextBoxColumn
            // 
            this.birthdateDataGridViewTextBoxColumn.DataPropertyName = "Birthdate";
            this.birthdateDataGridViewTextBoxColumn.HeaderText = "תאריך לידה";
            this.birthdateDataGridViewTextBoxColumn.Name = "birthdateDataGridViewTextBoxColumn";
            this.birthdateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "הערה";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            this.commentDataGridViewTextBoxColumn.ReadOnly = true;
            this.commentDataGridViewTextBoxColumn.Width = 200;
            // 
            // bindingSourceVolunteersList
            // 
            this.bindingSourceVolunteersList.DataSource = typeof(VolunteerManagementBL.Entities.Volunteer);
            // 
            // ReportWorkDistributionDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.Controls.Add(this.dataGridViewVolunteers);
            this.Controls.Add(this.labelAverageActivitiesForVolunteer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelActiveVolunteerPercent);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelNumOfActivities);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelNumOfVolunteers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerFinishDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.label3);
            this.Name = "ReportWorkDistributionDisplayControl";
            this.Size = new System.Drawing.Size(600, 330);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVolunteers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVolunteersList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNumOfVolunteers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinishDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelNumOfActivities;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelActiveVolunteerPercent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelAverageActivitiesForVolunteer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource bindingSourceVolunteersList;
        private System.Windows.Forms.DataGridView dataGridViewVolunteers;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn surnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumOfActivities;
        private System.Windows.Forms.DataGridViewTextBoxColumn cellPhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn homePhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eMailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volunteerTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
    }
}
