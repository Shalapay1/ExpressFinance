namespace ExpressFinance
{
    public partial class LoginForm
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
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientInactiveCaption;
            button1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            button1.Location = new Point(248, 153);
            button1.Name = "button1";
            button1.Size = new Size(79, 26);
            button1.TabIndex = 0;
            button1.Text = "Увійти";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(106, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(164, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(106, 88);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(164, 23);
            textBox2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 67);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 3;
            label1.Text = "Логін";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 91);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 4;
            label2.Text = "PIN-код";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(339, 191);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "LoginForm";
            Text = "Вхід";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;

       
    }
}
