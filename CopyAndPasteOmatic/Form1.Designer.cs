namespace CopyAndPasteOmatic
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            toggleButton = new Button();
            statusLabel = new Label();
            numericRate = new NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            numericMaxMessageLength = new NumericUpDown();
            segmentCountLabel = new Label();
            loopedCheckBox = new CheckBox();
            progressBar1 = new ProgressBar();
            timeLeftLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)numericRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMaxMessageLength).BeginInit();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(650, 397);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // toggleButton
            // 
            toggleButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            toggleButton.Location = new Point(668, 415);
            toggleButton.Name = "toggleButton";
            toggleButton.Size = new Size(120, 23);
            toggleButton.TabIndex = 1;
            toggleButton.Text = "Start";
            toggleButton.UseVisualStyleBackColor = true;
            toggleButton.Click += toggleButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            statusLabel.Location = new Point(654, 345);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(150, 69);
            statusLabel.TabIndex = 2;
            statusLabel.Text = "...";
            statusLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // numericRate
            // 
            numericRate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numericRate.Location = new Point(668, 317);
            numericRate.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numericRate.Name = "numericRate";
            numericRate.Size = new Size(120, 23);
            numericRate.TabIndex = 3;
            numericRate.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(668, 299);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 4;
            label2.Text = "Send Rate (ms)";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(668, 345);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 6;
            label1.Text = "Message Max Size";
            // 
            // numericMaxMessageLength
            // 
            numericMaxMessageLength.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numericMaxMessageLength.Location = new Point(668, 363);
            numericMaxMessageLength.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericMaxMessageLength.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericMaxMessageLength.Name = "numericMaxMessageLength";
            numericMaxMessageLength.Size = new Size(120, 23);
            numericMaxMessageLength.TabIndex = 5;
            numericMaxMessageLength.Value = new decimal(new int[] { 200, 0, 0, 0 });
            // 
            // segmentCountLabel
            // 
            segmentCountLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            segmentCountLabel.Location = new Point(668, 229);
            segmentCountLabel.Name = "segmentCountLabel";
            segmentCountLabel.Size = new Size(120, 45);
            segmentCountLabel.TabIndex = 7;
            segmentCountLabel.Text = "0 segments";
            segmentCountLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // loopedCheckBox
            // 
            loopedCheckBox.AutoSize = true;
            loopedCheckBox.Location = new Point(668, 277);
            loopedCheckBox.Name = "loopedCheckBox";
            loopedCheckBox.Size = new Size(66, 19);
            loopedCheckBox.TabIndex = 8;
            loopedCheckBox.Text = "Looped";
            loopedCheckBox.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            progressBar1.Location = new Point(12, 428);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(650, 10);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 9;
            // 
            // timeLeftLabel
            // 
            timeLeftLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            timeLeftLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            timeLeftLabel.Location = new Point(12, 414);
            timeLeftLabel.Name = "timeLeftLabel";
            timeLeftLabel.Size = new Size(650, 14);
            timeLeftLabel.TabIndex = 10;
            timeLeftLabel.Text = "00:00/00:00";
            timeLeftLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(timeLeftLabel);
            Controls.Add(progressBar1);
            Controls.Add(loopedCheckBox);
            Controls.Add(segmentCountLabel);
            Controls.Add(label1);
            Controls.Add(numericMaxMessageLength);
            Controls.Add(label2);
            Controls.Add(numericRate);
            Controls.Add(toggleButton);
            Controls.Add(richTextBox1);
            Controls.Add(statusLabel);
            MaximizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "CopyAndPasteOmatic";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)numericRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMaxMessageLength).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button toggleButton;
        private Label statusLabel;
        private NumericUpDown numericRate;
        private Label label2;
        private Label label1;
        private NumericUpDown numericMaxMessageLength;
        private Label segmentCountLabel;
        private CheckBox loopedCheckBox;
        private ProgressBar progressBar1;
        private Label timeLeftLabel;
    }
}