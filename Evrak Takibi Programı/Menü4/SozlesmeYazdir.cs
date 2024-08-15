using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evrak_Takibi_Programı.Menü4
{
    public partial class SozlesmeYazdir : Form
    {
        int selectedRowIndex;
        public SozlesmeYazdir()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];
            if (row.Cells[7].Value.ToString() != "Adi Ortaklık")
            {
                button_cerceve1.Enabled = true;
            }
            else
            {
                button_cerceve1.Enabled = true;
            }
        }

        private void SozlesmeYazdir_Load(object sender, EventArgs e)
        {
            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> columnNames = new List<string> { "musteri_kodu", "ad_soyad", "referans", "telefon_no", "eposta_adres", "is_baslangic_tarih", "son_islem_tarihi", "musteri_tur" };
                List<string> columnHeaders = new List<string> { "Müşteri Kodu", "Ad Soyad", "Referans", "telefon_no", "eposta_adres", "İş Başlangıç Tarihi", "Son İşlem Tarihi", "Müşteri Türü" };
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
                            row_3.Cells[7].Value = "Şahıs";
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
                            row_4.Cells[7].Value = "Adi Ortaklık";
                            dataGridView1.Rows.Add(row_4);
                        }
                    }
                }
            }
        }

        private void button_cerceve1_Click(object sender, EventArgs e)
        {
            
            sozlesmeDialog.Filter = "|PDF Dosyası|*.pdf";
            if (sozlesmeDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = sozlesmeDialog.FileName;
                PrintPDF(filePath);
            }
            //DialogResult result = new DialogResult();
            //DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];
            //switch(row.Cells[7].Value.ToString())
            //{
            //    case "Tüzel Kişi":
            //        result = MessageBox.Show($"{row.Cells[1].Value.ToString()} isimli tüzel kişinin çerçeve sözleşmesini yazdırmak üzeresiniz.\nİşleme devam etmek istiyor musunuz?", "Çerçeve Sözleşmesi Yazdır", MessageBoxButtons.YesNo, MessageBoxIcon.Question); break;
            //    case "Gerçek Kişi":
            //        result = MessageBox.Show($"{row.Cells[1].Value.ToString()} isimli gerçek kişinin çerçeve sözleşmesini yazdırmak üzeresiniz.\nİşleme devam etmek istiyor musunuz?", "Çerçeve Sözleşmesi Yazdır", MessageBoxButtons.YesNo, MessageBoxIcon.Question); break;
            //    case "Şahıs":
            //        result = MessageBox.Show($"{row.Cells[1].Value.ToString()} isimli şahsın çerçeve sözleşmesini yazdırmak üzeresiniz.\nİşleme devam etmek istiyor musunuz?", "Çerçeve Sözleşmesi Yazdır", MessageBoxButtons.YesNo, MessageBoxIcon.Question); break;
            //    case "Adi Ortaklık":
            //        result = MessageBox.Show($"{row.Cells[1].Value.ToString()} isimli adi ortaklığın birinci ortağının çerçeve sözleşmesini yazdırmak üzeresiniz.\nİşleme devam etmek istiyor musunuz?", "Çerçeve Sözleşmesi Yazdır", MessageBoxButtons.YesNo, MessageBoxIcon.Question); break;
            //}
            //if (result == DialogResult.Yes)
            //{
            //    string filename = "yazdir.pdf";

                //}
        }

        private void PrintPDF(string filePath)
        {
            PrintDocument printDocument = new PrintDocument();

            printDocument.PrintPage += (sender, e) =>
            {
                e.Graphics.DrawImage(System.Drawing.Image.FromFile(filePath), e.MarginBounds);
            };
            try
            {
                printDocument.Print();
            }
            catch
            {
                MessageBox.Show("Yazıcı şu anda kullanılamıyor veya yazıcı tanımlanmadı.", "Yazdırma Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
