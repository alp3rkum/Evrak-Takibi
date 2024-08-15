namespace Evrak_Takibi_Programı.Diğer
{
    partial class MusteriSil
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
            label20 = new Label();
            text_musteri = new TextBox();
            label1 = new Label();
            dataGrid_customer = new DataGridView();
            button_sil = new Button();
            panel_left_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid_customer).BeginInit();
            SuspendLayout();
            // 
            // panel_left_title
            // 
            panel_left_title.BackColor = Color.FromArgb(48, 80, 127);
            panel_left_title.BackgroundImage = Properties.Resources.gradient_center;
            panel_left_title.BackgroundImageLayout = ImageLayout.Stretch;
            panel_left_title.Controls.Add(label20);
            panel_left_title.Location = new Point(0, 0);
            panel_left_title.Name = "panel_left_title";
            panel_left_title.Size = new Size(637, 92);
            panel_left_title.TabIndex = 55;
            // 
            // label20
            // 
            label20.BackColor = Color.Transparent;
            label20.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label20.ForeColor = Color.White;
            label20.Location = new Point(0, 0);
            label20.Name = "label20";
            label20.Size = new Size(637, 92);
            label20.TabIndex = 0;
            label20.Text = "Müşteri Sil";
            label20.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // text_musteri
            // 
            text_musteri.Location = new Point(99, 101);
            text_musteri.Name = "text_musteri";
            text_musteri.Size = new Size(327, 23);
            text_musteri.TabIndex = 59;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(12, 104);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 58;
            label1.Text = "Seçili Müşteri:";
            // 
            // dataGrid_customer
            // 
            dataGrid_customer.AllowUserToAddRows = false;
            dataGrid_customer.AllowUserToDeleteRows = false;
            dataGrid_customer.AllowUserToResizeColumns = false;
            dataGrid_customer.AllowUserToResizeRows = false;
            dataGrid_customer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_customer.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGrid_customer.Location = new Point(12, 133);
            dataGrid_customer.MultiSelect = false;
            dataGrid_customer.Name = "dataGrid_customer";
            dataGrid_customer.Size = new Size(612, 305);
            dataGrid_customer.TabIndex = 60;
            dataGrid_customer.CellContentClick += dataGrid_customer_CellContentClick;
            // 
            // button_sil
            // 
            button_sil.BackColor = Color.FromArgb(72, 106, 169);
            button_sil.BackgroundImage = Properties.Resources.gradient_center;
            button_sil.BackgroundImageLayout = ImageLayout.Stretch;
            button_sil.FlatAppearance.BorderSize = 0;
            button_sil.FlatStyle = FlatStyle.Flat;
            button_sil.ForeColor = Color.White;
            button_sil.Location = new Point(549, 100);
            button_sil.Name = "button_sil";
            button_sil.Size = new Size(75, 23);
            button_sil.TabIndex = 61;
            button_sil.Text = "Sil";
            button_sil.UseVisualStyleBackColor = false;
            button_sil.Click += button_sil_Click;
            // 
            // MusteriSil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 450);
            Controls.Add(button_sil);
            Controls.Add(dataGrid_customer);
            Controls.Add(text_musteri);
            Controls.Add(label1);
            Controls.Add(panel_left_title);
            Name = "MusteriSil";
            Load += MusteriSil_Load;
            panel_left_title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGrid_customer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel_left_title;
        private Label label20;
        private TextBox text_musteri;
        private Label label1;
        private DataGridView dataGrid_customer;
        private Button button_sil;
    }
}