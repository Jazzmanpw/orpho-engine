namespace SpaceFix
{
    partial class DictionaryDebugForm
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
            this.showDictionaryButton = new System.Windows.Forms.Button();
            this.showDictionaryTextBox = new System.Windows.Forms.TextBox();
            this.sortByABCRadioButton = new System.Windows.Forms.RadioButton();
            this.sortLabel = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.sortByFreqRadioButton = new System.Windows.Forms.RadioButton();
            this.sortPanel = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.sortPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // showDictionaryButton
            // 
            this.showDictionaryButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.showDictionaryButton.Location = new System.Drawing.Point(0, 209);
            this.showDictionaryButton.Name = "showDictionaryButton";
            this.showDictionaryButton.Size = new System.Drawing.Size(174, 30);
            this.showDictionaryButton.TabIndex = 4;
            this.showDictionaryButton.Text = "Show";
            this.showDictionaryButton.UseVisualStyleBackColor = true;
            this.showDictionaryButton.Click += new System.EventHandler(this.showDictionaryButton_Click);
            // 
            // showDictionaryTextBox
            // 
            this.showDictionaryTextBox.BackColor = System.Drawing.Color.White;
            this.showDictionaryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showDictionaryTextBox.Location = new System.Drawing.Point(0, 43);
            this.showDictionaryTextBox.Multiline = true;
            this.showDictionaryTextBox.Name = "showDictionaryTextBox";
            this.showDictionaryTextBox.ReadOnly = true;
            this.showDictionaryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.showDictionaryTextBox.Size = new System.Drawing.Size(174, 166);
            this.showDictionaryTextBox.TabIndex = 6;
            this.showDictionaryTextBox.TabStop = false;
            // 
            // sortByABCRadioButton
            // 
            this.sortByABCRadioButton.AutoSize = true;
            this.sortByABCRadioButton.Checked = true;
            this.sortByABCRadioButton.Enabled = false;
            this.sortByABCRadioButton.Location = new System.Drawing.Point(2, 20);
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
            this.sortLabel.Location = new System.Drawing.Point(31, 0);
            this.sortLabel.Name = "sortLabel";
            this.sortLabel.Size = new System.Drawing.Size(119, 17);
            this.sortLabel.TabIndex = 13;
            this.sortLabel.Text = "Sort the dictionary";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.showDictionaryTextBox);
            this.panel.Controls.Add(this.sortPanel);
            this.panel.Controls.Add(this.showDictionaryButton);
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(174, 239);
            this.panel.TabIndex = 14;
            // 
            // sortByFreqRadioButton
            // 
            this.sortByFreqRadioButton.AutoSize = true;
            this.sortByFreqRadioButton.Enabled = false;
            this.sortByFreqRadioButton.Location = new System.Drawing.Point(88, 20);
            this.sortByFreqRadioButton.Name = "sortByFreqRadioButton";
            this.sortByFreqRadioButton.Size = new System.Drawing.Size(86, 17);
            this.sortByFreqRadioButton.TabIndex = 14;
            this.sortByFreqRadioButton.Text = "by frequency";
            this.sortByFreqRadioButton.UseVisualStyleBackColor = true;
            this.sortByFreqRadioButton.CheckedChanged += new System.EventHandler(this.sortRadioButtons_CheckedChanged);
            // 
            // sortPanel
            // 
            this.sortPanel.Controls.Add(this.sortLabel);
            this.sortPanel.Controls.Add(this.sortByFreqRadioButton);
            this.sortPanel.Controls.Add(this.sortByABCRadioButton);
            this.sortPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.sortPanel.Location = new System.Drawing.Point(0, 0);
            this.sortPanel.Name = "sortPanel";
            this.sortPanel.Size = new System.Drawing.Size(174, 43);
            this.sortPanel.TabIndex = 15;
            // 
            // DictionaryDebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 262);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(214, 1000);
            this.MinimumSize = new System.Drawing.Size(214, 300);
            this.Name = "DictionaryDebugForm";
            this.Text = "Debug";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DictionaryDebugForm_FormClosing);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.sortPanel.ResumeLayout(false);
            this.sortPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button showDictionaryButton;
        private System.Windows.Forms.TextBox showDictionaryTextBox;
        private System.Windows.Forms.RadioButton sortByABCRadioButton;
        private System.Windows.Forms.Label sortLabel;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.RadioButton sortByFreqRadioButton;
        private System.Windows.Forms.Panel sortPanel;
    }
}

