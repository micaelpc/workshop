namespace VolunteerManagementGUI.Entities
{
    partial class ActivityDisplayControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dateTimePickerActivityTimingFinishDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxActivityTiming = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePickerActivityEndTime = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.dateTimePickerActivityStartTime = new System.Windows.Forms.DateTimePicker();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.comboBoxActivityType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonDisplayAssignedVolunteerData = new System.Windows.Forms.Button();
            this.textBoxFindAvailableVolunteer = new System.Windows.Forms.TextBox();
            this.buttonFindAvailableVolunteer = new System.Windows.Forms.Button();
            this.buttonDisplayAvailableVolunteerData = new System.Windows.Forms.Button();
            this.textBoxFindNotAvailableVolunteer = new System.Windows.Forms.TextBox();
            this.buttonFindNotAvailableVolunteer = new System.Windows.Forms.Button();
            this.buttonDisplayNotAvailableVolunteerData = new System.Windows.Forms.Button();
            this.buttonClearAssignedVolunteers = new System.Windows.Forms.Button();
            this.buttonRemoveAssignedVolunteer = new System.Windows.Forms.Button();
            this.buttonAddNotAvailableVolunteer = new System.Windows.Forms.Button();
            this.buttonAddAvailableVolunteer = new System.Windows.Forms.Button();
            this.listBoxAssignedVolunteers = new System.Windows.Forms.ListBox();
            this.listBoxNotAvailableVolunteers = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxAvailableVolunteers = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(449, 430);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Cornsilk;
            this.tabPage1.Controls.Add(this.dateTimePickerActivityTimingFinishDate);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.comboBoxActivityTiming);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.dateTimePickerActivityEndTime);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.textBoxLocation);
            this.tabPage1.Controls.Add(this.dateTimePickerActivityStartTime);
            this.tabPage1.Controls.Add(this.textBoxDescription);
            this.tabPage1.Controls.Add(this.comboBoxActivityType);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(441, 404);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "מידע כללי";
            // 
            // dateTimePickerActivityTimingFinishDate
            // 
            this.dateTimePickerActivityTimingFinishDate.CustomFormat = "dd-MM-yy";
            this.dateTimePickerActivityTimingFinishDate.Enabled = false;
            this.dateTimePickerActivityTimingFinishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerActivityTimingFinishDate.Location = new System.Drawing.Point(79, 224);
            this.dateTimePickerActivityTimingFinishDate.Name = "dateTimePickerActivityTimingFinishDate";
            this.dateTimePickerActivityTimingFinishDate.Size = new System.Drawing.Size(79, 20);
            this.dateTimePickerActivityTimingFinishDate.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(164, 226);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "עד תאריך:";
            // 
            // comboBoxActivityTiming
            // 
            this.comboBoxActivityTiming.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxActivityTiming.Enabled = false;
            this.comboBoxActivityTiming.FormattingEnabled = true;
            this.comboBoxActivityTiming.Location = new System.Drawing.Point(239, 223);
            this.comboBoxActivityTiming.Name = "comboBoxActivityTiming";
            this.comboBoxActivityTiming.Size = new System.Drawing.Size(102, 21);
            this.comboBoxActivityTiming.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(355, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "מופע חוזר כל:";
            // 
            // dateTimePickerActivityEndTime
            // 
            this.dateTimePickerActivityEndTime.CustomFormat = "dd-MM-yy HH:mm";
            this.dateTimePickerActivityEndTime.Enabled = false;
            this.dateTimePickerActivityEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerActivityEndTime.Location = new System.Drawing.Point(186, 147);
            this.dateTimePickerActivityEndTime.Name = "dateTimePickerActivityEndTime";
            this.dateTimePickerActivityEndTime.Size = new System.Drawing.Size(113, 20);
            this.dateTimePickerActivityEndTime.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(239, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "מועד סיום:";
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Enabled = false;
            this.textBoxLocation.Location = new System.Drawing.Point(238, 189);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(149, 20);
            this.textBoxLocation.TabIndex = 7;
            // 
            // dateTimePickerActivityStartTime
            // 
            this.dateTimePickerActivityStartTime.CustomFormat = "dd-MM-yy HH:mm";
            this.dateTimePickerActivityStartTime.Enabled = false;
            this.dateTimePickerActivityStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerActivityStartTime.Location = new System.Drawing.Point(318, 147);
            this.dateTimePickerActivityStartTime.Name = "dateTimePickerActivityStartTime";
            this.dateTimePickerActivityStartTime.Size = new System.Drawing.Size(113, 20);
            this.dateTimePickerActivityStartTime.TabIndex = 6;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Enabled = false;
            this.textBoxDescription.Location = new System.Drawing.Point(16, 57);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(416, 59);
            this.textBoxDescription.TabIndex = 5;
            // 
            // comboBoxActivityType
            // 
            this.comboBoxActivityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxActivityType.Enabled = false;
            this.comboBoxActivityType.FormattingEnabled = true;
            this.comboBoxActivityType.Location = new System.Drawing.Point(182, 12);
            this.comboBoxActivityType.Name = "comboBoxActivityType";
            this.comboBoxActivityType.Size = new System.Drawing.Size(159, 21);
            this.comboBoxActivityType.TabIndex = 4;
            this.comboBoxActivityType.SelectedValueChanged += new System.EventHandler(this.comboBoxActivityType_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(393, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "מיקום:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "מועד התחלה:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "סוג הפעילות:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "תיאור הפעילות:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Cornsilk;
            this.tabPage2.Controls.Add(this.buttonDisplayAssignedVolunteerData);
            this.tabPage2.Controls.Add(this.textBoxFindAvailableVolunteer);
            this.tabPage2.Controls.Add(this.buttonFindAvailableVolunteer);
            this.tabPage2.Controls.Add(this.buttonDisplayAvailableVolunteerData);
            this.tabPage2.Controls.Add(this.textBoxFindNotAvailableVolunteer);
            this.tabPage2.Controls.Add(this.buttonFindNotAvailableVolunteer);
            this.tabPage2.Controls.Add(this.buttonDisplayNotAvailableVolunteerData);
            this.tabPage2.Controls.Add(this.buttonClearAssignedVolunteers);
            this.tabPage2.Controls.Add(this.buttonRemoveAssignedVolunteer);
            this.tabPage2.Controls.Add(this.buttonAddNotAvailableVolunteer);
            this.tabPage2.Controls.Add(this.buttonAddAvailableVolunteer);
            this.tabPage2.Controls.Add(this.listBoxAssignedVolunteers);
            this.tabPage2.Controls.Add(this.listBoxNotAvailableVolunteers);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.listBoxAvailableVolunteers);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(441, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "הקצאת מתנדבים";
            // 
            // buttonDisplayAssignedVolunteerData
            // 
            this.buttonDisplayAssignedVolunteerData.Location = new System.Drawing.Point(154, 355);
            this.buttonDisplayAssignedVolunteerData.Name = "buttonDisplayAssignedVolunteerData";
            this.buttonDisplayAssignedVolunteerData.Size = new System.Drawing.Size(45, 23);
            this.buttonDisplayAssignedVolunteerData.TabIndex = 17;
            this.buttonDisplayAssignedVolunteerData.Text = "הצג";
            this.buttonDisplayAssignedVolunteerData.UseVisualStyleBackColor = true;
            this.buttonDisplayAssignedVolunteerData.Click += new System.EventHandler(this.buttonDisplayAssignedVolunteerData_Click);
            // 
            // textBoxFindAvailableVolunteer
            // 
            this.textBoxFindAvailableVolunteer.Location = new System.Drawing.Point(307, 202);
            this.textBoxFindAvailableVolunteer.Name = "textBoxFindAvailableVolunteer";
            this.textBoxFindAvailableVolunteer.Size = new System.Drawing.Size(74, 20);
            this.textBoxFindAvailableVolunteer.TabIndex = 16;
            // 
            // buttonFindAvailableVolunteer
            // 
            this.buttonFindAvailableVolunteer.Location = new System.Drawing.Point(246, 199);
            this.buttonFindAvailableVolunteer.Name = "buttonFindAvailableVolunteer";
            this.buttonFindAvailableVolunteer.Size = new System.Drawing.Size(57, 23);
            this.buttonFindAvailableVolunteer.TabIndex = 15;
            this.buttonFindAvailableVolunteer.Text = "חפש שם";
            this.buttonFindAvailableVolunteer.UseVisualStyleBackColor = true;
            this.buttonFindAvailableVolunteer.Click += new System.EventHandler(this.buttonFindAvailableVolunteer_Click);
            // 
            // buttonDisplayAvailableVolunteerData
            // 
            this.buttonDisplayAvailableVolunteerData.Location = new System.Drawing.Point(387, 199);
            this.buttonDisplayAvailableVolunteerData.Name = "buttonDisplayAvailableVolunteerData";
            this.buttonDisplayAvailableVolunteerData.Size = new System.Drawing.Size(45, 23);
            this.buttonDisplayAvailableVolunteerData.TabIndex = 14;
            this.buttonDisplayAvailableVolunteerData.Text = "הצג";
            this.buttonDisplayAvailableVolunteerData.UseVisualStyleBackColor = true;
            this.buttonDisplayAvailableVolunteerData.Click += new System.EventHandler(this.buttonDisplayAvailableVolunteerData_Click);
            // 
            // textBoxFindNotAvailableVolunteer
            // 
            this.textBoxFindNotAvailableVolunteer.Location = new System.Drawing.Point(307, 358);
            this.textBoxFindNotAvailableVolunteer.Name = "textBoxFindNotAvailableVolunteer";
            this.textBoxFindNotAvailableVolunteer.Size = new System.Drawing.Size(74, 20);
            this.textBoxFindNotAvailableVolunteer.TabIndex = 13;
            // 
            // buttonFindNotAvailableVolunteer
            // 
            this.buttonFindNotAvailableVolunteer.Location = new System.Drawing.Point(246, 355);
            this.buttonFindNotAvailableVolunteer.Name = "buttonFindNotAvailableVolunteer";
            this.buttonFindNotAvailableVolunteer.Size = new System.Drawing.Size(57, 23);
            this.buttonFindNotAvailableVolunteer.TabIndex = 12;
            this.buttonFindNotAvailableVolunteer.Text = "חפש שם";
            this.buttonFindNotAvailableVolunteer.UseVisualStyleBackColor = true;
            this.buttonFindNotAvailableVolunteer.Click += new System.EventHandler(this.buttonFindNotAvailableVolunteer_Click);
            // 
            // buttonDisplayNotAvailableVolunteerData
            // 
            this.buttonDisplayNotAvailableVolunteerData.Location = new System.Drawing.Point(387, 355);
            this.buttonDisplayNotAvailableVolunteerData.Name = "buttonDisplayNotAvailableVolunteerData";
            this.buttonDisplayNotAvailableVolunteerData.Size = new System.Drawing.Size(45, 23);
            this.buttonDisplayNotAvailableVolunteerData.TabIndex = 11;
            this.buttonDisplayNotAvailableVolunteerData.Text = "הצג";
            this.buttonDisplayNotAvailableVolunteerData.UseVisualStyleBackColor = true;
            this.buttonDisplayNotAvailableVolunteerData.Click += new System.EventHandler(this.buttonDisplayNotAvailableVolunteerData_Click);
            // 
            // buttonClearAssignedVolunteers
            // 
            this.buttonClearAssignedVolunteers.Location = new System.Drawing.Point(13, 355);
            this.buttonClearAssignedVolunteers.Name = "buttonClearAssignedVolunteers";
            this.buttonClearAssignedVolunteers.Size = new System.Drawing.Size(76, 23);
            this.buttonClearAssignedVolunteers.TabIndex = 10;
            this.buttonClearAssignedVolunteers.Text = "נקה רשימה";
            this.buttonClearAssignedVolunteers.UseVisualStyleBackColor = true;
            this.buttonClearAssignedVolunteers.Click += new System.EventHandler(this.buttonClearAssignedVolunteers_Click);
            // 
            // buttonRemoveAssignedVolunteer
            // 
            this.buttonRemoveAssignedVolunteer.Location = new System.Drawing.Point(95, 355);
            this.buttonRemoveAssignedVolunteer.Name = "buttonRemoveAssignedVolunteer";
            this.buttonRemoveAssignedVolunteer.Size = new System.Drawing.Size(53, 23);
            this.buttonRemoveAssignedVolunteer.TabIndex = 9;
            this.buttonRemoveAssignedVolunteer.Text = "הסר";
            this.buttonRemoveAssignedVolunteer.UseVisualStyleBackColor = true;
            this.buttonRemoveAssignedVolunteer.Click += new System.EventHandler(this.buttonRemoveAssignedVolunteer_Click);
            // 
            // buttonAddNotAvailableVolunteer
            // 
            this.buttonAddNotAvailableVolunteer.Location = new System.Drawing.Point(205, 288);
            this.buttonAddNotAvailableVolunteer.Name = "buttonAddNotAvailableVolunteer";
            this.buttonAddNotAvailableVolunteer.Size = new System.Drawing.Size(35, 23);
            this.buttonAddNotAvailableVolunteer.TabIndex = 8;
            this.buttonAddNotAvailableVolunteer.Text = "->";
            this.buttonAddNotAvailableVolunteer.UseVisualStyleBackColor = true;
            this.buttonAddNotAvailableVolunteer.Click += new System.EventHandler(this.buttonAddNotAvailableVolunteer_Click);
            // 
            // buttonAddAvailableVolunteer
            // 
            this.buttonAddAvailableVolunteer.Location = new System.Drawing.Point(205, 99);
            this.buttonAddAvailableVolunteer.Name = "buttonAddAvailableVolunteer";
            this.buttonAddAvailableVolunteer.Size = new System.Drawing.Size(35, 23);
            this.buttonAddAvailableVolunteer.TabIndex = 7;
            this.buttonAddAvailableVolunteer.Text = "->";
            this.buttonAddAvailableVolunteer.UseVisualStyleBackColor = true;
            this.buttonAddAvailableVolunteer.Click += new System.EventHandler(this.buttonAddAvailableVolunteer_Click);
            // 
            // listBoxAssignedVolunteers
            // 
            this.listBoxAssignedVolunteers.FormattingEnabled = true;
            this.listBoxAssignedVolunteers.Location = new System.Drawing.Point(13, 33);
            this.listBoxAssignedVolunteers.Name = "listBoxAssignedVolunteers";
            this.listBoxAssignedVolunteers.Size = new System.Drawing.Size(186, 316);
            this.listBoxAssignedVolunteers.TabIndex = 6;
            this.listBoxAssignedVolunteers.DoubleClick += new System.EventHandler(this.listBoxAssignedVolunteers_DoubleClick);
            // 
            // listBoxNotAvailableVolunteers
            // 
            this.listBoxNotAvailableVolunteers.FormattingEnabled = true;
            this.listBoxNotAvailableVolunteers.Location = new System.Drawing.Point(246, 254);
            this.listBoxNotAvailableVolunteers.Name = "listBoxNotAvailableVolunteers";
            this.listBoxNotAvailableVolunteers.Size = new System.Drawing.Size(186, 95);
            this.listBoxNotAvailableVolunteers.TabIndex = 5;
            this.listBoxNotAvailableVolunteers.DoubleClick += new System.EventHandler(this.listBoxNotAvailableVolunteers_DoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "מתנדבים שהוקצו לפעילות:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(294, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "מתנדבים שאינם מתאימים:";
            // 
            // listBoxAvailableVolunteers
            // 
            this.listBoxAvailableVolunteers.FormattingEnabled = true;
            this.listBoxAvailableVolunteers.Location = new System.Drawing.Point(246, 33);
            this.listBoxAvailableVolunteers.Name = "listBoxAvailableVolunteers";
            this.listBoxAvailableVolunteers.Size = new System.Drawing.Size(186, 160);
            this.listBoxAvailableVolunteers.TabIndex = 2;
            this.listBoxAvailableVolunteers.DoubleClick += new System.EventHandler(this.listBoxAvailableVolunteers_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "מתנדבים מתאימים:";
            // 
            // ActivityDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ActivityDisplayControl";
            this.Size = new System.Drawing.Size(449, 430);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.DateTimePicker dateTimePickerActivityStartTime;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ComboBox comboBoxActivityType;
        private System.Windows.Forms.Button buttonRemoveAssignedVolunteer;
        private System.Windows.Forms.Button buttonAddNotAvailableVolunteer;
        private System.Windows.Forms.Button buttonAddAvailableVolunteer;
        private System.Windows.Forms.ListBox listBoxAssignedVolunteers;
        private System.Windows.Forms.ListBox listBoxNotAvailableVolunteers;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxAvailableVolunteers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonClearAssignedVolunteers;
        private System.Windows.Forms.DateTimePicker dateTimePickerActivityEndTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxActivityTiming;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePickerActivityTimingFinishDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonDisplayAssignedVolunteerData;
        private System.Windows.Forms.TextBox textBoxFindAvailableVolunteer;
        private System.Windows.Forms.Button buttonFindAvailableVolunteer;
        private System.Windows.Forms.Button buttonDisplayAvailableVolunteerData;
        private System.Windows.Forms.TextBox textBoxFindNotAvailableVolunteer;
        private System.Windows.Forms.Button buttonFindNotAvailableVolunteer;
        private System.Windows.Forms.Button buttonDisplayNotAvailableVolunteerData;
    }
}
