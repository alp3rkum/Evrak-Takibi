namespace Evrak_Takibi_Programı.Menü3
{
    partial class MusteriBelgeİceriAktar
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
            text_custname = new TextBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            check_fayda2 = new CheckBox();
            check_fayda1 = new CheckBox();
            text_faaliyet2 = new MaskedTextBox();
            label5 = new Label();
            text_vergilevha2 = new MaskedTextBox();
            label4 = new Label();
            text_sirkulertarih2 = new MaskedTextBox();
            label2 = new Label();
            check_tahakkuk = new CheckBox();
            check_ortaklik = new CheckBox();
            check_imza = new CheckBox();
            check_ikametgah = new CheckBox();
            check_kimlik2 = new CheckBox();
            text_ticaretsicil = new MaskedTextBox();
            label24 = new Label();
            text_faaliyet1 = new MaskedTextBox();
            label21 = new Label();
            text_vergilevha1 = new MaskedTextBox();
            label23 = new Label();
            text_sirkulertarih1 = new MaskedTextBox();
            label1 = new Label();
            check_kimlik1 = new CheckBox();
            check_cerceve2 = new CheckBox();
            check_cerceve1 = new CheckBox();
            button12 = new Button();
            button11 = new Button();
            dataGridView1 = new DataGridView();
            filedialog_import = new OpenFileDialog();
            button_save = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // text_custname
            // 
            text_custname.Location = new Point(110, 233);
            text_custname.Name = "text_custname";
            text_custname.Size = new Size(285, 23);
            text_custname.TabIndex = 122;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label3.Location = new Point(12, 233);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 121;
            label3.Text = "Müşteri Adı:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(check_fayda2);
            groupBox1.Controls.Add(check_fayda1);
            groupBox1.Controls.Add(text_faaliyet2);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(text_vergilevha2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(text_sirkulertarih2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(check_tahakkuk);
            groupBox1.Controls.Add(check_ortaklik);
            groupBox1.Controls.Add(check_imza);
            groupBox1.Controls.Add(check_ikametgah);
            groupBox1.Controls.Add(check_kimlik2);
            groupBox1.Controls.Add(text_ticaretsicil);
            groupBox1.Controls.Add(label24);
            groupBox1.Controls.Add(text_faaliyet1);
            groupBox1.Controls.Add(label21);
            groupBox1.Controls.Add(text_vergilevha1);
            groupBox1.Controls.Add(label23);
            groupBox1.Controls.Add(text_sirkulertarih1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(check_kimlik1);
            groupBox1.Controls.Add(check_cerceve2);
            groupBox1.Controls.Add(check_cerceve1);
            groupBox1.Controls.Add(button12);
            groupBox1.Controls.Add(button11);
            groupBox1.Location = new Point(12, 52);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(821, 169);
            groupBox1.TabIndex = 123;
            groupBox1.TabStop = false;
            groupBox1.Text = "Belge Bilgileri";
            // 
            // check_fayda2
            // 
            check_fayda2.AutoSize = true;
            check_fayda2.Enabled = false;
            check_fayda2.Location = new Point(383, 139);
            check_fayda2.Name = "check_fayda2";
            check_fayda2.Size = new Size(171, 19);
            check_fayda2.TabIndex = 76;
            check_fayda2.Text = "Gerçek Faydalanıcı Formu 2";
            check_fayda2.UseVisualStyleBackColor = true;
            // 
            // check_fayda1
            // 
            check_fayda1.AutoSize = true;
            check_fayda1.Enabled = false;
            check_fayda1.Location = new Point(383, 113);
            check_fayda1.Name = "check_fayda1";
            check_fayda1.Size = new Size(171, 19);
            check_fayda1.TabIndex = 75;
            check_fayda1.Text = "Gerçek Faydalanıcı Formu 1";
            check_fayda1.UseVisualStyleBackColor = true;
            // 
            // text_faaliyet2
            // 
            text_faaliyet2.Enabled = false;
            text_faaliyet2.Location = new Point(479, 52);
            text_faaliyet2.Mask = "00/00/0000";
            text_faaliyet2.Name = "text_faaliyet2";
            text_faaliyet2.Size = new Size(100, 23);
            text_faaliyet2.TabIndex = 74;
            text_faaliyet2.ValidatingType = typeof(DateTime);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(383, 56);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 73;
            label5.Text = "Faaliyet Belgesi 2";
            // 
            // text_vergilevha2
            // 
            text_vergilevha2.Enabled = false;
            text_vergilevha2.Location = new Point(273, 109);
            text_vergilevha2.Mask = "0000";
            text_vergilevha2.Name = "text_vergilevha2";
            text_vergilevha2.Size = new Size(100, 23);
            text_vergilevha2.TabIndex = 71;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(177, 113);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 72;
            label4.Text = "Vergi Levhası 2";
            // 
            // text_sirkulertarih2
            // 
            text_sirkulertarih2.Enabled = false;
            text_sirkulertarih2.Location = new Point(273, 50);
            text_sirkulertarih2.Mask = "00/00/0000";
            text_sirkulertarih2.Name = "text_sirkulertarih2";
            text_sirkulertarih2.Size = new Size(100, 23);
            text_sirkulertarih2.TabIndex = 70;
            text_sirkulertarih2.ValidatingType = typeof(DateTime);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(177, 55);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 69;
            label2.Text = "İmza Sirküleri 2";
            // 
            // check_tahakkuk
            // 
            check_tahakkuk.AutoSize = true;
            check_tahakkuk.Enabled = false;
            check_tahakkuk.Location = new Point(667, 44);
            check_tahakkuk.Name = "check_tahakkuk";
            check_tahakkuk.Size = new Size(95, 19);
            check_tahakkuk.TabIndex = 68;
            check_tahakkuk.Text = "Tahakkuk Fişi";
            check_tahakkuk.UseVisualStyleBackColor = true;
            // 
            // check_ortaklik
            // 
            check_ortaklik.AutoSize = true;
            check_ortaklik.Enabled = false;
            check_ortaklik.Location = new Point(667, 19);
            check_ortaklik.Name = "check_ortaklik";
            check_ortaklik.Size = new Size(148, 19);
            check_ortaklik.TabIndex = 67;
            check_ortaklik.Text = "Adi Ortaklık Sözleşmesi";
            check_ortaklik.UseVisualStyleBackColor = true;
            // 
            // check_imza
            // 
            check_imza.AutoSize = true;
            check_imza.Enabled = false;
            check_imza.Location = new Point(177, 140);
            check_imza.Name = "check_imza";
            check_imza.Size = new Size(77, 19);
            check_imza.TabIndex = 66;
            check_imza.Text = "Islak İmza";
            check_imza.UseVisualStyleBackColor = true;
            // 
            // check_ikametgah
            // 
            check_ikametgah.AutoSize = true;
            check_ikametgah.Enabled = false;
            check_ikametgah.Location = new Point(9, 140);
            check_ikametgah.Name = "check_ikametgah";
            check_ikametgah.Size = new Size(82, 19);
            check_ikametgah.TabIndex = 65;
            check_ikametgah.Text = "İkametgah";
            check_ikametgah.UseVisualStyleBackColor = true;
            // 
            // check_kimlik2
            // 
            check_kimlik2.AutoSize = true;
            check_kimlik2.Enabled = false;
            check_kimlik2.Location = new Point(9, 109);
            check_kimlik2.Name = "check_kimlik2";
            check_kimlik2.Size = new Size(95, 19);
            check_kimlik2.TabIndex = 64;
            check_kimlik2.Text = "Kimlik Kartı 2";
            check_kimlik2.UseVisualStyleBackColor = true;
            // 
            // text_ticaretsicil
            // 
            text_ticaretsicil.Enabled = false;
            text_ticaretsicil.Location = new Point(479, 82);
            text_ticaretsicil.Mask = "00/00/0000";
            text_ticaretsicil.Name = "text_ticaretsicil";
            text_ticaretsicil.Size = new Size(100, 23);
            text_ticaretsicil.TabIndex = 63;
            text_ticaretsicil.ValidatingType = typeof(DateTime);
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(383, 87);
            label24.Name = "label24";
            label24.Size = new Size(66, 15);
            label24.TabIndex = 62;
            label24.Text = "Ticaret Sicil";
            // 
            // text_faaliyet1
            // 
            text_faaliyet1.Enabled = false;
            text_faaliyet1.Location = new Point(479, 18);
            text_faaliyet1.Mask = "00/00/0000";
            text_faaliyet1.Name = "text_faaliyet1";
            text_faaliyet1.Size = new Size(100, 23);
            text_faaliyet1.TabIndex = 61;
            text_faaliyet1.ValidatingType = typeof(DateTime);
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(383, 22);
            label21.Name = "label21";
            label21.Size = new Size(96, 15);
            label21.TabIndex = 60;
            label21.Text = "Faaliyet Belgesi 1";
            // 
            // text_vergilevha1
            // 
            text_vergilevha1.Enabled = false;
            text_vergilevha1.Location = new Point(273, 81);
            text_vergilevha1.Mask = "0000";
            text_vergilevha1.Name = "text_vergilevha1";
            text_vergilevha1.Size = new Size(100, 23);
            text_vergilevha1.TabIndex = 58;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(177, 85);
            label23.Name = "label23";
            label23.Size = new Size(84, 15);
            label23.TabIndex = 59;
            label23.Text = "Vergi Levhası 1";
            // 
            // text_sirkulertarih1
            // 
            text_sirkulertarih1.Enabled = false;
            text_sirkulertarih1.Location = new Point(273, 18);
            text_sirkulertarih1.Mask = "00/00/0000";
            text_sirkulertarih1.Name = "text_sirkulertarih1";
            text_sirkulertarih1.Size = new Size(100, 23);
            text_sirkulertarih1.TabIndex = 26;
            text_sirkulertarih1.ValidatingType = typeof(DateTime);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(177, 23);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 16;
            label1.Text = "İmza Sirküleri 1";
            // 
            // check_kimlik1
            // 
            check_kimlik1.AutoSize = true;
            check_kimlik1.Enabled = false;
            check_kimlik1.Location = new Point(9, 78);
            check_kimlik1.Name = "check_kimlik1";
            check_kimlik1.Size = new Size(95, 19);
            check_kimlik1.TabIndex = 15;
            check_kimlik1.Text = "Kimlik Kartı 1";
            check_kimlik1.UseVisualStyleBackColor = true;
            // 
            // check_cerceve2
            // 
            check_cerceve2.AutoSize = true;
            check_cerceve2.Enabled = false;
            check_cerceve2.Location = new Point(9, 51);
            check_cerceve2.Name = "check_cerceve2";
            check_cerceve2.Size = new Size(137, 19);
            check_cerceve2.TabIndex = 14;
            check_cerceve2.Text = "Çerçeve Sözleşmesi 2";
            check_cerceve2.UseVisualStyleBackColor = true;
            // 
            // check_cerceve1
            // 
            check_cerceve1.AutoSize = true;
            check_cerceve1.Enabled = false;
            check_cerceve1.Location = new Point(9, 22);
            check_cerceve1.Name = "check_cerceve1";
            check_cerceve1.Size = new Size(137, 19);
            check_cerceve1.TabIndex = 13;
            check_cerceve1.Text = "Çerçeve Sözleşmesi 1";
            check_cerceve1.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            button12.BackColor = Color.FromArgb(106, 169, 72);
            button12.BackgroundImage = Properties.Resources.gradient_center;
            button12.BackgroundImageLayout = ImageLayout.Stretch;
            button12.Enabled = false;
            button12.FlatAppearance.BorderSize = 0;
            button12.FlatStyle = FlatStyle.Flat;
            button12.ForeColor = Color.White;
            button12.Location = new Point(672, 113);
            button12.Name = "button12";
            button12.Size = new Size(143, 23);
            button12.TabIndex = 12;
            button12.Text = "Fotoğraf";
            button12.UseVisualStyleBackColor = false;
            button12.Click += button12_Click;
            // 
            // button11
            // 
            button11.BackColor = Color.FromArgb(106, 169, 72);
            button11.BackgroundImage = Properties.Resources.gradient_center;
            button11.BackgroundImageLayout = ImageLayout.Stretch;
            button11.Enabled = false;
            button11.FlatAppearance.BorderSize = 0;
            button11.FlatStyle = FlatStyle.Flat;
            button11.ForeColor = Color.White;
            button11.Location = new Point(672, 80);
            button11.Name = "button11";
            button11.Size = new Size(143, 23);
            button11.TabIndex = 11;
            button11.Text = "İmza";
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 265);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(845, 502);
            dataGridView1.TabIndex = 124;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button_save
            // 
            button_save.BackColor = Color.FromArgb(106, 169, 72);
            button_save.BackgroundImage = Properties.Resources.gradient_center;
            button_save.BackgroundImageLayout = ImageLayout.Stretch;
            button_save.Enabled = false;
            button_save.FlatAppearance.BorderSize = 0;
            button_save.FlatStyle = FlatStyle.Flat;
            button_save.ForeColor = Color.White;
            button_save.Location = new Point(746, 227);
            button_save.Name = "button_save";
            button_save.Size = new Size(87, 32);
            button_save.TabIndex = 125;
            button_save.Text = "Kaydet";
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click;
            // 
            // MusteriBelgeİceriAktar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(button_save);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Controls.Add(text_custname);
            Controls.Add(label3);
            Name = "MusteriBelgeİceriAktar";
            Text = "MusteriBelgeİceriAktar";
            Load += MusteriBelgeİceriAktar_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox text_custname;
        private Label label3;
        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private Button button12;
        private OpenFileDialog filedialog_import;
        private Button button11;
        private Button button_save;
        private Label label1;
        private CheckBox check_kimlik1;
        private CheckBox check_cerceve2;
        private CheckBox check_cerceve1;
        private MaskedTextBox text_sirkulertarih1;
        private MaskedTextBox text_vergilevha1;
        private Label label23;
        private MaskedTextBox text_faaliyet1;
        private Label label21;
        private MaskedTextBox text_ticaretsicil;
        private Label label24;
        private CheckBox check_kimlik2;
        private CheckBox check_ikametgah;
        private CheckBox check_imza;
        private CheckBox check_tahakkuk;
        private CheckBox check_ortaklik;
        private MaskedTextBox text_vergilevha2;
        private Label label4;
        private MaskedTextBox text_sirkulertarih2;
        private Label label2;
        private MaskedTextBox text_faaliyet2;
        private Label label5;
        private CheckBox check_fayda2;
        private CheckBox check_fayda1;
    }
}