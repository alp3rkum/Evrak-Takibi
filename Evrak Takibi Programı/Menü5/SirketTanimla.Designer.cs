namespace Evrak_Takibi_Programı.Menü5
{
    partial class SirketTanimla
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
            check_kullanici = new CheckBox();
            label12 = new Label();
            text_yetkili = new TextBox();
            text_phone = new MaskedTextBox();
            label11 = new Label();
            label10 = new Label();
            text_taxoffice = new TextBox();
            label9 = new Label();
            text_ilkod = new TextBox();
            label8 = new Label();
            text_ilce = new TextBox();
            label6 = new Label();
            text_address = new TextBox();
            label7 = new Label();
            text_date = new MaskedTextBox();
            label5 = new Label();
            text_taxnum = new TextBox();
            label3 = new Label();
            text_unvan = new TextBox();
            label2 = new Label();
            text_tcid = new TextBox();
            label4 = new Label();
            text_namesurname = new TextBox();
            text_custcode = new TextBox();
            label1 = new Label();
            button_new = new Button();
            button_delete = new Button();
            button_update = new Button();
            button_save = new Button();
            label13 = new Label();
            text_eposta = new TextBox();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(label13);
            panel2.Controls.Add(text_eposta);
            panel2.Controls.Add(check_kullanici);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(text_yetkili);
            panel2.Controls.Add(text_phone);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(text_taxoffice);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(text_ilkod);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(text_ilce);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(text_address);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(text_date);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(text_taxnum);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(text_unvan);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(text_tcid);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(text_namesurname);
            panel2.Controls.Add(text_custcode);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(0, 98);
            panel2.Name = "panel2";
            panel2.Size = new Size(311, 619);
            panel2.TabIndex = 120;
            // 
            // check_kullanici
            // 
            check_kullanici.CheckAlign = ContentAlignment.MiddleRight;
            check_kullanici.Location = new Point(16, 499);
            check_kullanici.Name = "check_kullanici";
            check_kullanici.Size = new Size(275, 24);
            check_kullanici.TabIndex = 34;
            check_kullanici.Text = "Uygulamayı Kullanan Şirket";
            check_kullanici.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(12, 208);
            label12.Name = "label12";
            label12.Size = new Size(62, 15);
            label12.TabIndex = 32;
            label12.Text = "Yetkili Kişi:";
            // 
            // text_yetkili
            // 
            text_yetkili.Location = new Point(191, 205);
            text_yetkili.Name = "text_yetkili";
            text_yetkili.Size = new Size(100, 23);
            text_yetkili.TabIndex = 33;
            // 
            // text_phone
            // 
            text_phone.Location = new Point(192, 139);
            text_phone.Mask = "(999) 000-0000";
            text_phone.Name = "text_phone";
            text_phone.Size = new Size(100, 23);
            text_phone.TabIndex = 31;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 142);
            label11.Name = "label11";
            label11.Size = new Size(48, 15);
            label11.TabIndex = 30;
            label11.Text = "Telefon:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 240);
            label10.Name = "label10";
            label10.Size = new Size(71, 15);
            label10.TabIndex = 28;
            label10.Text = "Vergi Dairesi";
            // 
            // text_taxoffice
            // 
            text_taxoffice.Location = new Point(191, 237);
            text_taxoffice.Name = "text_taxoffice";
            text_taxoffice.Size = new Size(100, 23);
            text_taxoffice.TabIndex = 29;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 462);
            label9.Name = "label9";
            label9.Size = new Size(47, 15);
            label9.TabIndex = 26;
            label9.Text = "İl Kodu:";
            // 
            // text_ilkod
            // 
            text_ilkod.Location = new Point(191, 459);
            text_ilkod.Name = "text_ilkod";
            text_ilkod.Size = new Size(100, 23);
            text_ilkod.TabIndex = 27;
            text_ilkod.TextChanged += checkInput;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 429);
            label8.Name = "label8";
            label8.Size = new Size(28, 15);
            label8.TabIndex = 24;
            label8.Text = "İlçe:";
            // 
            // text_ilce
            // 
            text_ilce.Location = new Point(191, 426);
            text_ilce.Name = "text_ilce";
            text_ilce.Size = new Size(100, 23);
            text_ilce.TabIndex = 25;
            text_ilce.TextChanged += checkInput;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 347);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 22;
            label6.Text = "Adres:";
            // 
            // text_address
            // 
            text_address.Location = new Point(135, 344);
            text_address.MaxLength = 300;
            text_address.Multiline = true;
            text_address.Name = "text_address";
            text_address.ScrollBars = ScrollBars.Vertical;
            text_address.Size = new Size(156, 73);
            text_address.TabIndex = 23;
            text_address.TextChanged += checkInput;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 310);
            label7.Name = "label7";
            label7.Size = new Size(66, 15);
            label7.TabIndex = 20;
            label7.Text = "Geliş Tarihi:";
            // 
            // text_date
            // 
            text_date.Location = new Point(191, 307);
            text_date.Mask = "00/00/0000";
            text_date.Name = "text_date";
            text_date.Size = new Size(100, 23);
            text_date.TabIndex = 21;
            text_date.ValidatingType = typeof(DateTime);
            text_date.TextChanged += checkInput;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 274);
            label5.Name = "label5";
            label5.Size = new Size(87, 15);
            label5.TabIndex = 18;
            label5.Text = "Vergi Numarası";
            // 
            // text_taxnum
            // 
            text_taxnum.Location = new Point(191, 271);
            text_taxnum.Name = "text_taxnum";
            text_taxnum.Size = new Size(100, 23);
            text_taxnum.TabIndex = 19;
            text_taxnum.TextChanged += checkInput;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 109);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 16;
            label3.Text = "Unvan:";
            // 
            // text_unvan
            // 
            text_unvan.Location = new Point(191, 106);
            text_unvan.Name = "text_unvan";
            text_unvan.Size = new Size(100, 23);
            text_unvan.TabIndex = 17;
            text_unvan.TextChanged += checkInput;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 76);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 14;
            label2.Text = "TC Kimlik Numarası";
            // 
            // text_tcid
            // 
            text_tcid.Location = new Point(191, 73);
            text_tcid.MaxLength = 11;
            text_tcid.Name = "text_tcid";
            text_tcid.Size = new Size(100, 23);
            text_tcid.TabIndex = 15;
            text_tcid.TextChanged += checkInput;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 44);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 8;
            label4.Text = "Müşteri Adı:";
            // 
            // text_namesurname
            // 
            text_namesurname.Location = new Point(191, 41);
            text_namesurname.Name = "text_namesurname";
            text_namesurname.Size = new Size(100, 23);
            text_namesurname.TabIndex = 9;
            text_namesurname.TextChanged += checkInput;
            // 
            // text_custcode
            // 
            text_custcode.Location = new Point(191, 8);
            text_custcode.Name = "text_custcode";
            text_custcode.Size = new Size(100, 23);
            text_custcode.TabIndex = 1;
            text_custcode.TextChanged += checkInput;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 0;
            label1.Text = "Müşteri Kodu:";
            // 
            // button_new
            // 
            button_new.BackColor = SystemColors.ControlDark;
            button_new.BackgroundImage = Properties.Resources.gradient_center;
            button_new.BackgroundImageLayout = ImageLayout.Stretch;
            button_new.Enabled = false;
            button_new.FlatAppearance.BorderSize = 0;
            button_new.FlatStyle = FlatStyle.Flat;
            button_new.ForeColor = Color.White;
            button_new.Location = new Point(285, 723);
            button_new.Name = "button_new";
            button_new.Size = new Size(87, 32);
            button_new.TabIndex = 124;
            button_new.Text = "Yeni";
            button_new.UseVisualStyleBackColor = false;
            button_new.Click += button_new_Click;
            // 
            // button_delete
            // 
            button_delete.BackColor = SystemColors.ControlDark;
            button_delete.BackgroundImage = Properties.Resources.gradient_center;
            button_delete.BackgroundImageLayout = ImageLayout.Stretch;
            button_delete.FlatAppearance.BorderSize = 0;
            button_delete.FlatStyle = FlatStyle.Flat;
            button_delete.ForeColor = Color.White;
            button_delete.Location = new Point(192, 723);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(87, 32);
            button_delete.TabIndex = 123;
            button_delete.Text = "Sil";
            button_delete.UseVisualStyleBackColor = false;
            button_delete.Click += button_delete_Click;
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
            button_update.TabIndex = 122;
            button_update.Text = "Güncelle";
            button_update.UseVisualStyleBackColor = false;
            button_update.Click += button_update_Click;
            // 
            // button_save
            // 
            button_save.BackColor = SystemColors.ControlDark;
            button_save.BackgroundImage = Properties.Resources.gradient_center;
            button_save.BackgroundImageLayout = ImageLayout.Stretch;
            button_save.FlatAppearance.BorderSize = 0;
            button_save.FlatStyle = FlatStyle.Flat;
            button_save.ForeColor = Color.White;
            button_save.Location = new Point(6, 723);
            button_save.Name = "button_save";
            button_save.Size = new Size(87, 32);
            button_save.TabIndex = 121;
            button_save.Text = "Kaydet";
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(12, 174);
            label13.Name = "label13";
            label13.Size = new Size(81, 15);
            label13.TabIndex = 35;
            label13.Text = "Eposta Adresi:";
            // 
            // text_eposta
            // 
            text_eposta.Location = new Point(191, 171);
            text_eposta.Name = "text_eposta";
            text_eposta.Size = new Size(100, 23);
            text_eposta.TabIndex = 36;
            // 
            // SirketTanimla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(button_new);
            Controls.Add(button_delete);
            Controls.Add(button_update);
            Controls.Add(button_save);
            Controls.Add(panel2);
            Name = "SirketTanimla";
            Text = "SirketTanimla";
            Load += SirketTanimla_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private TextBox text_custcode;
        private Label label1;
        private Label label4;
        private TextBox text_namesurname;
        private Label label2;
        private TextBox text_tcid;
        private Label label3;
        private TextBox text_unvan;
        private Label label5;
        private TextBox text_taxnum;
        private Label label6;
        private TextBox text_address;
        private Label label7;
        private MaskedTextBox text_date;
        private Label label9;
        private TextBox text_ilkod;
        private Label label8;
        private TextBox text_ilce;
        private Button button_new;
        private Button button_delete;
        private Button button_update;
        private Button button_save;
        private Label label10;
        private TextBox text_taxoffice;
        private Label label11;
        private MaskedTextBox text_phone;
        private Label label12;
        private TextBox text_yetkili;
        private CheckBox check_kullanici;
        private Label label13;
        private TextBox text_eposta;
    }
}