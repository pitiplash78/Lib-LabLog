namespace LaborLog
{
    partial class UserControl_Entry
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxUsers = new System.Windows.Forms.TextBox();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.labelDuration = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.panelTime = new System.Windows.Forms.Panel();
            this.panelTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxUsers
            // 
            this.textBoxUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsers.Location = new System.Drawing.Point(173, 3);
            this.textBoxUsers.Multiline = true;
            this.textBoxUsers.Name = "textBoxUsers";
            this.textBoxUsers.ReadOnly = true;
            this.textBoxUsers.Size = new System.Drawing.Size(99, 67);
            this.textBoxUsers.TabIndex = 0;
            this.textBoxUsers.TextChanged += new System.EventHandler(this.textBoxUsers_TextChanged);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInfo.Location = new System.Drawing.Point(278, 3);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ReadOnly = true;
            this.textBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInfo.Size = new System.Drawing.Size(458, 67);
            this.textBoxInfo.TabIndex = 1;
            this.textBoxInfo.TextChanged += new System.EventHandler(this.textBoxInfo_TextChanged);
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.ForeColor = System.Drawing.Color.Red;
            this.labelStart.Location = new System.Drawing.Point(0, 1);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(51, 13);
            this.labelStart.TabIndex = 2;
            this.labelStart.Text = "labelStart";
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.ForeColor = System.Drawing.Color.Green;
            this.labelEnd.Location = new System.Drawing.Point(0, 14);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(48, 13);
            this.labelEnd.TabIndex = 3;
            this.labelEnd.Text = "labelEnd";
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.ForeColor = System.Drawing.Color.Black;
            this.labelDuration.Location = new System.Drawing.Point(0, 27);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(69, 13);
            this.labelDuration.TabIndex = 4;
            this.labelDuration.Text = "labelDuration";
            // 
            // textBoxCount
            // 
            this.textBoxCount.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCount.Location = new System.Drawing.Point(4, 3);
            this.textBoxCount.Multiline = true;
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.ReadOnly = true;
            this.textBoxCount.Size = new System.Drawing.Size(46, 20);
            this.textBoxCount.TabIndex = 8;
            this.textBoxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEdit.BackColor = System.Drawing.SystemColors.Control;
            this.buttonEdit.Location = new System.Drawing.Point(4, 47);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(46, 23);
            this.buttonEdit.TabIndex = 9;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = false;
            // 
            // panelTime
            // 
            this.panelTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTime.Controls.Add(this.labelStart);
            this.panelTime.Controls.Add(this.labelEnd);
            this.panelTime.Controls.Add(this.labelDuration);
            this.panelTime.Location = new System.Drawing.Point(59, 3);
            this.panelTime.Name = "panelTime";
            this.panelTime.Size = new System.Drawing.Size(108, 44);
            this.panelTime.TabIndex = 10;
            // 
            // UserControl_Entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelTime);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.textBoxUsers);
            this.Name = "UserControl_Entry";
            this.Size = new System.Drawing.Size(739, 75);
            this.panelTime.ResumeLayout(false);
            this.panelTime.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxUsers;
        public System.Windows.Forms.TextBox textBoxInfo;
        public System.Windows.Forms.Label labelStart;
        public System.Windows.Forms.Label labelEnd;
        public System.Windows.Forms.Label labelDuration;
        public System.Windows.Forms.TextBox textBoxCount;
        public System.Windows.Forms.Button buttonEdit;
        public System.Windows.Forms.Panel panelTime;
    }
}
