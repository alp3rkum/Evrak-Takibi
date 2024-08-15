namespace Evrak_Takibi_Programı.Menü4
{
    partial class SatisRaporuDisaAktar
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
            button_satis = new Button();
            button_alis = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button_hepsi);
            groupBox1.Controls.Add(button_satis);
            groupBox1.Controls.Add(button_alis);
            groupBox1.Location = new Point(12, 106);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(821, 54);
            groupBox1.TabIndex = 119;
            groupBox1.TabStop = false;
            groupBox1.Text = "İşlem Türleri";
            // 
            // button_hepsi
            // 
            button_hepsi.BackColor = Color.FromArgb(146, 169, 106);
            button_hepsi.BackgroundImage = Properties.Resources.gradient_center;
            button_hepsi.BackgroundImageLayout = ImageLayout.Stretch;
            button_hepsi.FlatAppearance.BorderSize = 0;
            button_hepsi.FlatStyle = FlatStyle.Flat;
            button_hepsi.ForeColor = Color.White;
            button_hepsi.Location = new Point(212, 22);
            button_hepsi.Name = "button_hepsi";
            button_hepsi.Size = new Size(97, 23);
            button_hepsi.TabIndex = 5;
            button_hepsi.Text = "Hepsi";
            button_hepsi.UseVisualStyleBackColor = false;
            button_hepsi.Click += button_hepsi_Click;
            // 
            // button_satis
            // 
            button_satis.BackColor = Color.FromArgb(146, 169, 106);
            button_satis.BackgroundImage = Properties.Resources.gradient_center;
            button_satis.BackgroundImageLayout = ImageLayout.Stretch;
            button_satis.FlatAppearance.BorderSize = 0;
            button_satis.FlatStyle = FlatStyle.Flat;
            button_satis.ForeColor = Color.White;
            button_satis.Location = new Point(109, 22);
            button_satis.Name = "button_satis";
            button_satis.Size = new Size(97, 23);
            button_satis.TabIndex = 3;
            button_satis.Text = "Satış";
            button_satis.UseVisualStyleBackColor = false;
            button_satis.Click += button_satis_Click;
            // 
            // button_alis
            // 
            button_alis.BackColor = Color.FromArgb(146, 169, 106);
            button_alis.BackgroundImage = Properties.Resources.gradient_center;
            button_alis.BackgroundImageLayout = ImageLayout.Stretch;
            button_alis.FlatAppearance.BorderSize = 0;
            button_alis.FlatStyle = FlatStyle.Flat;
            button_alis.ForeColor = Color.White;
            button_alis.Location = new Point(6, 22);
            button_alis.Name = "button_alis";
            button_alis.Size = new Size(97, 23);
            button_alis.TabIndex = 1;
            button_alis.Text = "Alış";
            button_alis.UseVisualStyleBackColor = false;
            button_alis.Click += button_alis_Click;
            // 
            // SatisRaporuDisaAktar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(groupBox1);
            Name = "SatisRaporuDisaAktar";
            Text = "SatisRaporuDisaAktar";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Button button_hepsi;
        private Button button_satis;
        private Button button_alis;
    }
}