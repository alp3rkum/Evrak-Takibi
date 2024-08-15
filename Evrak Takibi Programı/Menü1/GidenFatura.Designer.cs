namespace Evrak_Takibi_Programı
{
    partial class GidenFatura
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
            button_new = new Button();
            button_delete = new Button();
            button_save = new Button();
            panel3 = new Panel();
            dataGridView1 = new DataGridView();
            EID = new DataGridViewTextBoxColumn();
            Tarih = new DataGridViewTextBoxColumn();
            musteri_kod = new DataGridViewTextBoxColumn();
            AdSoyad = new DataGridViewTextBoxColumn();
            ans = new DataGridViewTextBoxColumn();
            doviz = new DataGridViewTextBoxColumn();
            dovizkur = new DataGridViewTextBoxColumn();
            miktar = new DataGridViewTextBoxColumn();
            miktar_tl = new DataGridViewTextBoxColumn();
            miktar_dolar = new DataGridViewTextBoxColumn();
            belge_no = new DataGridViewTextBoxColumn();
            label4 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            button_takip = new Button();
            button_temizle = new Button();
            button_getir = new Button();
            text_custname = new TextBox();
            label3 = new Label();
            text_faturano = new TextBox();
            label2 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button_new
            // 
            button_new.BackColor = Color.FromArgb(72, 106, 169);
            button_new.BackgroundImage = Properties.Resources.gradient_center;
            button_new.BackgroundImageLayout = ImageLayout.Stretch;
            button_new.FlatAppearance.BorderSize = 0;
            button_new.FlatStyle = FlatStyle.Flat;
            button_new.ForeColor = Color.White;
            button_new.Location = new Point(190, 732);
            button_new.Name = "button_new";
            button_new.Size = new Size(87, 32);
            button_new.TabIndex = 121;
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
            button_delete.Location = new Point(97, 732);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(87, 32);
            button_delete.TabIndex = 120;
            button_delete.Text = "Sil";
            button_delete.UseVisualStyleBackColor = false;
            button_delete.Click += button_delete_Click;
            // 
            // button_save
            // 
            button_save.BackColor = Color.FromArgb(72, 106, 169);
            button_save.BackgroundImage = Properties.Resources.gradient_center;
            button_save.BackgroundImageLayout = ImageLayout.Stretch;
            button_save.FlatAppearance.BorderSize = 0;
            button_save.FlatStyle = FlatStyle.Flat;
            button_save.ForeColor = Color.White;
            button_save.Location = new Point(4, 732);
            button_save.Name = "button_save";
            button_save.Size = new Size(87, 32);
            button_save.TabIndex = 118;
            button_save.Text = "Kaydet";
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGridView1);
            panel3.Location = new Point(12, 272);
            panel3.Name = "panel3";
            panel3.Size = new Size(821, 295);
            panel3.TabIndex = 117;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { EID, Tarih, musteri_kod, AdSoyad, ans, doviz, dovizkur, miktar, miktar_tl, miktar_dolar, belge_no });
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(815, 289);
            dataGridView1.TabIndex = 0;
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            // 
            // EID
            // 
            EID.HeaderText = "EID";
            EID.Name = "EID";
            // 
            // Tarih
            // 
            Tarih.HeaderText = "Tarih";
            Tarih.Name = "Tarih";
            // 
            // musteri_kod
            // 
            musteri_kod.HeaderText = "Müşteri Kodu";
            musteri_kod.Name = "musteri_kod";
            // 
            // AdSoyad
            // 
            AdSoyad.HeaderText = "Müşteri Adı";
            AdSoyad.Name = "AdSoyad";
            // 
            // ans
            // 
            ans.HeaderText = "A/S";
            ans.Name = "ans";
            // 
            // doviz
            // 
            doviz.HeaderText = "Döviz Cinsi";
            doviz.Name = "doviz";
            // 
            // dovizkur
            // 
            dovizkur.HeaderText = "Döviz Kuru";
            dovizkur.Name = "dovizkur";
            // 
            // miktar
            // 
            miktar.HeaderText = "Miktar";
            miktar.Name = "miktar";
            // 
            // miktar_tl
            // 
            miktar_tl.HeaderText = "TL Miktarı";
            miktar_tl.Name = "miktar_tl";
            // 
            // miktar_dolar
            // 
            miktar_dolar.HeaderText = "Dolar Miktarı";
            miktar_dolar.Name = "miktar_dolar";
            // 
            // belge_no
            // 
            belge_no.HeaderText = "Belge No";
            belge_no.Name = "belge_no";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(355, 234);
            label4.Name = "label4";
            label4.Size = new Size(136, 21);
            label4.TabIndex = 116;
            label4.Text = "Arama Sonuçları";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(355, 127);
            label1.Name = "label1";
            label1.Size = new Size(133, 21);
            label1.TabIndex = 115;
            label1.Text = "Arama Kıstasları";
            // 
            // panel2
            // 
            panel2.Controls.Add(button_takip);
            panel2.Controls.Add(button_temizle);
            panel2.Controls.Add(button_getir);
            panel2.Controls.Add(text_custname);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(text_faturano);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(12, 151);
            panel2.Name = "panel2";
            panel2.Size = new Size(821, 41);
            panel2.TabIndex = 114;
            // 
            // button_takip
            // 
            button_takip.BackColor = Color.FromArgb(72, 106, 169);
            button_takip.BackgroundImage = Properties.Resources.gradient_center;
            button_takip.BackgroundImageLayout = ImageLayout.Stretch;
            button_takip.FlatAppearance.BorderSize = 0;
            button_takip.FlatStyle = FlatStyle.Flat;
            button_takip.ForeColor = Color.White;
            button_takip.Location = new Point(727, 10);
            button_takip.Name = "button_takip";
            button_takip.Size = new Size(75, 23);
            button_takip.TabIndex = 7;
            button_takip.Text = "Takibe Al";
            button_takip.UseVisualStyleBackColor = false;
            button_takip.Click += button_takip_Click;
            // 
            // button_temizle
            // 
            button_temizle.BackColor = Color.FromArgb(72, 106, 169);
            button_temizle.BackgroundImage = Properties.Resources.gradient_center;
            button_temizle.BackgroundImageLayout = ImageLayout.Stretch;
            button_temizle.FlatAppearance.BorderSize = 0;
            button_temizle.FlatStyle = FlatStyle.Flat;
            button_temizle.ForeColor = Color.White;
            button_temizle.Location = new Point(646, 10);
            button_temizle.Name = "button_temizle";
            button_temizle.Size = new Size(75, 23);
            button_temizle.TabIndex = 6;
            button_temizle.Text = "Temizle";
            button_temizle.UseVisualStyleBackColor = false;
            button_temizle.Click += button_temizle_Click;
            // 
            // button_getir
            // 
            button_getir.BackColor = Color.FromArgb(72, 106, 169);
            button_getir.BackgroundImage = Properties.Resources.gradient_center;
            button_getir.BackgroundImageLayout = ImageLayout.Stretch;
            button_getir.FlatAppearance.BorderSize = 0;
            button_getir.FlatStyle = FlatStyle.Flat;
            button_getir.ForeColor = Color.White;
            button_getir.Location = new Point(565, 10);
            button_getir.Name = "button_getir";
            button_getir.Size = new Size(75, 23);
            button_getir.TabIndex = 4;
            button_getir.Text = "Getir";
            button_getir.UseVisualStyleBackColor = false;
            button_getir.Click += button_getir_Click;
            // 
            // text_custname
            // 
            text_custname.Location = new Point(406, 9);
            text_custname.Name = "text_custname";
            text_custname.Size = new Size(144, 23);
            text_custname.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label3.Location = new Point(308, 9);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 2;
            label3.Text = "Müşteri Adı:";
            // 
            // text_faturano
            // 
            text_faturano.Location = new Point(144, 10);
            text_faturano.Name = "text_faturano";
            text_faturano.Size = new Size(144, 23);
            text_faturano.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 0;
            label2.Text = "Fatura Numarası:";
            // 
            // GidenFatura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(button_new);
            Controls.Add(button_delete);
            Controls.Add(button_save);
            Controls.Add(panel3);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(panel2);
            Name = "GidenFatura";
            Text = "GidenFatura";
            Load += GidenFatura_Load;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button_new;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_getir;
        private System.Windows.Forms.TextBox text_custname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_faturano;
        private System.Windows.Forms.Label label2;
        private Button button_temizle;
        private DataGridViewTextBoxColumn EID;
        private DataGridViewTextBoxColumn Tarih;
        private DataGridViewTextBoxColumn musteri_kod;
        private DataGridViewTextBoxColumn AdSoyad;
        private DataGridViewTextBoxColumn ans;
        private DataGridViewTextBoxColumn doviz;
        private DataGridViewTextBoxColumn dovizkur;
        private DataGridViewTextBoxColumn miktar;
        private DataGridViewTextBoxColumn miktar_tl;
        private DataGridViewTextBoxColumn miktar_dolar;
        private DataGridViewTextBoxColumn belge_no;
        private Button button_takip;
    }
}