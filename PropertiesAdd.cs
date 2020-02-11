using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LaborLog
{
    public partial class PropertiesAdd : Form
    {
        internal string[] compareList = null;

        public PropertiesAdd(string Titel, string[] compareList, int MaxLength)
        {
            this.compareList = compareList;
            InitializeComponent();
            this.Text += Titel;
            textBox1.MaxLength = 15;
            textBox1.Focus();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public string result;
        private void buttonContinue_Click(object sender, EventArgs e)
        {
            result = textBox1.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (compareList != null)
            {
                for (int i = 0; i < compareList.Length; i++)
                    if (textBox1.Text == compareList[i])
                    {
                        textBox1.ForeColor = Color.Red;
                        break;
                    }
                    else
                        textBox1.ForeColor = SystemColors.WindowText;
            }
            if (textBox1.Text.Length > 0 && textBox1.ForeColor != Color.Red)
                buttonContinue.Enabled = true;
            else
                buttonContinue.Enabled = false;
        }


        private void KKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                if (buttonContinue.Enabled)
                {
                    result = textBox1.Text;
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
