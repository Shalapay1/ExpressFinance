namespace ExpressFinance
{
    partial class Transaction
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            button1 = new Button();
            tSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 81);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(604, 552);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 42);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 1;
            label1.Text = "Пошук за ім'ям";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientInactiveCaption;
            button1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            button1.Location = new Point(313, 39);
            button1.Name = "button1";
            button1.Size = new Size(27, 25);
            button1.TabIndex = 2;
            button1.Text = "🔍";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // tSearch
            // 
            tSearch.Location = new Point(106, 39);
            tSearch.Name = "tSearch";
            tSearch.Size = new Size(201, 23);
            tSearch.TabIndex = 3;
            // 
            // Transaction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(631, 645);
            Controls.Add(tSearch);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "Transaction";
            Text = "Транзакції";
            Load += Transaction_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button button1;
        private TextBox tSearch;
    }
}