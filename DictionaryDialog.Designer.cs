namespace SpaceFix
{
    partial class DictionaryDialog
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
            this.encodingLabel1 = new System.Windows.Forms.Label();
            this.encodingTextBox = new System.Windows.Forms.TextBox();
            this.encodingLabel2 = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // encodingLabel1
            // 
            this.encodingLabel1.AutoSize = true;
            this.encodingLabel1.Location = new System.Drawing.Point(12, 9);
            this.encodingLabel1.Name = "encodingLabel1";
            this.encodingLabel1.Size = new System.Drawing.Size(154, 13);
            this.encodingLabel1.TabIndex = 10;
            this.encodingLabel1.Text = "Enter encoding codepage here";
            // 
            // encodingTextBox
            // 
            this.encodingTextBox.Location = new System.Drawing.Point(12, 38);
            this.encodingTextBox.Name = "encodingTextBox";
            this.encodingTextBox.Size = new System.Drawing.Size(157, 20);
            this.encodingTextBox.TabIndex = 12;
            this.encodingTextBox.Text = "1251";
            // 
            // encodingLabel2
            // 
            this.encodingLabel2.AutoSize = true;
            this.encodingLabel2.Location = new System.Drawing.Point(12, 22);
            this.encodingLabel2.Name = "encodingLabel2";
            this.encodingLabel2.Size = new System.Drawing.Size(138, 13);
            this.encodingLabel2.TabIndex = 11;
            this.encodingLabel2.Text = "(if not needed, leave empty)";
            // 
            // createButton
            // 
            this.createButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.createButton.Location = new System.Drawing.Point(12, 65);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(76, 23);
            this.createButton.TabIndex = 13;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(94, 65);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 14;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // DictionaryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 95);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.encodingLabel1);
            this.Controls.Add(this.encodingTextBox);
            this.Controls.Add(this.encodingLabel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DictionaryDialog";
            this.Text = "Dictionary operation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label encodingLabel1;
        private System.Windows.Forms.TextBox encodingTextBox;
        private System.Windows.Forms.Label encodingLabel2;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button deleteButton;
    }
}