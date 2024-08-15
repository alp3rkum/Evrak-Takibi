namespace Evrak_Takibi_Programı
{
    partial class YeniAdiOrtak
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
            text_custcode = new TextBox();
            label2 = new Label();
            comboBox_donem = new ComboBox();
            label1 = new Label();
            text_taxnum1 = new TextBox();
            label3 = new Label();
            text_tcid1 = new TextBox();
            label5 = new Label();
            text_phone = new MaskedTextBox();
            label7 = new Label();
            text_reference = new TextBox();
            label9 = new Label();
            text_namesurname = new TextBox();
            label10 = new Label();
            text_comptype = new TextBox();
            label8 = new Label();
            text_sirkulertarih = new MaskedTextBox();
            label13 = new Label();
            text_tahakkuk = new TextBox();
            label12 = new Label();
            txt_matrah = new TextBox();
            label11 = new Label();
            text_sermaye = new TextBox();
            label14 = new Label();
            text_email = new TextBox();
            label15 = new Label();
            text_date = new MaskedTextBox();
            label16 = new Label();
            text_gerfayda = new TextBox();
            label17 = new Label();
            radio_none = new RadioButton();
            radio_sanayi = new RadioButton();
            radio_imib = new RadioButton();
            radio_tim = new RadioButton();
            text_opreason = new TextBox();
            label22 = new Label();
            text_lastoperation = new MaskedTextBox();
            label23 = new Label();
            button_new = new Button();
            button_delete = new Button();
            button_update = new Button();
            button_save = new Button();
            panel1 = new Panel();
            text_lastopcount = new TextBox();
            label31 = new Label();
            check_tahakkuk = new CheckBox();
            check_ortaklik = new CheckBox();
            label30 = new Label();
            text_taxoffice = new TextBox();
            panel2 = new Panel();
            check_fayda1 = new CheckBox();
            text_faaliyet1 = new MaskedTextBox();
            label24 = new Label();
            check_kimlik1 = new CheckBox();
            text_vergilevha1 = new MaskedTextBox();
            label29 = new Label();
            check_cerceve1 = new CheckBox();
            text_sirkuler1 = new MaskedTextBox();
            label32 = new Label();
            label25 = new Label();
            picture_signature = new PictureBox();
            picture_photo = new PictureBox();
            label26 = new Label();
            panel4 = new Panel();
            check_fayda2 = new CheckBox();
            text_faaliyet2 = new MaskedTextBox();
            label4 = new Label();
            label33 = new Label();
            pictureBox1 = new PictureBox();
            check_kimlik2 = new CheckBox();
            label6 = new Label();
            text_vergilevha2 = new MaskedTextBox();
            pictureBox2 = new PictureBox();
            label34 = new Label();
            textBox1 = new TextBox();
            check_cerceve2 = new CheckBox();
            label18 = new Label();
            text_sirkuler2 = new MaskedTextBox();
            label20 = new Label();
            label35 = new Label();
            textBox2 = new TextBox();
            label27 = new Label();
            textBox3 = new TextBox();
            fileDialog_imza = new OpenFileDialog();
            fileDialog_picture = new OpenFileDialog();
            fileDialog_document = new OpenFileDialog();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture_signature).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picture_photo).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // text_custcode
            // 
            text_custcode.Location = new Point(148, 43);
            text_custcode.Name = "text_custcode";
            text_custcode.Size = new Size(100, 23);
            text_custcode.TabIndex = 1;
            text_custcode.TextChanged += text_custcode_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 46);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 40;
            label2.Text = "Müşteri Kodu";
            // 
            // comboBox_donem
            // 
            comboBox_donem.FormattingEnabled = true;
            comboBox_donem.Location = new Point(148, 12);
            comboBox_donem.Name = "comboBox_donem";
            comboBox_donem.Size = new Size(100, 23);
            comboBox_donem.TabIndex = 39;
            comboBox_donem.SelectedIndexChanged += checkInput;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 15);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 38;
            label1.Text = "Dönem";
            // 
            // text_taxnum1
            // 
            text_taxnum1.Location = new Point(167, 12);
            text_taxnum1.Name = "text_taxnum1";
            text_taxnum1.Size = new Size(100, 23);
            text_taxnum1.TabIndex = 16;
            text_taxnum1.TextChanged += checkInput;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 15);
            label3.Name = "label3";
            label3.Size = new Size(131, 15);
            label3.TabIndex = 42;
            label3.Text = "1. Ortak Vergi Numarası";
            // 
            // text_tcid1
            // 
            text_tcid1.Location = new Point(167, 49);
            text_tcid1.MaxLength = 11;
            text_tcid1.Name = "text_tcid1";
            text_tcid1.Size = new Size(100, 23);
            text_tcid1.TabIndex = 17;
            text_tcid1.TextChanged += checkInput;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 52);
            label5.Name = "label5";
            label5.Size = new Size(119, 15);
            label5.TabIndex = 46;
            label5.Text = "1. Ortak TC Kimlik No";
            // 
            // text_phone
            // 
            text_phone.Location = new Point(148, 204);
            text_phone.Mask = "(999) 000-0000";
            text_phone.Name = "text_phone";
            text_phone.Size = new Size(100, 23);
            text_phone.TabIndex = 6;
            text_phone.TextChanged += checkInput;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 207);
            label7.Name = "label7";
            label7.Size = new Size(99, 15);
            label7.TabIndex = 56;
            label7.Text = "Telefon Numarası";
            // 
            // text_reference
            // 
            text_reference.Location = new Point(148, 170);
            text_reference.Name = "text_reference";
            text_reference.Size = new Size(100, 23);
            text_reference.TabIndex = 5;
            text_reference.TextChanged += checkInput;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(10, 173);
            label9.Name = "label9";
            label9.Size = new Size(52, 15);
            label9.TabIndex = 54;
            label9.Text = "Referans";
            // 
            // text_namesurname
            // 
            text_namesurname.Location = new Point(148, 134);
            text_namesurname.Name = "text_namesurname";
            text_namesurname.Size = new Size(100, 23);
            text_namesurname.TabIndex = 4;
            text_namesurname.TextChanged += checkInput;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(10, 137);
            label10.Name = "label10";
            label10.Size = new Size(102, 15);
            label10.TabIndex = 52;
            label10.Text = "Müşteri Ad/Soyad";
            // 
            // text_comptype
            // 
            text_comptype.Location = new Point(148, 101);
            text_comptype.Name = "text_comptype";
            text_comptype.Size = new Size(100, 23);
            text_comptype.TabIndex = 3;
            text_comptype.TextChanged += checkInput;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 104);
            label8.Name = "label8";
            label8.Size = new Size(58, 15);
            label8.TabIndex = 50;
            label8.Text = "Şirket Tipi";
            // 
            // text_sirkulertarih
            // 
            text_sirkulertarih.Location = new Point(148, 407);
            text_sirkulertarih.Mask = "00/00/0000";
            text_sirkulertarih.Name = "text_sirkulertarih";
            text_sirkulertarih.Size = new Size(100, 23);
            text_sirkulertarih.TabIndex = 12;
            text_sirkulertarih.ValidatingType = typeof(DateTime);
            text_sirkulertarih.TextChanged += checkInput;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(10, 410);
            label13.Name = "label13";
            label13.Size = new Size(113, 15);
            label13.TabIndex = 72;
            label13.Text = "İmza Sirküleri (Tarih)";
            // 
            // text_tahakkuk
            // 
            text_tahakkuk.Location = new Point(148, 373);
            text_tahakkuk.Name = "text_tahakkuk";
            text_tahakkuk.Size = new Size(100, 23);
            text_tahakkuk.TabIndex = 11;
            text_tahakkuk.TextChanged += checkInput;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(10, 376);
            label12.Name = "label12";
            label12.Size = new Size(114, 15);
            label12.TabIndex = 70;
            label12.Text = "Tahakkuk Eden Vergi";
            // 
            // txt_matrah
            // 
            txt_matrah.Location = new Point(148, 336);
            txt_matrah.Name = "txt_matrah";
            txt_matrah.Size = new Size(100, 23);
            txt_matrah.TabIndex = 10;
            txt_matrah.TextChanged += checkInput;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(10, 339);
            label11.Name = "label11";
            label11.Size = new Size(122, 15);
            label11.TabIndex = 68;
            label11.Text = "Beyah Olunan Matrah";
            // 
            // text_sermaye
            // 
            text_sermaye.Location = new Point(148, 303);
            text_sermaye.Name = "text_sermaye";
            text_sermaye.Size = new Size(100, 23);
            text_sermaye.TabIndex = 9;
            text_sermaye.TextChanged += checkInput;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(10, 306);
            label14.Name = "label14";
            label14.Size = new Size(60, 15);
            label14.TabIndex = 66;
            label14.Text = "Sermayesi";
            // 
            // text_email
            // 
            text_email.Location = new Point(148, 273);
            text_email.Name = "text_email";
            text_email.Size = new Size(100, 23);
            text_email.TabIndex = 8;
            text_email.TextChanged += checkInput;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(10, 276);
            label15.Name = "label15";
            label15.Size = new Size(83, 15);
            label15.TabIndex = 64;
            label15.Text = "E-posta Adresi";
            // 
            // text_date
            // 
            text_date.Location = new Point(148, 242);
            text_date.Mask = "00/00/0000";
            text_date.Name = "text_date";
            text_date.Size = new Size(100, 23);
            text_date.TabIndex = 7;
            text_date.ValidatingType = typeof(DateTime);
            text_date.TextChanged += checkInput;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(10, 245);
            label16.Name = "label16";
            label16.Size = new Size(99, 15);
            label16.TabIndex = 62;
            label16.Text = "İşe Başlama Tarihi";
            // 
            // text_gerfayda
            // 
            text_gerfayda.Location = new Point(167, 82);
            text_gerfayda.Name = "text_gerfayda";
            text_gerfayda.Size = new Size(100, 23);
            text_gerfayda.TabIndex = 18;
            text_gerfayda.TextChanged += checkInput;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(12, 85);
            label17.Name = "label17";
            label17.Size = new Size(149, 15);
            label17.TabIndex = 74;
            label17.Text = "1. Ortak Gerçek Faydalanıcı";
            // 
            // radio_none
            // 
            radio_none.AutoSize = true;
            radio_none.Location = new Point(190, 472);
            radio_none.Name = "radio_none";
            radio_none.Size = new Size(44, 19);
            radio_none.TabIndex = 100;
            radio_none.TabStop = true;
            radio_none.Text = "Yok";
            radio_none.UseVisualStyleBackColor = true;
            radio_none.CheckedChanged += checkInput;
            // 
            // radio_sanayi
            // 
            radio_sanayi.AutoSize = true;
            radio_sanayi.Location = new Point(116, 472);
            radio_sanayi.Name = "radio_sanayi";
            radio_sanayi.Size = new Size(68, 19);
            radio_sanayi.TabIndex = 99;
            radio_sanayi.TabStop = true;
            radio_sanayi.Text = "Sanayici";
            radio_sanayi.UseVisualStyleBackColor = true;
            radio_sanayi.CheckedChanged += checkInput;
            // 
            // radio_imib
            // 
            radio_imib.AutoSize = true;
            radio_imib.Location = new Point(63, 472);
            radio_imib.Name = "radio_imib";
            radio_imib.Size = new Size(49, 19);
            radio_imib.TabIndex = 98;
            radio_imib.TabStop = true;
            radio_imib.Text = "İmib";
            radio_imib.UseVisualStyleBackColor = true;
            radio_imib.CheckedChanged += checkInput;
            // 
            // radio_tim
            // 
            radio_tim.AutoSize = true;
            radio_tim.Location = new Point(12, 472);
            radio_tim.Name = "radio_tim";
            radio_tim.Size = new Size(45, 19);
            radio_tim.TabIndex = 97;
            radio_tim.TabStop = true;
            radio_tim.Text = "Tim";
            radio_tim.UseVisualStyleBackColor = true;
            radio_tim.CheckedChanged += checkInput;
            // 
            // text_opreason
            // 
            text_opreason.Location = new Point(148, 497);
            text_opreason.Name = "text_opreason";
            text_opreason.Size = new Size(100, 23);
            text_opreason.TabIndex = 14;
            text_opreason.TextChanged += checkInput;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(10, 500);
            label22.Name = "label22";
            label22.Size = new Size(123, 15);
            label22.TabIndex = 95;
            label22.Text = "Yapılan İşlemin Amacı";
            // 
            // text_lastoperation
            // 
            text_lastoperation.Location = new Point(148, 443);
            text_lastoperation.Mask = "00/00/0000";
            text_lastoperation.Name = "text_lastoperation";
            text_lastoperation.Size = new Size(100, 23);
            text_lastoperation.TabIndex = 13;
            text_lastoperation.ValidatingType = typeof(DateTime);
            text_lastoperation.TextChanged += checkInput;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(10, 446);
            label23.Name = "label23";
            label23.Size = new Size(89, 15);
            label23.TabIndex = 93;
            label23.Text = "Son İşlem Tarihi";
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
            button_new.Location = new Point(456, 731);
            button_new.Name = "button_new";
            button_new.Size = new Size(145, 32);
            button_new.TabIndex = 108;
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
            button_delete.Location = new Point(305, 731);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(145, 32);
            button_delete.TabIndex = 107;
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
            button_update.Location = new Point(154, 731);
            button_update.Name = "button_update";
            button_update.Size = new Size(145, 32);
            button_update.TabIndex = 106;
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
            button_save.Location = new Point(3, 731);
            button_save.Name = "button_save";
            button_save.Size = new Size(145, 32);
            button_save.TabIndex = 105;
            button_save.Text = "Müşteriyi Kaydet";
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(text_lastopcount);
            panel1.Controls.Add(label31);
            panel1.Controls.Add(check_tahakkuk);
            panel1.Controls.Add(check_ortaklik);
            panel1.Controls.Add(label30);
            panel1.Controls.Add(text_taxoffice);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(comboBox_donem);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(text_custcode);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(text_comptype);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(text_namesurname);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(text_opreason);
            panel1.Controls.Add(text_reference);
            panel1.Controls.Add(label22);
            panel1.Controls.Add(radio_none);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(radio_sanayi);
            panel1.Controls.Add(text_phone);
            panel1.Controls.Add(radio_imib);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(radio_tim);
            panel1.Controls.Add(text_date);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(text_email);
            panel1.Controls.Add(text_lastoperation);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label23);
            panel1.Controls.Add(text_sermaye);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(txt_matrah);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(text_tahakkuk);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(text_sirkulertarih);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(275, 724);
            panel1.TabIndex = 110;
            // 
            // text_lastopcount
            // 
            text_lastopcount.Location = new Point(148, 532);
            text_lastopcount.Name = "text_lastopcount";
            text_lastopcount.Size = new Size(100, 23);
            text_lastopcount.TabIndex = 15;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(10, 532);
            label31.Name = "label31";
            label31.Size = new Size(108, 15);
            label31.TabIndex = 111;
            label31.Text = "Yapılan İşlem Sayısı";
            // 
            // check_tahakkuk
            // 
            check_tahakkuk.CheckAlign = ContentAlignment.MiddleRight;
            check_tahakkuk.Location = new Point(10, 586);
            check_tahakkuk.Name = "check_tahakkuk";
            check_tahakkuk.RightToLeft = RightToLeft.No;
            check_tahakkuk.Size = new Size(238, 19);
            check_tahakkuk.TabIndex = 110;
            check_tahakkuk.Text = "Tahakkuk Fişi";
            check_tahakkuk.UseVisualStyleBackColor = true;
            check_tahakkuk.CheckedChanged += checkInput;
            // 
            // check_ortaklik
            // 
            check_ortaklik.CheckAlign = ContentAlignment.MiddleRight;
            check_ortaklik.Location = new Point(10, 561);
            check_ortaklik.Name = "check_ortaklik";
            check_ortaklik.RightToLeft = RightToLeft.No;
            check_ortaklik.Size = new Size(238, 19);
            check_ortaklik.TabIndex = 109;
            check_ortaklik.Text = "Adi Ortaklık Sözleşmesi";
            check_ortaklik.UseVisualStyleBackColor = true;
            check_ortaklik.CheckedChanged += checkInput;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(10, 75);
            label30.Name = "label30";
            label30.Size = new Size(71, 15);
            label30.TabIndex = 105;
            label30.Text = "Vergi Dairesi";
            // 
            // text_taxoffice
            // 
            text_taxoffice.Location = new Point(148, 72);
            text_taxoffice.Name = "text_taxoffice";
            text_taxoffice.Size = new Size(100, 23);
            text_taxoffice.TabIndex = 2;
            text_taxoffice.TextChanged += checkInput;
            // 
            // panel2
            // 
            panel2.Controls.Add(check_fayda1);
            panel2.Controls.Add(text_faaliyet1);
            panel2.Controls.Add(label24);
            panel2.Controls.Add(check_kimlik1);
            panel2.Controls.Add(text_vergilevha1);
            panel2.Controls.Add(label29);
            panel2.Controls.Add(check_cerceve1);
            panel2.Controls.Add(text_sirkuler1);
            panel2.Controls.Add(label32);
            panel2.Controls.Add(label25);
            panel2.Controls.Add(picture_signature);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(picture_photo);
            panel2.Controls.Add(text_taxnum1);
            panel2.Controls.Add(label26);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(text_tcid1);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(text_gerfayda);
            panel2.Location = new Point(285, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(275, 724);
            panel2.TabIndex = 112;
            // 
            // check_fayda1
            // 
            check_fayda1.CheckAlign = ContentAlignment.MiddleRight;
            check_fayda1.Location = new Point(12, 146);
            check_fayda1.Name = "check_fayda1";
            check_fayda1.RightToLeft = RightToLeft.No;
            check_fayda1.Size = new Size(250, 19);
            check_fayda1.TabIndex = 126;
            check_fayda1.Text = "Gerçek Faydalanıcı Formu";
            check_fayda1.UseVisualStyleBackColor = true;
            check_fayda1.CheckedChanged += checkInput;
            // 
            // text_faaliyet1
            // 
            text_faaliyet1.Location = new Point(162, 298);
            text_faaliyet1.Mask = "00/00/0000";
            text_faaliyet1.Name = "text_faaliyet1";
            text_faaliyet1.Size = new Size(100, 23);
            text_faaliyet1.TabIndex = 21;
            text_faaliyet1.ValidatingType = typeof(DateTime);
            text_faaliyet1.TextChanged += checkInput;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(11, 301);
            label24.Name = "label24";
            label24.Size = new Size(123, 15);
            label24.TabIndex = 123;
            label24.Text = "Faaliyet Belgesi (Tarih)";
            // 
            // check_kimlik1
            // 
            check_kimlik1.CheckAlign = ContentAlignment.MiddleRight;
            check_kimlik1.Location = new Point(11, 199);
            check_kimlik1.Name = "check_kimlik1";
            check_kimlik1.RightToLeft = RightToLeft.No;
            check_kimlik1.Size = new Size(251, 19);
            check_kimlik1.TabIndex = 128;
            check_kimlik1.Text = "Kimlik Kartı";
            check_kimlik1.UseVisualStyleBackColor = true;
            check_kimlik1.CheckedChanged += checkInput;
            // 
            // text_vergilevha1
            // 
            text_vergilevha1.Location = new Point(162, 262);
            text_vergilevha1.Mask = "0000";
            text_vergilevha1.Name = "text_vergilevha1";
            text_vergilevha1.Size = new Size(100, 23);
            text_vergilevha1.TabIndex = 20;
            text_vergilevha1.TextChanged += checkInput;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(12, 265);
            label29.Name = "label29";
            label29.Size = new Size(114, 15);
            label29.TabIndex = 122;
            label29.Text = "Vergi Levhası  (Tarih)";
            // 
            // check_cerceve1
            // 
            check_cerceve1.CheckAlign = ContentAlignment.MiddleRight;
            check_cerceve1.Location = new Point(11, 171);
            check_cerceve1.Name = "check_cerceve1";
            check_cerceve1.RightToLeft = RightToLeft.No;
            check_cerceve1.Size = new Size(251, 19);
            check_cerceve1.TabIndex = 127;
            check_cerceve1.Text = "Çerçeve Sözleşmesi";
            check_cerceve1.UseVisualStyleBackColor = true;
            check_cerceve1.CheckedChanged += checkInput;
            // 
            // text_sirkuler1
            // 
            text_sirkuler1.Location = new Point(162, 228);
            text_sirkuler1.Mask = "00/00/0000";
            text_sirkuler1.Name = "text_sirkuler1";
            text_sirkuler1.Size = new Size(100, 23);
            text_sirkuler1.TabIndex = 19;
            text_sirkuler1.ValidatingType = typeof(DateTime);
            text_sirkuler1.TextChanged += checkInput;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(11, 231);
            label32.Name = "label32";
            label32.Size = new Size(113, 15);
            label32.TabIndex = 117;
            label32.Text = "İmza Sirküleri (Tarih)";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(96, 336);
            label25.Name = "label25";
            label25.Size = new Size(76, 15);
            label25.TabIndex = 113;
            label25.Text = "1. Ortak İmza";
            // 
            // picture_signature
            // 
            picture_signature.BackColor = SystemColors.ControlDark;
            picture_signature.BackgroundImageLayout = ImageLayout.Stretch;
            picture_signature.Location = new Point(62, 354);
            picture_signature.Name = "picture_signature";
            picture_signature.Size = new Size(152, 85);
            picture_signature.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_signature.TabIndex = 114;
            picture_signature.TabStop = false;
            picture_signature.Click += picture_signature_Click;
            // 
            // picture_photo
            // 
            picture_photo.BackgroundImage = Properties.Resources.default_photo;
            picture_photo.BackgroundImageLayout = ImageLayout.Stretch;
            picture_photo.InitialImage = null;
            picture_photo.Location = new Point(62, 460);
            picture_photo.Name = "picture_photo";
            picture_photo.Size = new Size(152, 148);
            picture_photo.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_photo.TabIndex = 116;
            picture_photo.TabStop = false;
            picture_photo.Click += picture_photo_Click;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(84, 442);
            label26.Name = "label26";
            label26.Size = new Size(96, 15);
            label26.TabIndex = 115;
            label26.Text = "1. Ortak Fotoğraf";
            // 
            // panel4
            // 
            panel4.Controls.Add(check_fayda2);
            panel4.Controls.Add(text_faaliyet2);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label33);
            panel4.Controls.Add(pictureBox1);
            panel4.Controls.Add(check_kimlik2);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(text_vergilevha2);
            panel4.Controls.Add(pictureBox2);
            panel4.Controls.Add(label34);
            panel4.Controls.Add(textBox1);
            panel4.Controls.Add(check_cerceve2);
            panel4.Controls.Add(label18);
            panel4.Controls.Add(text_sirkuler2);
            panel4.Controls.Add(label20);
            panel4.Controls.Add(label35);
            panel4.Controls.Add(textBox2);
            panel4.Controls.Add(label27);
            panel4.Controls.Add(textBox3);
            panel4.Location = new Point(570, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(275, 724);
            panel4.TabIndex = 114;
            // 
            // check_fayda2
            // 
            check_fayda2.CheckAlign = ContentAlignment.MiddleRight;
            check_fayda2.Location = new Point(12, 146);
            check_fayda2.Name = "check_fayda2";
            check_fayda2.RightToLeft = RightToLeft.No;
            check_fayda2.Size = new Size(250, 19);
            check_fayda2.TabIndex = 25;
            check_fayda2.Text = "Gerçek Faydalanıcı Formu";
            check_fayda2.UseVisualStyleBackColor = true;
            check_fayda2.CheckedChanged += checkInput;
            // 
            // text_faaliyet2
            // 
            text_faaliyet2.Location = new Point(162, 298);
            text_faaliyet2.Mask = "00/00/0000";
            text_faaliyet2.Name = "text_faaliyet2";
            text_faaliyet2.Size = new Size(100, 23);
            text_faaliyet2.TabIndex = 27;
            text_faaliyet2.ValidatingType = typeof(DateTime);
            text_faaliyet2.TextChanged += checkInput;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(98, 336);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 113;
            label4.Text = "2. Ortak İmza";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(11, 301);
            label33.Name = "label33";
            label33.Size = new Size(123, 15);
            label33.TabIndex = 132;
            label33.Text = "Faaliyet Belgesi (Tarih)";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlDark;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(64, 354);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(152, 85);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 114;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // check_kimlik2
            // 
            check_kimlik2.CheckAlign = ContentAlignment.MiddleRight;
            check_kimlik2.Location = new Point(11, 199);
            check_kimlik2.Name = "check_kimlik2";
            check_kimlik2.RightToLeft = RightToLeft.No;
            check_kimlik2.Size = new Size(251, 19);
            check_kimlik2.TabIndex = 129;
            check_kimlik2.Text = "Kimlik Kartı";
            check_kimlik2.UseVisualStyleBackColor = true;
            check_kimlik2.CheckedChanged += checkInput;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 15);
            label6.Name = "label6";
            label6.Size = new Size(131, 15);
            label6.TabIndex = 42;
            label6.Text = "2. Ortak Vergi Numarası";
            // 
            // text_vergilevha2
            // 
            text_vergilevha2.Location = new Point(162, 262);
            text_vergilevha2.Mask = "0000";
            text_vergilevha2.Name = "text_vergilevha2";
            text_vergilevha2.Size = new Size(100, 23);
            text_vergilevha2.TabIndex = 26;
            text_vergilevha2.TextChanged += checkInput;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.default_photo;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.InitialImage = null;
            pictureBox2.Location = new Point(64, 460);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(152, 148);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 116;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(12, 265);
            label34.Name = "label34";
            label34.Size = new Size(114, 15);
            label34.TabIndex = 131;
            label34.Text = "Vergi Levhası  (Tarih)";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(167, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 22;
            textBox1.TextChanged += checkInput;
            // 
            // check_cerceve2
            // 
            check_cerceve2.CheckAlign = ContentAlignment.MiddleRight;
            check_cerceve2.Location = new Point(11, 171);
            check_cerceve2.Name = "check_cerceve2";
            check_cerceve2.RightToLeft = RightToLeft.No;
            check_cerceve2.Size = new Size(251, 19);
            check_cerceve2.TabIndex = 128;
            check_cerceve2.Text = "Çerçeve Sözleşmesi";
            check_cerceve2.UseVisualStyleBackColor = true;
            check_cerceve2.CheckedChanged += checkInput;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(86, 442);
            label18.Name = "label18";
            label18.Size = new Size(96, 15);
            label18.TabIndex = 115;
            label18.Text = "2. Ortak Fotoğraf";
            // 
            // text_sirkuler2
            // 
            text_sirkuler2.Location = new Point(162, 228);
            text_sirkuler2.Mask = "00/00/0000";
            text_sirkuler2.Name = "text_sirkuler2";
            text_sirkuler2.Size = new Size(100, 23);
            text_sirkuler2.TabIndex = 25;
            text_sirkuler2.ValidatingType = typeof(DateTime);
            text_sirkuler2.TextChanged += checkInput;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(12, 52);
            label20.Name = "label20";
            label20.Size = new Size(119, 15);
            label20.TabIndex = 46;
            label20.Text = "2. Ortak TC Kimlik No";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(11, 231);
            label35.Name = "label35";
            label35.Size = new Size(113, 15);
            label35.TabIndex = 126;
            label35.Text = "İmza Sirküleri (Tarih)";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(167, 49);
            textBox2.MaxLength = 11;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 23;
            textBox2.TextChanged += checkInput;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(12, 85);
            label27.Name = "label27";
            label27.Size = new Size(149, 15);
            label27.TabIndex = 74;
            label27.Text = "2. Ortak Gerçek Faydalanıcı";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(167, 82);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 24;
            textBox3.TextChanged += checkInput;
            // 
            // YeniAdiOrtak
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(button_new);
            Controls.Add(button_delete);
            Controls.Add(button_update);
            Controls.Add(button_save);
            Name = "YeniAdiOrtak";
            Text = "YeniAdiOrtak";
            Load += YeniAdiOrtak_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picture_signature).EndInit();
            ((System.ComponentModel.ISupportInitialize)picture_photo).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox text_custcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_donem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_taxnum1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_tcid1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox text_phone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox text_reference;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox text_namesurname;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox text_comptype;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox text_sirkulertarih;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox text_tahakkuk;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_matrah;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox text_sermaye;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox text_email;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MaskedTextBox text_date;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox text_gerfayda;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RadioButton radio_none;
        private System.Windows.Forms.RadioButton radio_sanayi;
        private System.Windows.Forms.RadioButton radio_imib;
        private System.Windows.Forms.RadioButton radio_tim;
        private System.Windows.Forms.TextBox text_opreason;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.MaskedTextBox text_lastoperation;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button button_new;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.PictureBox picture_signature;
        private System.Windows.Forms.PictureBox picture_photo;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.OpenFileDialog fileDialog_imza;
        private System.Windows.Forms.OpenFileDialog fileDialog_picture;
        private System.Windows.Forms.OpenFileDialog fileDialog_document;
        private Label label30;
        private TextBox text_taxoffice;
        private CheckBox check_ortaklik;
        private CheckBox check_tahakkuk;
        private CheckBox check_fayda1;
        private MaskedTextBox text_faaliyet1;
        private Label label24;
        private CheckBox check_kimlik1;
        private MaskedTextBox text_vergilevha1;
        private Label label29;
        private CheckBox check_cerceve1;
        private MaskedTextBox text_sirkuler1;
        private Label label32;
        private CheckBox check_fayda2;
        private MaskedTextBox text_faaliyet2;
        private Label label33;
        private CheckBox check_kimlik2;
        private MaskedTextBox text_vergilevha2;
        private Label label34;
        private CheckBox check_cerceve2;
        private MaskedTextBox text_sirkuler2;
        private Label label35;
        private TextBox text_lastopcount;
        private Label label31;
    }
}