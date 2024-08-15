namespace Evrak_Takibi_Programı.Diğer
{
    partial class LisansAnahtari
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
            text_licensekey = new MaskedTextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 0;
            label1.Text = "Lisans Anahtarı:";
            // 
            // text_licensekey
            // 
            text_licensekey.Location = new Point(110, 12);
            text_licensekey.Mask = "AAAAA-AAAAA-AAAAA-AAAAA";
            text_licensekey.Name = "text_licensekey";
            text_licensekey.Size = new Size(166, 23);
            text_licensekey.TabIndex = 1;
            text_licensekey.TextChanged += text_licensekey_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.BackgroundImage = Properties.Resources.gradient_center;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Enabled = false;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(282, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Doğrula";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // LisansAnahtari
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 47);
            Controls.Add(button1);
            Controls.Add(text_licensekey);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LisansAnahtari";
            Text = "Lisans Anahtarı Gir";
            FormClosing += LisansAnahtari_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private MaskedTextBox text_licensekey;
        private Button button1;
    }
}