namespace ExpressFinance
{
    partial class AdminPanel
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
            lblEmail = new Label();
            bDeletUsr = new Button();
            bTransacs = new Button();
            bAddUsr = new Button();
            bExit = new Button();
            bHistory = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.ImageAlign = ContentAlignment.TopLeft;
            lblEmail.Location = new Point(14, 10);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(43, 19);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "email";
            // 
            // bDeletUsr
            // 
            bDeletUsr.BackColor = SystemColors.GradientInactiveCaption;
            bDeletUsr.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            bDeletUsr.Location = new Point(10, 47);
            bDeletUsr.Name = "bDeletUsr";
            bDeletUsr.Size = new Size(103, 55);
            bDeletUsr.TabIndex = 6;
            bDeletUsr.Text = "Видалити користувача";
            bDeletUsr.UseVisualStyleBackColor = false;
            bDeletUsr.Click += bDeletUsr_Click;
            // 
            // bTransacs
            // 
            bTransacs.BackColor = SystemColors.GradientInactiveCaption;
            bTransacs.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            bTransacs.Location = new Point(270, 129);
            bTransacs.Name = "bTransacs";
            bTransacs.Size = new Size(101, 26);
            bTransacs.TabIndex = 7;
            bTransacs.Text = "Транзакції";
            bTransacs.UseVisualStyleBackColor = false;
            bTransacs.Click += bTransacs_Click;
            // 
            // bAddUsr
            // 
            bAddUsr.BackColor = SystemColors.GradientInactiveCaption;
            bAddUsr.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            bAddUsr.Location = new Point(270, 47);
            bAddUsr.Name = "bAddUsr";
            bAddUsr.Size = new Size(101, 55);
            bAddUsr.TabIndex = 8;
            bAddUsr.Text = "Додати користувача";
            bAddUsr.UseVisualStyleBackColor = false;
            bAddUsr.Click += bAddUsr_Click;
            // 
            // bExit
            // 
            bExit.BackColor = SystemColors.GradientInactiveCaption;
            bExit.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            bExit.Location = new Point(10, 195);
            bExit.Name = "bExit";
            bExit.Size = new Size(87, 29);
            bExit.TabIndex = 11;
            bExit.Text = "Вихід";
            bExit.UseVisualStyleBackColor = false;
            bExit.Click += bExit_Click;
            // 
            // bHistory
            // 
            bHistory.BackColor = SystemColors.GradientInactiveCaption;
            bHistory.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            bHistory.Location = new Point(10, 108);
            bHistory.Name = "bHistory";
            bHistory.Size = new Size(103, 69);
            bHistory.TabIndex = 12;
            bHistory.Text = "Звіт видалених і доданих";
            bHistory.UseVisualStyleBackColor = false;
            bHistory.Click += bHistory_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(119, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(145, 103);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // AdminPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(381, 238);
            Controls.Add(pictureBox1);
            Controls.Add(bHistory);
            Controls.Add(bExit);
            Controls.Add(bAddUsr);
            Controls.Add(bTransacs);
            Controls.Add(bDeletUsr);
            Controls.Add(lblEmail);
            Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            Name = "AdminPanel";
            Text = "Панель адміністратора";
            Load += AdminPanel_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmail;
        private Button bDeletUsr;
        private Button bTransacs;
        private Button bAddUsr;
        private Button bExit;
        private Button bHistory;
        private PictureBox pictureBox1;
    }
}