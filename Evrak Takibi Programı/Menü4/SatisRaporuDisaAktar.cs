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

namespace Evrak_Takibi_Programı.Menü4
{
    public partial class SatisRaporuDisaAktar : Form
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
        public SatisRaporuDisaAktar()
        {
            InitializeComponent();
        }

        private void button_alis_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            string query = "SELECT * FROM dbo.Fatura WHERE alis_satis = 0";
            DialogResult result = MessageBox.Show("Veritabanında kayıtlı alış türü faturaları dışa aktarmak istiyor musunuz?", "Alış Türü Faturaları Dışa Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            using (ExcelPackage package = new ExcelPackage())
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("AlisFatura");
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    worksheet.Cells[1, i + 1].Value = reader.GetName(i);
                                    worksheet.Cells[1, i + 1].AutoFitColumns();
                                }
                                int rowIndex = 2;
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        if (i == 5)
                                            worksheet.Cells[rowIndex, i + 1].Value = "A";
                                        else
                                            worksheet.Cells[rowIndex, i + 1].Value = reader[i];
                                    }
                                    rowIndex++;
                                }
                                string filePath = "C:raporlar\\alis_faturalar.xlsx";
                                package.SaveAs(new FileInfo(filePath));
                                MessageBox.Show("Alış faturaları başarıyla dışa aktarıldı.", "Dışa Aktarma Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }

        private void button_satis_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            string query = "SELECT * FROM dbo.Fatura WHERE alis_satis = 1";
            DialogResult result = MessageBox.Show("Veritabanında kayıtlı satış türü faturaları dışa aktarmak istiyor musunuz?", "Satış Türü Faturaları Dışa Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            using (ExcelPackage package = new ExcelPackage())
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("SatisFatura");
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    worksheet.Cells[1, i + 1].Value = reader.GetName(i);
                                    worksheet.Cells[1, i + 1].AutoFitColumns();
                                }
                                int rowIndex = 2;
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        if (i == 5)
                                            worksheet.Cells[rowIndex, i + 1].Value = "S";
                                        else
                                            worksheet.Cells[rowIndex, i + 1].Value = reader[i];
                                    }
                                    rowIndex++;
                                }
                                string filePath = "C:raporlar\\satis_faturalar.xlsx";
                                package.SaveAs(new FileInfo(filePath));
                                MessageBox.Show("Satış faturaları başarıyla dışa aktarıldı.", "Dışa Aktarma Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }

        private void button_hepsi_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            string query = "SELECT * FROM dbo.Fatura";
            DialogResult result = MessageBox.Show("Veritabanında kayıtlı BÜTÜN faturaları dışa aktaracaksınız.\nBu işlemi gerçekleştirmek istiyor musunuz?", "Bütün Faturaları Dışa Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            using (ExcelPackage package = new ExcelPackage())
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Faturalar");
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    worksheet.Cells[1, i + 1].Value = reader.GetName(i);
                                    worksheet.Cells[1, i + 1].AutoFitColumns();
                                }
                                int rowIndex = 2;
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        if (i == 5)
                                        {
                                            if (Convert.ToInt32(reader[i]) == 0)
                                                worksheet.Cells[rowIndex, i + 1].Value = "A";
                                            else
                                                worksheet.Cells[rowIndex, i + 1].Value = "S";
                                        }  
                                        else
                                            worksheet.Cells[rowIndex, i + 1].Value = reader[i];
                                    }
                                    rowIndex++;
                                }
                                string filePath = "C:raporlar\\tum_faturalar.xlsx";
                                package.SaveAs(new FileInfo(filePath));
                                MessageBox.Show("Tüm faturalar başarıyla dışa aktarıldı.", "Dışa Aktarma Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }
    }
}
