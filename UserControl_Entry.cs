using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LaborLog
{
    public partial class UserControl_Entry : UserControl
    {
        public TextBox textBoxCategories;
        public ComboBox comboBoxCategories;

        public UserControl_Entry()
        {
            InitializeComponent();
        }

        public UserControl_Entry(bool newEntry)
        {
            InitializeComponent();

            suppress = true;
            if (newEntry)
            {
                this.BackColor = Color.Gray;

                this.textBoxCount.ForeColor = Color.Red;

                this.buttonEdit.ForeColor = Color.Green;
                this.buttonEdit.Text = "Finish";

                this.labelEnd.Visible = false;

                this.comboBoxCategories = new ComboBox();
                this.comboBoxCategories.Location = new System.Drawing.Point(panelTime.Location.X, buttonEdit.Location.Y);
                this.comboBoxCategories.Name = "textBoxCategories";
                this.comboBoxCategories.Size = new System.Drawing.Size(panelTime.Width, buttonEdit.Height);
                this.comboBoxCategories.Anchor = ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));

                this.comboBoxCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F,
                               System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.comboBoxCategories.AllowDrop = false;
                this.comboBoxCategories.SelectedIndexChanged += new EventHandler(comboBoxCategories_SelectedIndexChanged);

                this.textBoxUsers.ReadOnly = false;
                this.textBoxInfo.ReadOnly = false;

                this.Controls.Add(comboBoxCategories); 

            }
            else
            {
                this.textBoxCategories = new TextBox();
                this.textBoxCategories.Location = new System.Drawing.Point(panelTime.Location.X, buttonEdit.Location.Y); 
                this.textBoxCategories.Name = "textBoxCategories";
                this.textBoxCategories.Size = new System.Drawing.Size(panelTime.Width, buttonEdit.Height);
                this.textBoxCategories.Anchor = ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.textBoxCategories.ReadOnly = true;
              
                this.Controls.Add(textBoxCategories); 
            }
            suppress = false;
        }

        private bool suppress = false;
        private void textBoxUsers_TextChanged(object sender, EventArgs e)
        {
            if (suppress)
                return;

            entryChanged(EntryChangedEvent.User);
        }

        private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppress)
                return;

            entryChanged(EntryChangedEvent.Category);
        }


        private void textBoxInfo_TextChanged(object sender, EventArgs e)
        {
            if (suppress)
                return;

            entryChanged(EntryChangedEvent.Information);
        }


        public delegate void EntryChangedHandler(object sender, EntryChangedEventArgs e);
        /// <summary>
        /// Event will by thrown do tue a change of the 'Station' object
        /// </summary>
        public event EntryChangedHandler EntryChanged;

        public enum EntryChangedEvent
        {
            None,
            Category,
            User,
            Information,
        }

        private void entryChanged(EntryChangedEvent status)
        {
            // Make sure someone is listening to event
            if (EntryChanged == null) return;

            EntryChangedEventArgs args = new EntryChangedEventArgs(status);
            EntryChanged(this, args);
        }

        public class EntryChangedEventArgs : EventArgs
        {
            public EntryChangedEvent Status { get; private set; }

            public EntryChangedEventArgs(EntryChangedEvent status)
            {
                Status = status;
            }
        }
   }
}
