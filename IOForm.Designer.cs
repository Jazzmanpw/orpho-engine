namespace SpaceFix
{
    partial class IOForm
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
            this.fixItButton = new System.Windows.Forms.Button();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.inputClearButton = new System.Windows.Forms.Button();
            this.pasteButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.outputClearButton = new System.Windows.Forms.Button();
            this.dictionaryButton = new System.Windows.Forms.Button();
            this.expectationsCheckBox = new System.Windows.Forms.CheckBox();
            this.dispersionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.dispersionLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispersionNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // fixItButton
            // 
            this.fixItButton.Enabled = false;
            this.fixItButton.Location = new System.Drawing.Point(561, 543);
            this.fixItButton.Name = "fixItButton";
            this.fixItButton.Size = new System.Drawing.Size(75, 23);
            this.fixItButton.TabIndex = 4;
            this.fixItButton.Text = "Fix";
            this.fixItButton.UseVisualStyleBackColor = true;
            this.fixItButton.Click += new System.EventHandler(this.fixItButton_Click);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.inputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputTextBox.Location = new System.Drawing.Point(0, 0);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputTextBox.Size = new System.Drawing.Size(405, 537);
            this.inputTextBox.TabIndex = 3;
            // 
            // inputClearButton
            // 
            this.inputClearButton.Location = new System.Drawing.Point(174, 543);
            this.inputClearButton.Name = "inputClearButton";
            this.inputClearButton.Size = new System.Drawing.Size(75, 23);
            this.inputClearButton.TabIndex = 2;
            this.inputClearButton.Text = "Clear";
            this.inputClearButton.UseVisualStyleBackColor = true;
            this.inputClearButton.Click += new System.EventHandler(this.inputClearButton_Click);
            // 
            // pasteButton
            // 
            this.pasteButton.Location = new System.Drawing.Point(93, 543);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(75, 23);
            this.pasteButton.TabIndex = 1;
            this.pasteButton.Text = "Paste";
            this.pasteButton.UseVisualStyleBackColor = true;
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(642, 543);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 23);
            this.copyButton.TabIndex = 5;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.outputTextBox);
            this.panel1.Controls.Add(this.inputTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 537);
            this.panel1.TabIndex = 6;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.outputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputTextBox.Location = new System.Drawing.Point(405, 0);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(405, 537);
            this.outputTextBox.TabIndex = 7;
            this.outputTextBox.TabStop = false;
            // 
            // outputClearButton
            // 
            this.outputClearButton.Location = new System.Drawing.Point(723, 543);
            this.outputClearButton.Name = "outputClearButton";
            this.outputClearButton.Size = new System.Drawing.Size(75, 23);
            this.outputClearButton.TabIndex = 6;
            this.outputClearButton.Text = "Clear";
            this.outputClearButton.UseVisualStyleBackColor = true;
            this.outputClearButton.Click += new System.EventHandler(this.outputClearButton_Click);
            // 
            // dictionaryButton
            // 
            this.dictionaryButton.Location = new System.Drawing.Point(12, 543);
            this.dictionaryButton.Name = "dictionaryButton";
            this.dictionaryButton.Size = new System.Drawing.Size(75, 23);
            this.dictionaryButton.TabIndex = 21;
            this.dictionaryButton.Text = "Dictionary...";
            this.dictionaryButton.UseVisualStyleBackColor = true;
            this.dictionaryButton.Click += new System.EventHandler(this.dictionaryButton_Click);
            // 
            // expectationsCheckBox
            // 
            this.expectationsCheckBox.AutoSize = true;
            this.expectationsCheckBox.Checked = true;
            this.expectationsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.expectationsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expectationsCheckBox.Location = new System.Drawing.Point(255, 545);
            this.expectationsCheckBox.Name = "expectationsCheckBox";
            this.expectationsCheckBox.Size = new System.Drawing.Size(144, 21);
            this.expectationsCheckBox.TabIndex = 22;
            this.expectationsCheckBox.Text = "Show expectations";
            this.expectationsCheckBox.UseVisualStyleBackColor = true;
            this.expectationsCheckBox.Visible = false;
            this.expectationsCheckBox.CheckedChanged += new System.EventHandler(this.expectationsCheckBox_CheckedChanged);
            // 
            // dispersionNumericUpDown
            // 
            this.dispersionNumericUpDown.DecimalPlaces = 4;
            this.dispersionNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dispersionNumericUpDown.Location = new System.Drawing.Point(481, 543);
            this.dispersionNumericUpDown.Name = "dispersionNumericUpDown";
            this.dispersionNumericUpDown.Size = new System.Drawing.Size(74, 23);
            this.dispersionNumericUpDown.TabIndex = 23;
            this.dispersionNumericUpDown.Visible = false;
            this.dispersionNumericUpDown.ValueChanged += new System.EventHandler(this.dispersionNumericUpDown_ValueChanged);
            // 
            // dispersionLabel
            // 
            this.dispersionLabel.AutoSize = true;
            this.dispersionLabel.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.dispersionLabel.Location = new System.Drawing.Point(405, 547);
            this.dispersionLabel.Name = "dispersionLabel";
            this.dispersionLabel.Size = new System.Drawing.Size(70, 17);
            this.dispersionLabel.TabIndex = 24;
            this.dispersionLabel.Text = "Dispertion";
            this.dispersionLabel.Visible = false;
            // 
            // IOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 578);
            this.Controls.Add(this.dispersionLabel);
            this.Controls.Add(this.dispersionNumericUpDown);
            this.Controls.Add(this.expectationsCheckBox);
            this.Controls.Add(this.dictionaryButton);
            this.Controls.Add(this.outputClearButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.pasteButton);
            this.Controls.Add(this.inputClearButton);
            this.Controls.Add(this.fixItButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "IOForm";
            this.Text = "Fix from TextBox";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IOForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispersionNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button fixItButton;
        private System.Windows.Forms.Button inputClearButton;
        private System.Windows.Forms.Button pasteButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button outputClearButton;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button dictionaryButton;
        private System.Windows.Forms.CheckBox expectationsCheckBox;
        private System.Windows.Forms.NumericUpDown dispersionNumericUpDown;
        private System.Windows.Forms.Label dispersionLabel;
    }
}