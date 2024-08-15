namespace Evrak_Takibi_Programı
{
    partial class YeniTuzel
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
            comboBox_donem = new ComboBox();
            label2 = new Label();
            text_custcode = new TextBox();
            text_taxnum = new TextBox();
            label3 = new Label();
            text_namesurname = new TextBox();
            label4 = new Label();
            text_reference = new TextBox();
            label5 = new Label();
            label6 = new Label();
            text_phone = new MaskedTextBox();
            text_date = new MaskedTextBox();
            label7 = new Label();
            text_email = new TextBox();
            label8 = new Label();
            text_gerfayda = new TextBox();
            label9 = new Label();
            text_sermaye = new TextBox();
            label10 = new Label();
            txt_matrah = new TextBox();
            label11 = new Label();
            text_tahakkuk = new TextBox();
            label12 = new Label();
            text_sirkulertarih = new MaskedTextBox();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            picture_signature = new PictureBox();
            label16 = new Label();
            picture_photo = new PictureBox();
            text_lastoperation = new MaskedTextBox();
            label18 = new Label();
            text_opreason = new TextBox();
            label17 = new Label();
            text_lastopcount = new TextBox();
            label19 = new Label();
            radio_tim = new RadioButton();
            radio_imib = new RadioButton();
            radio_sanayi = new RadioButton();
            radio_none = new RadioButton();
            button_save = new Button();
            button_update = new Button();
            button_delete = new Button();
            button_new = new Button();
            panel2 = new Panel();
            label20 = new Label();
            label22 = new Label();
            text_taxoffice = new TextBox();
            label23 = new Label();
            text_fax = new MaskedTextBox();
            panel3 = new Panel();
            check_fayda = new CheckBox();
            text_ticaretsicil = new MaskedTextBox();
            label24 = new Label();
            text_faaliyet = new MaskedTextBox();
            label21 = new Label();
            check_kimlik = new CheckBox();
            check_cerceve = new CheckBox();
            fileDialog_imza = new OpenFileDialog();
            fileDialog_picture = new OpenFileDialog();
            fileDialog_document = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)picture_signature).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picture_photo).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 52);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Dönem";
            // 
            // comboBox_donem
            // 
            comboBox_donem.FormattingEnabled = true;
            comboBox_donem.Location = new Point(140, 49);
            comboBox_donem.Name = "comboBox_donem";
            comboBox_donem.Size = new Size(100, 23);
            comboBox_donem.TabIndex = 1;
            comboBox_donem.SelectedIndexChanged += comboBox_donem_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 83);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 2;
            label2.Text = "Müşteri Kodu";
            // 
            // text_custcode
            // 
            text_custcode.Location = new Point(140, 80);
            text_custcode.Name = "text_custcode";
            text_custcode.Size = new Size(100, 23);
            text_custcode.TabIndex = 1;
            text_custcode.TextChanged += text_custcode_TextChanged;
            // 
            // text_taxnum
            // 
            text_taxnum.Location = new Point(140, 142);
            text_taxnum.Name = "text_taxnum";
            text_taxnum.Size = new Size(100, 23);
            text_taxnum.TabIndex = 3;
            text_taxnum.TextChanged += checkInput;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 145);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 4;
            label3.Text = "Vergi Numarası";
            // 
            // text_namesurname
            // 
            text_namesurname.Location = new Point(140, 178);
            text_namesurname.Name = "text_namesurname";
            text_namesurname.Size = new Size(100, 23);
            text_namesurname.TabIndex = 4;
            text_namesurname.TextChanged += checkInput;
            text_namesurname.Leave += checkInput;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 181);
            label4.Name = "label4";
            label4.Size = new Size(99, 15);
            label4.TabIndex = 6;
            label4.Text = "Şirket Adı/Ünvanı";
            // 
            // text_reference
            // 
            text_reference.Location = new Point(140, 214);
            text_reference.Name = "text_reference";
            text_reference.Size = new Size(100, 23);
            text_reference.TabIndex = 5;
            text_reference.TextChanged += checkInput;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 217);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 8;
            label5.Text = "Referans";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 251);
            label6.Name = "label6";
            label6.Size = new Size(99, 15);
            label6.TabIndex = 10;
            label6.Text = "Telefon Numarası";
            // 
            // text_phone
            // 
            text_phone.Location = new Point(140, 248);
            text_phone.Mask = "(999) 000-0000";
            text_phone.Name = "text_phone";
            text_phone.Size = new Size(100, 23);
            text_phone.TabIndex = 6;
            text_phone.TextChanged += checkInput;
            // 
            // text_date
            // 
            text_date.Location = new Point(140, 283);
            text_date.Mask = "00/00/0000";
            text_date.Name = "text_date";
            text_date.Size = new Size(100, 23);
            text_date.TabIndex = 7;
            text_date.ValidatingType = typeof(DateTime);
            text_date.TextChanged += checkInput;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 286);
            label7.Name = "label7";
            label7.Size = new Size(99, 15);
            label7.TabIndex = 12;
            label7.Text = "İşe Başlama Tarihi";
            // 
            // text_email
            // 
            text_email.Location = new Point(140, 312);
            text_email.Name = "text_email";
            text_email.Size = new Size(100, 23);
            text_email.TabIndex = 8;
            text_email.TextChanged += checkInput;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 315);
            label8.Name = "label8";
            label8.Size = new Size(83, 15);
            label8.TabIndex = 14;
            label8.Text = "E-posta Adresi";
            // 
            // text_gerfayda
            // 
            text_gerfayda.Location = new Point(140, 346);
            text_gerfayda.Name = "text_gerfayda";
            text_gerfayda.Size = new Size(100, 23);
            text_gerfayda.TabIndex = 9;
            text_gerfayda.TextChanged += checkInput;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 351);
            label9.Name = "label9";
            label9.Size = new Size(105, 15);
            label9.TabIndex = 16;
            label9.Text = "Gerçek Faydalanıcı";
            // 
            // text_sermaye
            // 
            text_sermaye.Location = new Point(140, 378);
            text_sermaye.Name = "text_sermaye";
            text_sermaye.Size = new Size(100, 23);
            text_sermaye.TabIndex = 10;
            text_sermaye.TextChanged += checkInput;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 381);
            label10.Name = "label10";
            label10.Size = new Size(60, 15);
            label10.TabIndex = 18;
            label10.Text = "Sermayesi";
            // 
            // txt_matrah
            // 
            txt_matrah.Location = new Point(140, 413);
            txt_matrah.Name = "txt_matrah";
            txt_matrah.Size = new Size(100, 23);
            txt_matrah.TabIndex = 11;
            txt_matrah.TextChanged += checkInput;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 416);
            label11.Name = "label11";
            label11.Size = new Size(122, 15);
            label11.TabIndex = 20;
            label11.Text = "Beyah Olunan Matrah";
            // 
            // text_tahakkuk
            // 
            text_tahakkuk.Location = new Point(140, 448);
            text_tahakkuk.Name = "text_tahakkuk";
            text_tahakkuk.Size = new Size(100, 23);
            text_tahakkuk.TabIndex = 12;
            text_tahakkuk.TextChanged += checkInput;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(12, 451);
            label12.Name = "label12";
            label12.Size = new Size(114, 15);
            label12.TabIndex = 22;
            label12.Text = "Tahakkuk Eden Vergi";
            // 
            // text_sirkulertarih
            // 
            text_sirkulertarih.Location = new Point(163, 139);
            text_sirkulertarih.Mask = "00/00/0000";
            text_sirkulertarih.Name = "text_sirkulertarih";
            text_sirkulertarih.Size = new Size(100, 23);
            text_sirkulertarih.TabIndex = 16;
            text_sirkulertarih.ValidatingType = typeof(DateTime);
            text_sirkulertarih.TextChanged += checkInput;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(12, 142);
            label13.Name = "label13";
            label13.Size = new Size(113, 15);
            label13.TabIndex = 24;
            label13.Text = "İmza Sirküleri (Tarih)";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label14.Location = new Point(97, 6);
            label14.Name = "label14";
            label14.Size = new Size(65, 20);
            label14.TabIndex = 26;
            label14.Text = "Belgeler";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(121, 280);
            label15.Name = "label15";
            label15.Size = new Size(32, 15);
            label15.TabIndex = 33;
            label15.Text = "İmza";
            // 
            // picture_signature
            // 
            picture_signature.BackColor = SystemColors.ControlDark;
            picture_signature.BackgroundImageLayout = ImageLayout.Stretch;
            picture_signature.Location = new Point(59, 298);
            picture_signature.Name = "picture_signature";
            picture_signature.Size = new Size(152, 85);
            picture_signature.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_signature.TabIndex = 34;
            picture_signature.TabStop = false;
            picture_signature.Click += picture_signature_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(112, 386);
            label16.Name = "label16";
            label16.Size = new Size(52, 15);
            label16.TabIndex = 35;
            label16.Text = "Fotoğraf";
            // 
            // picture_photo
            // 
            picture_photo.BackgroundImageLayout = ImageLayout.Stretch;
            picture_photo.Image = Properties.Resources.default_photo;
            picture_photo.InitialImage = null;
            picture_photo.Location = new Point(59, 404);
            picture_photo.Name = "picture_photo";
            picture_photo.Size = new Size(152, 148);
            picture_photo.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_photo.TabIndex = 36;
            picture_photo.TabStop = false;
            picture_photo.Click += picture_photo_Click;
            // 
            // text_lastoperation
            // 
            text_lastoperation.Location = new Point(140, 481);
            text_lastoperation.Mask = "00/00/0000";
            text_lastoperation.Name = "text_lastoperation";
            text_lastoperation.Size = new Size(100, 23);
            text_lastoperation.TabIndex = 13;
            text_lastoperation.ValidatingType = typeof(DateTime);
            text_lastoperation.TextChanged += checkInput;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(12, 486);
            label18.Name = "label18";
            label18.Size = new Size(89, 15);
            label18.TabIndex = 39;
            label18.Text = "Son İşlem Tarihi";
            // 
            // text_opreason
            // 
            text_opreason.Location = new Point(139, 537);
            text_opreason.Name = "text_opreason";
            text_opreason.Size = new Size(100, 23);
            text_opreason.TabIndex = 14;
            text_opreason.TextChanged += checkInput;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(11, 540);
            label17.Name = "label17";
            label17.Size = new Size(123, 15);
            label17.TabIndex = 41;
            label17.Text = "Yapılan İşlemin Amacı";
            // 
            // text_lastopcount
            // 
            text_lastopcount.Location = new Point(139, 568);
            text_lastopcount.Name = "text_lastopcount";
            text_lastopcount.Size = new Size(100, 23);
            text_lastopcount.TabIndex = 15;
            text_lastopcount.TextChanged += checkInput;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(11, 571);
            label19.Name = "label19";
            label19.Size = new Size(108, 15);
            label19.TabIndex = 43;
            label19.Text = "Yapılan İşlem Sayısı";
            // 
            // radio_tim
            // 
            radio_tim.AutoSize = true;
            radio_tim.Location = new Point(16, 509);
            radio_tim.Name = "radio_tim";
            radio_tim.Size = new Size(45, 19);
            radio_tim.TabIndex = 45;
            radio_tim.TabStop = true;
            radio_tim.Text = "Tim";
            radio_tim.UseVisualStyleBackColor = true;
            radio_tim.CheckedChanged += checkInput;
            // 
            // radio_imib
            // 
            radio_imib.AutoSize = true;
            radio_imib.Location = new Point(67, 509);
            radio_imib.Name = "radio_imib";
            radio_imib.Size = new Size(49, 19);
            radio_imib.TabIndex = 46;
            radio_imib.TabStop = true;
            radio_imib.Text = "İmib";
            radio_imib.UseVisualStyleBackColor = true;
            radio_imib.CheckedChanged += checkInput;
            // 
            // radio_sanayi
            // 
            radio_sanayi.AutoSize = true;
            radio_sanayi.Location = new Point(122, 509);
            radio_sanayi.Name = "radio_sanayi";
            radio_sanayi.Size = new Size(68, 19);
            radio_sanayi.TabIndex = 47;
            radio_sanayi.TabStop = true;
            radio_sanayi.Text = "Sanayici";
            radio_sanayi.UseVisualStyleBackColor = true;
            radio_sanayi.CheckedChanged += checkInput;
            // 
            // radio_none
            // 
            radio_none.AutoSize = true;
            radio_none.Location = new Point(196, 510);
            radio_none.Name = "radio_none";
            radio_none.Size = new Size(44, 19);
            radio_none.TabIndex = 48;
            radio_none.TabStop = true;
            radio_none.Text = "Yok";
            radio_none.UseVisualStyleBackColor = true;
            radio_none.CheckedChanged += checkInput;
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
            button_save.TabIndex = 49;
            button_save.Text = "Müşteriyi Kaydet";
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click;
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
            button_update.TabIndex = 50;
            button_update.Text = "Müşteri Güncelle";
            button_update.UseVisualStyleBackColor = false;
            button_update.Click += button_update_Click;
            // 
            // button_delete
            // 
            button_delete.BackColor = Color.FromArgb(72, 106, 169);
            button_delete.BackgroundImage = Properties.Resources.gradient_center;
            button_delete.BackgroundImageLayout = ImageLayout.Stretch;
            button_delete.FlatAppearance.BorderSize = 0;
            button_delete.FlatStyle = FlatStyle.Flat;
            button_delete.ForeColor = Color.White;
            button_delete.Location = new Point(305, 723);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(145, 32);
            button_delete.TabIndex = 51;
            button_delete.Text = "Sil";
            button_delete.UseVisualStyleBackColor = false;
            button_delete.Click += button_delete_Click;
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
            button_new.Location = new Point(456, 723);
            button_new.Name = "button_new";
            button_new.Size = new Size(145, 32);
            button_new.TabIndex = 52;
            button_new.Text = "Temizle";
            button_new.UseVisualStyleBackColor = false;
            button_new.Click += button_new_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(label20);
            panel2.Controls.Add(label22);
            panel2.Controls.Add(text_taxoffice);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(comboBox_donem);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(text_custcode);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(text_taxnum);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(text_namesurname);
            panel2.Controls.Add(text_lastopcount);
            panel2.Controls.Add(radio_none);
            panel2.Controls.Add(label19);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(text_opreason);
            panel2.Controls.Add(radio_sanayi);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(text_reference);
            panel2.Controls.Add(radio_imib);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(radio_tim);
            panel2.Controls.Add(text_phone);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(text_date);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(text_email);
            panel2.Controls.Add(text_lastoperation);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(text_gerfayda);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(text_sermaye);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(txt_matrah);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(text_tahakkuk);
            panel2.Location = new Point(0, 1);
            panel2.Name = "panel2";
            panel2.Size = new Size(275, 716);
            panel2.TabIndex = 54;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label20.Location = new Point(90, 6);
            label20.Name = "label20";
            label20.Size = new Size(100, 20);
            label20.TabIndex = 58;
            label20.Text = "Genel Bilgiler";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(12, 114);
            label22.Name = "label22";
            label22.Size = new Size(71, 15);
            label22.TabIndex = 49;
            label22.Text = "Vergi Dairesi";
            // 
            // text_taxoffice
            // 
            text_taxoffice.Location = new Point(140, 111);
            text_taxoffice.Name = "text_taxoffice";
            text_taxoffice.Size = new Size(100, 23);
            text_taxoffice.TabIndex = 2;
            text_taxoffice.TextChanged += checkInput;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(13, 176);
            label23.Name = "label23";
            label23.Size = new Size(114, 15);
            label23.TabIndex = 57;
            label23.Text = "Vergi Levhası  (Tarih)";
            // 
            // text_fax
            // 
            text_fax.Location = new Point(163, 173);
            text_fax.Mask = "0000";
            text_fax.Name = "text_fax";
            text_fax.Size = new Size(100, 23);
            text_fax.TabIndex = 17;
            text_fax.TextChanged += checkInput;
            // 
            // panel3
            // 
            panel3.Controls.Add(check_fayda);
            panel3.Controls.Add(text_ticaretsicil);
            panel3.Controls.Add(label24);
            panel3.Controls.Add(text_faaliyet);
            panel3.Controls.Add(label21);
            panel3.Controls.Add(check_kimlik);
            panel3.Controls.Add(text_fax);
            panel3.Controls.Add(label23);
            panel3.Controls.Add(check_cerceve);
            panel3.Controls.Add(label14);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(picture_signature);
            panel3.Controls.Add(label16);
            panel3.Controls.Add(picture_photo);
            panel3.Controls.Add(text_sirkulertarih);
            panel3.Controls.Add(label13);
            panel3.Location = new Point(570, 1);
            panel3.Name = "panel3";
            panel3.Size = new Size(275, 716);
            panel3.TabIndex = 55;
            // 
            // check_fayda
            // 
            check_fayda.CheckAlign = ContentAlignment.MiddleRight;
            check_fayda.Location = new Point(13, 57);
            check_fayda.Name = "check_fayda";
            check_fayda.RightToLeft = RightToLeft.No;
            check_fayda.Size = new Size(250, 19);
            check_fayda.TabIndex = 62;
            check_fayda.Text = "Gerçek Faydalanıcı Formu";
            check_fayda.UseVisualStyleBackColor = true;
            check_fayda.CheckedChanged += checkInput;
            // 
            // text_ticaretsicil
            // 
            text_ticaretsicil.Location = new Point(163, 243);
            text_ticaretsicil.Mask = "00/00/0000";
            text_ticaretsicil.Name = "text_ticaretsicil";
            text_ticaretsicil.Size = new Size(100, 23);
            text_ticaretsicil.TabIndex = 19;
            text_ticaretsicil.ValidatingType = typeof(DateTime);
            text_ticaretsicil.TextChanged += checkInput;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(12, 246);
            label24.Name = "label24";
            label24.Size = new Size(148, 15);
            label24.TabIndex = 60;
            label24.Text = "Ticaret Sicil Gazetesi (Tarih)";
            // 
            // text_faaliyet
            // 
            text_faaliyet.Location = new Point(163, 209);
            text_faaliyet.Mask = "00/00/0000";
            text_faaliyet.Name = "text_faaliyet";
            text_faaliyet.Size = new Size(100, 23);
            text_faaliyet.TabIndex = 18;
            text_faaliyet.ValidatingType = typeof(DateTime);
            text_faaliyet.TextChanged += checkInput;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(12, 212);
            label21.Name = "label21";
            label21.Size = new Size(123, 15);
            label21.TabIndex = 58;
            label21.Text = "Faaliyet Belgesi (Tarih)";
            // 
            // check_kimlik
            // 
            check_kimlik.CheckAlign = ContentAlignment.MiddleRight;
            check_kimlik.Location = new Point(12, 110);
            check_kimlik.Name = "check_kimlik";
            check_kimlik.RightToLeft = RightToLeft.No;
            check_kimlik.Size = new Size(251, 19);
            check_kimlik.TabIndex = 39;
            check_kimlik.Text = "Kimlik Kartı";
            check_kimlik.UseVisualStyleBackColor = true;
            check_kimlik.CheckedChanged += checkInput;
            // 
            // check_cerceve
            // 
            check_cerceve.CheckAlign = ContentAlignment.MiddleRight;
            check_cerceve.Location = new Point(12, 82);
            check_cerceve.Name = "check_cerceve";
            check_cerceve.RightToLeft = RightToLeft.No;
            check_cerceve.Size = new Size(251, 19);
            check_cerceve.TabIndex = 38;
            check_cerceve.Text = "Çerçeve Sözleşmesi";
            check_cerceve.UseVisualStyleBackColor = true;
            check_cerceve.CheckedChanged += checkInput;
            // 
            // YeniTuzel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(button_new);
            Controls.Add(button_delete);
            Controls.Add(button_update);
            Controls.Add(button_save);
            Name = "YeniTuzel";
            Text = "Yeni Tüzel Kişi";
            Load += YeniTuzel_Load;
            ((System.ComponentModel.ISupportInitialize)picture_signature).EndInit();
            ((System.ComponentModel.ISupportInitialize)picture_photo).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_donem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_custcode;
        private System.Windows.Forms.TextBox text_taxnum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_namesurname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_reference;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox text_phone;
        private System.Windows.Forms.MaskedTextBox text_date;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox text_email;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox text_gerfayda;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox text_sermaye;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_matrah;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox text_tahakkuk;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox text_sirkulertarih;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox picture_signature;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox picture_photo;
        private System.Windows.Forms.MaskedTextBox text_lastoperation;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox text_opreason;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox text_lastopcount;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RadioButton radio_tim;
        private System.Windows.Forms.RadioButton radio_imib;
        private System.Windows.Forms.RadioButton radio_sanayi;
        private System.Windows.Forms.RadioButton radio_none;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_new;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.OpenFileDialog fileDialog_imza;
        private System.Windows.Forms.OpenFileDialog fileDialog_picture;
        private System.Windows.Forms.OpenFileDialog fileDialog_document;
        private Label label22;
        private TextBox text_taxoffice;
        private MaskedTextBox text_fax;
        private Label label23;
        private Label label20;
        private CheckBox check_cerceve;
        private MaskedTextBox text_faaliyet;
        private Label label21;
        private CheckBox check_kimlik;
        private MaskedTextBox text_ticaretsicil;
        private Label label24;
        private CheckBox check_fayda;
    }
}