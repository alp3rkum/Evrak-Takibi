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

namespace Evrak_Takibi_Programı.Diğer
{
    public partial class SirketSil : Form
    {
        private int musteriKodu = 0;
        public SirketSil()
        {
            InitializeComponent();
        }

        private void SirketSil_Load(object sender, EventArgs e)
        {
            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> columnNames = new List<string> { "musteri_kodu", "musteri_adi", "vergi_no", "gelis_tarihi", "adres", "il_kodu" };
                List<string> columnHeaders = new List<string> { "Müşteri Kodu", "Müşteri Adı", "Vergi Numarası", "Geliş Tarihi", "Adres", "İl Kodu" };
                List<Type> columnTypes = new List<Type> { typeof(int), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(int) };
                for (int i = 0; i < 6; i++)
                {
                    DataGridViewColumn column = new DataGridViewTextBoxColumn();
                    column.Name = columnNames[i];
                    column.HeaderText = columnHeaders[i];
                    column.ValueType = columnTypes[i];
                    dataGrid_customer.Columns.Add(column);
                }
                query = $"SELECT * FROM dbo.Sirket";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataGridViewRow data_row = new DataGridViewRow();
                            data_row.CreateCells(dataGrid_customer);
                            for (int i = 0; i < columnNames.Count; i++)
                            {
                                data_row.Cells[i].Value = reader.GetValue(i + 1);
                            }
                            dataGrid_customer.Rows.Add(data_row);
                        }
                    }
                }
                connection.Close();
            }
        }

        private void dataGrid_customer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGrid_customer.Rows[e.RowIndex];
            musteriKodu = Convert.ToInt32(row.Cells[0].Value);
            text_musteri.Text = row.Cells[1].Value.ToString();
        }

        private void button_sil_Click(object sender, EventArgs e)
        {
            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                query = $"DELETE FROM dbo.Sirket WHERE musteri_kodu = @MusteriKodu";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MusteriKodu", musteriKodu);
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show($"{musteriKodu} kodlu şirketin kaydı başarıyla silindi.", "Kayıt Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show($"Kayıt silme operasyonu başarısız oldu.", "Kayıt Silinemedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
