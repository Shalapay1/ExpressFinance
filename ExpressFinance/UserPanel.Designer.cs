namespace ExpressFinance
{
    partial class UserPanel
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
            lblCardNumber = new Label();
            lblEmail = new Label();
            lblBalance = new Label();
            dataGridTransiction = new DataGridView();
            label1 = new Label();
            bTransition = new Button();
            bCashback = new Button();
            bExit = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridTransiction).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblCardNumber
            // 
            lblCardNumber.AutoSize = true;
            lblCardNumber.Location = new Point(208, 129);
            lblCardNumber.Margin = new Padding(3, 0, 50, 0);
            lblCardNumber.Name = "lblCardNumber";
            lblCardNumber.Size = new Size(38, 15);
            lblCardNumber.TabIndex = 3;
            lblCardNumber.Text = "label1";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.ImageAlign = ContentAlignment.TopLeft;
            lblEmail.Location = new Point(12, 129);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(38, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "label1";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.ImageAlign = ContentAlignment.MiddleLeft;
            lblBalance.Location = new Point(12, 144);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(38, 15);
            lblBalance.TabIndex = 5;
            lblBalance.Text = "label1";
            // 
            // dataGridTransiction
            // 
            dataGridTransiction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridTransiction.Location = new Point(12, 179);
            dataGridTransiction.Name = "dataGridTransiction";
            dataGridTransiction.ReadOnly = true;
            dataGridTransiction.Size = new Size(321, 340);
            dataGridTransiction.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(140, 161);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 7;
            label1.Text = "Ваші транзакції";
            // 
            // bTransition
            // 
            bTransition.BackColor = SystemColors.GradientInactiveCaption;
            bTransition.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            bTransition.Location = new Point(339, 193);
            bTransition.Name = "bTransition";
            bTransition.Size = new Size(86, 48);
            bTransition.TabIndex = 8;
            bTransition.Text = "Перевести кошти";
            bTransition.UseVisualStyleBackColor = false;
            bTransition.Click += bTransition_Click;
            // 
            // bCashback
            // 
            bCashback.BackColor = SystemColors.GradientInactiveCaption;
            bCashback.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            bCashback.Location = new Point(339, 252);
            bCashback.Name = "bCashback";
            bCashback.Size = new Size(86, 48);
            bCashback.TabIndex = 9;
            bCashback.Text = "Обрати кешбек";
            bCashback.UseVisualStyleBackColor = false;
            bCashback.Click += bCashback_Click;
            // 
            // bExit
            // 
            bExit.BackColor = SystemColors.GradientInactiveCaption;
            bExit.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            bExit.Location = new Point(339, 478);
            bExit.Name = "bExit";
            bExit.Size = new Size(86, 48);
            bExit.TabIndex = 10;
            bExit.Text = "Вихід";
            bExit.UseVisualStyleBackColor = false;
            bExit.Click += bExit_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(140, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(145, 103);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // UserPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(427, 531);
            Controls.Add(pictureBox1);
            Controls.Add(bExit);
            Controls.Add(bCashback);
            Controls.Add(bTransition);
            Controls.Add(label1);
            Controls.Add(dataGridTransiction);
            Controls.Add(lblBalance);
            Controls.Add(lblEmail);
            Controls.Add(lblCardNumber);
            Name = "UserPanel";
            Text = "Кабінет";
            Load += UserPanel_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridTransiction).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblCardNumber;
        private Label lblEmail;
        private Label lblBalance;
        private DataGridView dataGridTransiction;
        private Label label1;
        private Button bTransition;
        private Button bCashback;
        private Button bExit;
        private PictureBox pictureBox1;
    }
}