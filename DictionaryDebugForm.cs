using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceFix
{
    public partial class DictionaryDebugForm : Form
    {

        //Constructors
        public DictionaryDebugForm()
        {
            InitializeComponent();
        }

        //Methods
        public void RemoveText()
        {
            showDictionaryTextBox.Text = string.Empty;
            sortByABCRadioButton.Enabled =
            sortByFreqRadioButton.Enabled = false;
        }

        //Event handlers
        private void showDictionaryButton_Click(object sender, EventArgs e)
        {
            if (!Dictionary.IsEmpty)
            {
                sortByABCRadioButton.Enabled =
                sortByFreqRadioButton.Enabled = true;
                showDictionaryTextBox.Text =
                    "Total amount of words in processed text is " +
                    $"{Dictionary.TotalWordsCount}.";
                foreach (string word in Dictionary.Words)
                    showDictionaryTextBox.AppendText(
                        $"{Environment.NewLine}{word}" +
                        $" ({Dictionary.Frequency(word)})");
            }
            else
                SFMessage.Show(Messages.noDictionary);
        }
        private void sortRadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (sortByFreqRadioButton.Checked)
            {
                SFMessage.Show(Messages.sortingNotImplemented);
                sortByABCRadioButton.Checked =
                    !(sortByFreqRadioButton.Checked = false);
            }
        }
        private void DictionaryDebugForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
