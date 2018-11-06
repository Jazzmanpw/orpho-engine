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
        public IOForm(bool isInput)
        {
            InitializeComponent();
            textBox.ReadOnly =
                copyButton.Visible =
                !isInput;
            pasteButton.Visible =
                clearButton.Visible =
                cancelButton.Visible =
                isInput;
            Text = isInput ? "Text to fix spaces" : "Fixed text";
        }

        //Event handlers
        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            if (textBox.Text != string.Empty &&
                MessageBox.Show("Do you want to delete all " +
                "the data from the text box?", "Clear?",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
                textBox.Text = string.Empty;
        }
        private void copyButton_Click(object sender, EventArgs e)
        {
            if (textBox.Text != string.Empty)
                Clipboard.SetText(textBox.Text);
        }
        private void pasteButton_Click(object sender, EventArgs e)
        {
            string text = Clipboard.GetText();
            if (text == string.Empty) return;
            if (textBox.Text == string.Empty ||
            MessageBox.Show("The entered text will be relaced.\n" +
            "Do you want to continue?", "Replace?",
            MessageBoxButtons.OKCancel) == DialogResult.OK)
                textBox.Text = Clipboard.GetText();

        }
    }
}
