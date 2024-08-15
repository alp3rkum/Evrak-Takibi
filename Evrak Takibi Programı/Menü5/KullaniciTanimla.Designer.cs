namespace Evrak_Takibi_Programı.Menü5
{
    partial class KullaniciTanimla
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
            panel2 = new Panel();
            label3 = new Label();
            text_kurulus = new TextBox();
            label2 = new Label();
            text_telefon = new TextBox();
            label4 = new Label();
            text_namesurname = new TextBox();
            text_email = new TextBox();
            label1 = new Label();
            button_save = new Button();
            button_update = new Button();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(text_kurulus);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(text_telefon);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(text_namesurname);
            panel2.Controls.Add(text_email);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(0, 98);
            panel2.Name = "panel2";
            panel2.Size = new Size(311, 619);
            panel2.TabIndex = 126;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 109);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 16;
            label3.Text = "Kuruluş:";
            // 
            // text_kurulus
            // 
            text_kurulus.Location = new Point(191, 106);
            text_kurulus.Name = "text_kurulus";
            text_kurulus.Size = new Size(100, 23);
            text_kurulus.TabIndex = 17;
            text_kurulus.TextChanged += checkInput;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 76);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 14;
            label2.Text = "Telefon Numarası:";
            // 
            // text_telefon
            // 
            text_telefon.Location = new Point(191, 73);
            text_telefon.MaxLength = 11;
            text_telefon.Name = "text_telefon";
            text_telefon.Size = new Size(100, 23);
            text_telefon.TabIndex = 15;
            text_telefon.TextChanged += checkInput;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 44);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 8;
            label4.Text = "Eposta Adresi:";
            // 
            // text_namesurname
            // 
            text_namesurname.Location = new Point(191, 8);
            text_namesurname.Name = "text_namesurname";
            text_namesurname.Size = new Size(100, 23);
            text_namesurname.TabIndex = 9;
            text_namesurname.TextChanged += checkInput;
            // 
            // text_email
            // 
            text_email.Location = new Point(192, 41);
            text_email.Name = "text_email";
            text_email.Size = new Size(100, 23);
            text_email.TabIndex = 1;
            text_email.TextChanged += checkInput;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Ad Soyad:";
            // 
            // button_save
            // 
            button_save.BackColor = SystemColors.ControlDark;
            button_save.BackgroundImage = Properties.Resources.gradient_center;
            button_save.BackgroundImageLayout = ImageLayout.Stretch;
            button_save.Enabled = false;
            button_save.FlatAppearance.BorderSize = 0;
            button_save.FlatStyle = FlatStyle.Flat;
            button_save.ForeColor = Color.White;
            button_save.Location = new Point(6, 723);
            button_save.Name = "button_save";
            button_save.Size = new Size(87, 32);
            button_save.TabIndex = 130;
            button_save.Text = "Kaydet";
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click;
            // 
            // button_update
            // 
            button_update.BackColor = SystemColors.ControlDark;
            button_update.BackgroundImage = Properties.Resources.gradient_center;
            button_update.BackgroundImageLayout = ImageLayout.Stretch;
            button_update.FlatAppearance.BorderSize = 0;
            button_update.FlatStyle = FlatStyle.Flat;
            button_update.ForeColor = Color.White;
            button_update.Location = new Point(99, 723);
            button_update.Name = "button_update";
            button_update.Size = new Size(87, 32);
            button_update.TabIndex = 131;
            button_update.Text = "Güncelle";
            button_update.UseVisualStyleBackColor = false;
            button_update.Click += button_update_Click;
            // 
            // KullaniciTanimla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(button_update);
            Controls.Add(button_save);
            Controls.Add(panel2);
            Name = "KullaniciTanimla";
            Text = "KullaniciTanimla";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Label label3;
        private TextBox text_kurulus;
        private Label label2;
        private TextBox text_telefon;
        private Label label4;
        private TextBox text_namesurname;
        private TextBox text_email;
        private Label label1;
        private Button button_save;
        private Button button_update;
    }
}