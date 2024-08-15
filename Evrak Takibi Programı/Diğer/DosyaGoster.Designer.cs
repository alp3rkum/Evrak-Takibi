namespace Evrak_Takibi_Programı.Diğer
{
    partial class DosyaGoster
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
            button_save = new Button();
            button_print = new Button();
            browser_file = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)browser_file).BeginInit();
            SuspendLayout();
            // 
            // button_save
            // 
            button_save.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_save.BackColor = Color.FromArgb(169, 106, 72);
            button_save.BackgroundImage = Properties.Resources.gradient_center;
            button_save.BackgroundImageLayout = ImageLayout.Stretch;
            button_save.FlatAppearance.BorderSize = 0;
            button_save.FlatStyle = FlatStyle.Flat;
            button_save.ForeColor = Color.White;
            button_save.Location = new Point(12, 416);
            button_save.Name = "button_save";
            button_save.Size = new Size(87, 32);
            button_save.TabIndex = 50;
            button_save.Text = "Kaydet";
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click;
            // 
            // button_print
            // 
            button_print.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_print.BackColor = Color.FromArgb(169, 106, 72);
            button_print.BackgroundImage = Properties.Resources.gradient_center;
            button_print.BackgroundImageLayout = ImageLayout.Stretch;
            button_print.FlatAppearance.BorderSize = 0;
            button_print.FlatStyle = FlatStyle.Flat;
            button_print.ForeColor = Color.White;
            button_print.Location = new Point(105, 416);
            button_print.Name = "button_print";
            button_print.Size = new Size(87, 32);
            button_print.TabIndex = 51;
            button_print.Text = "Yazdır";
            button_print.UseVisualStyleBackColor = false;
            button_print.Click += button_print_Click;
            // 
            // browser_file
            // 
            browser_file.AllowExternalDrop = true;
            browser_file.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            browser_file.CreationProperties = null;
            browser_file.DefaultBackgroundColor = Color.White;
            browser_file.Location = new Point(0, 0);
            browser_file.Name = "browser_file";
            browser_file.Size = new Size(637, 410);
            browser_file.TabIndex = 52;
            browser_file.ZoomFactor = 1D;
            // 
            // DosyaGoster
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 450);
            Controls.Add(browser_file);
            Controls.Add(button_print);
            Controls.Add(button_save);
            MinimizeBox = false;
            Name = "DosyaGoster";
            Text = "Dosya Göster";
            Load += DosyaGoster_Load;
            ((System.ComponentModel.ISupportInitialize)browser_file).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button_save;
        private Button button_print;
        private Microsoft.Web.WebView2.WinForms.WebView2 browser_file;
    }
}