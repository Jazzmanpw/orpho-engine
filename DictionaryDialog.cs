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
    public partial class DictionaryDialog : Form
    {
        //Constructors
        public DictionaryDialog()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        //Fields
        int encoding;

        //Delegates
        delegate void pathsOperation(params string[] paths);

        //Methods
        //public void CreateSampleDectionary(
        void CreateDictionary(params string[] paths)
        {
            DeleteDictionary();
            if (encodingTextBox.Text == string.Empty)
                Dictionary.CreateFromFile(paths: paths);
            else
                Dictionary.CreateFromFile(encoding, paths);
        }
        void DeleteDictionary()
        {
            Dictionary.Delete();
            deleteButton.Enabled = false;
        }
        bool OpenFileAndDo(pathsOperation Operation)
        {
            //If encodingText is not empty and either we can not parse it
            //or it's less then zero or it's more then 65 535
            if (encodingTextBox.Text != string.Empty &&
                !int.TryParse(encodingTextBox.Text, out encoding) ||
                encoding < 0 || encoding > 65535)
                SFMessage.Show(Messages.codepageParse);
            else
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Multiselect = true;
                    ofd.Filter = "text files (*.txt)|*.txt";
                    ofd.InitialDirectory = Path.Combine(
                        (new DirectoryInfo(Application.StartupPath)).
                        Parent.Parent.FullName, "SampleTexts");
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        Operation(ofd.FileNames);
                        return true;
                    }
                }
            return false;
        }

        //Event handlers
        private void createButton_Click(object sender, EventArgs e)
        {
            if (!Dictionary.IsEmpty)
                if (SFMessage.Show(Messages.replaceDictionary) == DialogResult.No)
                    return;
            if (OpenFileAndDo(CreateDictionary))
                deleteButton.Enabled = true;
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (SFMessage.Show(Messages.deleteDictionary) == DialogResult.Yes)
                DeleteDictionary();
        }
    }
}
