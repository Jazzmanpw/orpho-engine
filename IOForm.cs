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
            KeyPreview = true;
            Fixer.IfShowExpectations = 
                expectationsCheckBox.Checked = true;
            dispersionNumericUpDown.Increment = .01M;
            dispersionNumericUpDown.Value = (decimal)(Dictionary.Dispersion = 0.01);
        }

        //Fields
        DictionaryDialog dDialog = new DictionaryDialog();
        DictionaryDebugForm ddForm = new DictionaryDebugForm();

        //Event handlers
        private void fixItButton_Click(object sender, EventArgs e)
        {
            try
            { outputTextBox.Text = Fixer.FixString(inputTextBox.Text); }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "keys")
                    SFMessage.Show(Messages.canNotFix);
                else throw;
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
                MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            MessageBoxButtons.YesNo) == DialogResult.Yes)
                inputTextBox.Text = Clipboard.GetText();
        }
        private void IOForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (fixItButton.Enabled && e.Control && e.KeyCode == Keys.D)
                ddForm.Show();
            if (e.Control && e.KeyCode == Keys.W)
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "Choose file to wreck";
                    ofd.Filter = "text files (*.txt)|*.txt";
                    ofd.InitialDirectory = System.IO.Path.Combine(
                        (new System.IO.DirectoryInfo(Application.StartupPath)).
                        Parent.Parent.Name, "SampleTexts");
                    if (ofd.ShowDialog() == DialogResult.OK)
                        Wrecker.WreckSpaces(ofd.FileName, 1251);
                }
        }
        private void dictionaryButton_Click(object sender, EventArgs e)
        {
            switch (dDialog.ShowDialog())
            {
                case DialogResult.Yes:
                    fixItButton.Enabled = true;
                    break;
                case DialogResult.No:
                    fixItButton.Enabled = false;
                    ddForm.RemoveText();
                    break;
            }
        }
        private void expectationsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Fixer.IfShowExpectations = expectationsCheckBox.Checked;
        }
        private void dispersionNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Dictionary.Dispersion = (double)dispersionNumericUpDown.Value;
        }
    }
}
