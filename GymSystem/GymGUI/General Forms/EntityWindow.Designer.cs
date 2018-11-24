namespace VolunteerManagementGUI
{
    partial class EntityWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntityWindow));
            this.panelEntityDisplayControl = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCloseEntity = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAddNew = new System.Windows.Forms.Button();
            this.buttonSaveUpdate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEntityDisplayControl
            // 
            this.panelEntityDisplayControl.AutoScroll = true;
            this.panelEntityDisplayControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEntityDisplayControl.Location = new System.Drawing.Point(0, 0);
            this.panelEntityDisplayControl.Name = "panelEntityDisplayControl";
            this.panelEntityDisplayControl.Size = new System.Drawing.Size(443, 474);
            this.panelEntityDisplayControl.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCloseEntity);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.buttonAddNew);
            this.panel1.Controls.Add(this.buttonSaveUpdate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 405);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 49);
            this.panel1.TabIndex = 4;
            // 
            // buttonCloseEntity
            // 
            this.buttonCloseEntity.Location = new System.Drawing.Point(20, 14);
            this.buttonCloseEntity.Name = "buttonCloseEntity";
            this.buttonCloseEntity.Size = new System.Drawing.Size(78, 23);
            this.buttonCloseEntity.TabIndex = 7;
            this.buttonCloseEntity.Text = "סגור כרטסת";
            this.buttonCloseEntity.UseVisualStyleBackColor = true;
            this.buttonCloseEntity.Click += new System.EventHandler(this.buttonCloseEntity_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(115, 14);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "מחק כרטסת";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAddNew
            // 
            this.buttonAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddNew.Location = new System.Drawing.Point(205, 14);
            this.buttonAddNew.Name = "buttonAddNew";
            this.buttonAddNew.Size = new System.Drawing.Size(115, 23);
            this.buttonAddNew.TabIndex = 5;
            this.buttonAddNew.Text = "פתח כרטסת חדשה";
            this.buttonAddNew.UseVisualStyleBackColor = true;
            this.buttonAddNew.Click += new System.EventHandler(this.buttonAddNew_Click);
            // 
            // buttonSaveUpdate
            // 
            this.buttonSaveUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveUpdate.Location = new System.Drawing.Point(335, 14);
            this.buttonSaveUpdate.Name = "buttonSaveUpdate";
            this.buttonSaveUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveUpdate.TabIndex = 4;
            this.buttonSaveUpdate.Text = "עדכן מידע";
            this.buttonSaveUpdate.UseVisualStyleBackColor = true;
            this.buttonSaveUpdate.Click += new System.EventHandler(this.buttonSaveUpdate_Click);
            // 
            // EntityWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(443, 454);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelEntityDisplayControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EntityWindow";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "EntityWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EntityWindow_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelEntityDisplayControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAddNew;
        private System.Windows.Forms.Button buttonSaveUpdate;
        private System.Windows.Forms.Button buttonCloseEntity;
    }
}