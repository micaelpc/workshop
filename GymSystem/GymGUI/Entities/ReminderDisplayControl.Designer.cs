namespace VolunteerManagementGUI.Entities
{
    partial class ReminderDisplayControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxTimingType = new System.Windows.Forms.ComboBox();
            this.dateTimePickerNextReminderDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxAttentionStatus = new System.Windows.Forms.ComboBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.comboBoxUserList = new System.Windows.Forms.ComboBox();
            this.bindingSourceActivities = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceActivities)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 25);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "משתמש מקושר:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 63);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "תוכן התזכורת:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 155);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "תאריך קרוב:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 189);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "האם טופלה:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(372, 222);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "מחזוריות:";
            // 
            // comboBoxTimingType
            // 
            this.comboBoxTimingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimingType.FormattingEnabled = true;
            this.comboBoxTimingType.Location = new System.Drawing.Point(258, 219);
            this.comboBoxTimingType.Name = "comboBoxTimingType";
            this.comboBoxTimingType.Size = new System.Drawing.Size(97, 21);
            this.comboBoxTimingType.TabIndex = 26;
            // 
            // dateTimePickerNextReminderDate
            // 
            this.dateTimePickerNextReminderDate.CustomFormat = "dd-MM-yy";
            this.dateTimePickerNextReminderDate.Enabled = false;
            this.dateTimePickerNextReminderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerNextReminderDate.Location = new System.Drawing.Point(273, 149);
            this.dateTimePickerNextReminderDate.Name = "dateTimePickerNextReminderDate";
            this.dateTimePickerNextReminderDate.Size = new System.Drawing.Size(82, 20);
            this.dateTimePickerNextReminderDate.TabIndex = 28;
            // 
            // comboBoxAttentionStatus
            // 
            this.comboBoxAttentionStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttentionStatus.FormattingEnabled = true;
            this.comboBoxAttentionStatus.Items.AddRange(new object[] {
            "כן",
            "לא"});
            this.comboBoxAttentionStatus.Location = new System.Drawing.Point(258, 186);
            this.comboBoxAttentionStatus.Name = "comboBoxAttentionStatus";
            this.comboBoxAttentionStatus.Size = new System.Drawing.Size(97, 21);
            this.comboBoxAttentionStatus.TabIndex = 29;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Enabled = false;
            this.textBoxDescription.Location = new System.Drawing.Point(13, 79);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(416, 59);
            this.textBoxDescription.TabIndex = 30;
            // 
            // comboBoxUserList
            // 
            this.comboBoxUserList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUserList.FormattingEnabled = true;
            this.comboBoxUserList.Location = new System.Drawing.Point(192, 22);
            this.comboBoxUserList.Name = "comboBoxUserList";
            this.comboBoxUserList.Size = new System.Drawing.Size(145, 21);
            this.comboBoxUserList.TabIndex = 31;
            // 
            // bindingSourceActivities
            // 
            this.bindingSourceActivities.DataSource = typeof(VolunteerManagementBL.Entities.Activity);
            this.bindingSourceActivities.Sort = "";
            // 
            // ReminderDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.Controls.Add(this.comboBoxUserList);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.comboBoxAttentionStatus);
            this.Controls.Add(this.dateTimePickerNextReminderDate);
            this.Controls.Add(this.comboBoxTimingType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "ReminderDisplayControl";
            this.Size = new System.Drawing.Size(449, 430);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceActivities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourceActivities;
        private System.Windows.Forms.DataGridViewTextBoxColumn activityDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn activityTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxTimingType;
        private System.Windows.Forms.DateTimePicker dateTimePickerNextReminderDate;
        private System.Windows.Forms.ComboBox comboBoxAttentionStatus;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ComboBox comboBoxUserList;

    }
}
