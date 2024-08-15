namespace Evrak_Takibi_Programı.Menü4
{
    partial class MusteriBilgileriDısaAktar
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
            button_export = new Button();
            dataGridView1 = new DataGridView();
            text_custname = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button_export
            // 
            button_export.BackColor = Color.FromArgb(106, 169, 72);
            button_export.BackgroundImage = Properties.Resources.gradient_center;
            button_export.BackgroundImageLayout = ImageLayout.Stretch;
            button_export.Enabled = false;
            button_export.FlatAppearance.BorderSize = 0;
            button_export.FlatStyle = FlatStyle.Flat;
            button_export.ForeColor = Color.White;
            button_export.Location = new Point(746, 113);
            button_export.Name = "button_export";
            button_export.Size = new Size(87, 32);
            button_export.TabIndex = 129;
            button_export.Text = "Dışarı Aktar";
            button_export.UseVisualStyleBackColor = false;
            button_export.Click += button_export_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 151);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(845, 617);
            dataGridView1.TabIndex = 128;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // text_custname
            // 
            text_custname.Location = new Point(106, 119);
            text_custname.Name = "text_custname";
            text_custname.Size = new Size(285, 23);
            text_custname.TabIndex = 127;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label3.Location = new Point(8, 119);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 126;
            label3.Text = "Müşteri Adı:";
            // 
            // MusteriBilgileriDısaAktar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(button_export);
            Controls.Add(dataGridView1);
            Controls.Add(text_custname);
            Controls.Add(label3);
            Name = "MusteriBilgileriDısaAktar";
            Text = "MusteriBilgileriDısaAktar";
            Load += MusteriBilgileriDısaAktar_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_export;
        private DataGridView dataGridView1;
        private TextBox text_custname;
        private Label label3;
    }
}