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
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.createDictionaryButton = new System.Windows.Forms.Button();
            this.sampleCheckBox = new System.Windows.Forms.CheckBox();
            this.timerLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.wreckItButton = new System.Windows.Forms.Button();
            this.showDictionaryButton = new System.Windows.Forms.Button();
            this.fixItButton = new System.Windows.Forms.Button();
            this.showDictionaryTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // createDictionaryButton
            // 
            this.createDictionaryButton.Location = new System.Drawing.Point(13, 13);
            this.createDictionaryButton.Name = "createDictionaryButton";
            this.createDictionaryButton.Size = new System.Drawing.Size(159, 23);
            this.createDictionaryButton.TabIndex = 0;
            this.createDictionaryButton.Text = "Create a dictionary";
            this.createDictionaryButton.UseVisualStyleBackColor = true;
            this.createDictionaryButton.Click += new System.EventHandler(this.createDictionaryButton_Click);
            // 
            // sampleCheckBox
            // 
            this.sampleCheckBox.AutoSize = true;
            this.sampleCheckBox.Checked = true;
            this.sampleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sampleCheckBox.Location = new System.Drawing.Point(13, 42);
            this.sampleCheckBox.Name = "sampleCheckBox";
            this.sampleCheckBox.Size = new System.Drawing.Size(81, 17);
            this.sampleCheckBox.TabIndex = 1;
            this.sampleCheckBox.Text = "Use sample";
            this.sampleCheckBox.UseVisualStyleBackColor = true;
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(98, 43);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(55, 13);
            this.timerLabel.TabIndex = 2;
            this.timerLabel.Text = "Time in s: ";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // wreckItButton
            // 
            this.wreckItButton.Location = new System.Drawing.Point(12, 95);
            this.wreckItButton.Name = "wreckItButton";
            this.wreckItButton.Size = new System.Drawing.Size(82, 23);
            this.wreckItButton.TabIndex = 3;
            this.wreckItButton.Text = "Wreck-It-Ralf";
            this.wreckItButton.UseVisualStyleBackColor = true;
            this.wreckItButton.Click += new System.EventHandler(this.wreckItButton_Click);
            // 
            // showDictionaryButton
            // 
            this.showDictionaryButton.Location = new System.Drawing.Point(12, 65);
            this.showDictionaryButton.Name = "showDictionaryButton";
            this.showDictionaryButton.Size = new System.Drawing.Size(160, 24);
            this.showDictionaryButton.TabIndex = 4;
            this.showDictionaryButton.Text = "Show the dictionary";
            this.showDictionaryButton.UseVisualStyleBackColor = true;
            this.showDictionaryButton.Click += new System.EventHandler(this.showDictionaryButton_Click);
            // 
            // fixItButton
            // 
            this.fixItButton.Location = new System.Drawing.Point(101, 95);
            this.fixItButton.Name = "fixItButton";
            this.fixItButton.Size = new System.Drawing.Size(71, 23);
            this.fixItButton.TabIndex = 5;
            this.fixItButton.Text = "Fix-It-Felix";
            this.fixItButton.UseVisualStyleBackColor = true;
            this.fixItButton.Click += new System.EventHandler(this.fixItButton_Click);
            // 
            // showDictionaryTextBox
            // 
            this.showDictionaryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showDictionaryTextBox.BackColor = System.Drawing.Color.White;
            this.showDictionaryTextBox.Location = new System.Drawing.Point(179, 13);
            this.showDictionaryTextBox.Multiline = true;
            this.showDictionaryTextBox.Name = "showDictionaryTextBox";
            this.showDictionaryTextBox.ReadOnly = true;
            this.showDictionaryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.showDictionaryTextBox.Size = new System.Drawing.Size(241, 237);
            this.showDictionaryTextBox.TabIndex = 6;
            this.showDictionaryTextBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 262);
            this.Controls.Add(this.showDictionaryTextBox);
            this.Controls.Add(this.fixItButton);
            this.Controls.Add(this.showDictionaryButton);
            this.Controls.Add(this.wreckItButton);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.sampleCheckBox);
            this.Controls.Add(this.createDictionaryButton);
            this.Name = "MainForm";
            this.Text = "Space Fix";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button createDictionaryButton;
        private System.Windows.Forms.CheckBox sampleCheckBox;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button wreckItButton;
        private System.Windows.Forms.Button showDictionaryButton;
        private System.Windows.Forms.Button fixItButton;
        private System.Windows.Forms.TextBox showDictionaryTextBox;
    }
}

