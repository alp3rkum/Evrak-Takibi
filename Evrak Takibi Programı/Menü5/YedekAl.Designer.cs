namespace Evrak_Takibi_Programı.Menü5
{
    partial class YedekAl
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
            label_status = new Label();
            button1 = new Button();
            button_save = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label_status);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button_save);
            groupBox1.Location = new Point(12, 106);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(833, 65);
            groupBox1.TabIndex = 119;
            groupBox1.TabStop = false;
            groupBox1.Text = "İşlem Türü";
            // 
            // label_status
            // 
            label_status.AutoSize = true;
            label_status.Location = new Point(266, 31);
            label_status.Name = "label_status";
            label_status.Size = new Size(0, 15);
            label_status.TabIndex = 52;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(166, 169, 167);
            button1.BackgroundImage = Properties.Resources.gradient_center;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(136, 22);
            button1.Name = "button1";
            button1.Size = new Size(124, 32);
            button1.TabIndex = 51;
            button1.Text = "Yedekten Yükle";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button_save
            // 
            button_save.BackColor = Color.FromArgb(166, 169, 167);
            button_save.BackgroundImage = Properties.Resources.gradient_center;
            button_save.BackgroundImageLayout = ImageLayout.Stretch;
            button_save.FlatAppearance.BorderSize = 0;
            button_save.FlatStyle = FlatStyle.Flat;
            button_save.ForeColor = Color.White;
            button_save.Location = new Point(6, 22);
            button_save.Name = "button_save";
            button_save.Size = new Size(124, 32);
            button_save.TabIndex = 50;
            button_save.Text = "Yedeğe Al";
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click;
            // 
            // YedekAl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(groupBox1);
            Name = "YedekAl";
            Text = "YedekAl";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Button button_save;
        private Button button1;
        private Label label_status;
    }
}