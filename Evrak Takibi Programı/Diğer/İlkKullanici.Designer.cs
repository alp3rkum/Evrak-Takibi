namespace Evrak_Takibi_Programı.Diğer
{
    partial class İlkKullanici
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
            text_username = new MaskedTextBox();
            label1 = new Label();
            text_email = new MaskedTextBox();
            label2 = new Label();
            text_phone = new MaskedTextBox();
            label3 = new Label();
            text_company = new MaskedTextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.BackgroundImage = Properties.Resources.gradient_center;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Enabled = false;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(282, 102);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Doğrula";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // text_username
            // 
            text_username.Location = new Point(105, 6);
            text_username.Name = "text_username";
            text_username.Size = new Size(166, 23);
            text_username.TabIndex = 5;
            text_username.TextChanged += checkInput;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 4;
            label1.Text = "Ad Soyad:";
            // 
            // text_email
            // 
            text_email.Location = new Point(105, 37);
            text_email.Name = "text_email";
            text_email.Size = new Size(166, 23);
            text_email.TabIndex = 7;
            text_email.TextChanged += checkInput;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(12, 40);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 6;
            label2.Text = "Eposta Adresi:";
            // 
            // text_phone
            // 
            text_phone.Location = new Point(105, 69);
            text_phone.Mask = "(999) 000-0000";
            text_phone.Name = "text_phone";
            text_phone.Size = new Size(166, 23);
            text_phone.TabIndex = 9;
            text_phone.TextChanged += checkInput;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(12, 72);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 8;
            label3.Text = "Telefon No:";
            // 
            // text_company
            // 
            text_company.Location = new Point(105, 102);
            text_company.Name = "text_company";
            text_company.Size = new Size(166, 23);
            text_company.TabIndex = 11;
            text_company.TextChanged += checkInput;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(12, 105);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 10;
            label4.Text = "Kuruluş:";
            // 
            // İlkKullanici
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 141);
            Controls.Add(text_company);
            Controls.Add(label4);
            Controls.Add(text_phone);
            Controls.Add(label3);
            Controls.Add(text_email);
            Controls.Add(label2);
            Controls.Add(text_username);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "İlkKullanici";
            Text = "Evrak Takibi Programı'na Hoşgeldiniz!";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private MaskedTextBox text_username;
        private Label label1;
        private MaskedTextBox text_email;
        private Label label2;
        private MaskedTextBox text_phone;
        private Label label3;
        private MaskedTextBox text_company;
        private Label label4;
    }
}