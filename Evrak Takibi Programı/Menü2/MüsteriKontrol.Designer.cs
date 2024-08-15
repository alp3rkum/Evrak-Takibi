namespace Evrak_Takibi_Programı.Menü2
{
    partial class MüsteriKontrol
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
            text_custname = new TextBox();
            label3 = new Label();
            button_getir = new Button();
            button_db = new Button();
            button_report = new Button();
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
            dataGridView1.Location = new Point(0, 162);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(845, 602);
            dataGridView1.TabIndex = 118;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // text_custname
            // 
            text_custname.Location = new Point(110, 121);
            text_custname.Name = "text_custname";
            text_custname.Size = new Size(285, 23);
            text_custname.TabIndex = 120;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label3.Location = new Point(12, 121);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 119;
            label3.Text = "Müşteri Adı:";
            // 
            // button_getir
            // 
            button_getir.BackColor = Color.FromArgb(169, 106, 72);
            button_getir.BackgroundImage = Properties.Resources.gradient_center;
            button_getir.BackgroundImageLayout = ImageLayout.Stretch;
            button_getir.FlatAppearance.BorderSize = 0;
            button_getir.FlatStyle = FlatStyle.Flat;
            button_getir.ForeColor = Color.White;
            button_getir.Location = new Point(401, 121);
            button_getir.Name = "button_getir";
            button_getir.Size = new Size(75, 23);
            button_getir.TabIndex = 121;
            button_getir.Text = "Kontrol Et";
            button_getir.UseVisualStyleBackColor = false;
            button_getir.Click += button_getir_Click;
            // 
            // button_db
            // 
            button_db.BackColor = Color.FromArgb(169, 106, 72);
            button_db.BackgroundImage = Properties.Resources.gradient_center;
            button_db.BackgroundImageLayout = ImageLayout.Stretch;
            button_db.FlatAppearance.BorderSize = 0;
            button_db.FlatStyle = FlatStyle.Flat;
            button_db.ForeColor = Color.White;
            button_db.Location = new Point(507, 112);
            button_db.Name = "button_db";
            button_db.Size = new Size(160, 32);
            button_db.TabIndex = 122;
            button_db.Text = "Veritabanından Getir";
            button_db.UseVisualStyleBackColor = false;
            button_db.Click += button_db_Click;
            // 
            // button_report
            // 
            button_report.BackColor = Color.FromArgb(169, 106, 72);
            button_report.BackgroundImage = Properties.Resources.gradient_center;
            button_report.BackgroundImageLayout = ImageLayout.Stretch;
            button_report.FlatAppearance.BorderSize = 0;
            button_report.FlatStyle = FlatStyle.Flat;
            button_report.ForeColor = Color.White;
            button_report.Location = new Point(673, 112);
            button_report.Name = "button_report";
            button_report.Size = new Size(160, 32);
            button_report.TabIndex = 123;
            button_report.Text = "Müşteri Raporundan Getir";
            button_report.UseVisualStyleBackColor = false;
            button_report.Click += button_report_Click;
            // 
            // MüsteriKontrol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(button_report);
            Controls.Add(button_db);
            Controls.Add(button_getir);
            Controls.Add(text_custname);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Name = "MüsteriKontrol";
            Text = "MüsteriKontrol";
            Load += MüsteriKontrol_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private TextBox text_custname;
        private Label label3;
        private Button button_getir;
        private Button button_db;
        private Button button_report;
    }
}