namespace Evrak_Takibi_Programı
{
    partial class DikkatKaydı
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
            button_delete = new Button();
            button_update = new Button();
            button_save = new Button();
            text_reason = new TextBox();
            label7 = new Label();
            text_opdate = new MaskedTextBox();
            label6 = new Label();
            text_recdate = new MaskedTextBox();
            label5 = new Label();
            text_custref = new TextBox();
            label4 = new Label();
            text_custname = new TextBox();
            label3 = new Label();
            text_custno = new TextBox();
            label2 = new Label();
            label8 = new Label();
            panel3 = new Panel();
            dataGrid_takip = new DataGridView();
            tarih = new DataGridViewTextBoxColumn();
            dikkat = new DataGridViewTextBoxColumn();
            musteri_adi = new DataGridViewTextBoxColumn();
            kayit_tarih = new DataGridViewTextBoxColumn();
            islem_tarih = new DataGridViewTextBoxColumn();
            panel4 = new Panel();
            dataGrid_tamam = new DataGridView();
            tamam_tarih = new DataGridViewTextBoxColumn();
            tamam_dikkat = new DataGridViewTextBoxColumn();
            tamam_musteri = new DataGridViewTextBoxColumn();
            tamam_islem = new DataGridViewTextBoxColumn();
            tamam_sonuc = new DataGridViewTextBoxColumn();
            label9 = new Label();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid_takip).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid_tamam).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(367, 120);
            label1.Name = "label1";
            label1.Size = new Size(123, 21);
            label1.TabIndex = 115;
            label1.Text = "Gerekli Bilgiler";
            // 
            // panel2
            // 
            panel2.Controls.Add(button_delete);
            panel2.Controls.Add(button_update);
            panel2.Controls.Add(button_save);
            panel2.Controls.Add(text_reason);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(text_opdate);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(text_recdate);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(text_custref);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(text_custname);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(text_custno);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(12, 151);
            panel2.Name = "panel2";
            panel2.Size = new Size(821, 109);
            panel2.TabIndex = 116;
            // 
            // button_delete
            // 
            button_delete.BackColor = Color.FromArgb(72, 106, 169);
            button_delete.BackgroundImage = Properties.Resources.gradient_center;
            button_delete.BackgroundImageLayout = ImageLayout.Stretch;
            button_delete.FlatAppearance.BorderSize = 0;
            button_delete.FlatStyle = FlatStyle.Flat;
            button_delete.ForeColor = Color.White;
            button_delete.Location = new Point(731, 11);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(87, 32);
            button_delete.TabIndex = 123;
            button_delete.Text = "Sil";
            button_delete.UseVisualStyleBackColor = false;
            // 
            // button_update
            // 
            button_update.BackColor = Color.FromArgb(72, 106, 169);
            button_update.BackgroundImage = Properties.Resources.gradient_center;
            button_update.BackgroundImageLayout = ImageLayout.Stretch;
            button_update.FlatAppearance.BorderSize = 0;
            button_update.FlatStyle = FlatStyle.Flat;
            button_update.ForeColor = Color.White;
            button_update.Location = new Point(638, 11);
            button_update.Name = "button_update";
            button_update.Size = new Size(87, 32);
            button_update.TabIndex = 122;
            button_update.Text = "Güncelle";
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
            button_save.Location = new Point(545, 11);
            button_save.Name = "button_save";
            button_save.Size = new Size(87, 32);
            button_save.TabIndex = 121;
            button_save.Text = "Kaydet";
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click;
            // 
            // text_reason
            // 
            text_reason.Location = new Point(397, 72);
            text_reason.Name = "text_reason";
            text_reason.Size = new Size(421, 23);
            text_reason.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(322, 75);
            label7.Name = "label7";
            label7.Size = new Size(75, 15);
            label7.TabIndex = 10;
            label7.Text = "İşlem Amacı:";
            // 
            // text_opdate
            // 
            text_opdate.Location = new Point(395, 39);
            text_opdate.Mask = "00/00/0000";
            text_opdate.Name = "text_opdate";
            text_opdate.Size = new Size(100, 23);
            text_opdate.TabIndex = 9;
            text_opdate.ValidatingType = typeof(DateTime);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(322, 42);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 8;
            label6.Text = "İşlem Tarihi:";
            // 
            // text_recdate
            // 
            text_recdate.Location = new Point(395, 8);
            text_recdate.Mask = "00/00/0000";
            text_recdate.Name = "text_recdate";
            text_recdate.Size = new Size(100, 23);
            text_recdate.TabIndex = 7;
            text_recdate.ValidatingType = typeof(DateTime);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(322, 11);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 6;
            label5.Text = "Kayıt Tarihi:";
            // 
            // text_custref
            // 
            text_custref.Location = new Point(78, 72);
            text_custref.Name = "text_custref";
            text_custref.Size = new Size(100, 23);
            text_custref.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 75);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 4;
            label4.Text = "Referans:";
            // 
            // text_custname
            // 
            text_custname.Location = new Point(78, 39);
            text_custname.Name = "text_custname";
            text_custname.Size = new Size(238, 23);
            text_custname.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 42);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 2;
            label3.Text = "Müşteri Adı:";
            // 
            // text_custno
            // 
            text_custno.Location = new Point(78, 8);
            text_custno.Name = "text_custno";
            text_custno.Size = new Size(100, 23);
            text_custno.TabIndex = 1;
            text_custno.TextChanged += text_custno_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 11);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 0;
            label2.Text = "Müşteri No:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.Location = new Point(358, 278);
            label8.Name = "label8";
            label8.Size = new Size(149, 21);
            label8.TabIndex = 117;
            label8.Text = "Takipteki Görevler";
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGrid_takip);
            panel3.Location = new Point(15, 310);
            panel3.Name = "panel3";
            panel3.Size = new Size(818, 178);
            panel3.TabIndex = 118;
            // 
            // dataGrid_takip
            // 
            dataGrid_takip.AllowUserToAddRows = false;
            dataGrid_takip.AllowUserToDeleteRows = false;
            dataGrid_takip.AllowUserToResizeColumns = false;
            dataGrid_takip.AllowUserToResizeRows = false;
            dataGrid_takip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_takip.Columns.AddRange(new DataGridViewColumn[] { tarih, dikkat, musteri_adi, kayit_tarih, islem_tarih });
            dataGrid_takip.Location = new Point(3, 4);
            dataGrid_takip.MultiSelect = false;
            dataGrid_takip.Name = "dataGrid_takip";
            dataGrid_takip.Size = new Size(812, 172);
            dataGrid_takip.TabIndex = 0;
            dataGrid_takip.CellClick += dataGrid_takip_CellClick;
            dataGrid_takip.CellContentClick += dataGrid_takip_CellContentClick;
            // 
            // tarih
            // 
            tarih.HeaderText = "Tarih";
            tarih.Name = "tarih";
            // 
            // dikkat
            // 
            dikkat.FillWeight = 250F;
            dikkat.HeaderText = "Dikkat";
            dikkat.Name = "dikkat";
            dikkat.Width = 250;
            // 
            // musteri_adi
            // 
            musteri_adi.FillWeight = 200F;
            musteri_adi.HeaderText = "Müşteri Adı";
            musteri_adi.Name = "musteri_adi";
            musteri_adi.Width = 200;
            // 
            // kayit_tarih
            // 
            kayit_tarih.HeaderText = "Kayıt Tarihi";
            kayit_tarih.Name = "kayit_tarih";
            // 
            // islem_tarih
            // 
            islem_tarih.HeaderText = "İşlem Tarihi";
            islem_tarih.Name = "islem_tarih";
            // 
            // panel4
            // 
            panel4.Controls.Add(dataGrid_tamam);
            panel4.Location = new Point(15, 534);
            panel4.Name = "panel4";
            panel4.Size = new Size(818, 178);
            panel4.TabIndex = 120;
            // 
            // dataGrid_tamam
            // 
            dataGrid_tamam.AllowUserToAddRows = false;
            dataGrid_tamam.AllowUserToDeleteRows = false;
            dataGrid_tamam.AllowUserToResizeColumns = false;
            dataGrid_tamam.AllowUserToResizeRows = false;
            dataGrid_tamam.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_tamam.Columns.AddRange(new DataGridViewColumn[] { tamam_tarih, tamam_dikkat, tamam_musteri, tamam_islem, tamam_sonuc });
            dataGrid_tamam.Location = new Point(3, 4);
            dataGrid_tamam.MultiSelect = false;
            dataGrid_tamam.Name = "dataGrid_tamam";
            dataGrid_tamam.Size = new Size(812, 172);
            dataGrid_tamam.TabIndex = 0;
            // 
            // tamam_tarih
            // 
            tamam_tarih.HeaderText = "Tarih";
            tamam_tarih.Name = "tamam_tarih";
            // 
            // tamam_dikkat
            // 
            tamam_dikkat.FillWeight = 250F;
            tamam_dikkat.HeaderText = "Dikkat";
            tamam_dikkat.Name = "tamam_dikkat";
            tamam_dikkat.Width = 250;
            // 
            // tamam_musteri
            // 
            tamam_musteri.FillWeight = 200F;
            tamam_musteri.HeaderText = "Müşteri Adi";
            tamam_musteri.Name = "tamam_musteri";
            tamam_musteri.Width = 200;
            // 
            // tamam_islem
            // 
            tamam_islem.HeaderText = "İşlem Tarihi";
            tamam_islem.Name = "tamam_islem";
            // 
            // tamam_sonuc
            // 
            tamam_sonuc.HeaderText = "Sonuç Tarihi";
            tamam_sonuc.Name = "tamam_sonuc";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label9.Location = new Point(343, 502);
            label9.Name = "label9";
            label9.Size = new Size(178, 21);
            label9.TabIndex = 119;
            label9.Text = "Tamamlanan Görevler";
            // 
            // DikkatKaydı
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(panel4);
            Controls.Add(label9);
            Controls.Add(panel3);
            Controls.Add(label8);
            Controls.Add(panel2);
            Controls.Add(label1);
            Name = "DikkatKaydı";
            Text = "DikkatKaydı";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGrid_takip).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGrid_tamam).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox text_custno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_custref;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_custname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox text_recdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_reason;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox text_opdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGrid_takip;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGrid_tamam;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn dikkat;
        private System.Windows.Forms.DataGridViewTextBoxColumn musteri_adi;
        private System.Windows.Forms.DataGridViewTextBoxColumn kayit_tarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn islem_tarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn tamam_tarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn tamam_dikkat;
        private System.Windows.Forms.DataGridViewTextBoxColumn tamam_musteri;
        private System.Windows.Forms.DataGridViewTextBoxColumn tamam_islem;
        private System.Windows.Forms.DataGridViewTextBoxColumn tamam_sonuc;
        private Button button_save;
        private Button button_update;
        private Button button_delete;
    }
}