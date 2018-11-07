using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceFix
{
    public partial class IOForm : Form
    {
        //Constructors
        public IOForm()
        {
            InitializeComponent();
        }

        //Event handlers
        private void fixItButton_Click(object sender, EventArgs e)
        {
            try
            { outputTextBox.Text = Fixer.FixString(inputTextBox.Text); }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "keys")
                    MainForm.MessageShow(MainForm.Messages.canNotFix);
                throw;
            }
        }
        private void inputClearButton_Click(object sender, EventArgs e)
        {
            if (inputTextBox.Text != string.Empty &&
                MessageBox.Show("Do you want to delete all " +
                "the data from the input text box?", "Clear?",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
                inputTextBox.Text = string.Empty;
        }
        private void outputClearButton_Click(object sender, EventArgs e)
        {
            if (outputTextBox.Text != string.Empty &&
                MessageBox.Show("Do you want to delete all " +
                "the data from the output text box?", "Clear?",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
                outputTextBox.Text = string.Empty;
        }
        private void copyButton_Click(object sender, EventArgs e)
        {
            if (outputTextBox.Text != string.Empty)
                Clipboard.SetText(outputTextBox.Text);
        }
        private void pasteButton_Click(object sender, EventArgs e)
        {
            string text = Clipboard.GetText();
            if (text == string.Empty) return;
            if (inputTextBox.Text == string.Empty ||
            MessageBox.Show("The entered text will be relaced.\n" +
            "Do you want to continue?", "Replace?",
            MessageBoxButtons.OKCancel) == DialogResult.OK)
                inputTextBox.Text = Clipboard.GetText();
        }

        private void IOForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
