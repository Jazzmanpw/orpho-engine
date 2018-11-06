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
            showDictionary
        }

        //Constructors
        public MainForm()
        {
            InitializeComponent();
        }

        //Fields
        int timerTime = 0;
        string
            sampleTextPath = @"../../SampleTexts/SimpleSample.txt",
            wreckedTextPath;

        //Methods
        void OpeningFilesNotDoneMessageShow()
        {
            MessageBox.Show("We have to handle file opening by OpenFileDialog first", "Upcoming task");
        }
        DialogResult MessageShow(Messages c)
        {
            switch (c)
            {
                case Messages.noDictionary:
                    return MessageBox.Show("A dictionary must be created first.");
                case Messages.openingFilesNotDone:
                    return MessageBox.Show(
                        "We have to handle file opening by OpenFileDialog first",
                        "Upcoming task");
                case Messages.textNotWrecked:
                    return MessageBox.Show("The sample text has to be wrecked first.");
                case Messages.showDictionary:
                    string message = "It takes about 15 seconds to get the keys " +
                        "of a dictionary with approximately 40 words. " +
                        "Do you really want to wait? Consider the text " +
                        "you made the dictionary with and the variety of words in it";
                    return MessageBox.Show(message, "Do you want to wait?", MessageBoxButtons.YesNo);
                default:
                    throw new NotImplementedException();
            }
        }

        //Event handlers
        private void createDictionaryButton_Click(object sender, EventArgs e)
        {
            timer.Start();
            if (sampleCheckBox.Checked)
            {
                if (!Dictionary.IsEmpty)
                    if (MessageBox.Show(
                        "A dictionary was already created.\nDo you want to replace it?",
                        "Dictionary replacing", MessageBoxButtons.YesNo)
                        == DialogResult.No)
                        return;
                Dictionary.CreateFromFile(sampleTextPath);
            }
            else OpeningFilesNotDoneMessageShow();
            timer.Stop();
            //Why doesn't timer count seconds correctly?!?
            timerLabel.Text = "Time in s: " + timerTime;
            timerTime = 0;
        }
        private void fixItButton_Click(object sender, EventArgs e)
        {
            if (sampleCheckBox.Checked)
            {
                if (!Dictionary.IsEmpty)
                    try { Fixer.FixSpaces(wreckedTextPath); }
                    catch (ArgumentNullException)
                    { MessageShow(Messages.textNotWrecked); }
                else MessageShow(Messages.noDictionary);
            }
            else MessageShow(Messages.openingFilesNotDone);
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
        private void wreckItButton_Click(object sender, EventArgs e)
        {
            if (sampleCheckBox.Checked)
                wreckedTextPath = Wrecker.WreckSpaces(sampleTextPath);
            else MessageShow(Messages.openingFilesNotDone);
        }
    }
}
