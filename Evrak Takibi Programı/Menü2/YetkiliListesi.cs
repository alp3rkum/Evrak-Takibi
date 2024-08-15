using OfficeOpenXml;
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
using Excel = OfficeOpenXml;

namespace Evrak_Takibi_Programı.Menü2
{
    public partial class YetkiliListesi : Form
    {
        public YetkiliListesi()
        {
            InitializeComponent();
        }

        private void YetkiliListesi_Load(object sender, EventArgs e)
        {
            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> columnNames = new List<string> { "musteri_kodu", "tc_kimlikno", "ad_soyad", "dogum_yili", "dogum_yeri1", "dogum_yeri2", "meslek", "gorev" };
                List<string> columnHeaders = new List<string> { "Müşteri Kodu", "TC Kimlik Numarası", "Ad Soyad", "Doğum Yılı", "Doğum Yeri (Ülke)", "Doğum Yeri (Şehir)", "Meslek", "Görev" };
                List<Type> columnTypes = new List<Type> { typeof(int), typeof(string), typeof(string), typeof(int), typeof(string), typeof(string), typeof(string), typeof(string) };
                for (int i = 0; i < 8; i++)
                {
                    DataGridViewColumn column = new DataGridViewTextBoxColumn();
                    column.Name = columnNames[i];
                    column.HeaderText = columnHeaders[i];
                    column.ValueType = columnTypes[i];
                    dataGridView1.Columns.Add(column);
                }
                query = "SELECT musteri_kodu, tc_kimlikno, ad_soyad, dogum_yili, dogum_yeri1, dogum_yeri2, meslek, gorev FROM dbo.Yetkili";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(dataGridView1);
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row.Cells[i].Value = reader.GetValue(i);
                            }
                            dataGridView1.Rows.Add(row);
                        }
                    }
                }
                query = "SELECT musteri_kodu, tc_kimlikno, ad_soyad, dogum_yili, dogum_yeri1, dogum_yeri2, meslek, gorev FROM dbo.CerceveYetkili";
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(dataGridView1);
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row.Cells[i].Value = reader.GetValue(i);
                            }
                            dataGridView1.Rows.Add(row);
                        }
                    }
                }
            }
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("raporlar"))
            {
                Directory.CreateDirectory("raporlar");
            }
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (Excel.ExcelPackage package = new Excel.ExcelPackage())
            {
                Excel.ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Yetkili Listesi");
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
                package.SaveAs(new FileInfo("raporlar\\yetkili_listesi.xlsx"));
            }
            MessageBox.Show("Yetkili Kişi listesi \"raporlar\" alt klasörüne kaydedildi", "Yetkili Listesi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
