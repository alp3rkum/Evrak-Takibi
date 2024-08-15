using Evrak_Takibi_Programı.Diğer;
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

namespace Evrak_Takibi_Programı.Menü2
{
    public partial class GuvenlikKontrolRapor : Form
    {
        private string yetkiliAdi;
        public GuvenlikKontrolRapor()
        {
            InitializeComponent();
        }

        private void GuvenlikKontrolRapor_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            yetkiliAdi = row.Cells[1].Value.ToString();
            text_custname.Text = yetkiliAdi;
        }

        private void button_getir_Click(object sender, EventArgs e)
        {
            if(text_custname.Text != null)
            {
                DosyaGoster dosyaGoster = new DosyaGoster(1, yetkiliAdi, "Yetkili Kişi", false);
                dosyaGoster.Show();
            }
            else
            {
                MessageBox.Show("Yetkili kişi seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
