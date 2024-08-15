namespace Evrak_Takibi_Programı.Menü2
{
    partial class MusteriListesi
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
            dataGridView1 = new DataGridView();
            button_export = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 165);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(845, 602);
            dataGridView1.TabIndex = 119;
            // 
            // button_export
            // 
            button_export.BackColor = Color.FromArgb(169, 106, 72);
            button_export.BackgroundImage = Properties.Resources.gradient_center;
            button_export.BackgroundImageLayout = ImageLayout.Stretch;
            button_export.FlatAppearance.BorderSize = 0;
            button_export.FlatStyle = FlatStyle.Flat;
            button_export.ForeColor = Color.White;
            button_export.Location = new Point(12, 127);
            button_export.Name = "button_export";
            button_export.Size = new Size(134, 32);
            button_export.TabIndex = 120;
            button_export.Text = "Dışa Aktar";
            button_export.UseVisualStyleBackColor = false;
            button_export.Click += button_export_Click;
            // 
            // MusteriListesi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(button_export);
            Controls.Add(dataGridView1);
            Name = "MusteriListesi";
            Text = "MusteriListesi";
            Load += MusteriListesi_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private Button button_export;
    }
}