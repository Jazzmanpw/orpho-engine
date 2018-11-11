namespace SpaceFix
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.createDictionaryButton = new System.Windows.Forms.Button();
            this.sampleCheckBox = new System.Windows.Forms.CheckBox();
            this.wreckItButton = new System.Windows.Forms.Button();
            this.showDictionaryButton = new System.Windows.Forms.Button();
            this.fixItFromFileButton = new System.Windows.Forms.Button();
            this.showDictionaryTextBox = new System.Windows.Forms.TextBox();
            this.encodingLabel1 = new System.Windows.Forms.Label();
            this.encodingLabel2 = new System.Windows.Forms.Label();
            this.encodingTextBox = new System.Windows.Forms.TextBox();
            this.dictionaryLabel = new System.Windows.Forms.Label();
            this.generalPanel = new System.Windows.Forms.Panel();
            this.maxVarNumNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxVarNumLabel = new System.Windows.Forms.Label();
            this.dictionaryPanel2 = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.expandButton = new System.Windows.Forms.Button();
            this.textsOperationsLabel = new System.Windows.Forms.Label();
            this.textsOperationsPanel = new System.Windows.Forms.Panel();
            this.fixItFromTextBoxButton = new System.Windows.Forms.Button();
            this.dictionaryPanel1 = new System.Windows.Forms.Panel();
            this.sortByABCRadioButton = new System.Windows.Forms.RadioButton();
            this.sortLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sortByFreqRadioButton = new System.Windows.Forms.RadioButton();
            this.generalPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxVarNumNumericUpDown)).BeginInit();
            this.dictionaryPanel2.SuspendLayout();
            this.textsOperationsPanel.SuspendLayout();
            this.dictionaryPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // createDictionaryButton
            // 
            this.createDictionaryButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.createDictionaryButton.Location = new System.Drawing.Point(0, 0);
            this.createDictionaryButton.Name = "createDictionaryButton";
            this.createDictionaryButton.Size = new System.Drawing.Size(81, 23);
            this.createDictionaryButton.TabIndex = 0;
            this.createDictionaryButton.Text = "Create";
            this.createDictionaryButton.UseVisualStyleBackColor = true;
            this.createDictionaryButton.Click += new System.EventHandler(this.createDictionaryButton_Click);
            // 
            // sampleCheckBox
            // 
            this.sampleCheckBox.AutoSize = true;
            this.sampleCheckBox.Location = new System.Drawing.Point(90, 31);
            this.sampleCheckBox.Name = "sampleCheckBox";
            this.sampleCheckBox.Size = new System.Drawing.Size(81, 17);
            this.sampleCheckBox.TabIndex = 1;
            this.sampleCheckBox.Text = "Use sample";
            this.sampleCheckBox.UseVisualStyleBackColor = true;
            this.sampleCheckBox.CheckedChanged += new System.EventHandler(this.sampleCheckBox_CheckedChanged);
            // 
            // wreckItButton
            // 
            this.wreckItButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.wreckItButton.Enabled = false;
            this.wreckItButton.Location = new System.Drawing.Point(0, 0);
            this.wreckItButton.Name = "wreckItButton";
            this.wreckItButton.Size = new System.Drawing.Size(162, 23);
            this.wreckItButton.TabIndex = 3;
            this.wreckItButton.Text = "Wreck-It-Ralf";
            this.wreckItButton.UseVisualStyleBackColor = true;
            this.wreckItButton.Click += new System.EventHandler(this.wreckItButton_Click);
            // 
            // showDictionaryButton
            // 
            this.showDictionaryButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showDictionaryButton.Location = new System.Drawing.Point(81, 0);
            this.showDictionaryButton.Name = "showDictionaryButton";
            this.showDictionaryButton.Size = new System.Drawing.Size(81, 23);
            this.showDictionaryButton.TabIndex = 4;
            this.showDictionaryButton.Text = "Show";
            this.showDictionaryButton.UseVisualStyleBackColor = true;
            this.showDictionaryButton.Click += new System.EventHandler(this.showDictionaryButton_Click);
            // 
            // fixItFromFileButton
            // 
            this.fixItFromFileButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.fixItFromFileButton.Location = new System.Drawing.Point(0, 23);
            this.fixItFromFileButton.Name = "fixItFromFileButton";
            this.fixItFromFileButton.Size = new System.Drawing.Size(162, 23);
            this.fixItFromFileButton.TabIndex = 5;
            this.fixItFromFileButton.Text = "Fix-It-Felix (Open...)";
            this.fixItFromFileButton.UseVisualStyleBackColor = true;
            this.fixItFromFileButton.Click += new System.EventHandler(this.fixItFromFileButton_Click);
            // 
            // showDictionaryTextBox
            // 
            this.showDictionaryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showDictionaryTextBox.BackColor = System.Drawing.Color.White;
            this.showDictionaryTextBox.Location = new System.Drawing.Point(0, 37);
            this.showDictionaryTextBox.Multiline = true;
            this.showDictionaryTextBox.Name = "showDictionaryTextBox";
            this.showDictionaryTextBox.ReadOnly = true;
            this.showDictionaryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.showDictionaryTextBox.Size = new System.Drawing.Size(174, 226);
            this.showDictionaryTextBox.TabIndex = 6;
            this.showDictionaryTextBox.TabStop = false;
            // 
            // encodingLabel1
            // 
            this.encodingLabel1.AutoSize = true;
            this.encodingLabel1.Location = new System.Drawing.Point(3, 0);
            this.encodingLabel1.Name = "encodingLabel1";
            this.encodingLabel1.Size = new System.Drawing.Size(154, 13);
            this.encodingLabel1.TabIndex = 7;
            this.encodingLabel1.Text = "Enter encoding codepage here";
            // 
            // encodingLabel2
            // 
            this.encodingLabel2.AutoSize = true;
            this.encodingLabel2.Location = new System.Drawing.Point(3, 13);
            this.encodingLabel2.Name = "encodingLabel2";
            this.encodingLabel2.Size = new System.Drawing.Size(138, 13);
            this.encodingLabel2.TabIndex = 8;
            this.encodingLabel2.Text = "(if not needed, leave empty)";
            // 
            // encodingTextBox
            // 
            this.encodingTextBox.Location = new System.Drawing.Point(3, 29);
            this.encodingTextBox.Name = "encodingTextBox";
            this.encodingTextBox.Size = new System.Drawing.Size(81, 20);
            this.encodingTextBox.TabIndex = 9;
            this.encodingTextBox.Text = "1251";
            // 
            // dictionaryLabel
            // 
            this.dictionaryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dictionaryLabel.AutoSize = true;
            this.dictionaryLabel.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dictionaryLabel.Location = new System.Drawing.Point(48, 51);
            this.dictionaryLabel.Name = "dictionaryLabel";
            this.dictionaryLabel.Size = new System.Drawing.Size(69, 17);
            this.dictionaryLabel.TabIndex = 10;
            this.dictionaryLabel.Text = "Dictionary";
            // 
            // generalPanel
            // 
            this.generalPanel.Controls.Add(this.maxVarNumNumericUpDown);
            this.generalPanel.Controls.Add(this.maxVarNumLabel);
            this.generalPanel.Controls.Add(this.dictionaryPanel2);
            this.generalPanel.Controls.Add(this.textsOperationsLabel);
            this.generalPanel.Controls.Add(this.textsOperationsPanel);
            this.generalPanel.Controls.Add(this.dictionaryPanel1);
            this.generalPanel.Controls.Add(this.dictionaryLabel);
            this.generalPanel.Controls.Add(this.encodingLabel1);
            this.generalPanel.Controls.Add(this.sampleCheckBox);
            this.generalPanel.Controls.Add(this.encodingTextBox);
            this.generalPanel.Controls.Add(this.encodingLabel2);
            this.generalPanel.Location = new System.Drawing.Point(5, 4);
            this.generalPanel.Name = "generalPanel";
            this.generalPanel.Size = new System.Drawing.Size(168, 263);
            this.generalPanel.TabIndex = 11;
            // 
            // maxVarNumNumericUpDown
            // 
            this.maxVarNumNumericUpDown.Location = new System.Drawing.Point(3, 235);
            this.maxVarNumNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maxVarNumNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxVarNumNumericUpDown.Name = "maxVarNumNumericUpDown";
            this.maxVarNumNumericUpDown.Size = new System.Drawing.Size(162, 20);
            this.maxVarNumNumericUpDown.TabIndex = 18;
            this.maxVarNumNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxVarNumNumericUpDown.ValueChanged += new System.EventHandler(this.maxVarNumNumericUpDown_ValueChanged);
            // 
            // maxVarNumLabel
            // 
            this.maxVarNumLabel.AutoSize = true;
            this.maxVarNumLabel.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.maxVarNumLabel.Location = new System.Drawing.Point(10, 214);
            this.maxVarNumLabel.Name = "maxVarNumLabel";
            this.maxVarNumLabel.Size = new System.Drawing.Size(149, 17);
            this.maxVarNumLabel.TabIndex = 17;
            this.maxVarNumLabel.Text = "Max number of variants";
            // 
            // dictionaryPanel2
            // 
            this.dictionaryPanel2.Controls.Add(this.deleteButton);
            this.dictionaryPanel2.Controls.Add(this.expandButton);
            this.dictionaryPanel2.Location = new System.Drawing.Point(3, 94);
            this.dictionaryPanel2.Name = "dictionaryPanel2";
            this.dictionaryPanel2.Size = new System.Drawing.Size(162, 23);
            this.dictionaryPanel2.TabIndex = 13;
            // 
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(81, 0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(81, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // expandButton
            // 
            this.expandButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.expandButton.Enabled = false;
            this.expandButton.Location = new System.Drawing.Point(0, 0);
            this.expandButton.Name = "expandButton";
            this.expandButton.Size = new System.Drawing.Size(81, 23);
            this.expandButton.TabIndex = 0;
            this.expandButton.Text = "Expand";
            this.expandButton.UseVisualStyleBackColor = true;
            this.expandButton.Click += new System.EventHandler(this.expandButton_Click);
            // 
            // textsOperationsLabel
            // 
            this.textsOperationsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textsOperationsLabel.AutoSize = true;
            this.textsOperationsLabel.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textsOperationsLabel.Location = new System.Drawing.Point(20, 120);
            this.textsOperationsLabel.Name = "textsOperationsLabel";
            this.textsOperationsLabel.Size = new System.Drawing.Size(129, 17);
            this.textsOperationsLabel.TabIndex = 11;
            this.textsOperationsLabel.Text = "Operations with text";
            // 
            // textsOperationsPanel
            // 
            this.textsOperationsPanel.Controls.Add(this.fixItFromTextBoxButton);
            this.textsOperationsPanel.Controls.Add(this.fixItFromFileButton);
            this.textsOperationsPanel.Controls.Add(this.wreckItButton);
            this.textsOperationsPanel.Location = new System.Drawing.Point(3, 140);
            this.textsOperationsPanel.Name = "textsOperationsPanel";
            this.textsOperationsPanel.Size = new System.Drawing.Size(162, 69);
            this.textsOperationsPanel.TabIndex = 12;
            // 
            // fixItFromTextBoxButton
            // 
            this.fixItFromTextBoxButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fixItFromTextBoxButton.Location = new System.Drawing.Point(0, 46);
            this.fixItFromTextBoxButton.Name = "fixItFromTextBoxButton";
            this.fixItFromTextBoxButton.Size = new System.Drawing.Size(162, 23);
            this.fixItFromTextBoxButton.TabIndex = 6;
            this.fixItFromTextBoxButton.Text = "Fix-It-Felix (Paste...)";
            this.fixItFromTextBoxButton.UseVisualStyleBackColor = true;
            this.fixItFromTextBoxButton.Click += new System.EventHandler(this.fixItFromTextBoxButton_Click);
            // 
            // dictionaryPanel1
            // 
            this.dictionaryPanel1.Controls.Add(this.showDictionaryButton);
            this.dictionaryPanel1.Controls.Add(this.createDictionaryButton);
            this.dictionaryPanel1.Location = new System.Drawing.Point(3, 71);
            this.dictionaryPanel1.Name = "dictionaryPanel1";
            this.dictionaryPanel1.Size = new System.Drawing.Size(162, 23);
            this.dictionaryPanel1.TabIndex = 11;
            // 
            // sortByABCRadioButton
            // 
            this.sortByABCRadioButton.AutoSize = true;
            this.sortByABCRadioButton.Checked = true;
            this.sortByABCRadioButton.Enabled = false;
            this.sortByABCRadioButton.Location = new System.Drawing.Point(3, 20);
            this.sortByABCRadioButton.Name = "sortByABCRadioButton";
            this.sortByABCRadioButton.Size = new System.Drawing.Size(80, 17);
            this.sortByABCRadioButton.TabIndex = 12;
            this.sortByABCRadioButton.TabStop = true;
            this.sortByABCRadioButton.Text = "by alphabet";
            this.sortByABCRadioButton.UseVisualStyleBackColor = true;
            // 
            // sortLabel
            // 
            this.sortLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sortLabel.AutoSize = true;
            this.sortLabel.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sortLabel.Location = new System.Drawing.Point(33, 0);
            this.sortLabel.Name = "sortLabel";
            this.sortLabel.Size = new System.Drawing.Size(119, 17);
            this.sortLabel.TabIndex = 13;
            this.sortLabel.Text = "Sort the dictionary";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sortByFreqRadioButton);
            this.panel1.Controls.Add(this.sortLabel);
            this.panel1.Controls.Add(this.sortByABCRadioButton);
            this.panel1.Controls.Add(this.showDictionaryTextBox);
            this.panel1.Location = new System.Drawing.Point(179, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 263);
            this.panel1.TabIndex = 14;
            // 
            // sortByFreqRadioButton
            // 
            this.sortByFreqRadioButton.AutoSize = true;
            this.sortByFreqRadioButton.Enabled = false;
            this.sortByFreqRadioButton.Location = new System.Drawing.Point(89, 20);
            this.sortByFreqRadioButton.Name = "sortByFreqRadioButton";
            this.sortByFreqRadioButton.Size = new System.Drawing.Size(86, 17);
            this.sortByFreqRadioButton.TabIndex = 14;
            this.sortByFreqRadioButton.Text = "by frequency";
            this.sortByFreqRadioButton.UseVisualStyleBackColor = true;
            this.sortByFreqRadioButton.CheckedChanged += new System.EventHandler(this.sortRadioButtons_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 273);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.generalPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Space Fix";
            this.generalPanel.ResumeLayout(false);
            this.generalPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxVarNumNumericUpDown)).EndInit();
            this.dictionaryPanel2.ResumeLayout(false);
            this.textsOperationsPanel.ResumeLayout(false);
            this.dictionaryPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button createDictionaryButton;
        private System.Windows.Forms.CheckBox sampleCheckBox;
        private System.Windows.Forms.Button wreckItButton;
        private System.Windows.Forms.Button showDictionaryButton;
        private System.Windows.Forms.Button fixItFromFileButton;
        private System.Windows.Forms.TextBox showDictionaryTextBox;
        private System.Windows.Forms.Label encodingLabel1;
        private System.Windows.Forms.Label encodingLabel2;
        private System.Windows.Forms.TextBox encodingTextBox;
        private System.Windows.Forms.Label dictionaryLabel;
        private System.Windows.Forms.Panel generalPanel;
        private System.Windows.Forms.Panel dictionaryPanel1;
        private System.Windows.Forms.Label textsOperationsLabel;
        private System.Windows.Forms.Panel textsOperationsPanel;
        private System.Windows.Forms.Button fixItFromTextBoxButton;
        private System.Windows.Forms.Panel dictionaryPanel2;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button expandButton;
        private System.Windows.Forms.RadioButton sortByABCRadioButton;
        private System.Windows.Forms.Label sortLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton sortByFreqRadioButton;
        private System.Windows.Forms.NumericUpDown maxVarNumNumericUpDown;
        private System.Windows.Forms.Label maxVarNumLabel;
    }
}

