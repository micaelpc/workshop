namespace VolunteerManagementGUI.Entities
{
    partial class UserDisplayControl
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
            this.bindingSourceActivities = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPasswordVerify = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxPermissionType = new System.Windows.Forms.ComboBox();
            this.comboBoxVolunteerList = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceActivities)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSourceActivities
            // 
            this.bindingSourceActivities.DataSource = typeof(VolunteerManagementBL.Entities.Activity);
            this.bindingSourceActivities.Sort = "";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(155, 14);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxUserName.Size = new System.Drawing.Size(181, 20);
            this.textBoxUserName.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(342, 17);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "שם המשתמש:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(342, 50);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "סוג הרשאה:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(153, 162);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxPassword.Size = new System.Drawing.Size(181, 20);
            this.textBoxPassword.TabIndex = 19;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 165);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "סיסמא:";
            // 
            // textBoxPasswordVerify
            // 
            this.textBoxPasswordVerify.Location = new System.Drawing.Point(153, 195);
            this.textBoxPasswordVerify.Name = "textBoxPasswordVerify";
            this.textBoxPasswordVerify.PasswordChar = '*';
            this.textBoxPasswordVerify.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxPasswordVerify.Size = new System.Drawing.Size(181, 20);
            this.textBoxPasswordVerify.TabIndex = 21;
            this.textBoxPasswordVerify.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 198);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "וידוא סיסמא:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 124);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(241, 26);
            this.label5.TabIndex = 22;
            this.label5.Text = "על מנת להגדיר סיסמא יש להכניס את הסיסמא\r\nהמבוקשת בשני השדות הבאים:";
            // 
            // comboBoxPermissionType
            // 
            this.comboBoxPermissionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPermissionType.FormattingEnabled = true;
            this.comboBoxPermissionType.Location = new System.Drawing.Point(155, 47);
            this.comboBoxPermissionType.Name = "comboBoxPermissionType";
            this.comboBoxPermissionType.Size = new System.Drawing.Size(181, 21);
            this.comboBoxPermissionType.TabIndex = 23;
            // 
            // comboBoxVolunteerList
            // 
            this.comboBoxVolunteerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVolunteerList.FormattingEnabled = true;
            this.comboBoxVolunteerList.Location = new System.Drawing.Point(155, 83);
            this.comboBoxVolunteerList.Name = "comboBoxVolunteerList";
            this.comboBoxVolunteerList.Size = new System.Drawing.Size(181, 21);
            this.comboBoxVolunteerList.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(342, 86);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "מתנדב מקושר:";
            // 
            // UserDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.Controls.Add(this.comboBoxVolunteerList);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxPermissionType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPasswordVerify);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.label2);
            this.Name = "UserDisplayControl";
            this.Size = new System.Drawing.Size(449, 430);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceActivities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourceActivities;
        private System.Windows.Forms.DataGridViewTextBoxColumn activityDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn activityTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPasswordVerify;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxPermissionType;
        private System.Windows.Forms.ComboBox comboBoxVolunteerList;
        private System.Windows.Forms.Label label6;

    }
}
