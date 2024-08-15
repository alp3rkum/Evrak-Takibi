using Excel = OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;

namespace Evrak_Takibi_Programı.Menü2
{
    public partial class TakiptekiFaturalar : Form
    {
        public TakiptekiFaturalar()
        {
            InitializeComponent();
        }

        private void TakiptekiFaturalar_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[4].ReadOnly = true;
            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                query = $"SELECT * FROM dbo.Fatura WHERE takipte = 1"; //takipte olan faturaları getir
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataGridViewRow row_1 = new DataGridViewRow();
                            row_1.CreateCells(dataGridView1);
                            for (int i = 1; i < reader.FieldCount - 1; i++)
                            {
                                if (i == 5)
                                {
                                    if (Convert.ToInt32(row_1.Cells[i - 1].Value) == 0)
                                        row_1.Cells[i - 1].Value = "A";
                                    else
                                        row_1.Cells[i - 1].Value = "S";
                                }
                                else
                                {
                                    row_1.Cells[i - 1].Value = reader.GetValue(i);
                                }

                            }
                            dataGridView1.Rows.Add(row_1);
                        }
                    }
                }
                connection.Close();
            }
        }

        private void button_getir_Click(object sender, EventArgs e)
        {
            if(text_faturano.Text.Length > 0 || text_custname.Text.Length > 0)
            {
                dataGridView1.Rows.Clear();
                string query = "";
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    if (text_faturano.Text.Length > 0)
                    {
                        query = $"SELECT * FROM dbo.Fatura WHERE eid LIKE '%@eid%' AND takipte = 1";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@eid", text_faturano.Text);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    DataGridViewRow row_1 = new DataGridViewRow();
                                    row_1.CreateCells(dataGridView1);
                                    for (int i = 1; i < reader.FieldCount - 1; i++)
                                    {
                                        if (i == 5)
                                        {
                                            if (Convert.ToInt32(row_1.Cells[i - 1].Value) == 0)
                                                row_1.Cells[i - 1].Value = "A";
                                            else
                                                row_1.Cells[i - 1].Value = "S";
                                        }
                                        else
                                        {
                                            row_1.Cells[i - 1].Value = reader.GetValue(i);
                                        }
                                    }
                                    dataGridView1.Rows.Add(row_1);
                                }
                            }
                        }
                    }
                    else if (text_custname.Text.Length > 0)
                    {
                        query = $"SELECT * FROM dbo.Fatura WHERE musteri_ad LIKE '%@ad%' takipte = 1";
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ad", text_custname.Text);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    DataGridViewRow row_1 = new DataGridViewRow();
                                    row_1.CreateCells(dataGridView1);
                                    for (int i = 1; i < reader.FieldCount - 1; i++)
                                    {
                                        if (i == 5)
                                        {
                                            if (Convert.ToInt32(row_1.Cells[i - 1].Value) == 0)
                                                row_1.Cells[i - 1].Value = "A";
                                            else
                                                row_1.Cells[i - 1].Value = "S";
                                        }
                                        else
                                        {
                                            row_1.Cells[i - 1].Value = reader.GetValue(i);
                                        }
                                    }
                                    dataGridView1.Rows.Add(row_1);
                                }
                            }
                        }
                    }
                    else if (text_faturano.Text.Length > 0 && text_custname.Text.Length > 0)
                    {
                        query = $"SELECT * FROM dbo.Fatura WHERE (eid LIKE '%@eid%' OR musteri_ad LIKE '%@ad%') AND takipte = 1";
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@eid", text_faturano.Text);
                            command.Parameters.AddWithValue("@ad", text_custname.Text);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    DataGridViewRow row_1 = new DataGridViewRow();
                                    row_1.CreateCells(dataGridView1);
                                    {
                                        for (int i = 1; i < reader.FieldCount - 1; i++)
                                        {
                                            if (i == 5)
                                            {
                                                if (Convert.ToInt32(row_1.Cells[i - 1].Value) == 0)
                                                    row_1.Cells[i - 1].Value = "A";
                                                else
                                                    row_1.Cells[i - 1].Value = "S";
                                            }
                                            else
                                            {
                                                row_1.Cells[i - 1].Value = reader.GetValue(i);
                                            }
                                        }
                                    }
                                    dataGridView1.Rows.Add(row_1);
                                }
                            }
                        }

                    }
                    connection.Close();
                }
                
            }
            else
            {
                MessageBox.Show("Arama kıstası girilmedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_temizle_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                query = $"SELECT * FROM dbo.Fatura WHERE takipte = 1"; //takipte olan faturaları getir
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataGridViewRow row_1 = new DataGridViewRow();
                            row_1.CreateCells(dataGridView1);
                            for (int i = 1; i < reader.FieldCount - 1; i++)
                            {
                                if (i == 5)
                                {
                                    if (Convert.ToInt32(row_1.Cells[i - 1].Value) == 0)
                                        row_1.Cells[i - 1].Value = "A";
                                    else
                                        row_1.Cells[i - 1].Value = "S";

                                }
                                else
                                {
                                    row_1.Cells[i - 1].Value = reader.GetValue(i);
                                }

                            }
                            dataGridView1.Rows.Add(row_1);
                        }
                    }
                }
                connection.Close();
            }
        }

        private void button_takip_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Takipte olan (imzalanmamış) faturaların hepsini dışarı aktaracaksınız.\nBu işlemi gerçekleştirmek istiyor musunuz?", "Takipteki Faturaları Dışa Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                if (!Directory.Exists("raporlar"))
                {
                    Directory.CreateDirectory("raporlar");
                }
                Excel.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (var package = new Excel.ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Faturalar");
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = dataGridView1.Columns[i].HeaderText;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].AutoFitColumns();
                    }
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1].Value = dataGridView1.Rows[i].Cells[j].Value;
                            worksheet.Cells[i + 2, j + 1].AutoFitColumns();
                        }
                    }
                    package.SaveAs(new FileInfo("raporlar\\takipteki_faturalar.xlsx"));
                }
                MessageBox.Show("Takipteki faturalar listesi \"raporlar\" alt klasörüne kaydedildi", "Müşteri Listesi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
