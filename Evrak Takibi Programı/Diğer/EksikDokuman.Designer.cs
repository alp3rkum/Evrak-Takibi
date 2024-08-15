namespace Evrak_Takibi_Programı.Diğer
{
    partial class EksikDokuman
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
            panel_left_title = new Panel();
            label1 = new Label();
            text_userlist = new TextBox();
            panel_left_title.SuspendLayout();
            SuspendLayout();
            // 
            // panel_left_title
            // 
            panel_left_title.BackColor = SystemColors.ControlDarkDark;
            panel_left_title.BackgroundImage = Properties.Resources.gradient_center;
            panel_left_title.BackgroundImageLayout = ImageLayout.Stretch;
            panel_left_title.Controls.Add(label1);
            panel_left_title.Location = new Point(0, 0);
            panel_left_title.Name = "panel_left_title";
            panel_left_title.Size = new Size(637, 92);
            panel_left_title.TabIndex = 56;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(637, 92);
            label1.TabIndex = 0;
            label1.Text = "Eksik Evraklı Müşteriler";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // text_userlist
            // 
            text_userlist.Location = new Point(12, 145);
            text_userlist.Multiline = true;
            text_userlist.Name = "text_userlist";
            text_userlist.ReadOnly = true;
            text_userlist.ScrollBars = ScrollBars.Vertical;
            text_userlist.Size = new Size(612, 293);
            text_userlist.TabIndex = 57;
            // 
            // EksikDokuman
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 450);
            Controls.Add(text_userlist);
            Controls.Add(panel_left_title);
            Name = "EksikDokuman";
            Load += EksikDokuman_Load;
            panel_left_title.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel_left_title;
        private Label label1;
        private TextBox text_userlist;
    }
}