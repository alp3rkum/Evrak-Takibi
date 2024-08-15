namespace Evrak_Takibi_Programı.Menü2
{
    partial class GuvenlikKontrolRapor
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
            button_getir = new Button();
            text_custname = new TextBox();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button_getir
            // 
            button_getir.BackColor = Color.FromArgb(169, 106, 72);
            button_getir.BackgroundImage = Properties.Resources.gradient_center;
            button_getir.BackgroundImageLayout = ImageLayout.Stretch;
            button_getir.FlatAppearance.BorderSize = 0;
            button_getir.FlatStyle = FlatStyle.Flat;
            button_getir.ForeColor = Color.White;
            button_getir.Location = new Point(401, 118);
            button_getir.Name = "button_getir";
            button_getir.Size = new Size(101, 23);
            button_getir.TabIndex = 124;
            button_getir.Text = "Rapor Çıkar";
            button_getir.UseVisualStyleBackColor = false;
            button_getir.Click += button_getir_Click;
            // 
            // text_custname
            // 
            text_custname.Location = new Point(110, 118);
            text_custname.Name = "text_custname";
            text_custname.Size = new Size(285, 23);
            text_custname.TabIndex = 123;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label3.Location = new Point(12, 118);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 122;
            label3.Text = "Yetkili Adı:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 161);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(845, 602);
            dataGridView1.TabIndex = 125;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // GuvenlikKontrolRapor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 766);
            Controls.Add(dataGridView1);
            Controls.Add(button_getir);
            Controls.Add(text_custname);
            Controls.Add(label3);
            Name = "GuvenlikKontrolRapor";
            Text = "GuvenlikKontrolRapor";
            Load += GuvenlikKontrolRapor_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button_getir;
        private TextBox text_custname;
        private Label label3;
        private DataGridView dataGridView1;
    }
}