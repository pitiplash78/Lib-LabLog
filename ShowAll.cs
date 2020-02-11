using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LaborLog
{
    public partial class ShowAll : Form
    {
        public LabLog LabLog
        {
            get { return labLog; }
        }
        private LabLog labLog = null;

        public bool ModifiedDataBase { get; private set; }

        #region private variables
        private bool AddUserOrCategory = false;
        private bool UsePassWord = true;

        private int activeEntry = -1;
        private TreeEntries treeEntries = null;

        private bool suppress = false;

        private enum OperationMode
        {
            None,
            EditEntry,
            NewEntry,
        }
        private OperationMode operationMode = OperationMode.None;

        #endregion

        public ShowAll(LabLog labLog, bool AddUserOrCategory = false, bool UsePassWord = true)
        {
            this.labLog = labLog;
            this.AddUserOrCategory = AddUserOrCategory;
            this.UsePassWord = UsePassWord;
            this.ModifiedDataBase = false;
            InitializeComponent();

            dTP1.CustomFormat = "HH:mm:ss   dd.MM.yyyy";
            dTP2.CustomFormat = "HH:mm:ss   dd.MM.yyyy";

            this.listBoxUsers.DrawMode = DrawMode.OwnerDrawFixed;
            this.listBoxUsers.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            fillUsers();

            this.listBoxCategories.DrawMode = DrawMode.OwnerDrawFixed;
            this.listBoxCategories.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            fillCategories();

            buttonAddUser.Visible = AddUserOrCategory;
            buttonUsersDelete.Visible = AddUserOrCategory;
            buttonUsersUp.Visible = AddUserOrCategory;
            buttonUsersDown.Visible = AddUserOrCategory;

            buttonAddCategorie.Visible = AddUserOrCategory;
            buttonCatergoriesDelete.Visible = AddUserOrCategory;
            buttonCategoriesUp.Visible = AddUserOrCategory;
            buttonCategoriesDown.Visible = AddUserOrCategory;

            treeEntries = fillTree(labLog, TreeEntries.SortOrder.Descending);

            selectAllUsers(true);
            selectAllCategories(true);
        }

        private void ShowAll_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (operationMode != OperationMode.None)
                return;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }


        #region Users
        private void fillUsers()
        {
            suppress = true;
            listBoxUsers.Items.Clear();
            if (labLog.metaInformation.AllUsers != null)
            {
                for (int i = 0; i < labLog.metaInformation.AllUsers.Length; i++)
                {
                    if (labLog.metaInformation.AllUsers[i].Active)
                        listBoxUsers.Items.Add(
                            new MyListBoxItem(Color.Green, labLog.metaInformation.AllUsers[i].Name));
                    else
                        listBoxUsers.Items.Add(
                            new MyListBoxItem(Color.DarkGray, labLog.metaInformation.AllUsers[i].Name));
                }
                listBoxUsers.TopIndex = 0;
            }
            suppress = false;
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            addUser();
        }
        private void addUser()
        {
            List<string> users = new List<string>();
            if (labLog.metaInformation.AllUsers != null)
                foreach (LaborLog.UsersClass cc in labLog.metaInformation.AllUsers)
                    if (cc.Active)
                        users.Add(cc.Name);

            PropertiesAdd uAdd = new PropertiesAdd("User", (string[])users.ToArray(), 15);
            if (uAdd.ShowDialog() == DialogResult.OK)
            {
                List<LaborLog.UsersClass> u = new List<UsersClass>();
                if (labLog.metaInformation.AllUsers != null)
                    u = new List<LaborLog.UsersClass>(labLog.metaInformation.AllUsers);

                bool existent = false;
                if (labLog.metaInformation.AllUsers != null)
                {
                    for (int i = 0; i < labLog.metaInformation.AllUsers.Length; i++)
                    {
                        if (labLog.metaInformation.AllUsers[i].Name == uAdd.result)
                        {
                            labLog.metaInformation.AllUsers[i].Active = true;
                            existent = true;
                        }
                    }
                }
                if (!existent)
                {

                    u.Add(new LaborLog.UsersClass(uAdd.result, true));
                    labLog.metaInformation.AllUsers = u.ToArray();
                }
                ModifiedDataBase = true;
                fillUsers();
            }
        }
      
        private void buttonUsersDelete_Click(object sender, EventArgs e)
        {
            string tuser = labLog.metaInformation.AllUsers[listBoxUsers.SelectedIndex].Name;

            List<LaborLog.UsersClass> user = new List<LaborLog.UsersClass>(labLog.metaInformation.AllUsers);
          
            bool existent = false;

            for (int i = 0; i < labLog.InfoEntryItems.Length; i++)
            {
                for (int j = 0; j < labLog.InfoEntryItems[i].Users.Length; j++)
                {
                    for (int k = 0; k < user.Count; k++)
                    {
                        if (tuser == labLog.InfoEntryItems[i].Users[j])
                        {
                            existent = true;
                            break;
                        }
                    }
                }
            }

            if (existent)
                user[listBoxUsers.SelectedIndex].Active = false;
            else
                user.RemoveAt(listBoxUsers.SelectedIndex);
            
            labLog.metaInformation.AllUsers = user.ToArray();
            ModifiedDataBase = true;

            buttonUsersDelete.Enabled = false;
            buttonUsersUp.Enabled = false;
            buttonUsersDown.Enabled = false;

            fillUsers();
        }
        
        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppress)
                return;
           
            if (listBoxUsers.SelectedIndex != -1)
            {
                // get if multiple is selected
                int imultiple = 0;
                for (int i = 0; i < listBoxUsers.Items.Count; i++)
                {
                    if (listBoxUsers.GetSelected(i))
                        imultiple++;
                }
                if (imultiple > 1)
                {
                    buttonUsersDelete.Enabled = false;
                    buttonUsersUp.Enabled = false;
                    buttonUsersDown.Enabled = false;
                }
                else
                {
                    buttonUsersDelete.Enabled = true;

                    if (listBoxUsers.SelectedIndex > 0 && labLog.metaInformation.AllUsers.Length > 1)
                        buttonUsersUp.Enabled = true;
                    else
                        buttonUsersUp.Enabled = false;

                    if (listBoxUsers.SelectedIndex < (labLog.metaInformation.AllUsers.Length - 1) &&
                        labLog.metaInformation.AllUsers.Length > 1)
                        buttonUsersDown.Enabled = true;
                    else
                        buttonUsersDown.Enabled = false;
                }
            }
            treeEntries = fillTree(labLog, treeEntries.sortOrder);
        }
        
        private void buttonUsersUp_Click(object sender, EventArgs e)
        {
            int i_old = listBoxUsers.SelectedIndex;
            int i_new = listBoxUsers.SelectedIndex - 1;

            List<LaborLog.UsersClass> user = new List<LaborLog.UsersClass>(labLog.metaInformation.AllUsers);
            LaborLog.UsersClass tmp = user[i_old];

            user.RemoveAt(i_old);
            user.Insert(i_new, tmp);

            labLog.metaInformation.AllUsers = user.ToArray();

            fillUsers();

            listBoxUsers.SelectedIndex = i_new;
        }
        private void buttonUsersDown_Click(object sender, EventArgs e)
        {
            int i_old = listBoxUsers.SelectedIndex;
            int i_new = listBoxUsers.SelectedIndex + 1;

            List<LaborLog.UsersClass> user = new List<LaborLog.UsersClass>(labLog.metaInformation.AllUsers);
            LaborLog.UsersClass tmp = user[i_old];

            user.RemoveAt(i_old);
            user.Insert(i_new, tmp);

            labLog.metaInformation.AllUsers = user.ToArray();

            fillUsers();

            listBoxUsers.SelectedIndex = i_new;
        }
        
        private void buttonSelectAllUsers_Click(object sender, EventArgs e)
        {
            selectAllUsers(true);
        }
        private void buttonUnSelectAllUsers_Click(object sender, EventArgs e)
        {
            selectAllUsers(false);
        }

        private void selectAllUsers(bool state)
        {
            suppress = true;
            for (int x = 0; x < listBoxUsers.Items.Count; x++)
                listBoxUsers.SetSelected(x, state);
            listBoxUsers.TopIndex = 0;
            suppress = false;
            treeEntries = fillTree(labLog, treeEntries.sortOrder);

            buttonUsersDelete.Enabled = false;
            buttonUsersUp.Enabled = false;
            buttonUsersDown.Enabled = false;
        }
        #endregion

        #region Categories
        private void fillCategories()
        {
            suppress = true;
            listBoxCategories.Items.Clear();
            for (int i = 0; i < labLog.metaInformation.Categories.Length; i++)
            {
                if (labLog.metaInformation.Categories[i].Active)
                {
                    if(labLog.metaInformation.Categories[i].UsedForNotfication)
                        listBoxCategories.Items.Add(
                            new MyListBoxItem(Color.Red, labLog.metaInformation.Categories[i].Name));
                    else
                        listBoxCategories.Items.Add(
                            new MyListBoxItem(Color.Green, labLog.metaInformation.Categories[i].Name));
                }
                else
                    listBoxCategories.Items.Add(
                        new MyListBoxItem(Color.DarkGray, labLog.metaInformation.Categories[i].Name));
            }
            listBoxCategories.TopIndex = 0;

            suppress = false;
        }

        private void buttonAddCategorie_Click(object sender, EventArgs e)
        {
            List<string> c = new List<string>();
            foreach (CategoryClass cc in labLog.metaInformation.Categories)
                c.Add(cc.Name);

            PropertiesAdd uAdd = new PropertiesAdd("Categories", (string[])c.ToArray(), 15);
            if (uAdd.ShowDialog() == DialogResult.OK)
            {
                List<CategoryClass> cC = new List<CategoryClass>(labLog.metaInformation.Categories);
                cC.Add(new CategoryClass(uAdd.result, true, true));
                labLog.metaInformation.Categories = cC.ToArray();
                ModifiedDataBase = true;
                fillCategories();
            }
        }

        private void buttonCatergoriesDelete_Click(object sender, EventArgs e)
        {
            string tcategorie = labLog.metaInformation.Categories[listBoxCategories.SelectedIndex].Name;

            List<LaborLog.CategoryClass> catergories = new List<LaborLog.CategoryClass>(labLog.metaInformation.Categories);

            bool existent = false;

            for (int i = 0; i < labLog.InfoEntryItems.Length; i++)
            {
                for (int k = 0; k < catergories.Count; k++)
                {
                    if (tcategorie == labLog.InfoEntryItems[i].Category.Name)
                    {
                        existent = true;
                        break;
                    }
                }
                if (existent)
                    break;
            }

            if (existent)
                catergories[listBoxCategories.SelectedIndex].Active = false;
            else
                catergories.RemoveAt(listBoxCategories.SelectedIndex);

            labLog.metaInformation.Categories = catergories.ToArray();
            ModifiedDataBase = true;

            buttonCatergoriesDelete.Enabled = false;
            buttonCategoriesUp.Enabled = false;
            buttonCategoriesDown.Enabled = false;

            fillCategories();
        }
       
        private void listBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppress)
                return;

            if (listBoxCategories.SelectedIndex != -1)
            {
                // get if multiple is selected
                int imultiple = 0;
                for (int i = 0; i < listBoxCategories.Items.Count; i++)
                {
                    if (listBoxCategories.GetSelected(i))
                        imultiple++;
                }
                if (imultiple > 1)
                {
                    buttonCatergoriesDelete.Enabled = false;
                    buttonCategoriesUp.Enabled = false;
                    buttonCategoriesDown.Enabled = false;
                }
                else
                {
                    buttonCatergoriesDelete.Enabled = true;

                    if (listBoxCategories.SelectedIndex > 0 && labLog.metaInformation.AllUsers.Length > 1)
                        buttonCategoriesUp.Enabled = true;
                    else
                        buttonCategoriesUp.Enabled = false;

                    if (listBoxCategories.SelectedIndex < (labLog.metaInformation.AllUsers.Length - 1) &&
                        labLog.metaInformation.AllUsers.Length > 1)
                        buttonCategoriesDown.Enabled = true;
                    else
                        buttonCategoriesDown.Enabled = false;
                }
            }
            treeEntries = fillTree(labLog, treeEntries.sortOrder);
        }

        private void buttonCategoriesUp_Click(object sender, EventArgs e)
        {
            int i_old = listBoxCategories.SelectedIndex;
            int i_new = listBoxCategories.SelectedIndex - 1;

            List<LaborLog.CategoryClass> categories = new List<LaborLog.CategoryClass>(labLog.metaInformation.Categories);
            LaborLog.CategoryClass tmp = categories[i_old];

            categories.RemoveAt(i_old);
            categories.Insert(i_new, tmp);

            labLog.metaInformation.Categories = categories.ToArray();

            fillCategories();

            listBoxCategories.SelectedIndex = i_new;
        }
        private void buttonCategoriesDown_Click(object sender, EventArgs e)
        {
            int i_old = listBoxCategories.SelectedIndex;
            int i_new = listBoxCategories.SelectedIndex + 1;

            List<LaborLog.CategoryClass> categories = new List<LaborLog.CategoryClass>(labLog.metaInformation.Categories);
            LaborLog.CategoryClass tmp = categories[i_old];

            categories.RemoveAt(i_old);
            categories.Insert(i_new, tmp);

            labLog.metaInformation.Categories = categories.ToArray();

            fillCategories();

            listBoxCategories.SelectedIndex = i_new;
        }

        private void buttonAllCategories_Click(object sender, EventArgs e)
        {
            selectAllCategories(true);
        }
        private void buttonUnselectAllCategories_Click(object sender, EventArgs e)
        {
            selectAllCategories(false);
        }
       
        private void selectAllCategories(bool state)
        {
            suppress = true;
            for (int x = 0; x < listBoxCategories.Items.Count; x++)
                listBoxCategories.SetSelected(x, state);
            listBoxCategories.TopIndex = 0;
            suppress = false;
            treeEntries = fillTree(labLog, treeEntries.sortOrder);

            buttonCatergoriesDelete.Enabled = false;
            buttonCategoriesUp.Enabled = false;
            buttonCategoriesDown.Enabled = false;
        }
        #endregion

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            MyListBoxItem item = listBox.Items[e.Index] as MyListBoxItem; // Get the current item and cast it to MyListBoxItem
            if (item != null)
            {
                e.DrawBackground();
                if (listBox.GetSelected(e.Index))
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), e.Bounds);
                else
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);

                e.Graphics.DrawString( // Draw the appropriate text in the ListBox
                    item.Message, // The message linked to the item
                    listBox.Font, // Take the font from the listbox
                    new SolidBrush(item.ItemColor), // Set the color 
                    0, // X pixel coordinate
                    e.Index * listBox.ItemHeight // Y pixel coordinate.  Multiply the index by the ItemHeight defined in the listbox.
                );
            }
            else
            {
                // The item isn't a MyListBoxItem, do something about it
            }
        }

        public class MyListBoxItem
        {
            public MyListBoxItem(Color c, string m)
            {
                ItemColor = c;
                Message = m;
            }
            public Color ItemColor { get; set; }
            public string Message { get; set; }
        }

        #region time table (TreeView) forms and control
        private TreeEntries fillTree(LabLog lablog, TreeEntries.SortOrder SortOrder)
        {
            List<LaborLog.UsersClass> users = new List<LaborLog.UsersClass>();
            for (int i = 0; i < listBoxUsers.Items.Count; i++)
                if (listBoxUsers.GetSelected(i))
                    users.Add(lablog.metaInformation.AllUsers[i]);

            List<LaborLog.CategoryClass> categories = new List<LaborLog.CategoryClass>();
            for (int i = 0; i < listBoxCategories.Items.Count; i++)
                if (listBoxCategories.GetSelected(i))
                    categories.Add(lablog.metaInformation.Categories[i]);

            TreeEntries treeEntries = new TreeEntries(SortOrder);
            int numberOfEntries = 0;

            if (SortOrder == TreeEntries.SortOrder.Ascending)
            {
                for (int i = 0; i < lablog.InfoEntryItems.Length; i++)
                {
                    Entry entry = lablog.InfoEntryItems[i];
                    addEntry(ref treeEntries, ref entry, ref users, ref categories, ref numberOfEntries);
                }
            }

            if (SortOrder == TreeEntries.SortOrder.Descending)
            {
                for (int i = lablog.InfoEntryItems.Length - 1; i >= 0; i--)
                {
                    Entry entry = lablog.InfoEntryItems[i];
                    addEntry(ref treeEntries, ref entry, ref users, ref categories, ref numberOfEntries);
                }
            }
            textBoxNumberOfEntries.Text = numberOfEntries.ToString();
            treeView1.Nodes.Clear();
            if (treeEntries.treeList.Count > 0)
            {
                treeView1.BeginUpdate();
                // Add a root TreeNode for each Customer object in the ArrayList.
                foreach (TreeEntries.Year year in treeEntries.treeList)
                {
                    treeView1.Nodes.Add(new TreeNode(year.year.ToString()));
                    // Add a child treenode for each Order object in the current Customer object.
                    foreach (TreeEntries.Month month in year.Month)
                    {
                        List<TreeNode> tList = new List<TreeNode>();
                        bool c = false;
                        foreach (Entry entry in month.Entries)
                        {
                            DateTime start = DateTime.Parse(entry.StartTime);
                            TimeSpan duration = TimeSpan.Parse(entry.Duration);
                            duration = new TimeSpan(duration.Days, duration.Hours, duration.Minutes, duration.Seconds);
                            TreeNode t = new TreeNode(start.ToString("HH:mm:ss   dd.MM.yyyy") + " - " + duration.ToString());
                            if (c)
                                t.BackColor = SystemColors.ControlLightLight;
                            else
                                t.BackColor = SystemColors.ControlLight;
                            c = !c;
                            tList.Add(t);
                        }
                        TreeNode treeNode = new TreeNode(
                            System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month.month),
                            tList.ToArray());
                        treeView1.Nodes[treeEntries.treeList.IndexOf(year)].Nodes.Add(treeNode);
                    }
                }
                for (int i = 0; i < treeView1.Nodes.Count; i++)
                    treeView1.Nodes[i].Expand();

                treeView1.EndUpdate();

                if (treeEntries.sortOrder == TreeEntries.SortOrder.Ascending)
                {
                    buttonAscending.Enabled = false;
                    buttonDescending.Enabled = true;
                    treeView1.Nodes[treeView1.Nodes.Count - 1].Expand();
                    treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes[treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes.Count - 1].Expand();
                    int i = treeView1.Nodes.Count - 1;
                    int j = treeView1.Nodes[i].Nodes.Count - 1;
                    int k = treeView1.Nodes[i].Nodes[j].Nodes.Count - 1;
                    treeView1.SelectedNode = treeView1.Nodes[i].Nodes[j].Nodes[k];
                    treeView1.Nodes[i].Nodes[j].Nodes[k].EnsureVisible();
                }
                if (treeEntries.sortOrder == TreeEntries.SortOrder.Descending)
                {
                    buttonAscending.Enabled = true;
                    buttonDescending.Enabled = false;
                    treeView1.Nodes[0].Expand();
                    treeView1.Nodes[0].Nodes[0].Expand();
                    treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0].Nodes[0];
                    treeView1.Nodes[0].EnsureVisible();
                }
            }
            if (treeEntries.treeList.Count == 0)
            {
                buttonDeleteEntry.Enabled = false;
                buttonEditNewEntry1.Enabled = false;
                panelUsers.Controls.Clear();
            }
            else
            {
                buttonDeleteEntry.Enabled = true;
                buttonEditNewEntry1.Enabled = true;
            }

            return treeEntries;
        }
        private void addEntry(ref TreeEntries treeEntries, ref Entry entry, ref List<LaborLog.UsersClass> users, ref List<CategoryClass> categories, ref int numberOfEntries)
        {
            if (checkUsers(ref entry, ref users) && checkCategories(ref entry, ref categories))
            {
                DateTime dt = DateTime.Parse(entry.StartTime);

                int indexYear = treeEntries.ContainsYear(dt.Year);
                int indexMonth = treeEntries.ContainsMonth(indexYear, dt.Month);

                if (indexYear == -1 && indexMonth == -1)
                {
                    TreeEntries.Month m = new TreeEntries.Month(dt.Month);
                    m.Entries.Add(entry);

                    TreeEntries.Year y = new TreeEntries.Year(dt.Year);
                    y.Month.Add(m);

                    treeEntries.treeList.Add(y);
                }
                if (indexYear != -1 && indexMonth == -1)
                {
                    TreeEntries.Month m = new TreeEntries.Month(dt.Month);
                    m.Entries.Add(entry);
                    treeEntries.treeList[indexYear].Month.Add(m);
                }
                if (indexYear != -1 && indexMonth != -1)
                {
                    treeEntries.treeList[indexYear].Month[indexMonth].Entries.Add(entry);
                }
                numberOfEntries++;
            }
        }

        private bool checkUsers(ref Entry entry, ref List<LaborLog.UsersClass> users)
        {
            for (int i = 0; i < entry.Users.Length; i++)
            {
                for (int j = 0; j < users.Count; j++)
                {
                    if (users[j].Name == entry.Users[i])
                        return true;
                }
            }
            return false;
        }
        private bool checkCategories(ref Entry entry, ref List<CategoryClass> categories)
        {
            for (int i = 0; i < categories.Count; i++)
                if (entry.Category.Name == categories[i].Name)
                    return true;
            return false;
        }
        private void setCategories()
        {
            comboBoxCategories.Items.Clear();
            for (int i = 0; i < labLog.metaInformation.Categories.Length; i++)
                this.comboBoxCategories.Items.Add(labLog.metaInformation.Categories[i].Name);

            this.comboBoxCategories.SelectedIndex = 0;
        }
       

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            panelEditNew.Enabled = false;

            var treeNode = treeView1.SelectedNode;
            panelUsers.Controls.Clear();
            textBoxInfo.Text = null;

            if (treeNode.Level != 2)
                return;

            string[] p = treeNode.Text.Split(new char[] { '-' });
            DateTime dtstart = DateTime.Parse(p[0]);
            dtstart = new DateTime(dtstart.Year, dtstart.Month, dtstart.Day, dtstart.Hour, dtstart.Minute, dtstart.Second);
            TimeSpan tsduration = TimeSpan.Parse(p[1]);
            tsduration = new TimeSpan(tsduration.Days, tsduration.Hours, tsduration.Minutes, tsduration.Seconds);

            activeEntry = -1;
            for (int i = 0; i < labLog.InfoEntryItems.Length; i++)
            {
                DateTime s = DateTime.Parse(labLog.InfoEntryItems[i].StartTime);
                s = new DateTime(s.Year, s.Month, s.Day, s.Hour, s.Minute, s.Second);
                TimeSpan t = TimeSpan.Parse(labLog.InfoEntryItems[i].Duration);
                t = new TimeSpan(t.Days, t.Hours, t.Minutes, t.Seconds);

                if (dtstart == s && tsduration == t)
                {
                    activeEntry = i;
                    break;
                }
            }

            if (activeEntry == -1)
                return;
                       
            setUserbuttons(true);
            setCategories();

            // Buttons setzen
            for (int i = 0; i < labLog.InfoEntryItems[activeEntry].Users.Length; i++)
            {
                for (int j = 0; j < UserButtons.Length; j++)
                {
                    if (labLog.InfoEntryItems[activeEntry].Users[i] == UserButtons[j].Text)
                    {
                        UserButtons[j].FlatStyle = FlatStyle.Flat;
                        UserButtons[j].BackColor = Color.Red;
                    }
                }
            }
            // Kategorie setzen
            for (int i = 0; i < labLog.metaInformation.Categories.Length; i++)
                if (labLog.metaInformation.Categories[i].Name == labLog.InfoEntryItems[activeEntry].Category.Name)
                    comboBoxCategories.SelectedIndex = i;

            // Zeiten setzen
            DateTime dt = DateTime.Parse(labLog.InfoEntryItems[activeEntry].StartTime);
            dt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            dTP1.Value = dt;
            dt = DateTime.Parse(labLog.InfoEntryItems[activeEntry].StartTime).Add(TimeSpan.Parse(labLog.InfoEntryItems[activeEntry].Duration));
            dt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            dTP2.Value = dt;
            TimeSpan duration = dTP2.Value - dTP1.Value;
            if (duration < new TimeSpan(0))
                labelDuration.ForeColor = Color.Red;
            else
                labelDuration.ForeColor = System.Drawing.SystemColors.ControlText;

            labelDuration.Text = duration.ToString();

            // Text setzen
            textBoxInfo.Lines = labLog.InfoEntryItems[activeEntry].InfoString;
        }

        private void buttonAscending_Click(object sender, EventArgs e)
        {
            treeEntries = fillTree(labLog, TreeEntries.SortOrder.Ascending);
        }

        private void buttonDescending_Click(object sender, EventArgs e)
        {
            treeEntries = fillTree(labLog, TreeEntries.SortOrder.Descending);
        }

        private void buttonExpand_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void buttonCollpaseAll_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private class TreeEntries
        {
            public enum SortOrder
            {
                None,
                Ascending,
                Descending
            }

            public SortOrder sortOrder { get; set; }

            public TreeEntries(SortOrder sortOrder)
            {
                this.sortOrder = sortOrder;
            }

            public List<Year> treeList = new List<Year>();

            public int ContainsYear(int year)
            {
                int index = -1;

                if (treeList.Count == 0)
                    return index;

                for (int i = 0; i < treeList.Count; i++)
                {
                    if (year == treeList[i].year)
                    {
                        index = i;
                        break;
                    }
                }
                return index;
            }

            public int ContainsMonth(int indexYear, int Month)
            {
                int index = -1;

                if (treeList.Count == 0 || indexYear == -1)
                    return index;

                for (int i = 0; i < treeList[indexYear].Month.Count; i++)
                {
                    if (Month == treeList[indexYear].Month[i].month)
                    {
                        index = i;
                        break;
                    }
                }

                return index;
            }

            public class Year : System.Object
            {
                public int year { get; set; }

                protected List<Month> month = new List<Month>();

                public Year(int year)
                {
                    this.year = year;
                }

                public List<Month> Month
                {
                    get { return this.month; }
                }
            }

            public class Month : System.Object
            {
                public int month { get; set; }

                protected List<Entry> entry = new List<Entry>();

                public Month(int month)
                {
                    this.month = month;
                }

                public List<Entry> Entries
                {
                    get { return this.entry; }
                }
            }
        }
        #endregion

        #region Entry events 
        private void buttonDeleteEntry_Click(object sender, EventArgs e)
        {
            if (UsePassWord)
            {
                if (labLog.metaInformation.UsePassword)
                {
                    PasswordEntry pw = new PasswordEntry(labLog.metaInformation.Password);
                    if (pw.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        return;
                }
            }
            labLog.RemoveColoumnEntryAt(activeEntry);
            ModifiedDataBase = true;
            treeEntries = fillTree(labLog, treeEntries.sortOrder);
        }

        private static class ButtonText
        {
            public const string labelOperationEdit = "Edit entry";
            public const string labelOperationNew = "New entry";
            public const string buttonEditNewEntry1 = "Edit entry";
            public const string buttonEditNewEntry1_Dialog = "Continue";
            public const string buttonEditNewEntry2 = "Add Additional Session ...";
            public const string buttonEditNewEntry2_Dialog = "Return";
        }

        private void buttonAddNewEntry_Click(object sender, EventArgs e)
        {
            if (operationMode == OperationMode.None)
            {
                panelTimeTable.Enabled = false;
                panelSelection.Enabled = false;
                buttonClose.Enabled = false;
                panelEditNew.Enabled = true;

                // edit entry
                if (((Button)sender).Name == buttonEditNewEntry1.Name)
                {
                    if (UsePassWord)
                    {
                        if (labLog.metaInformation.UsePassword)
                        {
                            PasswordEntry pw = new PasswordEntry(labLog.metaInformation.Password);
                            if (pw.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                return;
                        }
                    }
                    labelOperation.Text = ButtonText.labelOperationEdit;
                    operationMode = OperationMode.EditEntry;

                    buttonEditNewEntry1.Text = ButtonText.buttonEditNewEntry1_Dialog;
                    buttonEditNewEntry2.Text = ButtonText.buttonEditNewEntry2_Dialog;
                }

                // new entry
                if (((Button)sender).Name == buttonEditNewEntry2.Name)
                {
                    labelOperation.Text = ButtonText.labelOperationNew;
                    operationMode = OperationMode.NewEntry;

                    buttonEditNewEntry1.Text = ButtonText.buttonEditNewEntry1_Dialog;
                    buttonEditNewEntry2.Text = ButtonText.buttonEditNewEntry2_Dialog;

                    setUserbuttons(false);
                    setCategories();
                    dTP1.Value = DateTime.Now;
                    dTP2.Value = dTP1.Value.AddHours(1);
                    textBoxInfo.Text = "";
                }
            }
            else if (operationMode == OperationMode.EditEntry || operationMode == OperationMode.NewEntry)
            {
                panelUsers.Controls.Clear();
                panelTimeTable.Enabled = true;
                panelSelection.Enabled = true;
                buttonEditNewEntry1.Enabled = true;
                buttonClose.Enabled = true;
                panelEditNew.Enabled = false;

                labelOperation.Text = "";

                buttonEditNewEntry1.Text = ButtonText.buttonEditNewEntry1;
                buttonEditNewEntry2.Text = ButtonText.buttonEditNewEntry2;

                if (((Button)sender).Name == buttonEditNewEntry1.Name)
                {
                    Entry newEntry = getEntry();
                    if (operationMode == OperationMode.EditEntry)
                    {
                        labLog.RemoveColoumnEntryAt(activeEntry);
                    }
                    else if (operationMode == OperationMode.NewEntry)
                    {
                        // Nothing to do
                    }

                    int entryNumber = -1;
                    LabLog.insertEntry(ref labLog, ref newEntry, false, out entryNumber);
                    ModifiedDataBase = true;
                    treeEntries = fillTree(labLog, treeEntries.sortOrder);
                }
                else
                {
                    if (treeEntries.treeList.Count == 0)
                    {
                        buttonDeleteEntry.Enabled = false;
                        buttonEditNewEntry1.Enabled = false;
                        panelUsers.Controls.Clear();
                    }
                    else
                    {
                        buttonDeleteEntry.Enabled = true;
                        buttonEditNewEntry1.Enabled = true;
                    }
                }

                operationMode = OperationMode.None;
            }
        }

        private Entry getEntry()
        {
            Entry entry = new Entry();

            //entry updaten
            List<string> tmpUsersList = new List<string>();
            for (int i = 0; i < UserButtons.Length; i++)
                if (UserButtons[i].BackColor == Color.Red)
                    tmpUsersList.Add(UserButtons[i].Text);

            entry.Users = tmpUsersList.ToArray();

            entry.Category = labLog.metaInformation.Categories[comboBoxCategories.SelectedIndex];

            entry.StartTime = dTP1.Value.ToString("o");
            entry.Duration = (dTP2.Value - dTP1.Value).ToString();
            entry.InfoString = textBoxInfo.Lines;
            return entry;
        }

        private Button[] UserButtons;
        private void setUserbuttons(bool all)
        {
            if (UserButtons != null)
                this.panelUsers.Controls.Clear();
            
            int length = 0;
            if (all)
            {
                if (labLog.metaInformation.AllUsers == null)
                    addUser(); 
                length = labLog.metaInformation.AllUsers.Length;
            }
            else
            {
                if(labLog.metaInformation.AllUsers == null)
                    addUser();
                length = labLog.metaInformation.AllUsers.Length;
            }
            
            UserButtons = new Button[length];

            int width = panelUsers.Width - 17;
            if (length * 23 < panelUsers.Height)
                width = panelUsers.Width;

            for (int i = 0; i < length; i++)
            {
                UserButtons[i] = new Button();
                UserButtons[i].Size = new Size(width, 23);
                UserButtons[i].Location = new Point(0, i * 23);
                UserButtons[i].TextAlign = ContentAlignment.MiddleRight;
                if (all)
                {
                    string user = labLog.metaInformation.AllUsers[i].Name;
                    UserButtons[i].Text = user;
                }
                else
                    UserButtons[i].Text = labLog.metaInformation.AllUsers[i].Name;
                UserButtons[i].Name = i.ToString();
                UserButtons[i].BackColor = SystemColors.Control;
                UserButtons[i].Click += UserButtons_click;
            }
            if (UserButtons.Length == 1)
                UserButtons[0].PerformClick();

            this.panelUsers.Controls.AddRange(UserButtons);
        }
        private void UserButtons_click(object sender, EventArgs e)
        {
            Button uB = (Button)sender;

            if (uB.FlatStyle == FlatStyle.Flat)
            {
                uB.FlatStyle = FlatStyle.Standard;
                Color color;
                if (Convert.ToInt32(uB.Name) % 2 == 0)
                    color = Color.GhostWhite;
                else
                    color = Color.Gainsboro;
                uB.BackColor = color;
                uB.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                uB.FlatStyle = FlatStyle.Flat;
                uB.BackColor = Color.Red;
            }
            checkCompleteEntry();
        }
       
        private void comboBoxCategories_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                e.Handled = true;
            checkCompleteEntry();
        }
        private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkCompleteEntry();
        }
        
        private void dTP_ValueChanged(object sender, EventArgs e)
        {
            if (suppress)
                return;

            TimeSpan duration = dTP2.Value - dTP1.Value;
            labelDuration.Text = duration.ToString();

            if (duration < new TimeSpan(0))
                labelDuration.ForeColor = Color.Red;
            else
                labelDuration.ForeColor = System.Drawing.SystemColors.ControlText;

            checkCompleteEntry();
        }

        private void checkCompleteEntry()
        {
            if (operationMode != OperationMode.None)
            {
                bool complete = true;

                if (labelDuration.ForeColor == Color.Red)
                    complete = false;

                bool us = false;
                for (int i = 0; i < UserButtons.Length; i++)
                    if (UserButtons[i].BackColor == Color.Red)
                        us = true;

                complete = us;

                if (complete)
                    buttonEditNewEntry1.Enabled = true;
                else
                    buttonEditNewEntry1.Enabled = false;
            }
        }
        #endregion
    }
}