namespace Evrak_Takibi_Programı.Diğer
{
    partial class EksikBelgeliKullaniciListesi
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
            text_userlist = new TextBox();
            panel_left_title = new Panel();
            label20 = new Label();
            panel_left_title.SuspendLayout();
            SuspendLayout();
            // 
            // text_userlist
            // 
            text_userlist.Location = new Point(12, 145);
            text_userlist.Multiline = true;
            text_userlist.Name = "text_userlist";
            text_userlist.ReadOnly = true;
            text_userlist.ScrollBars = ScrollBars.Vertical;
            text_userlist.Size = new Size(612, 293);
            text_userlist.TabIndex = 0;
            // 
            // panel_left_title
            // 
            panel_left_title.BackColor = Color.FromArgb(127, 80, 48);
            panel_left_title.BackgroundImage = Properties.Resources.gradient_center;
            panel_left_title.BackgroundImageLayout = ImageLayout.Stretch;
            panel_left_title.Controls.Add(label20);
            panel_left_title.Location = new Point(0, 0);
            panel_left_title.Name = "panel_left_title";
            panel_left_title.Size = new Size(637, 92);
            panel_left_title.TabIndex = 55;
            // 
            // label20
            // 
            label20.BackColor = Color.Transparent;
            label20.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label20.ForeColor = Color.White;
            label20.Location = new Point(0, 0);
            label20.Name = "label20";
            label20.Size = new Size(637, 92);
            label20.TabIndex = 0;
            label20.Text = "Eksik Evraklı Müşteriler";
            label20.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EksikBelgeliKullaniciListesi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 450);
            Controls.Add(panel_left_title);
            Controls.Add(text_userlist);
            Name = "EksikBelgeliKullaniciListesi";
            Load += EksikBelgeliKullaniciListesi_Load;
            panel_left_title.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox text_userlist;
        private Panel panel_left_title;
        private Label label20;
    }
}