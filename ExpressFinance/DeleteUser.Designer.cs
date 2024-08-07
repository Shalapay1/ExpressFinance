namespace ExpressFinance
{
    partial class DeleteUser
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
            button1 = new Button();
            tDeletEmail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientInactiveCaption;
            button1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            button1.Location = new Point(277, 163);
            button1.Name = "button1";
            button1.Size = new Size(153, 46);
            button1.TabIndex = 0;
            button1.Text = "Видалити користувача";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // tDeletEmail
            // 
            tDeletEmail.Location = new Point(134, 83);
            tDeletEmail.Name = "tDeletEmail";
            tDeletEmail.Size = new Size(205, 23);
            tDeletEmail.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(134, 50);
            label1.Name = "label1";
            label1.Size = new Size(205, 15);
            label1.TabIndex = 3;
            label1.Text = "Введіть логін або email користувача";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(187, 65);
            label2.Name = "label2";
            label2.Size = new Size(106, 15);
            label2.TabIndex = 4;
            label2.Text = "aбо номер картки";
            // 
            // DeleteUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(442, 221);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tDeletEmail);
            Controls.Add(button1);
            Name = "DeleteUser";
            Text = "Видалити користувача";
            Load += DeleteUser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox tDeletEmail;
        private Label label1;
        private Label label2;
    }
}