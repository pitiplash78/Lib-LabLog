using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LaborLog
{
    public partial class PasswordEntry : Form
    {
        internal string Password = null;

        public PasswordEntry(string Password)
        {
            this.Password = Password;

            InitializeComponent();
        }

        private void checkCapsLock()
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
                labelCapsLook.Text = "Caps Lock is activated!";
            else
                labelCapsLook.Text = "";
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            verify();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void verify()
        {
            if (SimpleDecode(Password) == textBox1.Text)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                labelWrongPassword.Text = "Wrong password! Try again!";
                textBox1.SelectAll();
            }
        }

        private void KKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                verify();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            checkCapsLock();
        }

        /// <summary>
        /// Simple encoding for a string.
        /// </summary>
        /// <param name="str">String to encoded.</param>
        /// <returns>Encoded string.</returns>
        private static string SimpleEncode(string str)
        {
            string result = null;
            for (int i = 0; i < str.Length; ++i)
                result = string.Concat(result, (char)(str[i] - 1));
            return result;
        }

        /// <summary>
        /// Simple decoding for a string.
        /// </summary>
        /// <param name="str">String to decoded.</param>
        /// <returns>Decoded string.</returns>
        public static string SimpleDecode(string str)
        {
            string result = null;
            for (int i = 0; i < str.Length; ++i)
                result = string.Concat(result, (char)(str[i] + 1));

            return result;
        }

    }
}
