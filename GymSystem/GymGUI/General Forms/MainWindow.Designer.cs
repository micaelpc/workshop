namespace VolunteerManagementGUI
{
    partial class MainWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageVolunteers = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.dataGridViewVolunteers = new System.Windows.Forms.DataGridView();
            this.comboBoxVolunteerActivityType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAddNewVolunteer = new System.Windows.Forms.Button();
            this.textBoxVolunteerID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonLoadVolunteer = new System.Windows.Forms.Button();
            this.textBoxVolunteerName = new System.Windows.Forms.TextBox();
            this.buttonFindVolunteer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageActivities = new System.Windows.Forms.TabPage();
            this.buttonAttendReminder = new System.Windows.Forms.Button();
            this.buttonAddReminder = new System.Windows.Forms.Button();
            this.listBoxAllReminders = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonAddNewActivityType = new System.Windows.Forms.Button();
            this.buttonLoadActivityType = new System.Windows.Forms.Button();
            this.comboBoxActivityTypes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAddNewActivity = new System.Windows.Forms.Button();
            this.buttonLoadActivity = new System.Windows.Forms.Button();
            this.listBoxActivities = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.monthCalendarActivities = new System.Windows.Forms.MonthCalendar();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.comboBoxReportReminderCycleTime = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonAddReportReminder = new System.Windows.Forms.Button();
            this.buttonExecuteReport = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panelReportView = new System.Windows.Forms.Panel();
            this.comboBoxReportType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPageUsers = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.comboBoxUserType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonAddNewUser = new System.Windows.Forms.Button();
            this.buttonLoadUser = new System.Windows.Forms.Button();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.buttonFindUser = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTimePickerReportReminderFinishDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.iDNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cellPhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.homePhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eMailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volunteerTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceVolunteersList = new System.Windows.Forms.BindingSource(this.components);
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volunteerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceUsersList = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageVolunteers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVolunteers)).BeginInit();
            this.tabPageActivities.SuspendLayout();
            this.tabPageReports.SuspendLayout();
            this.tabPageUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVolunteersList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsersList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageVolunteers);
            this.tabControl1.Controls.Add(this.tabPageActivities);
            this.tabControl1.Controls.Add(this.tabPageReports);
            this.tabControl1.Controls.Add(this.tabPageUsers);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(691, 482);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageVolunteers
            // 
            this.tabPageVolunteers.BackColor = System.Drawing.Color.Cornsilk;
            this.tabPageVolunteers.Controls.Add(this.label13);
            this.tabPageVolunteers.Controls.Add(this.dataGridViewVolunteers);
            this.tabPageVolunteers.Controls.Add(this.comboBoxVolunteerActivityType);
            this.tabPageVolunteers.Controls.Add(this.label6);
            this.tabPageVolunteers.Controls.Add(this.buttonAddNewVolunteer);
            this.tabPageVolunteers.Controls.Add(this.textBoxVolunteerID);
            this.tabPageVolunteers.Controls.Add(this.label4);
            this.tabPageVolunteers.Controls.Add(this.buttonLoadVolunteer);
            this.tabPageVolunteers.Controls.Add(this.textBoxVolunteerName);
            this.tabPageVolunteers.Controls.Add(this.buttonFindVolunteer);
            this.tabPageVolunteers.Controls.Add(this.label1);
            this.tabPageVolunteers.Location = new System.Drawing.Point(4, 22);
            this.tabPageVolunteers.Name = "tabPageVolunteers";
            this.tabPageVolunteers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVolunteers.Size = new System.Drawing.Size(683, 456);
            this.tabPageVolunteers.TabIndex = 0;
            this.tabPageVolunteers.Text = "מתנדבים";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(622, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "שם:";
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
            this.cellPhoneDataGridViewTextBoxColumn,
            this.homePhoneDataGridViewTextBoxColumn,
            this.eMailDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.volunteerTypeDataGridViewTextBoxColumn,
            this.birthdateDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn});
            this.dataGridViewVolunteers.DataSource = this.bindingSourceVolunteersList;
            this.dataGridViewVolunteers.Location = new System.Drawing.Point(22, 74);
            this.dataGridViewVolunteers.MultiSelect = false;
            this.dataGridViewVolunteers.Name = "dataGridViewVolunteers";
            this.dataGridViewVolunteers.ReadOnly = true;
            this.dataGridViewVolunteers.RowHeadersVisible = false;
            this.dataGridViewVolunteers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVolunteers.Size = new System.Drawing.Size(650, 298);
            this.dataGridViewVolunteers.TabIndex = 16;
            this.dataGridViewVolunteers.DoubleClick += new System.EventHandler(this.dataGridViewVolunteers_DoubleClick);
            // 
            // comboBoxVolunteerActivityType
            // 
            this.comboBoxVolunteerActivityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVolunteerActivityType.FormattingEnabled = true;
            this.comboBoxVolunteerActivityType.Location = new System.Drawing.Point(112, 47);
            this.comboBoxVolunteerActivityType.Name = "comboBoxVolunteerActivityType";
            this.comboBoxVolunteerActivityType.Size = new System.Drawing.Size(152, 21);
            this.comboBoxVolunteerActivityType.TabIndex = 15;
            this.comboBoxVolunteerActivityType.VisibleChanged += new System.EventHandler(this.comboBoxVolunteerActivityType_VisibleChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = " סוג התנדבות:";
            // 
            // buttonAddNewVolunteer
            // 
            this.buttonAddNewVolunteer.Location = new System.Drawing.Point(427, 391);
            this.buttonAddNewVolunteer.Name = "buttonAddNewVolunteer";
            this.buttonAddNewVolunteer.Size = new System.Drawing.Size(114, 23);
            this.buttonAddNewVolunteer.TabIndex = 13;
            this.buttonAddNewVolunteer.Text = "הוסף מתנדב חדש";
            this.buttonAddNewVolunteer.UseVisualStyleBackColor = true;
            this.buttonAddNewVolunteer.Click += new System.EventHandler(this.buttonAddNewVolunteer_Click);
            // 
            // textBoxVolunteerID
            // 
            this.textBoxVolunteerID.Location = new System.Drawing.Point(355, 47);
            this.textBoxVolunteerID.Name = "textBoxVolunteerID";
            this.textBoxVolunteerID.Size = new System.Drawing.Size(110, 20);
            this.textBoxVolunteerID.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(471, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "ת\"ז:";
            // 
            // buttonLoadVolunteer
            // 
            this.buttonLoadVolunteer.Location = new System.Drawing.Point(558, 391);
            this.buttonLoadVolunteer.Name = "buttonLoadVolunteer";
            this.buttonLoadVolunteer.Size = new System.Drawing.Size(114, 23);
            this.buttonLoadVolunteer.TabIndex = 5;
            this.buttonLoadVolunteer.Text = "טען פרטי מתנדב";
            this.buttonLoadVolunteer.UseVisualStyleBackColor = true;
            this.buttonLoadVolunteer.Click += new System.EventHandler(this.buttonLoadVolunteer_Click);
            // 
            // textBoxVolunteerName
            // 
            this.textBoxVolunteerName.Location = new System.Drawing.Point(504, 47);
            this.textBoxVolunteerName.Name = "textBoxVolunteerName";
            this.textBoxVolunteerName.Size = new System.Drawing.Size(112, 20);
            this.textBoxVolunteerName.TabIndex = 3;
            // 
            // buttonFindVolunteer
            // 
            this.buttonFindVolunteer.Location = new System.Drawing.Point(22, 45);
            this.buttonFindVolunteer.Name = "buttonFindVolunteer";
            this.buttonFindVolunteer.Size = new System.Drawing.Size(75, 23);
            this.buttonFindVolunteer.TabIndex = 2;
            this.buttonFindVolunteer.Text = "חפש";
            this.buttonFindVolunteer.UseVisualStyleBackColor = true;
            this.buttonFindVolunteer.Click += new System.EventHandler(this.buttonFindVolunteer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(585, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "מצא מתנדב לפי:";
            // 
            // tabPageActivities
            // 
            this.tabPageActivities.BackColor = System.Drawing.Color.Cornsilk;
            this.tabPageActivities.Controls.Add(this.buttonAttendReminder);
            this.tabPageActivities.Controls.Add(this.buttonAddReminder);
            this.tabPageActivities.Controls.Add(this.listBoxAllReminders);
            this.tabPageActivities.Controls.Add(this.label12);
            this.tabPageActivities.Controls.Add(this.buttonAddNewActivityType);
            this.tabPageActivities.Controls.Add(this.buttonLoadActivityType);
            this.tabPageActivities.Controls.Add(this.comboBoxActivityTypes);
            this.tabPageActivities.Controls.Add(this.label5);
            this.tabPageActivities.Controls.Add(this.buttonAddNewActivity);
            this.tabPageActivities.Controls.Add(this.buttonLoadActivity);
            this.tabPageActivities.Controls.Add(this.listBoxActivities);
            this.tabPageActivities.Controls.Add(this.label3);
            this.tabPageActivities.Controls.Add(this.monthCalendarActivities);
            this.tabPageActivities.Location = new System.Drawing.Point(4, 22);
            this.tabPageActivities.Name = "tabPageActivities";
            this.tabPageActivities.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageActivities.Size = new System.Drawing.Size(683, 456);
            this.tabPageActivities.TabIndex = 1;
            this.tabPageActivities.Text = "פעילויות ותזכורות";
            // 
            // buttonAttendReminder
            // 
            this.buttonAttendReminder.Location = new System.Drawing.Point(54, 343);
            this.buttonAttendReminder.Name = "buttonAttendReminder";
            this.buttonAttendReminder.Size = new System.Drawing.Size(124, 23);
            this.buttonAttendReminder.TabIndex = 32;
            this.buttonAttendReminder.Text = "סימון כמטופלת";
            this.buttonAttendReminder.UseVisualStyleBackColor = true;
            this.buttonAttendReminder.Click += new System.EventHandler(this.buttonAttendReminder_Click);
            // 
            // buttonAddReminder
            // 
            this.buttonAddReminder.Location = new System.Drawing.Point(184, 343);
            this.buttonAddReminder.Name = "buttonAddReminder";
            this.buttonAddReminder.Size = new System.Drawing.Size(124, 23);
            this.buttonAddReminder.TabIndex = 31;
            this.buttonAddReminder.Text = "הוסף תזכורת חדשה";
            this.buttonAddReminder.UseVisualStyleBackColor = true;
            this.buttonAddReminder.Click += new System.EventHandler(this.buttonAddReminder_Click);
            // 
            // listBoxAllReminders
            // 
            this.listBoxAllReminders.FormattingEnabled = true;
            this.listBoxAllReminders.Location = new System.Drawing.Point(20, 190);
            this.listBoxAllReminders.Name = "listBoxAllReminders";
            this.listBoxAllReminders.Size = new System.Drawing.Size(316, 147);
            this.listBoxAllReminders.TabIndex = 30;
            this.listBoxAllReminders.DoubleClick += new System.EventHandler(this.listBoxAllReminders_DoubleClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(241, 174);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "תזכורות מוגדרות:";
            // 
            // buttonAddNewActivityType
            // 
            this.buttonAddNewActivityType.Location = new System.Drawing.Point(385, 401);
            this.buttonAddNewActivityType.Name = "buttonAddNewActivityType";
            this.buttonAddNewActivityType.Size = new System.Drawing.Size(62, 39);
            this.buttonAddNewActivityType.TabIndex = 28;
            this.buttonAddNewActivityType.Text = "הוסף תבנית";
            this.buttonAddNewActivityType.UseVisualStyleBackColor = true;
            this.buttonAddNewActivityType.Click += new System.EventHandler(this.buttonAddNewActivityType_Click);
            // 
            // buttonLoadActivityType
            // 
            this.buttonLoadActivityType.Location = new System.Drawing.Point(453, 401);
            this.buttonLoadActivityType.Name = "buttonLoadActivityType";
            this.buttonLoadActivityType.Size = new System.Drawing.Size(63, 39);
            this.buttonLoadActivityType.TabIndex = 27;
            this.buttonLoadActivityType.Text = "טען פרטי תבנית";
            this.buttonLoadActivityType.UseVisualStyleBackColor = true;
            this.buttonLoadActivityType.Click += new System.EventHandler(this.buttonLoadActivityType_Click);
            // 
            // comboBoxActivityTypes
            // 
            this.comboBoxActivityTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxActivityTypes.FormattingEnabled = true;
            this.comboBoxActivityTypes.Location = new System.Drawing.Point(385, 375);
            this.comboBoxActivityTypes.Name = "comboBoxActivityTypes";
            this.comboBoxActivityTypes.Size = new System.Drawing.Size(131, 21);
            this.comboBoxActivityTypes.TabIndex = 26;
            this.comboBoxActivityTypes.VisibleChanged += new System.EventHandler(this.comboBoxActivityTypes_VisibleChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(531, 378);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "בחר תבנית פעילות:";
            // 
            // buttonAddNewActivity
            // 
            this.buttonAddNewActivity.Location = new System.Drawing.Point(385, 343);
            this.buttonAddNewActivity.Name = "buttonAddNewActivity";
            this.buttonAddNewActivity.Size = new System.Drawing.Size(129, 23);
            this.buttonAddNewActivity.TabIndex = 24;
            this.buttonAddNewActivity.Text = "הוסף פעילות חדשה";
            this.buttonAddNewActivity.UseVisualStyleBackColor = true;
            this.buttonAddNewActivity.Click += new System.EventHandler(this.buttonAddNewActivity_Click);
            // 
            // buttonLoadActivity
            // 
            this.buttonLoadActivity.Location = new System.Drawing.Point(520, 343);
            this.buttonLoadActivity.Name = "buttonLoadActivity";
            this.buttonLoadActivity.Size = new System.Drawing.Size(123, 23);
            this.buttonLoadActivity.TabIndex = 23;
            this.buttonLoadActivity.Text = "טען פרטי פעילות";
            this.buttonLoadActivity.UseVisualStyleBackColor = true;
            this.buttonLoadActivity.Click += new System.EventHandler(this.buttonLoadActivity_Click);
            // 
            // listBoxActivities
            // 
            this.listBoxActivities.FormattingEnabled = true;
            this.listBoxActivities.Location = new System.Drawing.Point(352, 190);
            this.listBoxActivities.Name = "listBoxActivities";
            this.listBoxActivities.Size = new System.Drawing.Size(311, 147);
            this.listBoxActivities.TabIndex = 22;
            this.listBoxActivities.DoubleClick += new System.EventHandler(this.listBoxActivities_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(537, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "בחר פעילות בתאריך זה:";
            // 
            // monthCalendarActivities
            // 
            this.monthCalendarActivities.Location = new System.Drawing.Point(227, 12);
            this.monthCalendarActivities.Name = "monthCalendarActivities";
            this.monthCalendarActivities.RightToLeftLayout = true;
            this.monthCalendarActivities.TabIndex = 19;
            this.monthCalendarActivities.VisibleChanged += new System.EventHandler(this.monthCalendarActivities_VisibleChanged);
            this.monthCalendarActivities.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarActivities_DateChanged);
            // 
            // tabPageReports
            // 
            this.tabPageReports.BackColor = System.Drawing.Color.Cornsilk;
            this.tabPageReports.Controls.Add(this.dateTimePickerReportReminderFinishDate);
            this.tabPageReports.Controls.Add(this.label10);
            this.tabPageReports.Controls.Add(this.comboBoxReportReminderCycleTime);
            this.tabPageReports.Controls.Add(this.label9);
            this.tabPageReports.Controls.Add(this.buttonAddReportReminder);
            this.tabPageReports.Controls.Add(this.buttonExecuteReport);
            this.tabPageReports.Controls.Add(this.label8);
            this.tabPageReports.Controls.Add(this.panelReportView);
            this.tabPageReports.Controls.Add(this.comboBoxReportType);
            this.tabPageReports.Controls.Add(this.label7);
            this.tabPageReports.Location = new System.Drawing.Point(4, 22);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Size = new System.Drawing.Size(683, 456);
            this.tabPageReports.TabIndex = 2;
            this.tabPageReports.Text = "דו\"חות";
            // 
            // comboBoxReportReminderCycleTime
            // 
            this.comboBoxReportReminderCycleTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReportReminderCycleTime.FormattingEnabled = true;
            this.comboBoxReportReminderCycleTime.Location = new System.Drawing.Point(386, 396);
            this.comboBoxReportReminderCycleTime.Name = "comboBoxReportReminderCycleTime";
            this.comboBoxReportReminderCycleTime.Size = new System.Drawing.Size(121, 21);
            this.comboBoxReportReminderCycleTime.TabIndex = 7;
            this.comboBoxReportReminderCycleTime.VisibleChanged += new System.EventHandler(this.comboBoxReportReminderCycleTime_VisibleChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(513, 399);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "הוסף תזכורת לדו\"ח כל";
            // 
            // buttonAddReportReminder
            // 
            this.buttonAddReportReminder.Location = new System.Drawing.Point(144, 394);
            this.buttonAddReportReminder.Name = "buttonAddReportReminder";
            this.buttonAddReportReminder.Size = new System.Drawing.Size(64, 23);
            this.buttonAddReportReminder.TabIndex = 5;
            this.buttonAddReportReminder.Text = "הוסף";
            this.buttonAddReportReminder.UseVisualStyleBackColor = true;
            this.buttonAddReportReminder.Click += new System.EventHandler(this.buttonAddReportReminder_Click);
            // 
            // buttonExecuteReport
            // 
            this.buttonExecuteReport.Location = new System.Drawing.Point(539, 354);
            this.buttonExecuteReport.Name = "buttonExecuteReport";
            this.buttonExecuteReport.Size = new System.Drawing.Size(97, 23);
            this.buttonExecuteReport.TabIndex = 4;
            this.buttonExecuteReport.Text = "הרץ דו\"ח";
            this.buttonExecuteReport.UseVisualStyleBackColor = true;
            this.buttonExecuteReport.Click += new System.EventHandler(this.buttonExecuteReport_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(416, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(223, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "הכנס פרמטרים נדרשים במידת הצורך והרץ";
            // 
            // panelReportView
            // 
            this.panelReportView.AutoScroll = true;
            this.panelReportView.Location = new System.Drawing.Point(27, 73);
            this.panelReportView.Name = "panelReportView";
            this.panelReportView.Size = new System.Drawing.Size(609, 264);
            this.panelReportView.TabIndex = 2;
            // 
            // comboBoxReportType
            // 
            this.comboBoxReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReportType.FormattingEnabled = true;
            this.comboBoxReportType.Location = new System.Drawing.Point(292, 15);
            this.comboBoxReportType.Name = "comboBoxReportType";
            this.comboBoxReportType.Size = new System.Drawing.Size(251, 21);
            this.comboBoxReportType.TabIndex = 1;
            this.comboBoxReportType.VisibleChanged += new System.EventHandler(this.comboBoxReportType_VisibleChanged);
            this.comboBoxReportType.SelectedValueChanged += new System.EventHandler(this.comboBoxReportType_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(561, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "בחר סוג דו\"ח:";
            // 
            // tabPageUsers
            // 
            this.tabPageUsers.BackColor = System.Drawing.Color.Cornsilk;
            this.tabPageUsers.Controls.Add(this.label14);
            this.tabPageUsers.Controls.Add(this.dataGridViewUsers);
            this.tabPageUsers.Controls.Add(this.comboBoxUserType);
            this.tabPageUsers.Controls.Add(this.label15);
            this.tabPageUsers.Controls.Add(this.buttonAddNewUser);
            this.tabPageUsers.Controls.Add(this.buttonLoadUser);
            this.tabPageUsers.Controls.Add(this.textBoxUserName);
            this.tabPageUsers.Controls.Add(this.buttonFindUser);
            this.tabPageUsers.Controls.Add(this.label16);
            this.tabPageUsers.Location = new System.Drawing.Point(4, 22);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Size = new System.Drawing.Size(683, 456);
            this.tabPageUsers.TabIndex = 4;
            this.tabPageUsers.Text = "ניהול משתמשים";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(615, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "שם:";
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AllowUserToDeleteRows = false;
            this.dataGridViewUsers.AllowUserToOrderColumns = true;
            this.dataGridViewUsers.AutoGenerateColumns = false;
            this.dataGridViewUsers.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.volunteerIDDataGridViewTextBoxColumn,
            this.userTypeDataGridViewTextBoxColumn});
            this.dataGridViewUsers.DataSource = this.bindingSourceUsersList;
            this.dataGridViewUsers.Location = new System.Drawing.Point(15, 81);
            this.dataGridViewUsers.MultiSelect = false;
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.ReadOnly = true;
            this.dataGridViewUsers.RowHeadersVisible = false;
            this.dataGridViewUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsers.Size = new System.Drawing.Size(650, 298);
            this.dataGridViewUsers.TabIndex = 25;
            this.dataGridViewUsers.DoubleClick += new System.EventHandler(this.dataGridViewUsers_DoubleClick);
            // 
            // comboBoxUserType
            // 
            this.comboBoxUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUserType.FormattingEnabled = true;
            this.comboBoxUserType.Location = new System.Drawing.Point(250, 52);
            this.comboBoxUserType.Name = "comboBoxUserType";
            this.comboBoxUserType.Size = new System.Drawing.Size(152, 21);
            this.comboBoxUserType.TabIndex = 24;
            this.comboBoxUserType.VisibleChanged += new System.EventHandler(this.comboBoxUserType_VisibleChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(408, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "סוג משתמש:";
            // 
            // buttonAddNewUser
            // 
            this.buttonAddNewUser.Location = new System.Drawing.Point(421, 385);
            this.buttonAddNewUser.Name = "buttonAddNewUser";
            this.buttonAddNewUser.Size = new System.Drawing.Size(114, 23);
            this.buttonAddNewUser.TabIndex = 22;
            this.buttonAddNewUser.Text = "הוסף משתמש חדש";
            this.buttonAddNewUser.UseVisualStyleBackColor = true;
            this.buttonAddNewUser.Click += new System.EventHandler(this.buttonAddNewUser_Click);
            // 
            // buttonLoadUser
            // 
            this.buttonLoadUser.Location = new System.Drawing.Point(551, 385);
            this.buttonLoadUser.Name = "buttonLoadUser";
            this.buttonLoadUser.Size = new System.Drawing.Size(114, 23);
            this.buttonLoadUser.TabIndex = 21;
            this.buttonLoadUser.Text = "טען פרטי משתמש";
            this.buttonLoadUser.UseVisualStyleBackColor = true;
            this.buttonLoadUser.Click += new System.EventHandler(this.buttonLoadUser_Click);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(497, 54);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(112, 20);
            this.textBoxUserName.TabIndex = 20;
            // 
            // buttonFindUser
            // 
            this.buttonFindUser.Location = new System.Drawing.Point(128, 51);
            this.buttonFindUser.Name = "buttonFindUser";
            this.buttonFindUser.Size = new System.Drawing.Size(75, 23);
            this.buttonFindUser.TabIndex = 19;
            this.buttonFindUser.Text = "חפש";
            this.buttonFindUser.UseVisualStyleBackColor = true;
            this.buttonFindUser.Click += new System.EventHandler(this.buttonFindUser_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(578, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 13);
            this.label16.TabIndex = 18;
            this.label16.Text = "מצא משתמש לפי:";
            // 
            // dateTimePickerReportReminderFinishDate
            // 
            this.dateTimePickerReportReminderFinishDate.CustomFormat = "dd-MM-yy";
            this.dateTimePickerReportReminderFinishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerReportReminderFinishDate.Location = new System.Drawing.Point(226, 397);
            this.dateTimePickerReportReminderFinishDate.Name = "dateTimePickerReportReminderFinishDate";
            this.dateTimePickerReportReminderFinishDate.Size = new System.Drawing.Size(79, 20);
            this.dateTimePickerReportReminderFinishDate.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(306, 399);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "החל מתאריך:";
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
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "שם המשתמש";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.userNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // volunteerIDDataGridViewTextBoxColumn
            // 
            this.volunteerIDDataGridViewTextBoxColumn.DataPropertyName = "VolunteerID";
            this.volunteerIDDataGridViewTextBoxColumn.HeaderText = "ת\"ז מתנדב מקושר";
            this.volunteerIDDataGridViewTextBoxColumn.Name = "volunteerIDDataGridViewTextBoxColumn";
            this.volunteerIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.volunteerIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // userTypeDataGridViewTextBoxColumn
            // 
            this.userTypeDataGridViewTextBoxColumn.DataPropertyName = "UserType";
            this.userTypeDataGridViewTextBoxColumn.HeaderText = "סוג המשתמש";
            this.userTypeDataGridViewTextBoxColumn.Name = "userTypeDataGridViewTextBoxColumn";
            this.userTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.userTypeDataGridViewTextBoxColumn.Width = 150;
            // 
            // bindingSourceUsersList
            // 
            this.bindingSourceUsersList.DataSource = typeof(VolunteerManagementBL.Entities.User);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(691, 482);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "מערכת לניהול מתנדבים - צער בעלי חיים";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPageVolunteers.ResumeLayout(false);
            this.tabPageVolunteers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVolunteers)).EndInit();
            this.tabPageActivities.ResumeLayout(false);
            this.tabPageActivities.PerformLayout();
            this.tabPageReports.ResumeLayout(false);
            this.tabPageReports.PerformLayout();
            this.tabPageUsers.ResumeLayout(false);
            this.tabPageUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVolunteersList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsersList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageVolunteers;
        private System.Windows.Forms.TabPage tabPageActivities;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.Button buttonLoadVolunteer;
        private System.Windows.Forms.TextBox textBoxVolunteerName;
        private System.Windows.Forms.Button buttonFindVolunteer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxVolunteerID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddNewVolunteer;
        private System.Windows.Forms.Button buttonAddReportReminder;
        private System.Windows.Forms.Button buttonExecuteReport;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelReportView;
        private System.Windows.Forms.ComboBox comboBoxReportType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxReportReminderCycleTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPageUsers;
        private System.Windows.Forms.Button buttonAddNewActivityType;
        private System.Windows.Forms.Button buttonLoadActivityType;
        private System.Windows.Forms.ComboBox comboBoxActivityTypes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAddNewActivity;
        private System.Windows.Forms.Button buttonLoadActivity;
        private System.Windows.Forms.ListBox listBoxActivities;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MonthCalendar monthCalendarActivities;
        private System.Windows.Forms.ComboBox comboBoxVolunteerActivityType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridViewVolunteers;
        private System.Windows.Forms.BindingSource bindingSourceVolunteersList;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn surnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cellPhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn homePhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eMailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volunteerTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.ComboBox comboBoxUserType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonAddNewUser;
        private System.Windows.Forms.Button buttonLoadUser;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Button buttonFindUser;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.BindingSource bindingSourceUsersList;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volunteerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonAttendReminder;
        private System.Windows.Forms.Button buttonAddReminder;
        private System.Windows.Forms.ListBox listBoxAllReminders;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePickerReportReminderFinishDate;
        private System.Windows.Forms.Label label10;
    }
}