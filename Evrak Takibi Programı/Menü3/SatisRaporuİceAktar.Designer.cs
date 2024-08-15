namespace Evrak_Takibi_Programı
{
    partial class SatisRaporuİceAktar
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
            groupBox1 = new GroupBox();
            button2 = new Button();
            text_toplamsatis = new TextBox();
            label4 = new Label();
            text_musterisayi = new TextBox();
            label3 = new Label();
            text_alisSatis = new TextBox();
            label2 = new Label();
            text_filepath = new TextBox();
            label1 = new Label();
            button1 = new Button();
            satisRaporuDialog = new OpenFileDialog();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(text_toplamsatis);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(text_musterisayi);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(text_alisSatis);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(text_filepath);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(12, 106);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(821, 100);
            groupBox1.TabIndex = 116;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dosya Özellikleri";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(106, 169, 72);
            button2.BackgroundImage = Properties.Resources.gradient_center;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Enabled = false;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(740, 58);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "Kaydet";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // text_toplamsatis
            // 
            text_toplamsatis.Location = new Point(451, 58);
            text_toplamsatis.Name = "text_toplamsatis";
            text_toplamsatis.ReadOnly = true;
            text_toplamsatis.Size = new Size(85, 23);
            text_toplamsatis.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(292, 61);
            label4.Name = "label4";
            label4.Size = new Size(153, 15);
            label4.TabIndex = 7;
            label4.Text = "Toplam Satış (TL cinsinden):";
            // 
            // text_musterisayi
            // 
            text_musterisayi.Location = new Point(245, 58);
            text_musterisayi.Name = "text_musterisayi";
            text_musterisayi.ReadOnly = true;
            text_musterisayi.Size = new Size(41, 23);
            text_musterisayi.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(157, 61);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 5;
            label3.Text = "Müşteri Sayısı:";
            // 
            // text_alisSatis
            // 
            text_alisSatis.Location = new Point(102, 58);
            text_alisSatis.Name = "text_alisSatis";
            text_alisSatis.ReadOnly = true;
            text_alisSatis.Size = new Size(41, 23);
            text_alisSatis.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 61);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 3;
            label2.Text = "Alış/Satış Sayısı:";
            // 
            // text_filepath
            // 
            text_filepath.Enabled = false;
            text_filepath.Location = new Point(174, 22);
            text_filepath.Name = "text_filepath";
            text_filepath.ReadOnly = true;
            text_filepath.Size = new Size(641, 23);
            text_filepath.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 26);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 1;
            label1.Text = "Dosya Yolu:";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(106, 169, 72);
            button1.BackgroundImage = Properties.Resources.gradient_center;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(6, 22);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Dosya Al";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // SatisRaporuİceAktar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(groupBox1);
            Name = "SatisRaporuİceAktar";
            Text = "SatisRaporuİceAktar";
            Load += SatisRaporuİceAktar_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Button button1;
        private TextBox text_filepath;
        private Label label1;
        private OpenFileDialog satisRaporuDialog;
        private TextBox text_alisSatis;
        private Label label2;
        private TextBox text_musterisayi;
        private Label label3;
        private TextBox text_toplamsatis;
        private Label label4;
        private Button button2;
    }
}