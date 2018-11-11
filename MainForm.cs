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
    public partial class MainForm : Form
    {
        //Enumerators
        internal enum Messages
        {
            noDictionary,
            expandingNotDone,
            textNotWrecked,
            codepageParse,
            replaceDictionary,
            canNotFix,
            deleteDictionary,
            sortingNotImplemented
        }

        //Constructors
        public MainForm()
        {
            InitializeComponent();
            maxVarNumNumericUpDown.Minimum =
                Fixer.NumOfVars = 1;
        }

        //Fields
        int encoding;
        string
            sampleTextPath = @"../../SampleTexts/SimpleSample.txt",
            wreckedTextPath;
        IOForm iof = new IOForm();

        //Delegates
        delegate void pathsOperation(params string[] paths);

        //Methods
        static internal DialogResult MessageShow(Messages c)
        {
            switch (c)
            {
                case Messages.noDictionary:
                    return MessageBox.Show(
                        "A dictionary must be created first.",
                        "There is no dictionary");

                case Messages.expandingNotDone:
                    return MessageBox.Show(
                        "The method to expand the dictionary must be updated first " +
                        "according to the changes made in the dictionary structure.",
                        "Upcoming task");

                case Messages.textNotWrecked:
                    return MessageBox.Show(
                        "The sample text has to be wrecked first.",
                        "Wreck it first");

                case Messages.codepageParse:
                    return MessageBox.Show(
                        "The codepage number must be" +
                        " an integer number between zero and 65 535.",
                        "Can't parse the codepage");

                case Messages.replaceDictionary:
                    return MessageBox.Show(
                        "A dictionary was already created.\n" +
                        "Do you want to replace it?",
                        "Dictionary replacing", MessageBoxButtons.YesNo);

                case Messages.canNotFix:
                    return MessageBox.Show("Entered text can not be fixed with the dictionary.\n" +
                        "May be some words have another form or typo.\n" +
                        "Please, check the text and try again");

                case Messages.deleteDictionary:
                    return MessageBox.Show(
                        "This will delete all the words from " +
                        "the dictionary. Do you want to continue?",
                        "Delete?", MessageBoxButtons.YesNo);

                case Messages.sortingNotImplemented:
                    return MessageBox.Show("The ordering of the words" +
                        "by frequency of their emerging in the processed text " +
                        "is not done yet.", "Upcoming task");

                default:
                    throw new NotImplementedException();
            }
        }
        void CreateDictionary(params string[] paths)
        {
            DeleteDictionary();
            if (encodingTextBox.Text == string.Empty)
                Dictionary.CreateFromFile(paths: paths);
            else
                Dictionary.CreateFromFile(encoding, paths);
        }
        void ExpandDictionary(params string[] paths)
        {
            if (encodingTextBox.Text == string.Empty)
                Dictionary.Expand(paths: paths);
            else
                Dictionary.Expand(encoding, paths);
        }
        void DeleteDictionary()
        {
            Dictionary.Delete();
            showDictionaryTextBox.Text = string.Empty;
            expandButton.Enabled =
            deleteButton.Enabled =
            sortByABCRadioButton.Enabled =
            sortByFreqRadioButton.Enabled = false;
        }
        void OpenFileAndDo(pathsOperation Operation)
        {
            //If encodingText is not empty and either we can not parse it
            //or it's less then zero or it's more then 65 535
            if (encodingTextBox.Text != string.Empty &&
                !int.TryParse(encodingTextBox.Text, out encoding) ||
                encoding < 0 || encoding > 65535)
                MessageShow(Messages.codepageParse);
            else
            {
                if (sampleCheckBox.Checked)
                    Operation(sampleTextPath);
                else
                    using (OpenFileDialog ofd = new OpenFileDialog())
                    {
                        ofd.Multiselect = true;
                        ofd.Filter = "text files (*.txt)|*.txt";
                        string
                            sp = Application.StartupPath,
                            sp1 = sp.Remove(sp.LastIndexOf('\\'));
                        ofd.InitialDirectory =
                            sp1.Remove(sp1.LastIndexOf('\\')) +
                            "\\SapmleTexts";
                        if (ofd.ShowDialog() == DialogResult.OK)
                            Operation(ofd.FileNames);
                        else throw new OperationCanceledException();
                    }
            }
        }
        void WreckIt(params string[] paths)
        {
            if (encodingTextBox.Text == string.Empty)
                Dictionary.CreateFromFile(paths: paths);
            else
                Dictionary.CreateFromFile(encoding, paths);
        }

        //Event handlers
        private void createDictionaryButton_Click(object sender, EventArgs e)
        {
            if (!Dictionary.IsEmpty)
                if (MessageShow(Messages.replaceDictionary) == DialogResult.No)
                    return;
            try
            {
                OpenFileAndDo(CreateDictionary);
                expandButton.Enabled = true;
                deleteButton.Enabled = true;
            }
            catch (OperationCanceledException) { }
        }
        private void fixItFromFileButton_Click(object sender, EventArgs e)
        {
            if (!Dictionary.IsEmpty)
                if (sampleCheckBox.Checked && wreckedTextPath == null)
                    MessageShow(Messages.textNotWrecked);
                else
                    try { OpenFileAndDo(Fixer.FixSpaces); }
                    catch (OperationCanceledException) { }
            else MessageShow(Messages.noDictionary);
        }
        private void fixItFromTextBoxButton_Click(object sender, EventArgs e)
        {
            if (!Dictionary.IsEmpty)
                //using (IOForm IForm = new IOForm(true))
                //{
                //    string text;
                //    try
                //    {
                //        text = TryToFix(IForm);
                //        using (IOForm OForm = new IOForm(false))
                //        {
                //            OForm.inputTextBox.Text = text;
                //            OForm.ShowDialog();
                //        }
                //    }
                //    catch (OperationCanceledException)
                //    { }
                //}
                iof.Show();
            else MessageShow(Messages.noDictionary);
        }
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
                MessageShow(Messages.noDictionary);
        }
        private void expandButton_Click(object sender, EventArgs e)
        {
            try
            {
                //OpenFileAndDo(ExpandDictionary);
                MessageShow(Messages.expandingNotDone);
            }
            catch (OperationCanceledException) { }
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageShow(Messages.deleteDictionary) == DialogResult.Yes)
                DeleteDictionary();
        }
        private void sampleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            fixItFromTextBoxButton.Enabled =
                !(wreckItButton.Enabled = sampleCheckBox.Checked);
        }
        private void sortRadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (sortByFreqRadioButton.Checked)
            {
                MessageShow(Messages.sortingNotImplemented);
                sortByABCRadioButton.Checked =
                    !(sortByFreqRadioButton.Checked = false);
            }
        }
        private void maxVarNumNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Fixer.NumOfVars = (int)maxVarNumNumericUpDown.Value;
        }
        private void wreckItButton_Click(object sender, EventArgs e)
        {
            if (encodingTextBox.Text != string.Empty &&
                !int.TryParse(encodingTextBox.Text, out encoding) ||
                encoding < 0 || encoding > 65535)
                MessageShow(Messages.codepageParse);
            else
            {
                if (encodingTextBox.Text == string.Empty)
                    wreckedTextPath = Wrecker.WreckSpaces(sampleTextPath);
                else
                    wreckedTextPath = Wrecker.WreckSpaces(sampleTextPath, encoding);
            }

        }
    }
}
