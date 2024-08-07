namespace ExpressFinance
{
    partial class TransferForm
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            buttonEnter = new Button();
            buttonExit = new Button();
            lblBalance = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(129, 13);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(182, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(129, 42);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(182, 23);
            textBox2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 16);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 2;
            label1.Text = "Номер картки";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(87, 45);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 3;
            label2.Text = "Сума";
            // 
            // buttonEnter
            // 
            buttonEnter.BackColor = SystemColors.GradientInactiveCaption;
            buttonEnter.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            buttonEnter.Location = new Point(302, 108);
            buttonEnter.Name = "buttonEnter";
            buttonEnter.Size = new Size(87, 26);
            buttonEnter.TabIndex = 4;
            buttonEnter.Text = "Надіслати";
            buttonEnter.UseVisualStyleBackColor = false;
            buttonEnter.Click += buttonEnter_Click;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = SystemColors.GradientInactiveCaption;
            buttonExit.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            buttonExit.Location = new Point(12, 108);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(87, 26);
            buttonExit.TabIndex = 5;
            buttonExit.Text = "Скасувати";
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(171, 68);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(85, 15);
            lblBalance.TabIndex = 6;
            lblBalance.Text = "Номер картки";
            // 
            // TransferForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(401, 146);
            Controls.Add(lblBalance);
            Controls.Add(buttonExit);
            Controls.Add(buttonEnter);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "TransferForm";
            Text = "Переведення коштів";
            Load += TransferForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button buttonEnter;
        private Button buttonExit;
        private Label lblBalance;
    }
}