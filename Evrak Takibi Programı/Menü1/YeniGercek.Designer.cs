namespace Evrak_Takibi_Programı
{
    partial class YeniGercek
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
            text_taxnum = new TextBox();
            label3 = new Label();
            text_custcode = new TextBox();
            label2 = new Label();
            comboBox_donem = new ComboBox();
            label1 = new Label();
            text_tcid = new TextBox();
            label4 = new Label();
            text_comptype = new TextBox();
            label5 = new Label();
            text_email = new TextBox();
            label8 = new Label();
            text_date = new MaskedTextBox();
            label7 = new Label();
            text_phone = new MaskedTextBox();
            label6 = new Label();
            text_reference = new TextBox();
            label9 = new Label();
            text_namesurname = new TextBox();
            label10 = new Label();
            text_sirkulertarih = new MaskedTextBox();
            text_tahakkuk = new TextBox();
            label12 = new Label();
            txt_matrah = new TextBox();
            label11 = new Label();
            text_sermaye = new TextBox();
            label14 = new Label();
            radio_none = new RadioButton();
            radio_sanayi = new RadioButton();
            radio_imib = new RadioButton();
            radio_tim = new RadioButton();
            text_opreason = new TextBox();
            label18 = new Label();
            text_lastoperation = new MaskedTextBox();
            label19 = new Label();
            button_new = new Button();
            button_delete = new Button();
            button_update = new Button();
            button_save = new Button();
            panel1 = new Panel();
            text_lastopcount = new TextBox();
            label13 = new Label();
            label24 = new Label();
            label15 = new Label();
            text_taxoffice = new TextBox();
            text_fax = new MaskedTextBox();
            panel3 = new Panel();
            label21 = new Label();
            check_kimlik = new CheckBox();
            label22 = new Label();
            label17 = new Label();
            pictureBox1 = new PictureBox();
            check_cerceve = new CheckBox();
            label23 = new Label();
            label20 = new Label();
            pictureBox2 = new PictureBox();
            fileDialog_imza = new OpenFileDialog();
            fileDialog_picture = new OpenFileDialog();
            fileDialog_document = new OpenFileDialog();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // text_taxnum
            // 
            text_taxnum.Location = new Point(155, 157);
            text_taxnum.Name = "text_taxnum";
            text_taxnum.Size = new Size(100, 23);
            text_taxnum.TabIndex = 3;
            text_taxnum.TextChanged += checkInput;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 161);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 10;
            label3.Text = "Vergi Numarası";
            // 
            // text_custcode
            // 
            text_custcode.Location = new Point(156, 91);
            text_custcode.Name = "text_custcode";
            text_custcode.Size = new Size(100, 23);
            text_custcode.TabIndex = 1;
            text_custcode.TextChanged += text_custcode_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 94);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 8;
            label2.Text = "Müşteri Kodu";
            // 
            // comboBox_donem
            // 
            comboBox_donem.FormattingEnabled = true;
            comboBox_donem.Location = new Point(156, 60);
            comboBox_donem.Name = "comboBox_donem";
            comboBox_donem.Size = new Size(100, 23);
            comboBox_donem.TabIndex = 7;
            comboBox_donem.SelectedIndexChanged += comboBox_donem_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 63);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 6;
            label1.Text = "Dönem";
            // 
            // text_tcid
            // 
            text_tcid.Location = new Point(155, 187);
            text_tcid.MaxLength = 11;
            text_tcid.Name = "text_tcid";
            text_tcid.Size = new Size(100, 23);
            text_tcid.TabIndex = 4;
            text_tcid.TextChanged += checkInput;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 190);
            label4.Name = "label4";
            label4.Size = new Size(110, 15);
            label4.TabIndex = 12;
            label4.Text = "TC Kimlik Numarası";
            // 
            // text_comptype
            // 
            text_comptype.Location = new Point(155, 220);
            text_comptype.Name = "text_comptype";
            text_comptype.Size = new Size(100, 23);
            text_comptype.TabIndex = 5;
            text_comptype.TextChanged += checkInput;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 223);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 14;
            label5.Text = "Şirket Tipi";
            // 
            // text_email
            // 
            text_email.Location = new Point(155, 387);
            text_email.Name = "text_email";
            text_email.Size = new Size(100, 23);
            text_email.TabIndex = 10;
            text_email.TextChanged += checkInput;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(14, 390);
            label8.Name = "label8";
            label8.Size = new Size(83, 15);
            label8.TabIndex = 24;
            label8.Text = "E-posta Adresi";
            // 
            // text_date
            // 
            text_date.Location = new Point(155, 356);
            text_date.Mask = "00/00/0000";
            text_date.Name = "text_date";
            text_date.Size = new Size(100, 23);
            text_date.TabIndex = 9;
            text_date.ValidatingType = typeof(DateTime);
            text_date.TextChanged += checkInput;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 359);
            label7.Name = "label7";
            label7.Size = new Size(99, 15);
            label7.TabIndex = 22;
            label7.Text = "İşe Başlama Tarihi";
            // 
            // text_phone
            // 
            text_phone.Location = new Point(155, 322);
            text_phone.Mask = "(999) 000-0000";
            text_phone.Name = "text_phone";
            text_phone.Size = new Size(100, 23);
            text_phone.TabIndex = 8;
            text_phone.TextChanged += checkInput;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 324);
            label6.Name = "label6";
            label6.Size = new Size(99, 15);
            label6.TabIndex = 20;
            label6.Text = "Telefon Numarası";
            // 
            // text_reference
            // 
            text_reference.Location = new Point(155, 289);
            text_reference.Name = "text_reference";
            text_reference.Size = new Size(100, 23);
            text_reference.TabIndex = 7;
            text_reference.TextChanged += checkInput;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(11, 292);
            label9.Name = "label9";
            label9.Size = new Size(52, 15);
            label9.TabIndex = 18;
            label9.Text = "Referans";
            // 
            // text_namesurname
            // 
            text_namesurname.Location = new Point(155, 253);
            text_namesurname.Name = "text_namesurname";
            text_namesurname.Size = new Size(100, 23);
            text_namesurname.TabIndex = 6;
            text_namesurname.TextChanged += checkInput;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(11, 256);
            label10.Name = "label10";
            label10.Size = new Size(102, 15);
            label10.TabIndex = 16;
            label10.Text = "Müşteri Ad/Soyad";
            // 
            // text_sirkulertarih
            // 
            text_sirkulertarih.Location = new Point(163, 120);
            text_sirkulertarih.Mask = "00/00/0000";
            text_sirkulertarih.Name = "text_sirkulertarih";
            text_sirkulertarih.Size = new Size(100, 23);
            text_sirkulertarih.TabIndex = 17;
            text_sirkulertarih.ValidatingType = typeof(DateTime);
            text_sirkulertarih.TextChanged += checkInput;
            // 
            // text_tahakkuk
            // 
            text_tahakkuk.Location = new Point(155, 494);
            text_tahakkuk.Name = "text_tahakkuk";
            text_tahakkuk.Size = new Size(100, 23);
            text_tahakkuk.TabIndex = 13;
            text_tahakkuk.TextChanged += checkInput;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(14, 497);
            label12.Name = "label12";
            label12.Size = new Size(114, 15);
            label12.TabIndex = 30;
            label12.Text = "Tahakkuk Eden Vergi";
            // 
            // txt_matrah
            // 
            txt_matrah.Location = new Point(155, 457);
            txt_matrah.Name = "txt_matrah";
            txt_matrah.Size = new Size(100, 23);
            txt_matrah.TabIndex = 12;
            txt_matrah.TextChanged += checkInput;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(14, 460);
            label11.Name = "label11";
            label11.Size = new Size(122, 15);
            label11.TabIndex = 28;
            label11.Text = "Beyah Olunan Matrah";
            // 
            // text_sermaye
            // 
            text_sermaye.Location = new Point(155, 420);
            text_sermaye.Name = "text_sermaye";
            text_sermaye.Size = new Size(100, 23);
            text_sermaye.TabIndex = 11;
            text_sermaye.TextChanged += checkInput;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(14, 423);
            label14.Name = "label14";
            label14.Size = new Size(60, 15);
            label14.TabIndex = 26;
            label14.Text = "Sermayesi";
            // 
            // radio_none
            // 
            radio_none.AutoSize = true;
            radio_none.Location = new Point(197, 557);
            radio_none.Name = "radio_none";
            radio_none.Size = new Size(44, 19);
            radio_none.TabIndex = 56;
            radio_none.TabStop = true;
            radio_none.Text = "Yok";
            radio_none.UseVisualStyleBackColor = true;
            radio_none.CheckedChanged += checkInput;
            // 
            // radio_sanayi
            // 
            radio_sanayi.AutoSize = true;
            radio_sanayi.Location = new Point(123, 557);
            radio_sanayi.Name = "radio_sanayi";
            radio_sanayi.Size = new Size(68, 19);
            radio_sanayi.TabIndex = 55;
            radio_sanayi.TabStop = true;
            radio_sanayi.Text = "Sanayici";
            radio_sanayi.UseVisualStyleBackColor = true;
            radio_sanayi.CheckedChanged += checkInput;
            // 
            // radio_imib
            // 
            radio_imib.AutoSize = true;
            radio_imib.Location = new Point(68, 557);
            radio_imib.Name = "radio_imib";
            radio_imib.Size = new Size(49, 19);
            radio_imib.TabIndex = 54;
            radio_imib.TabStop = true;
            radio_imib.Text = "İmib";
            radio_imib.UseVisualStyleBackColor = true;
            radio_imib.CheckedChanged += checkInput;
            // 
            // radio_tim
            // 
            radio_tim.AutoSize = true;
            radio_tim.Location = new Point(17, 557);
            radio_tim.Name = "radio_tim";
            radio_tim.Size = new Size(45, 19);
            radio_tim.TabIndex = 53;
            radio_tim.TabStop = true;
            radio_tim.Text = "Tim";
            radio_tim.UseVisualStyleBackColor = true;
            radio_tim.CheckedChanged += checkInput;
            // 
            // text_opreason
            // 
            text_opreason.Location = new Point(158, 585);
            text_opreason.Name = "text_opreason";
            text_opreason.Size = new Size(100, 23);
            text_opreason.TabIndex = 15;
            text_opreason.TextChanged += checkInput;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(17, 588);
            label18.Name = "label18";
            label18.Size = new Size(123, 15);
            label18.TabIndex = 51;
            label18.Text = "Yapılan İşlemin Amacı";
            // 
            // text_lastoperation
            // 
            text_lastoperation.Location = new Point(155, 528);
            text_lastoperation.Mask = "00/00/0000";
            text_lastoperation.Name = "text_lastoperation";
            text_lastoperation.Size = new Size(100, 23);
            text_lastoperation.TabIndex = 14;
            text_lastoperation.ValidatingType = typeof(DateTime);
            text_lastoperation.TextChanged += checkInput;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(14, 531);
            label19.Name = "label19";
            label19.Size = new Size(89, 15);
            label19.TabIndex = 49;
            label19.Text = "Son İşlem Tarihi";
            // 
            // button_new
            // 
            button_new.BackColor = Color.FromArgb(72, 106, 169);
            button_new.BackgroundImage = Properties.Resources.gradient_center;
            button_new.BackgroundImageLayout = ImageLayout.Stretch;
            button_new.Enabled = false;
            button_new.FlatAppearance.BorderSize = 0;
            button_new.FlatStyle = FlatStyle.Flat;
            button_new.ForeColor = Color.White;
            button_new.Location = new Point(455, 733);
            button_new.Name = "button_new";
            button_new.Size = new Size(145, 32);
            button_new.TabIndex = 60;
            button_new.Text = "Yeni";
            button_new.UseVisualStyleBackColor = false;
            button_new.Click += button_new_Click;
            // 
            // button_delete
            // 
            button_delete.BackColor = Color.FromArgb(72, 106, 169);
            button_delete.BackgroundImage = Properties.Resources.gradient_center;
            button_delete.BackgroundImageLayout = ImageLayout.Stretch;
            button_delete.FlatAppearance.BorderSize = 0;
            button_delete.FlatStyle = FlatStyle.Flat;
            button_delete.ForeColor = Color.White;
            button_delete.Location = new Point(304, 733);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(145, 32);
            button_delete.TabIndex = 59;
            button_delete.Text = "Sil";
            button_delete.UseVisualStyleBackColor = false;
            button_delete.Click += button_delete_Click;
            // 
            // button_update
            // 
            button_update.BackColor = Color.FromArgb(72, 106, 169);
            button_update.BackgroundImage = Properties.Resources.gradient_center;
            button_update.BackgroundImageLayout = ImageLayout.Stretch;
            button_update.FlatAppearance.BorderSize = 0;
            button_update.FlatStyle = FlatStyle.Flat;
            button_update.ForeColor = Color.White;
            button_update.Location = new Point(153, 733);
            button_update.Name = "button_update";
            button_update.Size = new Size(145, 32);
            button_update.TabIndex = 58;
            button_update.Text = "Müşteri Güncelle";
            button_update.UseVisualStyleBackColor = false;
            button_update.Click += button_update_Click;
            // 
            // button_save
            // 
            button_save.BackColor = Color.FromArgb(72, 106, 169);
            button_save.BackgroundImage = Properties.Resources.gradient_center;
            button_save.BackgroundImageLayout = ImageLayout.Stretch;
            button_save.FlatAppearance.BorderSize = 0;
            button_save.FlatStyle = FlatStyle.Flat;
            button_save.ForeColor = Color.White;
            button_save.Location = new Point(2, 733);
            button_save.Name = "button_save";
            button_save.Size = new Size(145, 32);
            button_save.TabIndex = 57;
            button_save.Text = "Müşteriyi Kaydet";
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(text_lastopcount);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label24);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(text_taxoffice);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(comboBox_donem);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(text_custcode);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(text_taxnum);
            panel1.Controls.Add(radio_none);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(radio_sanayi);
            panel1.Controls.Add(radio_imib);
            panel1.Controls.Add(text_tcid);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(text_opreason);
            panel1.Controls.Add(radio_tim);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(text_comptype);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(text_namesurname);
            panel1.Controls.Add(text_lastoperation);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label19);
            panel1.Controls.Add(text_reference);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(text_phone);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(text_date);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(text_email);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(text_sermaye);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(txt_matrah);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(text_tahakkuk);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(273, 727);
            panel1.TabIndex = 62;
            // 
            // text_lastopcount
            // 
            text_lastopcount.Location = new Point(158, 614);
            text_lastopcount.Name = "text_lastopcount";
            text_lastopcount.Size = new Size(100, 23);
            text_lastopcount.TabIndex = 16;
            text_lastopcount.TextChanged += checkInput;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(17, 617);
            label13.Name = "label13";
            label13.Size = new Size(108, 15);
            label13.TabIndex = 67;
            label13.Text = "Yapılan İşlem Sayısı";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label24.Location = new Point(82, 9);
            label24.Name = "label24";
            label24.Size = new Size(100, 20);
            label24.TabIndex = 66;
            label24.Text = "Genel Bilgiler";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(12, 128);
            label15.Name = "label15";
            label15.Size = new Size(71, 15);
            label15.TabIndex = 57;
            label15.Text = "Vergi Dairesi";
            // 
            // text_taxoffice
            // 
            text_taxoffice.Location = new Point(156, 124);
            text_taxoffice.Name = "text_taxoffice";
            text_taxoffice.Size = new Size(100, 23);
            text_taxoffice.TabIndex = 2;
            text_taxoffice.TextChanged += checkInput;
            // 
            // text_fax
            // 
            text_fax.Location = new Point(163, 149);
            text_fax.Mask = "0000";
            text_fax.Name = "text_fax";
            text_fax.Size = new Size(100, 23);
            text_fax.TabIndex = 18;
            text_fax.TextChanged += checkInput;
            // 
            // panel3
            // 
            panel3.Controls.Add(label21);
            panel3.Controls.Add(check_kimlik);
            panel3.Controls.Add(text_fax);
            panel3.Controls.Add(label22);
            panel3.Controls.Add(label17);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(check_cerceve);
            panel3.Controls.Add(label23);
            panel3.Controls.Add(label20);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(text_sirkulertarih);
            panel3.Location = new Point(570, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(275, 727);
            panel3.TabIndex = 64;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label21.Location = new Point(111, 9);
            label21.Name = "label21";
            label21.Size = new Size(65, 20);
            label21.TabIndex = 65;
            label21.Text = "Belgeler";
            // 
            // check_kimlik
            // 
            check_kimlik.CheckAlign = ContentAlignment.MiddleRight;
            check_kimlik.Location = new Point(12, 91);
            check_kimlik.Name = "check_kimlik";
            check_kimlik.RightToLeft = RightToLeft.No;
            check_kimlik.Size = new Size(251, 19);
            check_kimlik.TabIndex = 68;
            check_kimlik.Text = "Kimlik Kartı";
            check_kimlik.UseVisualStyleBackColor = true;
            check_kimlik.CheckedChanged += checkInput;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(120, 193);
            label22.Name = "label22";
            label22.Size = new Size(32, 15);
            label22.TabIndex = 33;
            label22.Text = "İmza";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(13, 157);
            label17.Name = "label17";
            label17.Size = new Size(114, 15);
            label17.TabIndex = 70;
            label17.Text = "Vergi Levhası  (Tarih)";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlDark;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(58, 211);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(152, 85);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 34;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // check_cerceve
            // 
            check_cerceve.CheckAlign = ContentAlignment.MiddleRight;
            check_cerceve.Location = new Point(12, 63);
            check_cerceve.Name = "check_cerceve";
            check_cerceve.RightToLeft = RightToLeft.No;
            check_cerceve.Size = new Size(251, 19);
            check_cerceve.TabIndex = 67;
            check_cerceve.Text = "Çerçeve Sözleşmesi";
            check_cerceve.UseVisualStyleBackColor = true;
            check_cerceve.CheckedChanged += checkInput;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(111, 299);
            label23.Name = "label23";
            label23.Size = new Size(52, 15);
            label23.TabIndex = 35;
            label23.Text = "Fotoğraf";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(12, 123);
            label20.Name = "label20";
            label20.Size = new Size(113, 15);
            label20.TabIndex = 65;
            label20.Text = "İmza Sirküleri (Tarih)";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Image = Properties.Resources.default_photo;
            pictureBox2.InitialImage = null;
            pictureBox2.Location = new Point(58, 317);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(152, 148);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 36;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // YeniGercek
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(button_new);
            Controls.Add(button_delete);
            Controls.Add(button_update);
            Controls.Add(button_save);
            Name = "YeniGercek";
            Text = "Yeni Gerçek Kişi";
            Load += YeniGercek_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox text_taxnum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_custcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_donem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_tcid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_comptype;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_email;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox text_date;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox text_phone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox text_reference;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox text_namesurname;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox text_sirkulertarih;
        private System.Windows.Forms.TextBox text_tahakkuk;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_matrah;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox text_sermaye;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton radio_none;
        private System.Windows.Forms.RadioButton radio_sanayi;
        private System.Windows.Forms.RadioButton radio_imib;
        private System.Windows.Forms.RadioButton radio_tim;
        private System.Windows.Forms.TextBox text_opreason;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MaskedTextBox text_lastoperation;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button_new;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Panel panel_left_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.OpenFileDialog fileDialog_imza;
        private System.Windows.Forms.OpenFileDialog fileDialog_picture;
        private System.Windows.Forms.OpenFileDialog fileDialog_document;
        private Label label15;
        private TextBox text_taxoffice;
        private MaskedTextBox text_fax;
        private CheckBox check_kimlik;
        private Label label17;
        private CheckBox check_cerceve;
        private Label label20;
        private Label label24;
        private Label label21;
        private TextBox text_lastopcount;
        private Label label13;
    }
}