namespace ExpressFinance
{
    partial class AddUser
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
            bAdd = new Button();
            tlogin = new TextBox();
            tpassword = new TextBox();
            label2 = new Label();
            tcard = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            comboBox_Role = new ComboBox();
            checkfop = new CheckBox();
            comboBox_Fop = new ComboBox();
            bclear = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(92, 100);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "Логін";
            // 
            // bAdd
            // 
            bAdd.BackColor = SystemColors.GradientInactiveCaption;
            bAdd.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            bAdd.Location = new Point(431, 233);
            bAdd.Name = "bAdd";
            bAdd.Size = new Size(88, 28);
            bAdd.TabIndex = 1;
            bAdd.Text = "Додати";
            bAdd.UseVisualStyleBackColor = false;
            bAdd.Click += bAdd_Click;
            // 
            // tlogin
            // 
            tlogin.Location = new Point(134, 97);
            tlogin.Name = "tlogin";
            tlogin.Size = new Size(100, 23);
            tlogin.TabIndex = 2;
            // 
            // tpassword
            // 
            tpassword.Location = new Point(134, 126);
            tpassword.Name = "tpassword";
            tpassword.Size = new Size(100, 23);
            tpassword.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(81, 129);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 3;
            label2.Text = "PIN-код";
            // 
            // tcard
            // 
            tcard.Location = new Point(134, 155);
            tcard.Name = "tcard";
            tcard.Size = new Size(167, 23);
            tcard.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 158);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 5;
            label3.Text = "Номер картки";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(240, 100);
            label4.Name = "label4";
            label4.Size = new Size(125, 15);
            label4.TabIndex = 7;
            label4.Text = "Робітник\\Користувач";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(59, 212);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 8;
            label5.Text = "Який саме?";
            label5.Visible = false;
            // 
            // comboBox_Role
            // 
            comboBox_Role.FormattingEnabled = true;
            comboBox_Role.Items.AddRange(new object[] { "user", "admin" });
            comboBox_Role.Location = new Point(370, 97);
            comboBox_Role.Name = "comboBox_Role";
            comboBox_Role.Size = new Size(121, 23);
            comboBox_Role.TabIndex = 10;
            // 
            // checkfop
            // 
            checkfop.AutoSize = true;
            checkfop.Location = new Point(134, 184);
            checkfop.Name = "checkfop";
            checkfop.Size = new Size(94, 19);
            checkfop.TabIndex = 11;
            checkfop.Text = "Бизнес лице";
            checkfop.UseVisualStyleBackColor = true;
            checkfop.CheckedChanged += checkfop_CheckedChanged;
            // 
            // comboBox_Fop
            // 
            comboBox_Fop.AutoCompleteCustomSource.AddRange(new string[] { "car", "clother", "food" });
            comboBox_Fop.FormattingEnabled = true;
            comboBox_Fop.Items.AddRange(new object[] { "food", "clother", "car" });
            comboBox_Fop.Location = new Point(134, 209);
            comboBox_Fop.Name = "comboBox_Fop";
            comboBox_Fop.Size = new Size(121, 23);
            comboBox_Fop.TabIndex = 12;
            comboBox_Fop.Visible = false;
            // 
            // bclear
            // 
            bclear.BackColor = SystemColors.GradientInactiveCaption;
            bclear.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            bclear.Location = new Point(9, 233);
            bclear.Name = "bclear";
            bclear.Size = new Size(80, 28);
            bclear.TabIndex = 13;
            bclear.Text = "Очистити";
            bclear.UseVisualStyleBackColor = false;
            bclear.Click += bclear_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(190, -6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(145, 103);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // AddUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(534, 281);
            Controls.Add(pictureBox1);
            Controls.Add(bclear);
            Controls.Add(comboBox_Fop);
            Controls.Add(checkfop);
            Controls.Add(comboBox_Role);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(tcard);
            Controls.Add(label3);
            Controls.Add(tpassword);
            Controls.Add(label2);
            Controls.Add(tlogin);
            Controls.Add(bAdd);
            Controls.Add(label1);
            Name = "AddUser";
            Text = "Додавання користувача";
            Load += AddUser_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button bAdd;
        private TextBox tlogin;
        private TextBox tpassword;
        private Label label2;
        private TextBox tcard;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBox_Role;
        private CheckBox checkfop;
        private ComboBox comboBox_Fop;
        private Button bclear;
        private PictureBox pictureBox1;
    }
}