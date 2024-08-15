using System;

namespace Evrak_Takibi_Programı
{
    partial class YeniYetkili
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
            components = new System.ComponentModel.Container();
            text_phone = new MaskedTextBox();
            label6 = new Label();
            text_namesurname = new TextBox();
            label10 = new Label();
            text_tcid = new TextBox();
            label4 = new Label();
            text_custcode = new TextBox();
            label2 = new Label();
            label1 = new Label();
            text_birth2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label5 = new Label();
            textBox2 = new TextBox();
            label7 = new Label();
            picture_photo = new PictureBox();
            label16 = new Label();
            picture_signature = new PictureBox();
            label15 = new Label();
            button_scan = new Button();
            button_new = new Button();
            button_delete = new Button();
            button_update = new Button();
            button_save = new Button();
            panel1 = new Panel();
            check_kimlik = new CheckBox();
            combo_country = new ComboBox();
            label27 = new Label();
            text_birthyear = new TextBox();
            panel_bilgi_title = new Panel();
            label29 = new Label();
            panel2 = new Panel();
            label30 = new Label();
            text_spk1 = new TextBox();
            text_un = new TextBox();
            label28 = new Label();
            text_masak1 = new TextBox();
            text_swt = new TextBox();
            text_eu = new TextBox();
            label26 = new Label();
            label24 = new Label();
            text_masak4 = new TextBox();
            label23 = new Label();
            text_masak3 = new TextBox();
            label22 = new Label();
            text_masak2 = new TextBox();
            label8 = new Label();
            label21 = new Label();
            text_terror = new TextBox();
            label20 = new Label();
            label19 = new Label();
            label18 = new Label();
            text_uk = new TextBox();
            label14 = new Label();
            label13 = new Label();
            text_sdn = new TextBox();
            radio_100 = new RadioButton();
            radio_70 = new RadioButton();
            radio_50 = new RadioButton();
            radio_30 = new RadioButton();
            label12 = new Label();
            label11 = new Label();
            label9 = new Label();
            text_tckimlik = new TextBox();
            panel3 = new Panel();
            label25 = new Label();
            fileDialog_imza = new OpenFileDialog();
            fileDialog_picture = new OpenFileDialog();
            fileDialog_document = new OpenFileDialog();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)picture_photo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picture_signature).BeginInit();
            panel1.SuspendLayout();
            panel_bilgi_title.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // text_phone
            // 
            text_phone.Location = new Point(147, 102);
            text_phone.Mask = "(999) 000-0000";
            text_phone.Name = "text_phone";
            text_phone.Size = new Size(100, 23);
            text_phone.TabIndex = 4;
            text_phone.Leave += checkInput;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 105);
            label6.Name = "label6";
            label6.Size = new Size(99, 15);
            label6.TabIndex = 56;
            label6.Text = "Telefon Numarası";
            // 
            // text_namesurname
            // 
            text_namesurname.Location = new Point(147, 70);
            text_namesurname.Name = "text_namesurname";
            text_namesurname.Size = new Size(100, 23);
            text_namesurname.TabIndex = 3;
            text_namesurname.Leave += checkInput;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(11, 74);
            label10.Name = "label10";
            label10.Size = new Size(102, 15);
            label10.TabIndex = 54;
            label10.Text = "Müşteri Ad/Soyad";
            // 
            // text_tcid
            // 
            text_tcid.Location = new Point(147, 41);
            text_tcid.MaxLength = 11;
            text_tcid.Name = "text_tcid";
            text_tcid.Size = new Size(100, 23);
            text_tcid.TabIndex = 2;
            text_tcid.Leave += checkInput;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 44);
            label4.Name = "label4";
            label4.Size = new Size(110, 15);
            label4.TabIndex = 52;
            label4.Text = "TC Kimlik Numarası";
            // 
            // text_custcode
            // 
            text_custcode.Location = new Point(147, 9);
            text_custcode.Name = "text_custcode";
            text_custcode.Size = new Size(100, 23);
            text_custcode.TabIndex = 1;
            text_custcode.Leave += checkInput;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 12);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 50;
            label2.Text = "Müşteri Kodu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 172);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 72;
            label1.Text = "Doğum Yeri (Ülke)";
            label1.Click += label1_Click;
            // 
            // text_birth2
            // 
            text_birth2.Location = new Point(147, 202);
            text_birth2.Name = "text_birth2";
            text_birth2.Size = new Size(100, 23);
            text_birth2.TabIndex = 7;
            text_birth2.Leave += checkInput;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 205);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 74;
            label3.Text = "Doğum Yeri (Şehir)";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(147, 267);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 9;
            textBox1.Leave += checkInput;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 270);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 78;
            label5.Text = "İşi - Görevi";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(147, 234);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 8;
            textBox2.Leave += checkInput;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(11, 237);
            label7.Name = "label7";
            label7.Size = new Size(48, 15);
            label7.TabIndex = 76;
            label7.Text = "Mesleği";
            // 
            // picture_photo
            // 
            picture_photo.BackgroundImageLayout = ImageLayout.Stretch;
            picture_photo.Image = Properties.Resources.default_photo;
            picture_photo.InitialImage = null;
            picture_photo.Location = new Point(57, 471);
            picture_photo.Name = "picture_photo";
            picture_photo.Size = new Size(152, 148);
            picture_photo.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_photo.TabIndex = 85;
            picture_photo.TabStop = false;
            picture_photo.Click += picture_photo_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(105, 453);
            label16.Name = "label16";
            label16.Size = new Size(52, 15);
            label16.TabIndex = 84;
            label16.Text = "Fotoğraf";
            // 
            // picture_signature
            // 
            picture_signature.BackColor = SystemColors.ControlDark;
            picture_signature.BackgroundImageLayout = ImageLayout.Stretch;
            picture_signature.Location = new Point(57, 365);
            picture_signature.Name = "picture_signature";
            picture_signature.Size = new Size(152, 85);
            picture_signature.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_signature.TabIndex = 83;
            picture_signature.TabStop = false;
            picture_signature.Click += picture_signature_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(113, 347);
            label15.Name = "label15";
            label15.Size = new Size(32, 15);
            label15.TabIndex = 82;
            label15.Text = "İmza";
            // 
            // button_scan
            // 
            button_scan.BackColor = Color.FromArgb(72, 106, 169);
            button_scan.BackgroundImage = Properties.Resources.gradient_center;
            button_scan.BackgroundImageLayout = ImageLayout.Stretch;
            button_scan.FlatAppearance.BorderSize = 0;
            button_scan.FlatStyle = FlatStyle.Flat;
            button_scan.ForeColor = Color.White;
            button_scan.Location = new Point(63, 70);
            button_scan.Name = "button_scan";
            button_scan.Size = new Size(152, 23);
            button_scan.TabIndex = 86;
            button_scan.Text = "Güvenlik Taraması Yap";
            button_scan.UseVisualStyleBackColor = false;
            button_scan.Click += button_scan_Click;
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
            button_new.Location = new Point(464, 723);
            button_new.Name = "button_new";
            button_new.Size = new Size(145, 32);
            button_new.TabIndex = 90;
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
            button_delete.Location = new Point(313, 723);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(145, 32);
            button_delete.TabIndex = 89;
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
            button_update.Location = new Point(162, 723);
            button_update.Name = "button_update";
            button_update.Size = new Size(145, 32);
            button_update.TabIndex = 88;
            button_update.Text = "Yetkili Güncelle";
            button_update.UseVisualStyleBackColor = false;
            button_update.Click += button_update_Click;
            // 
            // button_save
            // 
            button_save.BackColor = Color.FromArgb(72, 106, 169);
            button_save.BackgroundImage = Properties.Resources.gradient_center;
            button_save.BackgroundImageLayout = ImageLayout.Stretch;
            button_save.Enabled = false;
            button_save.FlatAppearance.BorderSize = 0;
            button_save.FlatStyle = FlatStyle.Flat;
            button_save.ForeColor = Color.White;
            button_save.Location = new Point(11, 723);
            button_save.Name = "button_save";
            button_save.Size = new Size(145, 32);
            button_save.TabIndex = 87;
            button_save.Text = "Yetkiliyi Kaydet";
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(check_kimlik);
            panel1.Controls.Add(combo_country);
            panel1.Controls.Add(label27);
            panel1.Controls.Add(text_birthyear);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(text_custcode);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(text_tcid);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(text_namesurname);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(picture_photo);
            panel1.Controls.Add(text_phone);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(picture_signature);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(text_birth2);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(0, 92);
            panel1.Name = "panel1";
            panel1.Size = new Size(275, 625);
            panel1.TabIndex = 92;
            // 
            // check_kimlik
            // 
            check_kimlik.CheckAlign = ContentAlignment.MiddleRight;
            check_kimlik.Location = new Point(12, 325);
            check_kimlik.Name = "check_kimlik";
            check_kimlik.RightToLeft = RightToLeft.No;
            check_kimlik.Size = new Size(251, 19);
            check_kimlik.TabIndex = 121;
            check_kimlik.Text = "Kimlik Kartı";
            check_kimlik.UseVisualStyleBackColor = true;
            // 
            // combo_country
            // 
            combo_country.FormattingEnabled = true;
            combo_country.Location = new Point(147, 169);
            combo_country.Name = "combo_country";
            combo_country.Size = new Size(100, 23);
            combo_country.TabIndex = 6;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(12, 139);
            label27.Name = "label27";
            label27.Size = new Size(66, 15);
            label27.TabIndex = 86;
            label27.Text = "Doğum Yılı";
            // 
            // text_birthyear
            // 
            text_birthyear.Location = new Point(148, 136);
            text_birthyear.Name = "text_birthyear";
            text_birthyear.Size = new Size(100, 23);
            text_birthyear.TabIndex = 5;
            text_birthyear.Leave += checkInput;
            // 
            // panel_bilgi_title
            // 
            panel_bilgi_title.BackColor = Color.FromArgb(48, 80, 127);
            panel_bilgi_title.BackgroundImage = Properties.Resources.gradient_center;
            panel_bilgi_title.Controls.Add(label29);
            panel_bilgi_title.Location = new Point(0, 0);
            panel_bilgi_title.Name = "panel_bilgi_title";
            panel_bilgi_title.Size = new Size(275, 92);
            panel_bilgi_title.TabIndex = 91;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.BackColor = Color.Transparent;
            label29.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label29.ForeColor = Color.White;
            label29.Location = new Point(68, 32);
            label29.Name = "label29";
            label29.Size = new Size(132, 25);
            label29.TabIndex = 1;
            label29.Text = "Kişisel Bilgiler";
            // 
            // panel2
            // 
            panel2.Controls.Add(label30);
            panel2.Controls.Add(text_spk1);
            panel2.Controls.Add(text_un);
            panel2.Controls.Add(label28);
            panel2.Controls.Add(text_masak1);
            panel2.Controls.Add(text_swt);
            panel2.Controls.Add(text_eu);
            panel2.Controls.Add(label26);
            panel2.Controls.Add(label24);
            panel2.Controls.Add(text_masak4);
            panel2.Controls.Add(label23);
            panel2.Controls.Add(text_masak3);
            panel2.Controls.Add(label22);
            panel2.Controls.Add(text_masak2);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label21);
            panel2.Controls.Add(text_terror);
            panel2.Controls.Add(label20);
            panel2.Controls.Add(label19);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(text_uk);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(text_sdn);
            panel2.Controls.Add(radio_100);
            panel2.Controls.Add(radio_70);
            panel2.Controls.Add(radio_50);
            panel2.Controls.Add(radio_30);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(text_tckimlik);
            panel2.Controls.Add(button_scan);
            panel2.Location = new Point(569, 92);
            panel2.Name = "panel2";
            panel2.Size = new Size(275, 625);
            panel2.TabIndex = 94;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(8, 512);
            label30.Name = "label30";
            label30.Size = new Size(126, 15);
            label30.TabIndex = 128;
            label30.Text = "SPK İdari Para Cezalılar";
            // 
            // text_spk1
            // 
            text_spk1.Location = new Point(144, 509);
            text_spk1.Name = "text_spk1";
            text_spk1.ReadOnly = true;
            text_spk1.Size = new Size(100, 23);
            text_spk1.TabIndex = 129;
            // 
            // text_un
            // 
            text_un.Location = new Point(145, 309);
            text_un.Name = "text_un";
            text_un.ReadOnly = true;
            text_un.Size = new Size(100, 23);
            text_un.TabIndex = 127;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(9, 312);
            label28.Name = "label28";
            label28.Size = new Size(119, 15);
            label28.TabIndex = 126;
            label28.Text = "B.M. Yaptırımlı Listesi";
            // 
            // text_masak1
            // 
            text_masak1.Location = new Point(145, 344);
            text_masak1.Name = "text_masak1";
            text_masak1.ReadOnly = true;
            text_masak1.Size = new Size(100, 23);
            text_masak1.TabIndex = 125;
            // 
            // text_swt
            // 
            text_swt.Location = new Point(145, 274);
            text_swt.Name = "text_swt";
            text_swt.ReadOnly = true;
            text_swt.Size = new Size(100, 23);
            text_swt.TabIndex = 124;
            // 
            // text_eu
            // 
            text_eu.Location = new Point(145, 204);
            text_eu.Name = "text_eu";
            text_eu.ReadOnly = true;
            text_eu.Size = new Size(100, 23);
            text_eu.TabIndex = 123;
            // 
            // label26
            // 
            label26.Location = new Point(0, 560);
            label26.Name = "label26";
            label26.Size = new Size(275, 35);
            label26.TabIndex = 122;
            label26.Text = "Tarama yapılmadı";
            label26.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(8, 446);
            label24.Name = "label24";
            label24.Size = new Size(129, 15);
            label24.TabIndex = 120;
            label24.Text = "MASAK Yasaklı Listesi 4";
            // 
            // text_masak4
            // 
            text_masak4.Location = new Point(144, 443);
            text_masak4.Name = "text_masak4";
            text_masak4.ReadOnly = true;
            text_masak4.Size = new Size(100, 23);
            text_masak4.TabIndex = 121;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(9, 415);
            label23.Name = "label23";
            label23.Size = new Size(129, 15);
            label23.TabIndex = 118;
            label23.Text = "MASAK Yasaklı Listesi 3";
            // 
            // text_masak3
            // 
            text_masak3.Location = new Point(145, 412);
            text_masak3.Name = "text_masak3";
            text_masak3.ReadOnly = true;
            text_masak3.Size = new Size(100, 23);
            text_masak3.TabIndex = 119;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(9, 383);
            label22.Name = "label22";
            label22.Size = new Size(129, 15);
            label22.TabIndex = 116;
            label22.Text = "MASAK Yasaklı Listesi 2";
            // 
            // text_masak2
            // 
            text_masak2.Location = new Point(145, 380);
            text_masak2.Name = "text_masak2";
            text_masak2.ReadOnly = true;
            text_masak2.Size = new Size(100, 23);
            text_masak2.TabIndex = 117;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label8.Location = new Point(0, 541);
            label8.Name = "label8";
            label8.Size = new Size(275, 20);
            label8.TabIndex = 115;
            label8.Text = "Sonuç";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(8, 480);
            label21.Name = "label21";
            label21.Size = new Size(107, 15);
            label21.TabIndex = 113;
            label21.Text = "Terörden Arananlar";
            // 
            // text_terror
            // 
            text_terror.Location = new Point(144, 477);
            text_terror.Name = "text_terror";
            text_terror.ReadOnly = true;
            text_terror.Size = new Size(100, 23);
            text_terror.TabIndex = 114;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(9, 347);
            label20.Name = "label20";
            label20.Size = new Size(129, 15);
            label20.TabIndex = 111;
            label20.Text = "MASAK Yasaklı Listesi 1";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(9, 277);
            label19.Name = "label19";
            label19.Size = new Size(128, 15);
            label19.TabIndex = 109;
            label19.Text = "İsviçre Yaptırımlı Listesi";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(9, 243);
            label18.Name = "label18";
            label18.Size = new Size(115, 15);
            label18.TabIndex = 107;
            label18.Text = "B.K. Yaptırımlı Listesi";
            // 
            // text_uk
            // 
            text_uk.Location = new Point(145, 240);
            text_uk.Name = "text_uk";
            text_uk.ReadOnly = true;
            text_uk.Size = new Size(100, 23);
            text_uk.TabIndex = 108;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(9, 207);
            label14.Name = "label14";
            label14.Size = new Size(110, 15);
            label14.TabIndex = 105;
            label14.Text = "AB Yaptırımlı Listesi";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(9, 175);
            label13.Name = "label13";
            label13.Size = new Size(132, 15);
            label13.TabIndex = 103;
            label13.Text = "OAFCT Yaptırımlı Listesi";
            // 
            // text_sdn
            // 
            text_sdn.Location = new Point(145, 172);
            text_sdn.Name = "text_sdn";
            text_sdn.ReadOnly = true;
            text_sdn.Size = new Size(100, 23);
            text_sdn.TabIndex = 104;
            // 
            // radio_100
            // 
            radio_100.AutoSize = true;
            radio_100.Location = new Point(198, 40);
            radio_100.Name = "radio_100";
            radio_100.Size = new Size(53, 19);
            radio_100.TabIndex = 102;
            radio_100.TabStop = true;
            radio_100.Text = "%100";
            radio_100.UseVisualStyleBackColor = true;
            // 
            // radio_70
            // 
            radio_70.AutoSize = true;
            radio_70.Location = new Point(136, 40);
            radio_70.Name = "radio_70";
            radio_70.Size = new Size(47, 19);
            radio_70.TabIndex = 101;
            radio_70.TabStop = true;
            radio_70.Text = "%70";
            radio_70.UseVisualStyleBackColor = true;
            // 
            // radio_50
            // 
            radio_50.AutoSize = true;
            radio_50.Location = new Point(72, 40);
            radio_50.Name = "radio_50";
            radio_50.Size = new Size(47, 19);
            radio_50.TabIndex = 100;
            radio_50.TabStop = true;
            radio_50.Text = "%50";
            radio_50.UseVisualStyleBackColor = true;
            // 
            // radio_30
            // 
            radio_30.AutoSize = true;
            radio_30.Location = new Point(9, 40);
            radio_30.Name = "radio_30";
            radio_30.Size = new Size(47, 19);
            radio_30.TabIndex = 99;
            radio_30.TabStop = true;
            radio_30.Text = "%30";
            radio_30.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label12.Location = new Point(66, 8);
            label12.Name = "label12";
            label12.Size = new Size(149, 20);
            label12.TabIndex = 98;
            label12.Text = "Hedef Eşleşme Oranı";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label11.Location = new Point(66, 105);
            label11.Name = "label11";
            label11.Size = new Size(133, 20);
            label11.TabIndex = 97;
            label11.Text = "Güvenlik Kıstasları";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(9, 142);
            label9.Name = "label9";
            label9.Size = new Size(118, 15);
            label9.TabIndex = 95;
            label9.Text = "TC Kimlik Doğrulama";
            label9.MouseHover += label9_MouseHover;
            // 
            // text_tckimlik
            // 
            text_tckimlik.Location = new Point(145, 139);
            text_tckimlik.Name = "text_tckimlik";
            text_tckimlik.ReadOnly = true;
            text_tckimlik.Size = new Size(100, 23);
            text_tckimlik.TabIndex = 96;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(48, 80, 127);
            panel3.BackgroundImage = Properties.Resources.gradient_center;
            panel3.Controls.Add(label25);
            panel3.Location = new Point(569, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(275, 92);
            panel3.TabIndex = 93;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.BackColor = Color.Transparent;
            label25.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label25.ForeColor = Color.White;
            label25.Location = new Point(56, 32);
            label25.Name = "label25";
            label25.Size = new Size(173, 25);
            label25.TabIndex = 1;
            label25.Text = "Güvenlik Taraması";
            // 
            // YeniYetkili
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel_bilgi_title);
            Controls.Add(button_new);
            Controls.Add(button_delete);
            Controls.Add(button_update);
            Controls.Add(button_save);
            Name = "YeniYetkili";
            Text = "Yeni Yetkili Kişi";
            Load += YeniYetkili_Load;
            ((System.ComponentModel.ISupportInitialize)picture_photo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picture_signature).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel_bilgi_title.ResumeLayout(false);
            panel_bilgi_title.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.MaskedTextBox text_phone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox text_namesurname;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox text_tcid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_custcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_birth2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox text_birthyear;
        private System.Windows.Forms.PictureBox picture_photo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox picture_signature;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button_scan;
        private System.Windows.Forms.Button button_new;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_bilgi_title;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox text_tckimlik;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox text_sdn;
        private System.Windows.Forms.RadioButton radio_100;
        private System.Windows.Forms.RadioButton radio_70;
        private System.Windows.Forms.RadioButton radio_50;
        private System.Windows.Forms.RadioButton radio_30;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox text_uk;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox text_terror;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox text_masak2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox text_masak4;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox text_masak3;
        private System.Windows.Forms.TextBox text_eu;
        private System.Windows.Forms.TextBox text_masak1;
        private System.Windows.Forms.TextBox text_swt;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.OpenFileDialog fileDialog_imza;
        private System.Windows.Forms.OpenFileDialog fileDialog_picture;
        private System.Windows.Forms.OpenFileDialog fileDialog_document;
        private System.Windows.Forms.ToolTip toolTip1;
        private TextBox text_un;
        private Label label28;
        private ComboBox combo_country;
        private Label label30;
        private TextBox text_spk1;
        private CheckBox check_kimlik;
    }
}