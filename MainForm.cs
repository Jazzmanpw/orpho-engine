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
        public enum Messages
        {
            noDictionary,
            openingFilesNotDone,
            textNotWrecked,
            showDictionary,
            codepageParse,
            replaceDictionary,
            canNotFix
        }

        //Constructors
        public MainForm()
        {
            InitializeComponent();
        }

        //Fields
        int
            timerTime = 0,
            encoding;
        string
            sampleTextPath = @"../../SampleTexts/SimpleSample.txt",
            wreckedTextPath;

        //Delegates
        delegate void pathsOperation(params string[] paths);

        //Methods
        DialogResult MessageShow(Messages c)
        {
            switch (c)
            {
                case Messages.noDictionary:
                    return MessageBox.Show(
                        "A dictionary must be created first.",
                        "There is no dictionary");

                case Messages.openingFilesNotDone:
                    return MessageBox.Show(
                        "We have to handle file opening by OpenFileDialog first",
                        "Upcoming task");

                case Messages.textNotWrecked:
                    return MessageBox.Show(
                        "The sample text has to be wrecked first.",
                        "Wreck it first");

                case Messages.showDictionary:
                    string message = "It takes about 15 seconds to get the keys " +
                        "of a dictionary with approximately 40 words. " +
                        "Do you really want to wait? Consider the text " +
                        "you made the dictionary with and the variety of words in it";
                    return MessageBox.Show(message, "Do you want to wait?", MessageBoxButtons.YesNo);

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

                default:
                    throw new NotImplementedException();
            }
        }
        void CreateDictionary(params string[] paths)
        {
            if (encodingTextBox.Text == string.Empty)
                Dictionary.CreateFromFile(paths);
            else
                Dictionary.CreateFromFile(encoding, paths);
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
                    }
            }
        }
        string TryToFix(IOForm IForm)
        {
            if (IForm.ShowDialog() == DialogResult.OK)
                try
                { return Fixer.FixString(IForm.textBox.Text); }
                catch (ArgumentException e)
                {
                    if (e.ParamName == "keys")
                    {
                        MessageShow(Messages.canNotFix);
                        return TryToFix(IForm);
                    }
                    throw;
                }
            throw new OperationCanceledException();
        }

        //Event handlers
        private void createDictionaryButton_Click(object sender, EventArgs e)
        {
            //timer.Start();
            if (!Dictionary.IsEmpty)
                if (MessageShow(Messages.replaceDictionary) == DialogResult.No)
                    return;
            OpenFileAndDo(CreateDictionary);

            //timer.Stop();
            ////Why doesn't timer count seconds correctly?!?
            //timerLabel.Text = "Time in s: " + timerTime;
            //timerTime = 0;
        }
        private void fixItFromFileButton_Click(object sender, EventArgs e)
        {
            if (!Dictionary.IsEmpty)
                if (sampleCheckBox.Checked && wreckedTextPath == null)
                    MessageShow(Messages.textNotWrecked);
                else OpenFileAndDo(Fixer.FixSpaces);
            else MessageShow(Messages.noDictionary);
        }
        private void fixItFromTextBoxButton_Click(object sender, EventArgs e)
        {
            using (IOForm IForm = new IOForm(true))
            {
                string text;
                try
                {
                    text = TryToFix(IForm);
                    using (IOForm OForm = new IOForm(false))
                    {
                        OForm.textBox.Text = text;
                        OForm.ShowDialog();
                    }
                }
                catch (OperationCanceledException)
                { }
            }
        }
        private void showDictionaryButton_Click(object sender, EventArgs e)
        {
            if (!Dictionary.IsEmpty)
            {
                if (MessageShow(Messages.showDictionary)
                    == DialogResult.Yes)
                    showDictionaryTextBox.Lines = Dictionary.Words;
            }
            else
                MessageShow(Messages.noDictionary);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timerTime++;
        }
        private void sampleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            fixItFromTextBoxButton.Enabled =
                !(wreckItButton.Enabled = sampleCheckBox.Checked);
        }
        private void wreckItButton_Click(object sender, EventArgs e)
        {
            //if (sampleCheckBox.Checked)
            wreckedTextPath = Wrecker.WreckSpaces(sampleTextPath);
            //else MessageShow(Messages.openingFilesNotDone);
        }
    }
}
