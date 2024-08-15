namespace Evrak_Takibi_Programı.Menü2
{
    partial class TakiptekiFaturalar
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
            panel2 = new Panel();
            button_takip = new Button();
            button_temizle = new Button();
            button_getir = new Button();
            text_custname = new TextBox();
            label3 = new Label();
            text_faturano = new TextBox();
            label2 = new Label();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            belge_no = new DataGridViewTextBoxColumn();
            miktar_dolar = new DataGridViewTextBoxColumn();
            miktar_tl = new DataGridViewTextBoxColumn();
            miktar = new DataGridViewTextBoxColumn();
            dovizkur = new DataGridViewTextBoxColumn();
            doviz = new DataGridViewTextBoxColumn();
            ans = new DataGridViewTextBoxColumn();
            AdSoyad = new DataGridViewTextBoxColumn();
            musteri_kod = new DataGridViewTextBoxColumn();
            Tarih = new DataGridViewTextBoxColumn();
            EID = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(355, 136);
            label1.Name = "label1";
            label1.Size = new Size(133, 21);
            label1.TabIndex = 4;
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
            panel2.Location = new Point(12, 160);
            panel2.Name = "panel2";
            panel2.Size = new Size(821, 41);
            panel2.TabIndex = 3;
            // 
            // button_takip
            // 
            button_takip.BackColor = Color.FromArgb(169, 106, 72);
            button_takip.BackgroundImage = Properties.Resources.gradient_center;
            button_takip.BackgroundImageLayout = ImageLayout.Stretch;
            button_takip.FlatAppearance.BorderSize = 0;
            button_takip.FlatStyle = FlatStyle.Flat;
            button_takip.ForeColor = Color.White;
            button_takip.Location = new Point(727, 10);
            button_takip.Name = "button_takip";
            button_takip.Size = new Size(75, 23);
            button_takip.TabIndex = 6;
            button_takip.Text = "Dışa Aktar";
            button_takip.UseVisualStyleBackColor = false;
            button_takip.Click += button_takip_Click;
            // 
            // button_temizle
            // 
            button_temizle.BackColor = Color.FromArgb(169, 106, 72);
            button_temizle.BackgroundImage = Properties.Resources.gradient_center;
            button_temizle.BackgroundImageLayout = ImageLayout.Stretch;
            button_temizle.FlatAppearance.BorderSize = 0;
            button_temizle.FlatStyle = FlatStyle.Flat;
            button_temizle.ForeColor = Color.White;
            button_temizle.Location = new Point(646, 10);
            button_temizle.Name = "button_temizle";
            button_temizle.Size = new Size(75, 23);
            button_temizle.TabIndex = 5;
            button_temizle.Text = "Temizle";
            button_temizle.UseVisualStyleBackColor = false;
            button_temizle.Click += button_temizle_Click;
            // 
            // button_getir
            // 
            button_getir.BackColor = Color.FromArgb(169, 106, 72);
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(355, 235);
            label4.Name = "label4";
            label4.Size = new Size(136, 21);
            label4.TabIndex = 118;
            label4.Text = "Arama Sonuçları";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { EID, Tarih, musteri_kod, AdSoyad, ans, doviz, dovizkur, miktar, miktar_tl, miktar_dolar, belge_no });
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(815, 289);
            dataGridView1.TabIndex = 0;
            // 
            // belge_no
            // 
            belge_no.HeaderText = "Belge No";
            belge_no.Name = "belge_no";
            // 
            // miktar_dolar
            // 
            miktar_dolar.HeaderText = "Dolar Miktarı";
            miktar_dolar.Name = "miktar_dolar";
            // 
            // miktar_tl
            // 
            miktar_tl.HeaderText = "TL Miktarı";
            miktar_tl.Name = "miktar_tl";
            // 
            // miktar
            // 
            miktar.HeaderText = "Miktar";
            miktar.Name = "miktar";
            // 
            // dovizkur
            // 
            dovizkur.HeaderText = "Döviz Kuru";
            dovizkur.Name = "dovizkur";
            // 
            // doviz
            // 
            doviz.HeaderText = "Döviz Cinsi";
            doviz.Name = "doviz";
            // 
            // ans
            // 
            ans.HeaderText = "A/S";
            ans.Name = "ans";
            // 
            // AdSoyad
            // 
            AdSoyad.HeaderText = "Müşteri Adı";
            AdSoyad.Name = "AdSoyad";
            // 
            // musteri_kod
            // 
            musteri_kod.HeaderText = "Müşteri Kodu";
            musteri_kod.Name = "musteri_kod";
            // 
            // Tarih
            // 
            Tarih.HeaderText = "Tarih";
            Tarih.Name = "Tarih";
            // 
            // EID
            // 
            EID.HeaderText = "EID";
            EID.Name = "EID";
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGridView1);
            panel3.Location = new Point(12, 273);
            panel3.Name = "panel3";
            panel3.Size = new Size(821, 295);
            panel3.TabIndex = 119;
            // 
            // TakiptekiFaturalar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(panel3);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(panel2);
            Name = "TakiptekiFaturalar";
            Text = "TakiptekiFaturalar";
            Load += TakiptekiFaturalar_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Panel panel2;
        private Button button_takip;
        private Button button_temizle;
        private Button button_getir;
        private TextBox text_custname;
        private Label label3;
        private TextBox text_faturano;
        private Label label2;
        private Label label4;
        private DataGridView dataGridView1;
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
        private Panel panel3;
    }
}