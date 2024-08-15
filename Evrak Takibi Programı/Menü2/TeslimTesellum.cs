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
    public partial class TeslimTesellum : Form
    {
        private string faturaEid;
        private string musteriAd;
        public TeslimTesellum()
        {
            InitializeComponent();
        }

        private void button_getir_Click(object sender, EventArgs e)
        {
            if(text_billno.Text.Length > 0)
            {
                DosyaGoster dosyaGoster = new DosyaGoster(6, musteriAd, faturaEid, false);
                dosyaGoster.Show();
            }
            else
            {
                MessageBox.Show("Müşteri seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            faturaEid = row.Cells[0].Value.ToString();
            musteriAd = row.Cells[3].Value.ToString();
            text_billno.Text = faturaEid;
        }

        private void TeslimTesellum_Load(object sender, EventArgs e)
        {
            List<string> columnNames = new List<string> { "eid", "tarih", "musteri_kod", "musteri_ad", "alis_satis", "cins", "miktar", "kur", "tutar_tl", "tutar_dolar", "belge_no" };
            List<string> columnHeaders = new List<string> { "Fatura No (EID)", "Tarih", "Müşteri Kod", "Müşteri Ad/Soyad", "Alış/Satış", "Döviz Cinsi", "Miktar", "Kur", "TL Tutarı", "Dolar Tutarı", "Belge No" };
            List<Type> columnTypes = new List<Type> { typeof(string), typeof(DateTime), typeof(int), typeof(string), typeof(bool), typeof(string), typeof(int), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string) };
            for (int i = 0; i < 11; i++)
            {
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.Name = columnNames[i];
                column.HeaderText = columnHeaders[i];
                column.ValueType = columnTypes[i];
                dataGridView1.Columns.Add(column);
            }
            string query = "SELECT * FROM dbo.Fatura";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
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
                                    if (Convert.ToInt32(reader.GetValue(i)) == 0)
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
                    connection.Close();
                }
            }
        }
    }
}
