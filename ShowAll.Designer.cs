namespace LaborLog
{
    partial class ShowAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowAll));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAscending = new System.Windows.Forms.Button();
            this.buttonDescending = new System.Windows.Forms.Button();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.listBoxCategories = new System.Windows.Forms.ListBox();
            this.buttonSelectAllUsers = new System.Windows.Forms.Button();
            this.buttonSelectAllCategories = new System.Windows.Forms.Button();
            this.textBoxNumberOfEntries = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.labelDuration = new System.Windows.Forms.Label();
            this.dTP2 = new System.Windows.Forms.DateTimePicker();
            this.dTP1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.panelUsers = new System.Windows.Forms.Panel();
            this.buttonExpand = new System.Windows.Forms.Button();
            this.buttonCollpaseAll = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelEditNew = new System.Windows.Forms.Panel();
            this.labelOperation = new System.Windows.Forms.Label();
            this.buttonEditNewEntry1 = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonEditNewEntry2 = new System.Windows.Forms.Button();
            this.panelSelection = new System.Windows.Forms.Panel();
            this.buttonUnselectAllCategories = new System.Windows.Forms.Button();
            this.buttonUnSelectAllUsers = new System.Windows.Forms.Button();
            this.buttonCategoriesDown = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.buttonCategoriesUp = new System.Windows.Forms.Button();
            this.buttonAddCategorie = new System.Windows.Forms.Button();
            this.buttonUsersDown = new System.Windows.Forms.Button();
            this.buttonUsersUp = new System.Windows.Forms.Button();
            this.buttonCatergoriesDelete = new System.Windows.Forms.Button();
            this.buttonUsersDelete = new System.Windows.Forms.Button();
            this.buttonDeleteEntry = new System.Windows.Forms.Button();
            this.panelTimeTable = new System.Windows.Forms.Panel();
            this.panelEditNew.SuspendLayout();
            this.panelSelection.SuspendLayout();
            this.panelTimeTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(3, 33);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(305, 591);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sort order:";
            // 
            // buttonAscending
            // 
            this.buttonAscending.Location = new System.Drawing.Point(65, 4);
            this.buttonAscending.Name = "buttonAscending";
            this.buttonAscending.Size = new System.Drawing.Size(75, 23);
            this.buttonAscending.TabIndex = 0;
            this.buttonAscending.Text = "Ascending";
            this.buttonAscending.UseVisualStyleBackColor = true;
            this.buttonAscending.Click += new System.EventHandler(this.buttonAscending_Click);
            // 
            // buttonDescending
            // 
            this.buttonDescending.Location = new System.Drawing.Point(146, 4);
            this.buttonDescending.Name = "buttonDescending";
            this.buttonDescending.Size = new System.Drawing.Size(75, 23);
            this.buttonDescending.TabIndex = 1;
            this.buttonDescending.Text = "Descending";
            this.buttonDescending.UseVisualStyleBackColor = true;
            this.buttonDescending.Click += new System.EventHandler(this.buttonDescending_Click);
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.Location = new System.Drawing.Point(84, 27);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxUsers.Size = new System.Drawing.Size(176, 225);
            this.listBoxUsers.TabIndex = 0;
            this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.listBoxUsers_SelectedIndexChanged);
            // 
            // listBoxCategories
            // 
            this.listBoxCategories.Location = new System.Drawing.Point(340, 27);
            this.listBoxCategories.Name = "listBoxCategories";
            this.listBoxCategories.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxCategories.Size = new System.Drawing.Size(176, 225);
            this.listBoxCategories.TabIndex = 2;
            this.listBoxCategories.SelectedIndexChanged += new System.EventHandler(this.listBoxCategories_SelectedIndexChanged);
            // 
            // buttonSelectAllUsers
            // 
            this.buttonSelectAllUsers.Location = new System.Drawing.Point(84, 257);
            this.buttonSelectAllUsers.Name = "buttonSelectAllUsers";
            this.buttonSelectAllUsers.Size = new System.Drawing.Size(85, 23);
            this.buttonSelectAllUsers.TabIndex = 1;
            this.buttonSelectAllUsers.Text = "Select all";
            this.buttonSelectAllUsers.UseVisualStyleBackColor = true;
            this.buttonSelectAllUsers.Click += new System.EventHandler(this.buttonSelectAllUsers_Click);
            // 
            // buttonSelectAllCategories
            // 
            this.buttonSelectAllCategories.Location = new System.Drawing.Point(340, 258);
            this.buttonSelectAllCategories.Name = "buttonSelectAllCategories";
            this.buttonSelectAllCategories.Size = new System.Drawing.Size(85, 23);
            this.buttonSelectAllCategories.TabIndex = 3;
            this.buttonSelectAllCategories.Text = "Select all";
            this.buttonSelectAllCategories.UseVisualStyleBackColor = true;
            this.buttonSelectAllCategories.Click += new System.EventHandler(this.buttonAllCategories_Click);
            // 
            // textBoxNumberOfEntries
            // 
            this.textBoxNumberOfEntries.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxNumberOfEntries.Location = new System.Drawing.Point(99, 632);
            this.textBoxNumberOfEntries.Name = "textBoxNumberOfEntries";
            this.textBoxNumberOfEntries.ReadOnly = true;
            this.textBoxNumberOfEntries.Size = new System.Drawing.Size(47, 20);
            this.textBoxNumberOfEntries.TabIndex = 12;
            this.textBoxNumberOfEntries.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 635);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Number of entries:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Duration:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "End:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(370, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Begin:";
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Location = new System.Drawing.Point(135, 77);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInfo.Size = new System.Drawing.Size(476, 157);
            this.textBoxInfo.TabIndex = 4;
            // 
            // labelDuration
            // 
            this.labelDuration.Location = new System.Drawing.Point(530, 55);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(57, 19);
            this.labelDuration.TabIndex = 25;
            this.labelDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dTP2
            // 
            this.dTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTP2.Location = new System.Drawing.Point(452, 29);
            this.dTP2.Name = "dTP2";
            this.dTP2.Size = new System.Drawing.Size(159, 20);
            this.dTP2.TabIndex = 3;
            this.dTP2.ValueChanged += new System.EventHandler(this.dTP_ValueChanged);
            // 
            // dTP1
            // 
            this.dTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTP1.Location = new System.Drawing.Point(452, 3);
            this.dTP1.Name = "dTP1";
            this.dTP1.Size = new System.Drawing.Size(159, 20);
            this.dTP1.TabIndex = 2;
            this.dTP1.ValueChanged += new System.EventHandler(this.dTP_ValueChanged);
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(136, 50);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(124, 21);
            this.comboBoxCategories.TabIndex = 1;
            this.comboBoxCategories.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategories_SelectedIndexChanged);
            // 
            // panelUsers
            // 
            this.panelUsers.AutoScroll = true;
            this.panelUsers.BackColor = System.Drawing.SystemColors.Control;
            this.panelUsers.Location = new System.Drawing.Point(6, 16);
            this.panelUsers.Name = "panelUsers";
            this.panelUsers.Size = new System.Drawing.Size(124, 218);
            this.panelUsers.TabIndex = 0;
            // 
            // buttonExpand
            // 
            this.buttonExpand.Location = new System.Drawing.Point(152, 630);
            this.buttonExpand.Name = "buttonExpand";
            this.buttonExpand.Size = new System.Drawing.Size(75, 23);
            this.buttonExpand.TabIndex = 2;
            this.buttonExpand.Text = "Expand all";
            this.buttonExpand.UseVisualStyleBackColor = true;
            this.buttonExpand.Click += new System.EventHandler(this.buttonExpand_Click);
            // 
            // buttonCollpaseAll
            // 
            this.buttonCollpaseAll.Location = new System.Drawing.Point(233, 630);
            this.buttonCollpaseAll.Name = "buttonCollpaseAll";
            this.buttonCollpaseAll.Size = new System.Drawing.Size(75, 23);
            this.buttonCollpaseAll.TabIndex = 3;
            this.buttonCollpaseAll.Text = "Collapse all";
            this.buttonCollpaseAll.UseVisualStyleBackColor = true;
            this.buttonCollpaseAll.Click += new System.EventHandler(this.buttonCollpaseAll_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(136, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Category:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "User:";
            // 
            // panelEditNew
            // 
            this.panelEditNew.BackColor = System.Drawing.SystemColors.Info;
            this.panelEditNew.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelEditNew.Controls.Add(this.labelOperation);
            this.panelEditNew.Controls.Add(this.label6);
            this.panelEditNew.Controls.Add(this.label7);
            this.panelEditNew.Controls.Add(this.panelUsers);
            this.panelEditNew.Controls.Add(this.dTP1);
            this.panelEditNew.Controls.Add(this.label3);
            this.panelEditNew.Controls.Add(this.comboBoxCategories);
            this.panelEditNew.Controls.Add(this.label4);
            this.panelEditNew.Controls.Add(this.dTP2);
            this.panelEditNew.Controls.Add(this.label5);
            this.panelEditNew.Controls.Add(this.labelDuration);
            this.panelEditNew.Controls.Add(this.textBoxInfo);
            this.panelEditNew.Location = new System.Drawing.Point(323, 331);
            this.panelEditNew.Name = "panelEditNew";
            this.panelEditNew.Size = new System.Drawing.Size(618, 245);
            this.panelEditNew.TabIndex = 3;
            // 
            // labelOperation
            // 
            this.labelOperation.ForeColor = System.Drawing.Color.Red;
            this.labelOperation.Location = new System.Drawing.Point(136, 9);
            this.labelOperation.Name = "labelOperation";
            this.labelOperation.Size = new System.Drawing.Size(197, 13);
            this.labelOperation.TabIndex = 34;
            // 
            // buttonEditNewEntry1
            // 
            this.buttonEditNewEntry1.Location = new System.Drawing.Point(323, 582);
            this.buttonEditNewEntry1.Name = "buttonEditNewEntry1";
            this.buttonEditNewEntry1.Size = new System.Drawing.Size(202, 23);
            this.buttonEditNewEntry1.TabIndex = 4;
            this.buttonEditNewEntry1.Text = "Edit entry";
            this.buttonEditNewEntry1.UseVisualStyleBackColor = true;
            this.buttonEditNewEntry1.Click += new System.EventHandler(this.buttonAddNewEntry_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(845, 628);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(96, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(81, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Entry shown for user:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(337, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Entry shown for category:";
            // 
            // buttonEditNewEntry2
            // 
            this.buttonEditNewEntry2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEditNewEntry2.Location = new System.Drawing.Point(739, 582);
            this.buttonEditNewEntry2.Name = "buttonEditNewEntry2";
            this.buttonEditNewEntry2.Size = new System.Drawing.Size(202, 23);
            this.buttonEditNewEntry2.TabIndex = 5;
            this.buttonEditNewEntry2.Text = "Add Additional Session ...";
            this.buttonEditNewEntry2.UseVisualStyleBackColor = true;
            this.buttonEditNewEntry2.Click += new System.EventHandler(this.buttonAddNewEntry_Click);
            // 
            // panelSelection
            // 
            this.panelSelection.Controls.Add(this.buttonUnselectAllCategories);
            this.panelSelection.Controls.Add(this.buttonUnSelectAllUsers);
            this.panelSelection.Controls.Add(this.buttonCategoriesDown);
            this.panelSelection.Controls.Add(this.buttonAddUser);
            this.panelSelection.Controls.Add(this.buttonCategoriesUp);
            this.panelSelection.Controls.Add(this.buttonAddCategorie);
            this.panelSelection.Controls.Add(this.buttonUsersDown);
            this.panelSelection.Controls.Add(this.buttonUsersUp);
            this.panelSelection.Controls.Add(this.label8);
            this.panelSelection.Controls.Add(this.buttonCatergoriesDelete);
            this.panelSelection.Controls.Add(this.label9);
            this.panelSelection.Controls.Add(this.buttonUsersDelete);
            this.panelSelection.Controls.Add(this.listBoxUsers);
            this.panelSelection.Controls.Add(this.listBoxCategories);
            this.panelSelection.Controls.Add(this.buttonSelectAllUsers);
            this.panelSelection.Controls.Add(this.buttonSelectAllCategories);
            this.panelSelection.Location = new System.Drawing.Point(314, 0);
            this.panelSelection.Name = "panelSelection";
            this.panelSelection.Size = new System.Drawing.Size(640, 325);
            this.panelSelection.TabIndex = 2;
            // 
            // buttonUnselectAllCategories
            // 
            this.buttonUnselectAllCategories.Location = new System.Drawing.Point(431, 257);
            this.buttonUnselectAllCategories.Name = "buttonUnselectAllCategories";
            this.buttonUnselectAllCategories.Size = new System.Drawing.Size(85, 23);
            this.buttonUnselectAllCategories.TabIndex = 41;
            this.buttonUnselectAllCategories.Text = "Unselect all";
            this.buttonUnselectAllCategories.UseVisualStyleBackColor = true;
            this.buttonUnselectAllCategories.Click += new System.EventHandler(this.buttonUnselectAllCategories_Click);
            // 
            // buttonUnSelectAllUsers
            // 
            this.buttonUnSelectAllUsers.Location = new System.Drawing.Point(175, 257);
            this.buttonUnSelectAllUsers.Name = "buttonUnSelectAllUsers";
            this.buttonUnSelectAllUsers.Size = new System.Drawing.Size(85, 23);
            this.buttonUnSelectAllUsers.TabIndex = 40;
            this.buttonUnSelectAllUsers.Text = "Unselect all";
            this.buttonUnSelectAllUsers.UseVisualStyleBackColor = true;
            this.buttonUnSelectAllUsers.Click += new System.EventHandler(this.buttonUnSelectAllUsers_Click);
            // 
            // buttonCategoriesDown
            // 
            this.buttonCategoriesDown.Enabled = false;
            this.buttonCategoriesDown.Image = ((System.Drawing.Image)(resources.GetObject("buttonCategoriesDown.Image")));
            this.buttonCategoriesDown.Location = new System.Drawing.Point(522, 56);
            this.buttonCategoriesDown.Name = "buttonCategoriesDown";
            this.buttonCategoriesDown.Size = new System.Drawing.Size(29, 23);
            this.buttonCategoriesDown.TabIndex = 18;
            this.buttonCategoriesDown.UseVisualStyleBackColor = true;
            this.buttonCategoriesDown.Click += new System.EventHandler(this.buttonCategoriesDown_Click);
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(84, 286);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(85, 23);
            this.buttonAddUser.TabIndex = 38;
            this.buttonAddUser.Text = "Add ...";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // buttonCategoriesUp
            // 
            this.buttonCategoriesUp.Enabled = false;
            this.buttonCategoriesUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonCategoriesUp.Image")));
            this.buttonCategoriesUp.Location = new System.Drawing.Point(522, 27);
            this.buttonCategoriesUp.Name = "buttonCategoriesUp";
            this.buttonCategoriesUp.Size = new System.Drawing.Size(29, 23);
            this.buttonCategoriesUp.TabIndex = 17;
            this.buttonCategoriesUp.UseVisualStyleBackColor = true;
            this.buttonCategoriesUp.Click += new System.EventHandler(this.buttonCategoriesUp_Click);
            // 
            // buttonAddCategorie
            // 
            this.buttonAddCategorie.Location = new System.Drawing.Point(340, 286);
            this.buttonAddCategorie.Name = "buttonAddCategorie";
            this.buttonAddCategorie.Size = new System.Drawing.Size(85, 23);
            this.buttonAddCategorie.TabIndex = 39;
            this.buttonAddCategorie.Text = "Add ...";
            this.buttonAddCategorie.UseVisualStyleBackColor = true;
            this.buttonAddCategorie.Click += new System.EventHandler(this.buttonAddCategorie_Click);
            // 
            // buttonUsersDown
            // 
            this.buttonUsersDown.Enabled = false;
            this.buttonUsersDown.Image = ((System.Drawing.Image)(resources.GetObject("buttonUsersDown.Image")));
            this.buttonUsersDown.Location = new System.Drawing.Point(267, 56);
            this.buttonUsersDown.Name = "buttonUsersDown";
            this.buttonUsersDown.Size = new System.Drawing.Size(29, 23);
            this.buttonUsersDown.TabIndex = 14;
            this.buttonUsersDown.UseVisualStyleBackColor = true;
            this.buttonUsersDown.Click += new System.EventHandler(this.buttonUsersDown_Click);
            // 
            // buttonUsersUp
            // 
            this.buttonUsersUp.Enabled = false;
            this.buttonUsersUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonUsersUp.Image")));
            this.buttonUsersUp.Location = new System.Drawing.Point(267, 27);
            this.buttonUsersUp.Name = "buttonUsersUp";
            this.buttonUsersUp.Size = new System.Drawing.Size(29, 23);
            this.buttonUsersUp.TabIndex = 13;
            this.buttonUsersUp.UseVisualStyleBackColor = true;
            this.buttonUsersUp.Click += new System.EventHandler(this.buttonUsersUp_Click);
            // 
            // buttonCatergoriesDelete
            // 
            this.buttonCatergoriesDelete.Location = new System.Drawing.Point(431, 286);
            this.buttonCatergoriesDelete.Name = "buttonCatergoriesDelete";
            this.buttonCatergoriesDelete.Size = new System.Drawing.Size(85, 23);
            this.buttonCatergoriesDelete.TabIndex = 16;
            this.buttonCatergoriesDelete.Text = "Delete";
            this.buttonCatergoriesDelete.UseVisualStyleBackColor = true;
            this.buttonCatergoriesDelete.Click += new System.EventHandler(this.buttonCatergoriesDelete_Click);
            // 
            // buttonUsersDelete
            // 
            this.buttonUsersDelete.Location = new System.Drawing.Point(175, 286);
            this.buttonUsersDelete.Name = "buttonUsersDelete";
            this.buttonUsersDelete.Size = new System.Drawing.Size(85, 23);
            this.buttonUsersDelete.TabIndex = 12;
            this.buttonUsersDelete.Text = "Delete";
            this.buttonUsersDelete.UseVisualStyleBackColor = true;
            this.buttonUsersDelete.Click += new System.EventHandler(this.buttonUsersDelete_Click);
            // 
            // buttonDeleteEntry
            // 
            this.buttonDeleteEntry.Location = new System.Drawing.Point(531, 582);
            this.buttonDeleteEntry.Name = "buttonDeleteEntry";
            this.buttonDeleteEntry.Size = new System.Drawing.Size(202, 23);
            this.buttonDeleteEntry.TabIndex = 6;
            this.buttonDeleteEntry.Text = "Delete entry";
            this.buttonDeleteEntry.UseVisualStyleBackColor = true;
            this.buttonDeleteEntry.Click += new System.EventHandler(this.buttonDeleteEntry_Click);
            // 
            // panelTimeTable
            // 
            this.panelTimeTable.Controls.Add(this.label1);
            this.panelTimeTable.Controls.Add(this.buttonAscending);
            this.panelTimeTable.Controls.Add(this.textBoxNumberOfEntries);
            this.panelTimeTable.Controls.Add(this.treeView1);
            this.panelTimeTable.Controls.Add(this.buttonCollpaseAll);
            this.panelTimeTable.Controls.Add(this.label2);
            this.panelTimeTable.Controls.Add(this.buttonDescending);
            this.panelTimeTable.Controls.Add(this.buttonExpand);
            this.panelTimeTable.Location = new System.Drawing.Point(0, 0);
            this.panelTimeTable.Name = "panelTimeTable";
            this.panelTimeTable.Size = new System.Drawing.Size(317, 660);
            this.panelTimeTable.TabIndex = 1;
            // 
            // ShowAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 659);
            this.Controls.Add(this.panelTimeTable);
            this.Controls.Add(this.panelSelection);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonEditNewEntry1);
            this.Controls.Add(this.buttonEditNewEntry2);
            this.Controls.Add(this.buttonDeleteEntry);
            this.Controls.Add(this.panelEditNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowAll";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show all entries ...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowAll_FormClosing);
            this.panelEditNew.ResumeLayout(false);
            this.panelEditNew.PerformLayout();
            this.panelSelection.ResumeLayout(false);
            this.panelSelection.PerformLayout();
            this.panelTimeTable.ResumeLayout(false);
            this.panelTimeTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAscending;
        private System.Windows.Forms.Button buttonDescending;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.ListBox listBoxCategories;
        private System.Windows.Forms.Button buttonSelectAllUsers;
        private System.Windows.Forms.Button buttonSelectAllCategories;
        private System.Windows.Forms.TextBox textBoxNumberOfEntries;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.DateTimePicker dTP2;
        private System.Windows.Forms.DateTimePicker dTP1;
        private System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.Panel panelUsers;
        private System.Windows.Forms.Button buttonExpand;
        private System.Windows.Forms.Button buttonCollpaseAll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelEditNew;
        private System.Windows.Forms.Button buttonEditNewEntry1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonEditNewEntry2;
        private System.Windows.Forms.Panel panelSelection;
        private System.Windows.Forms.Panel panelTimeTable;
        private System.Windows.Forms.Label labelOperation;
        private System.Windows.Forms.Button buttonDeleteEntry;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonAddCategorie;
        private System.Windows.Forms.Button buttonCategoriesDown;
        private System.Windows.Forms.Button buttonCategoriesUp;
        private System.Windows.Forms.Button buttonUsersDown;
        private System.Windows.Forms.Button buttonUsersUp;
        private System.Windows.Forms.Button buttonCatergoriesDelete;
        private System.Windows.Forms.Button buttonUsersDelete;
        private System.Windows.Forms.Button buttonUnSelectAllUsers;
        private System.Windows.Forms.Button buttonUnselectAllCategories;
    }
}