namespace Evrak_Takibi_Programı.Menü4
{
    partial class MusteriRaporuDisaAktar
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
            button_hepsi = new Button();
            button_ortaklik = new Button();
            button_sahis = new Button();
            button_gercek = new Button();
            button_tuzel = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button_hepsi);
            groupBox1.Controls.Add(button_ortaklik);
            groupBox1.Controls.Add(button_sahis);
            groupBox1.Controls.Add(button_gercek);
            groupBox1.Controls.Add(button_tuzel);
            groupBox1.Location = new Point(12, 106);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(821, 54);
            groupBox1.TabIndex = 118;
            groupBox1.TabStop = false;
            groupBox1.Text = "Müşteri Türleri";
            // 
            // button_hepsi
            // 
            button_hepsi.BackColor = Color.FromArgb(146, 169, 106);
            button_hepsi.BackgroundImage = Properties.Resources.gradient_center;
            button_hepsi.BackgroundImageLayout = ImageLayout.Stretch;
            button_hepsi.FlatAppearance.BorderSize = 0;
            button_hepsi.FlatStyle = FlatStyle.Flat;
            button_hepsi.ForeColor = Color.White;
            button_hepsi.Location = new Point(718, 22);
            button_hepsi.Name = "button_hepsi";
            button_hepsi.Size = new Size(97, 23);
            button_hepsi.TabIndex = 5;
            button_hepsi.Text = "Hepsi";
            button_hepsi.UseVisualStyleBackColor = false;
            button_hepsi.Click += button_hepsi_Click;
            // 
            // button_ortaklik
            // 
            button_ortaklik.BackColor = Color.FromArgb(146, 169, 106);
            button_ortaklik.BackgroundImage = Properties.Resources.gradient_center;
            button_ortaklik.BackgroundImageLayout = ImageLayout.Stretch;
            button_ortaklik.FlatAppearance.BorderSize = 0;
            button_ortaklik.FlatStyle = FlatStyle.Flat;
            button_ortaklik.ForeColor = Color.White;
            button_ortaklik.Location = new Point(539, 22);
            button_ortaklik.Name = "button_ortaklik";
            button_ortaklik.Size = new Size(97, 23);
            button_ortaklik.TabIndex = 4;
            button_ortaklik.Text = "Adi Ortaklık";
            button_ortaklik.UseVisualStyleBackColor = false;
            button_ortaklik.Click += button_ortaklik_Click;
            // 
            // button_sahis
            // 
            button_sahis.BackColor = Color.FromArgb(146, 169, 106);
            button_sahis.BackgroundImage = Properties.Resources.gradient_center;
            button_sahis.BackgroundImageLayout = ImageLayout.Stretch;
            button_sahis.FlatAppearance.BorderSize = 0;
            button_sahis.FlatStyle = FlatStyle.Flat;
            button_sahis.ForeColor = Color.White;
            button_sahis.Location = new Point(362, 22);
            button_sahis.Name = "button_sahis";
            button_sahis.Size = new Size(97, 23);
            button_sahis.TabIndex = 3;
            button_sahis.Text = "Şahıs";
            button_sahis.UseVisualStyleBackColor = false;
            button_sahis.Click += button_sahis_Click;
            // 
            // button_gercek
            // 
            button_gercek.BackColor = Color.FromArgb(146, 169, 106);
            button_gercek.BackgroundImage = Properties.Resources.gradient_center;
            button_gercek.BackgroundImageLayout = ImageLayout.Stretch;
            button_gercek.FlatAppearance.BorderSize = 0;
            button_gercek.FlatStyle = FlatStyle.Flat;
            button_gercek.ForeColor = Color.White;
            button_gercek.Location = new Point(181, 22);
            button_gercek.Name = "button_gercek";
            button_gercek.Size = new Size(97, 23);
            button_gercek.TabIndex = 2;
            button_gercek.Text = "Gerçek Kişi";
            button_gercek.UseVisualStyleBackColor = false;
            button_gercek.Click += button_gercek_Click;
            // 
            // button_tuzel
            // 
            button_tuzel.BackColor = Color.FromArgb(146, 169, 106);
            button_tuzel.BackgroundImage = Properties.Resources.gradient_center;
            button_tuzel.BackgroundImageLayout = ImageLayout.Stretch;
            button_tuzel.FlatAppearance.BorderSize = 0;
            button_tuzel.FlatStyle = FlatStyle.Flat;
            button_tuzel.ForeColor = Color.White;
            button_tuzel.Location = new Point(6, 22);
            button_tuzel.Name = "button_tuzel";
            button_tuzel.Size = new Size(97, 23);
            button_tuzel.TabIndex = 1;
            button_tuzel.Text = "Tüzel Kişi";
            button_tuzel.UseVisualStyleBackColor = false;
            button_tuzel.Click += button_tuzel_Click;
            // 
            // MusteriRaporuDisaAktar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(groupBox1);
            Name = "MusteriRaporuDisaAktar";
            Text = "MusteriRaporuDisaAktar";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Button button_tuzel;
        private Button button_hepsi;
        private Button button_ortaklik;
        private Button button_sahis;
        private Button button_gercek;
    }
}