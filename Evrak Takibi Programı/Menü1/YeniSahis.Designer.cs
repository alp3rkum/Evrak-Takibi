namespace Evrak_Takibi_Programı
{
    partial class YeniSahis
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
            text_sirkulertarih = new MaskedTextBox();
            text_tahakkuk = new TextBox();
            label12 = new Label();
            txt_matrah = new TextBox();
            label11 = new Label();
            text_sermaye = new TextBox();
            label14 = new Label();
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
            text_comptype = new TextBox();
            label5 = new Label();
            text_tcid = new TextBox();
            label4 = new Label();
            text_taxnum = new TextBox();
            label3 = new Label();
            text_custcode = new TextBox();
            label2 = new Label();
            comboBox_donem = new ComboBox();
            label1 = new Label();
            picture_photo = new PictureBox();
            label16 = new Label();
            picture_signature = new PictureBox();
            label15 = new Label();
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
            panel3 = new Panel();
            check_imza = new CheckBox();
            check_ikamet = new CheckBox();
            label20 = new Label();
            check_kimlik = new CheckBox();
            check_cerceve = new CheckBox();
            label21 = new Label();
            fileDialog_imza = new OpenFileDialog();
            fileDialog_picture = new OpenFileDialog();
            fileDialog_document = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)picture_photo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picture_signature).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // text_sirkulertarih
            // 
            text_sirkulertarih.Location = new Point(163, 98);
            text_sirkulertarih.Mask = "00/00/0000";
            text_sirkulertarih.Name = "text_sirkulertarih";
            text_sirkulertarih.Size = new Size(100, 23);
            text_sirkulertarih.TabIndex = 16;
            text_sirkulertarih.ValidatingType = typeof(DateTime);
            text_sirkulertarih.TextChanged += checkInput;
            // 
            // text_tahakkuk
            // 
            text_tahakkuk.Location = new Point(160, 448);
            text_tahakkuk.Name = "text_tahakkuk";
            text_tahakkuk.Size = new Size(100, 23);
            text_tahakkuk.TabIndex = 12;
            text_tahakkuk.TextChanged += checkInput;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(15, 451);
            label12.Name = "label12";
            label12.Size = new Size(114, 15);
            label12.TabIndex = 58;
            label12.Text = "Tahakkuk Eden Vergi";
            // 
            // txt_matrah
            // 
            txt_matrah.Location = new Point(160, 411);
            txt_matrah.Name = "txt_matrah";
            txt_matrah.Size = new Size(100, 23);
            txt_matrah.TabIndex = 11;
            txt_matrah.TextChanged += checkInput;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(15, 414);
            label11.Name = "label11";
            label11.Size = new Size(122, 15);
            label11.TabIndex = 56;
            label11.Text = "Beyah Olunan Matrah";
            // 
            // text_sermaye
            // 
            text_sermaye.Location = new Point(160, 376);
            text_sermaye.Name = "text_sermaye";
            text_sermaye.Size = new Size(100, 23);
            text_sermaye.TabIndex = 10;
            text_sermaye.TextChanged += checkInput;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(15, 379);
            label14.Name = "label14";
            label14.Size = new Size(60, 15);
            label14.TabIndex = 54;
            label14.Text = "Sermayesi";
            // 
            // text_email
            // 
            text_email.Location = new Point(160, 343);
            text_email.Name = "text_email";
            text_email.Size = new Size(100, 23);
            text_email.TabIndex = 9;
            text_email.TextChanged += checkInput;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 346);
            label8.Name = "label8";
            label8.Size = new Size(83, 15);
            label8.TabIndex = 52;
            label8.Text = "E-posta Adresi";
            // 
            // text_date
            // 
            text_date.Location = new Point(160, 314);
            text_date.Mask = "00/00/0000";
            text_date.Name = "text_date";
            text_date.Size = new Size(100, 23);
            text_date.TabIndex = 8;
            text_date.ValidatingType = typeof(DateTime);
            text_date.TextChanged += checkInput;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 317);
            label7.Name = "label7";
            label7.Size = new Size(99, 15);
            label7.TabIndex = 50;
            label7.Text = "İşe Başlama Tarihi";
            // 
            // text_phone
            // 
            text_phone.Location = new Point(160, 280);
            text_phone.Mask = "(999) 000-0000";
            text_phone.Name = "text_phone";
            text_phone.Size = new Size(100, 23);
            text_phone.TabIndex = 7;
            text_phone.TextChanged += checkInput;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 283);
            label6.Name = "label6";
            label6.Size = new Size(99, 15);
            label6.TabIndex = 48;
            label6.Text = "Telefon Numarası";
            // 
            // text_reference
            // 
            text_reference.Location = new Point(160, 246);
            text_reference.Name = "text_reference";
            text_reference.Size = new Size(100, 23);
            text_reference.TabIndex = 6;
            text_reference.TextChanged += checkInput;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 249);
            label9.Name = "label9";
            label9.Size = new Size(52, 15);
            label9.TabIndex = 46;
            label9.Text = "Referans";
            // 
            // text_namesurname
            // 
            text_namesurname.Location = new Point(160, 210);
            text_namesurname.Name = "text_namesurname";
            text_namesurname.Size = new Size(100, 23);
            text_namesurname.TabIndex = 5;
            text_namesurname.TextChanged += checkInput;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(15, 213);
            label10.Name = "label10";
            label10.Size = new Size(102, 15);
            label10.TabIndex = 44;
            label10.Text = "Müşteri Ad/Soyad";
            // 
            // text_comptype
            // 
            text_comptype.Location = new Point(160, 177);
            text_comptype.Name = "text_comptype";
            text_comptype.Size = new Size(100, 23);
            text_comptype.TabIndex = 4;
            text_comptype.TextChanged += checkInput;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 180);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 42;
            label5.Text = "Şirket Tipi";
            // 
            // text_tcid
            // 
            text_tcid.Location = new Point(160, 144);
            text_tcid.MaxLength = 11;
            text_tcid.Name = "text_tcid";
            text_tcid.Size = new Size(100, 23);
            text_tcid.TabIndex = 3;
            text_tcid.TextChanged += checkInput;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 147);
            label4.Name = "label4";
            label4.Size = new Size(110, 15);
            label4.TabIndex = 40;
            label4.Text = "TC Kimlik Numarası";
            // 
            // text_taxnum
            // 
            text_taxnum.Location = new Point(160, 113);
            text_taxnum.Name = "text_taxnum";
            text_taxnum.Size = new Size(100, 23);
            text_taxnum.TabIndex = 2;
            text_taxnum.TextChanged += checkInput;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 116);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 38;
            label3.Text = "Vergi Numarası";
            // 
            // text_custcode
            // 
            text_custcode.Location = new Point(160, 77);
            text_custcode.Name = "text_custcode";
            text_custcode.Size = new Size(100, 23);
            text_custcode.TabIndex = 1;
            text_custcode.TextChanged += text_custcode_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 80);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 36;
            label2.Text = "Müşteri Kodu";
            // 
            // comboBox_donem
            // 
            comboBox_donem.FormattingEnabled = true;
            comboBox_donem.Location = new Point(160, 46);
            comboBox_donem.Name = "comboBox_donem";
            comboBox_donem.Size = new Size(100, 23);
            comboBox_donem.TabIndex = 35;
            comboBox_donem.SelectedIndexChanged += checkInput;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 49);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 34;
            label1.Text = "Dönem";
            // 
            // picture_photo
            // 
            picture_photo.BackgroundImageLayout = ImageLayout.Stretch;
            picture_photo.Image = Properties.Resources.default_photo;
            picture_photo.InitialImage = null;
            picture_photo.Location = new Point(70, 322);
            picture_photo.Name = "picture_photo";
            picture_photo.Size = new Size(152, 148);
            picture_photo.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_photo.TabIndex = 65;
            picture_photo.TabStop = false;
            picture_photo.Click += picture_photo_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(114, 304);
            label16.Name = "label16";
            label16.Size = new Size(52, 15);
            label16.TabIndex = 64;
            label16.Text = "Fotoğraf";
            // 
            // picture_signature
            // 
            picture_signature.BackColor = SystemColors.ControlDark;
            picture_signature.BackgroundImageLayout = ImageLayout.Stretch;
            picture_signature.Location = new Point(70, 216);
            picture_signature.Name = "picture_signature";
            picture_signature.Size = new Size(152, 85);
            picture_signature.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_signature.TabIndex = 63;
            picture_signature.TabStop = false;
            picture_signature.Click += picture_signature_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(124, 198);
            label15.Name = "label15";
            label15.Size = new Size(32, 15);
            label15.TabIndex = 62;
            label15.Text = "İmza";
            // 
            // radio_none
            // 
            radio_none.AutoSize = true;
            radio_none.Location = new Point(200, 514);
            radio_none.Name = "radio_none";
            radio_none.Size = new Size(44, 19);
            radio_none.TabIndex = 78;
            radio_none.TabStop = true;
            radio_none.Text = "Yok";
            radio_none.UseVisualStyleBackColor = true;
            radio_none.CheckedChanged += checkInput;
            // 
            // radio_sanayi
            // 
            radio_sanayi.AutoSize = true;
            radio_sanayi.Location = new Point(126, 514);
            radio_sanayi.Name = "radio_sanayi";
            radio_sanayi.Size = new Size(68, 19);
            radio_sanayi.TabIndex = 77;
            radio_sanayi.TabStop = true;
            radio_sanayi.Text = "Sanayici";
            radio_sanayi.UseVisualStyleBackColor = true;
            radio_sanayi.CheckedChanged += checkInput;
            // 
            // radio_imib
            // 
            radio_imib.AutoSize = true;
            radio_imib.Location = new Point(71, 514);
            radio_imib.Name = "radio_imib";
            radio_imib.Size = new Size(49, 19);
            radio_imib.TabIndex = 76;
            radio_imib.TabStop = true;
            radio_imib.Text = "İmib";
            radio_imib.UseVisualStyleBackColor = true;
            radio_imib.CheckedChanged += checkInput;
            // 
            // radio_tim
            // 
            radio_tim.AutoSize = true;
            radio_tim.Location = new Point(20, 514);
            radio_tim.Name = "radio_tim";
            radio_tim.Size = new Size(45, 19);
            radio_tim.TabIndex = 75;
            radio_tim.TabStop = true;
            radio_tim.Text = "Tim";
            radio_tim.UseVisualStyleBackColor = true;
            radio_tim.CheckedChanged += checkInput;
            // 
            // text_opreason
            // 
            text_opreason.Location = new Point(161, 543);
            text_opreason.Name = "text_opreason";
            text_opreason.Size = new Size(100, 23);
            text_opreason.TabIndex = 14;
            text_opreason.TextChanged += checkInput;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(15, 546);
            label18.Name = "label18";
            label18.Size = new Size(123, 15);
            label18.TabIndex = 73;
            label18.Text = "Yapılan İşlemin Amacı";
            // 
            // text_lastoperation
            // 
            text_lastoperation.Location = new Point(161, 485);
            text_lastoperation.Mask = "00/00/0000";
            text_lastoperation.Name = "text_lastoperation";
            text_lastoperation.Size = new Size(100, 23);
            text_lastoperation.TabIndex = 13;
            text_lastoperation.ValidatingType = typeof(DateTime);
            text_lastoperation.TextChanged += checkInput;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(16, 488);
            label19.Name = "label19";
            label19.Size = new Size(89, 15);
            label19.TabIndex = 71;
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
            button_new.Location = new Point(305, 723);
            button_new.Name = "button_new";
            button_new.Size = new Size(145, 32);
            button_new.TabIndex = 83;
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
            button_delete.Location = new Point(456, 723);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(145, 32);
            button_delete.TabIndex = 82;
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
            button_update.Location = new Point(154, 723);
            button_update.Name = "button_update";
            button_update.Size = new Size(145, 32);
            button_update.TabIndex = 81;
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
            button_save.Location = new Point(3, 723);
            button_save.Name = "button_save";
            button_save.Size = new Size(145, 32);
            button_save.TabIndex = 80;
            button_save.Text = "Müşteriyi Kaydet";
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(text_lastopcount);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label24);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(comboBox_donem);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(text_custcode);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(text_taxnum);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(text_opreason);
            panel1.Controls.Add(radio_none);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(text_tcid);
            panel1.Controls.Add(radio_sanayi);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(radio_imib);
            panel1.Controls.Add(text_comptype);
            panel1.Controls.Add(radio_tim);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(text_namesurname);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(text_lastoperation);
            panel1.Controls.Add(text_reference);
            panel1.Controls.Add(label19);
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
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(275, 718);
            panel1.TabIndex = 85;
            // 
            // text_lastopcount
            // 
            text_lastopcount.Location = new Point(161, 574);
            text_lastopcount.Name = "text_lastopcount";
            text_lastopcount.Size = new Size(100, 23);
            text_lastopcount.TabIndex = 15;
            text_lastopcount.TextChanged += checkInput;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(15, 577);
            label13.Name = "label13";
            label13.Size = new Size(108, 15);
            label13.TabIndex = 84;
            label13.Text = "Yapılan İşlem Sayısı";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label24.Location = new Point(90, 10);
            label24.Name = "label24";
            label24.Size = new Size(100, 20);
            label24.TabIndex = 83;
            label24.Text = "Genel Bilgiler";
            // 
            // panel3
            // 
            panel3.Controls.Add(check_imza);
            panel3.Controls.Add(check_ikamet);
            panel3.Controls.Add(label20);
            panel3.Controls.Add(check_kimlik);
            panel3.Controls.Add(check_cerceve);
            panel3.Controls.Add(label21);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(picture_signature);
            panel3.Controls.Add(picture_photo);
            panel3.Controls.Add(label16);
            panel3.Controls.Add(text_sirkulertarih);
            panel3.Location = new Point(570, -1);
            panel3.Name = "panel3";
            panel3.Size = new Size(275, 718);
            panel3.TabIndex = 86;
            // 
            // check_imza
            // 
            check_imza.CheckAlign = ContentAlignment.MiddleRight;
            check_imza.Location = new Point(12, 157);
            check_imza.Name = "check_imza";
            check_imza.RightToLeft = RightToLeft.No;
            check_imza.Size = new Size(251, 19);
            check_imza.TabIndex = 74;
            check_imza.Text = "Islak İmza";
            check_imza.UseVisualStyleBackColor = true;
            check_imza.CheckedChanged += checkInput;
            // 
            // check_ikamet
            // 
            check_ikamet.CheckAlign = ContentAlignment.MiddleRight;
            check_ikamet.Location = new Point(12, 129);
            check_ikamet.Name = "check_ikamet";
            check_ikamet.RightToLeft = RightToLeft.No;
            check_ikamet.Size = new Size(251, 19);
            check_ikamet.TabIndex = 73;
            check_ikamet.Text = "İkametgah";
            check_ikamet.UseVisualStyleBackColor = true;
            check_ikamet.CheckedChanged += checkInput;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(12, 103);
            label20.Name = "label20";
            label20.Size = new Size(113, 15);
            label20.TabIndex = 71;
            label20.Text = "İmza Sirküleri (Tarih)";
            // 
            // check_kimlik
            // 
            check_kimlik.CheckAlign = ContentAlignment.MiddleRight;
            check_kimlik.Location = new Point(12, 73);
            check_kimlik.Name = "check_kimlik";
            check_kimlik.RightToLeft = RightToLeft.No;
            check_kimlik.Size = new Size(251, 19);
            check_kimlik.TabIndex = 70;
            check_kimlik.Text = "Kimlik Kartı";
            check_kimlik.UseVisualStyleBackColor = true;
            check_kimlik.CheckedChanged += checkInput;
            // 
            // check_cerceve
            // 
            check_cerceve.CheckAlign = ContentAlignment.MiddleRight;
            check_cerceve.Location = new Point(12, 45);
            check_cerceve.Name = "check_cerceve";
            check_cerceve.RightToLeft = RightToLeft.No;
            check_cerceve.Size = new Size(251, 19);
            check_cerceve.TabIndex = 69;
            check_cerceve.Text = "Çerçeve Sözleşmesi";
            check_cerceve.UseVisualStyleBackColor = true;
            check_cerceve.CheckedChanged += checkInput;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label21.Location = new Point(110, 10);
            label21.Name = "label21";
            label21.Size = new Size(65, 20);
            label21.TabIndex = 66;
            label21.Text = "Belgeler";
            // 
            // YeniSahis
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
            Name = "YeniSahis";
            Text = "Yeni Şahıs";
            Load += YeniSahis_Load;
            ((System.ComponentModel.ISupportInitialize)picture_photo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picture_signature).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.MaskedTextBox text_sirkulertarih;
        private System.Windows.Forms.TextBox text_tahakkuk;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_matrah;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox text_sermaye;
        private System.Windows.Forms.Label label14;
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
        private System.Windows.Forms.TextBox text_comptype;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_tcid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_taxnum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_custcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_donem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picture_photo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox picture_signature;
        private System.Windows.Forms.Label label15;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.OpenFileDialog fileDialog_imza;
        private System.Windows.Forms.OpenFileDialog fileDialog_picture;
        private System.Windows.Forms.OpenFileDialog fileDialog_document;
        private Label label24;
        private Label label21;
        private CheckBox check_kimlik;
        private CheckBox check_cerceve;
        private Label label20;
        private CheckBox check_imza;
        private CheckBox check_ikamet;
        private TextBox text_lastopcount;
        private Label label13;
    }
}