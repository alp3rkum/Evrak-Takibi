namespace Evrak_Takibi_Programı.Menü4
{
    partial class SozlesmeYazdir
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
            button_cerceve1 = new Button();
            sozlesmeDialog = new OpenFileDialog();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button_cerceve1
            // 
            button_cerceve1.BackColor = Color.FromArgb(146, 169, 106);
            button_cerceve1.BackgroundImage = Properties.Resources.gradient_center;
            button_cerceve1.BackgroundImageLayout = ImageLayout.Stretch;
            button_cerceve1.Enabled = false;
            button_cerceve1.FlatAppearance.BorderSize = 0;
            button_cerceve1.FlatStyle = FlatStyle.Flat;
            button_cerceve1.ForeColor = Color.White;
            button_cerceve1.Location = new Point(12, 121);
            button_cerceve1.Name = "button_cerceve1";
            button_cerceve1.Size = new Size(145, 41);
            button_cerceve1.TabIndex = 2;
            button_cerceve1.Text = "Çerçeve Sözleşmesi Yazdır";
            button_cerceve1.UseVisualStyleBackColor = false;
            button_cerceve1.Click += button_cerceve1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 168);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(845, 600);
            dataGridView1.TabIndex = 120;
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            // 
            // SozlesmeYazdir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(button_cerceve1);
            Controls.Add(dataGridView1);
            Name = "SozlesmeYazdir";
            Text = "SozlesmeYazdir";
            Load += SozlesmeYazdir_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button_cerceve1;
        private OpenFileDialog sozlesmeDialog;
        private DataGridView dataGridView1;
    }
}