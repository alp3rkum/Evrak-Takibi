namespace Evrak_Takibi_Programı.Menü2
{
    partial class TeslimTesellum
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
            label3 = new Label();
            text_billno = new TextBox();
            button_getir = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label3.Location = new Point(12, 120);
            label3.Name = "label3";
            label3.Size = new Size(163, 20);
            label3.TabIndex = 123;
            label3.Text = "Fatura Numarası (EID):";
            // 
            // text_billno
            // 
            text_billno.Location = new Point(181, 121);
            text_billno.Name = "text_billno";
            text_billno.Size = new Size(285, 23);
            text_billno.TabIndex = 124;
            // 
            // button_getir
            // 
            button_getir.BackColor = Color.FromArgb(169, 106, 72);
            button_getir.BackgroundImage = Properties.Resources.gradient_center;
            button_getir.BackgroundImageLayout = ImageLayout.Stretch;
            button_getir.FlatAppearance.BorderSize = 0;
            button_getir.FlatStyle = FlatStyle.Flat;
            button_getir.ForeColor = Color.White;
            button_getir.Location = new Point(472, 121);
            button_getir.Name = "button_getir";
            button_getir.Size = new Size(75, 23);
            button_getir.TabIndex = 125;
            button_getir.Text = "Kontrol Et";
            button_getir.UseVisualStyleBackColor = false;
            button_getir.Click += button_getir_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 166);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(845, 602);
            dataGridView1.TabIndex = 126;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // TeslimTesellum
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(dataGridView1);
            Controls.Add(button_getir);
            Controls.Add(text_billno);
            Controls.Add(label3);
            Name = "TeslimTesellum";
            Text = "TeslimTesellum";
            Load += TeslimTesellum_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private TextBox text_billno;
        private Button button_getir;
        private DataGridView dataGridView1;
    }
}