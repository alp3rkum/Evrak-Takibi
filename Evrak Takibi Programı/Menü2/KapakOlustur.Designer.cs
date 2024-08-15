namespace Evrak_Takibi_Programı.Menü2
{
    partial class KapakOlustur
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
            text_custname = new TextBox();
            label3 = new Label();
            button_risk = new Button();
            button_fatf = new Button();
            button_form = new Button();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(text_custname);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(button_risk);
            groupBox1.Controls.Add(button_fatf);
            groupBox1.Controls.Add(button_form);
            groupBox1.Location = new Point(12, 106);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(821, 64);
            groupBox1.TabIndex = 120;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kapak";
            // 
            // text_custname
            // 
            text_custname.Location = new Point(104, 27);
            text_custname.Name = "text_custname";
            text_custname.Size = new Size(285, 23);
            text_custname.TabIndex = 122;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label3.Location = new Point(6, 27);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 121;
            label3.Text = "Müşteri Adı:";
            // 
            // button_risk
            // 
            button_risk.BackColor = Color.FromArgb(169, 106, 72);
            button_risk.BackgroundImage = Properties.Resources.gradient_center;
            button_risk.BackgroundImageLayout = ImageLayout.Stretch;
            button_risk.FlatAppearance.BorderSize = 0;
            button_risk.FlatStyle = FlatStyle.Flat;
            button_risk.ForeColor = Color.White;
            button_risk.Location = new Point(681, 22);
            button_risk.Name = "button_risk";
            button_risk.Size = new Size(134, 32);
            button_risk.TabIndex = 52;
            button_risk.Text = "Müşteri Risk Belgesi";
            button_risk.UseVisualStyleBackColor = false;
            button_risk.Click += button_risk_Click;
            // 
            // button_fatf
            // 
            button_fatf.BackColor = Color.FromArgb(169, 106, 72);
            button_fatf.BackgroundImage = Properties.Resources.gradient_center;
            button_fatf.BackgroundImageLayout = ImageLayout.Stretch;
            button_fatf.FlatAppearance.BorderSize = 0;
            button_fatf.FlatStyle = FlatStyle.Flat;
            button_fatf.ForeColor = Color.White;
            button_fatf.Location = new Point(541, 22);
            button_fatf.Name = "button_fatf";
            button_fatf.Size = new Size(134, 32);
            button_fatf.TabIndex = 51;
            button_fatf.Text = "FATF Belgesi";
            button_fatf.UseVisualStyleBackColor = false;
            button_fatf.Click += button_fatf_Click;
            // 
            // button_form
            // 
            button_form.BackColor = Color.FromArgb(169, 106, 72);
            button_form.BackgroundImage = Properties.Resources.gradient_center;
            button_form.BackgroundImageLayout = ImageLayout.Stretch;
            button_form.FlatAppearance.BorderSize = 0;
            button_form.FlatStyle = FlatStyle.Flat;
            button_form.ForeColor = Color.White;
            button_form.Location = new Point(401, 22);
            button_form.Name = "button_form";
            button_form.Size = new Size(134, 32);
            button_form.TabIndex = 50;
            button_form.Text = "Müşteri Formu";
            button_form.UseVisualStyleBackColor = false;
            button_form.Click += button_save_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 176);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(845, 593);
            dataGridView1.TabIndex = 121;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // KapakOlustur
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 767);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Name = "KapakOlustur";
            Text = "KapakOlustur";
            Load += KapakOlustur_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Button button_risk;
        private Button button_fatf;
        private Button button_form;
        private TextBox text_custname;
        private Label label3;
        private DataGridView dataGridView1;
    }
}