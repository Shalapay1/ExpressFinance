namespace ExpressFinance
{
    partial class Welcome
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
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 9F);
            label1.Location = new Point(75, 9);
            label1.Name = "label1";
            label1.Size = new Size(277, 17);
            label1.TabIndex = 0;
            label1.Text = "Система обліку фінансових транзакцій";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.welcome1;
            pictureBox1.Location = new Point(125, 42);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(157, 133);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Black", 9F);
            label2.Location = new Point(139, 24);
            label2.Name = "label2";
            label2.Size = new Size(130, 17);
            label2.TabIndex = 2;
            label2.Text = "«ЕкспресФінанс»";
            // 
            // Welcome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(407, 212);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "Welcome";
            Text = "ЕкспресФінанс";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
    }
}