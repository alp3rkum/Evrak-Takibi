using iText.Layout.Element;
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
    public partial class MusteriListesi : Form
    {
        public MusteriListesi()
        {
            InitializeComponent();
        }

        private void MusteriListesi_Load(object sender, EventArgs e)
        {
            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> columnNames = new List<string> { "musteri_kodu", "ad_soyad", "referans", "telefon_no", "eposta_adres", "is_baslangic_tarih", "son_islem_tarihi", "musteri_tur" };
                List<string> columnHeaders = new List<string> { "Müşteri Kodu", "Ad Soyad", "Referans", "Telefon Numarası", "Eposta Adresi", "İş Başlangıç Tarihi", "Son İşlem Tarihi", "Müşteri Türü" };
                List<Type> columnTypes = new List<Type> { typeof(int), typeof(string), typeof(int), typeof(string), typeof(string), typeof(DateTime), typeof(DateTime), typeof(string) };
                for (int i = 0; i < 8; i++)
                {
                    DataGridViewColumn column = new DataGridViewTextBoxColumn();
                    column.Name = columnNames[i];
                    column.HeaderText = columnHeaders[i];
                    column.ValueType = columnTypes[i];
                    dataGridView1.Columns.Add(column);
                }
                query = $"SELECT musteri_kodu, ad_soyad, referans, telefon_no, eposta_adres, is_baslangic_tarih, son_islem_tarihi FROM dbo.TuzelKisi";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataGridViewRow row_1 = new DataGridViewRow();
                            row_1.CreateCells(dataGridView1);
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row_1.Cells[i].Value = reader.GetValue(i);
                            }
                            row_1.Cells[7].Value = "Tüzel Kişi";
                            dataGridView1.Rows.Add(row_1);
                        }
                    }
                }
                query = $"SELECT musteri_kodu, ad_soyad, referans, telefon_no, eposta_adres, is_baslangic_tarih, son_islem_tarihi FROM dbo.GercekKisi";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataGridViewRow row_2 = new DataGridViewRow();
                            row_2.CreateCells(dataGridView1);
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row_2.Cells[i].Value = reader.GetValue(i);
                            }
                            row_2.Cells[7].Value = "Gerçek Kişi";
                            dataGridView1.Rows.Add(row_2);
                        }
                    }
                }
                query = $"SELECT musteri_kodu, ad_soyad, referans, telefon_no, eposta_adres, is_baslangic_tarih, son_islem_tarihi FROM dbo.Sahis";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataGridViewRow row_3 = new DataGridViewRow();
                            row_3.CreateCells(dataGridView1);
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row_3.Cells[i].Value = reader.GetValue(i);
                            }
                            row_3.Cells[7].Value = "Sahis";
                            dataGridView1.Rows.Add(row_3);
                        }
                    }
                }
                query = $"SELECT musteri_kodu, ad_soyad, referans, telefon_no, eposta_adres, is_baslangic_tarih, son_islem_tarihi FROM dbo.AdiOrtaklik";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataGridViewRow row_4 = new DataGridViewRow();
                            row_4.CreateCells(dataGridView1);
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row_4.Cells[i].Value = reader.GetValue(i);
                            }
                            row_4.Cells[7].Value = "Adi Ortaklik";
                            dataGridView1.Rows.Add(row_4);
                        }
                    }
                }
            }

        }

        private void button_export_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists("raporlar"))
            {
                Directory.CreateDirectory("raporlar");
            }
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (Excel.ExcelPackage package = new Excel.ExcelPackage())
            {
                Excel.ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Müşteri Listesi");
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
                package.SaveAs(new FileInfo("raporlar\\müsteri_listesi.xlsx"));
            }
            MessageBox.Show("Müşteri listesi \"raporlar\" alt klasörüne kaydedildi","Müşteri Listesi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
