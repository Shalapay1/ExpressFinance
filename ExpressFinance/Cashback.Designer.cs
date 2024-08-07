namespace ExpressFinance
{
    partial class Cashback
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
            lcar = new Label();
            buttonExit = new Button();
            buttonEnter = new Button();
            bcashback_out = new Button();
            ltotal_cash = new Label();
            label1 = new Label();
            radioButtonFood = new RadioButton();
            radioButtonCar = new RadioButton();
            radioButtonClothing = new RadioButton();
            SuspendLayout();
            // 
            // lcar
            // 
            lcar.AutoSize = true;
            lcar.Location = new Point(34, 119);
            lcar.Name = "lcar";
            lcar.Size = new Size(0, 15);
            lcar.TabIndex = 2;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = SystemColors.GradientInactiveCaption;
            buttonExit.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            buttonExit.Location = new Point(8, 159);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(87, 27);
            buttonExit.TabIndex = 7;
            buttonExit.Text = "Вийти";
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // buttonEnter
            // 
            buttonEnter.BackColor = SystemColors.GradientInactiveCaption;
            buttonEnter.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            buttonEnter.Location = new Point(212, 159);
            buttonEnter.Name = "buttonEnter";
            buttonEnter.Size = new Size(87, 27);
            buttonEnter.TabIndex = 8;
            buttonEnter.Text = "Зберегти";
            buttonEnter.UseVisualStyleBackColor = false;
            buttonEnter.Click += buttonEnter_Click;
            // 
            // bcashback_out
            // 
            bcashback_out.BackColor = SystemColors.GradientInactiveCaption;
            bcashback_out.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            bcashback_out.Location = new Point(212, 102);
            bcashback_out.Name = "bcashback_out";
            bcashback_out.Size = new Size(87, 51);
            bcashback_out.TabIndex = 10;
            bcashback_out.Text = "Вивести кешбек";
            bcashback_out.UseVisualStyleBackColor = false;
            bcashback_out.Click += bcashback_out_Click;
            // 
            // ltotal_cash
            // 
            ltotal_cash.AutoSize = true;
            ltotal_cash.Location = new Point(8, 17);
            ltotal_cash.Name = "ltotal_cash";
            ltotal_cash.Size = new Size(172, 15);
            ltotal_cash.TabIndex = 11;
            ltotal_cash.Text = "Оберіть потрбній вам кешбек";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 60);
            label1.Name = "label1";
            label1.Size = new Size(175, 15);
            label1.TabIndex = 9;
            label1.Text = "Оберіть потрібній вам кешбек";
            // 
            // radioButtonFood
            // 
            radioButtonFood.AutoSize = true;
            radioButtonFood.Location = new Point(10, 80);
            radioButtonFood.Name = "radioButtonFood";
            radioButtonFood.Size = new Size(194, 19);
            radioButtonFood.TabIndex = 12;
            radioButtonFood.TabStop = true;
            radioButtonFood.Text = "Кешбек кафе та ресторанів 5%";
            radioButtonFood.UseVisualStyleBackColor = true;
            radioButtonFood.CheckedChanged += radioButtonFood_CheckedChanged;
            // 
            // radioButtonCar
            // 
            radioButtonCar.AutoSize = true;
            radioButtonCar.Location = new Point(10, 98);
            radioButtonCar.Name = "radioButtonCar";
            radioButtonCar.Size = new Size(180, 19);
            radioButtonCar.TabIndex = 13;
            radioButtonCar.TabStop = true;
            radioButtonCar.Text = "Кешбек заправок та СТО 2%";
            radioButtonCar.UseVisualStyleBackColor = true;
            // 
            // radioButtonClothing
            // 
            radioButtonClothing.AutoSize = true;
            radioButtonClothing.Location = new Point(10, 117);
            radioButtonClothing.Name = "radioButtonClothing";
            radioButtonClothing.Size = new Size(178, 19);
            radioButtonClothing.TabIndex = 14;
            radioButtonClothing.TabStop = true;
            radioButtonClothing.Text = "Кешбек магазинів одежі 4%";
            radioButtonClothing.UseVisualStyleBackColor = true;
            // 
            // Cashback
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(306, 194);
            Controls.Add(radioButtonClothing);
            Controls.Add(radioButtonCar);
            Controls.Add(radioButtonFood);
            Controls.Add(ltotal_cash);
            Controls.Add(bcashback_out);
            Controls.Add(label1);
            Controls.Add(buttonEnter);
            Controls.Add(buttonExit);
            Controls.Add(lcar);
            Name = "Cashback";
            Text = "Кешбек";
            Load += Cashback_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lcar;
        private Button buttonExit;
        private Button buttonEnter;
        private Button bcashback_out;
        private Label ltotal_cash;
        private Label label1;
        private RadioButton radioButtonFood;
        private RadioButton radioButtonCar;
        private RadioButton radioButtonClothing;
    }
}