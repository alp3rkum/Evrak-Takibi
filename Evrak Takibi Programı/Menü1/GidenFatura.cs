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

namespace Evrak_Takibi_Programı
{
    public partial class GidenFatura : Form
    {
        internal bool faturaSelected = false;
        internal int selectedRowIndex = 0;
        public GidenFatura()
        {
            InitializeComponent();
        }

        private void GidenFatura_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[4].ReadOnly = true;
            if (!(Form1.satisRaporu == null))
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(Form1.satisRaporu))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                    {
                        if (worksheet.Cells[row, 3].Value.ToString().Equals("S", StringComparison.OrdinalIgnoreCase))
                        {
                            DataGridViewRow data_row = new DataGridViewRow();
                            data_row.CreateCells(dataGridView1);
                            data_row.Cells[0].Value = worksheet.Cells[row, 54].Value;
                            data_row.Cells[1].Value = worksheet.Cells[row, 8].Value;
                            data_row.Cells[2].Value = worksheet.Cells[row, 58].Value;
                            data_row.Cells[3].Value = worksheet.Cells[row, 11].Value;
                            data_row.Cells[4].Value = worksheet.Cells[row, 3].Value;
                            data_row.Cells[5].Value = worksheet.Cells[row, 2].Value;
                            data_row.Cells[6].Value = worksheet.Cells[row, 5].Value;
                            data_row.Cells[7].Value = worksheet.Cells[row, 4].Value;
                            data_row.Cells[8].Value = worksheet.Cells[row, 6].Value;
                            data_row.Cells[9].Value = worksheet.Cells[row, 24].Value;
                            data_row.Cells[10].Value = worksheet.Cells[row, 31].Value;
                            dataGridView1.Rows.Add(data_row);
                        }

                    }
                }
            }
            else
            {
                button_save.Text = "Güncelle";
                string query = "";
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    query = $"SELECT * FROM dbo.Fatura WHERE alis_satis = 1"; //satış faturalarını getir
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
        }

        private void button_getir_Click(object sender, EventArgs e)
        {
            faturaSelected = false;
            dataGridView1.Rows.Clear();
            if (!(Form1.satisRaporu == null))
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(Form1.satisRaporu))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                    {
                        if (worksheet.Cells[row, 3].Value.ToString().Equals("S", StringComparison.OrdinalIgnoreCase))
                        {
                            if (text_faturano.Text.Length > 0)
                            {
                                if ((worksheet.Cells[row, 54].Value.ToString().Contains(text_faturano.Text, StringComparison.OrdinalIgnoreCase)))
                                {
                                    DataGridViewRow data_row = new DataGridViewRow();
                                    data_row.CreateCells(dataGridView1);
                                    data_row.Cells[0].Value = worksheet.Cells[row, 54].Value;
                                    data_row.Cells[1].Value = DateTime.FromOADate(Convert.ToDouble(worksheet.Cells[row, 8].Value));
                                    data_row.Cells[2].Value = worksheet.Cells[row, 58].Value;
                                    data_row.Cells[3].Value = worksheet.Cells[row, 11].Value;
                                    data_row.Cells[4].Value = worksheet.Cells[row, 3].Value;
                                    data_row.Cells[5].Value = worksheet.Cells[row, 2].Value;
                                    data_row.Cells[6].Value = worksheet.Cells[row, 5].Value;
                                    data_row.Cells[7].Value = worksheet.Cells[row, 4].Value;
                                    data_row.Cells[8].Value = worksheet.Cells[row, 6].Value;
                                    data_row.Cells[9].Value = worksheet.Cells[row, 24].Value;
                                    data_row.Cells[10].Value = worksheet.Cells[row, 31].Value;
                                    dataGridView1.Rows.Add(data_row);
                                }
                            }
                            else if (text_custname.Text.Length > 0)
                            {
                                if ((worksheet.Cells[row, 11].Value.ToString().Contains(text_custname.Text, StringComparison.OrdinalIgnoreCase)))
                                {
                                    DataGridViewRow data_row = new DataGridViewRow();
                                    data_row.CreateCells(dataGridView1);
                                    data_row.Cells[0].Value = worksheet.Cells[row, 54].Value;
                                    data_row.Cells[1].Value = DateTime.FromOADate(Convert.ToDouble(worksheet.Cells[row, 8].Value));
                                    data_row.Cells[2].Value = worksheet.Cells[row, 58].Value;
                                    data_row.Cells[3].Value = worksheet.Cells[row, 11].Value;
                                    data_row.Cells[4].Value = worksheet.Cells[row, 3].Value;
                                    data_row.Cells[5].Value = worksheet.Cells[row, 2].Value;
                                    data_row.Cells[6].Value = worksheet.Cells[row, 5].Value;
                                    data_row.Cells[7].Value = worksheet.Cells[row, 4].Value;
                                    data_row.Cells[8].Value = worksheet.Cells[row, 6].Value;
                                    data_row.Cells[9].Value = worksheet.Cells[row, 24].Value;
                                    data_row.Cells[10].Value = worksheet.Cells[row, 31].Value;
                                    dataGridView1.Rows.Add(data_row);
                                }
                            }
                            else if (text_faturano.Text.Length > 0 && text_custname.Text.Length > 0)
                            {
                                if ((worksheet.Cells[row, 54].Value.ToString().Contains(text_faturano.Text, StringComparison.OrdinalIgnoreCase)) && (worksheet.Cells[row, 11].Value.ToString().Contains(text_custname.Text, StringComparison.OrdinalIgnoreCase)))
                                {
                                    DataGridViewRow data_row = new DataGridViewRow();
                                    data_row.CreateCells(dataGridView1);
                                    data_row.Cells[0].Value = worksheet.Cells[row, 54].Value;
                                    data_row.Cells[1].Value = DateTime.FromOADate(Convert.ToDouble(worksheet.Cells[row, 8].Value));
                                    data_row.Cells[2].Value = worksheet.Cells[row, 58].Value;
                                    data_row.Cells[3].Value = worksheet.Cells[row, 11].Value;
                                    data_row.Cells[4].Value = worksheet.Cells[row, 3].Value;
                                    data_row.Cells[5].Value = worksheet.Cells[row, 2].Value;
                                    data_row.Cells[6].Value = worksheet.Cells[row, 5].Value;
                                    data_row.Cells[7].Value = worksheet.Cells[row, 4].Value;
                                    data_row.Cells[8].Value = worksheet.Cells[row, 6].Value;
                                    data_row.Cells[9].Value = worksheet.Cells[row, 24].Value;
                                    data_row.Cells[10].Value = worksheet.Cells[row, 31].Value;
                                    dataGridView1.Rows.Add(data_row);
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                string query = "";
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    if (text_faturano.Text.Length > 0)
                    {
                        query = $"SELECT * FROM dbo.Fatura WHERE eid LIKE '%@eid%' AND alis_satis = 1";
                        connection.Open();
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
                    else if (text_custname.Text.Length > 0)
                    {
                        query = $"SELECT * FROM dbo.Fatura WHERE musteri_ad LIKE '%@ad%' alis_satis = 1";
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
                    else if (text_faturano.Text.Length > 0 && text_custname.Text.Length > 0)
                    {
                        query = $"SELECT * FROM dbo.Fatura WHERE (eid LIKE '%@eid%' OR musteri_ad LIKE '%@ad%') AND alis_satis = 1";
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
                                    for (int i = 1; i < reader.FieldCount - 1; i++)
                                    {
                                        if (i == 5)
                                        {
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

        private void button_temizle_Click(object sender, EventArgs e)
        {
            faturaSelected = false;
            dataGridView1.Rows.Clear();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(Form1.satisRaporu))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                {
                    if (worksheet.Cells[row, 3].Value.ToString().Equals("S", StringComparison.OrdinalIgnoreCase))
                    {
                        DataGridViewRow data_row = new DataGridViewRow();
                        data_row.CreateCells(dataGridView1);
                        data_row.Cells[0].Value = worksheet.Cells[row, 54].Value;
                        data_row.Cells[1].Value = DateTime.FromOADate(Convert.ToDouble(worksheet.Cells[row, 8].Value));
                        data_row.Cells[2].Value = worksheet.Cells[row, 58].Value;
                        data_row.Cells[3].Value = worksheet.Cells[row, 11].Value;
                        data_row.Cells[4].Value = worksheet.Cells[row, 3].Value;
                        data_row.Cells[5].Value = worksheet.Cells[row, 2].Value;
                        data_row.Cells[6].Value = worksheet.Cells[row, 5].Value;
                        data_row.Cells[7].Value = worksheet.Cells[row, 4].Value;
                        data_row.Cells[8].Value = worksheet.Cells[row, 6].Value;
                        data_row.Cells[9].Value = worksheet.Cells[row, 24].Value;
                        data_row.Cells[10].Value = worksheet.Cells[row, 31].Value;
                        dataGridView1.Rows.Add(data_row);
                    }

                }
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Rows.Count >= 2)
            {
                int lastRowIndex = dataGridView1.Rows.Count - 2;
                if (e.RowIndex == lastRowIndex + 1)
                {
                    dataGridView1.Rows[lastRowIndex].Cells[4].Value = "A";
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            faturaSelected = false;
            bool didSave = false;
            DataTable dataTable = new DataTable();
            List<DataRow> dataList = new List<DataRow>();
            List<List<object>> dataGridRows = new List<List<object>>();
            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                query = $"SELECT eid, tarih, musteri_kod, musteri_ad, alis_satis, cins, miktar, kur, tutar_tl, tutar_dolar, belge_no FROM dbo.Fatura WHERE alis_satis = 0";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                        dataList = dataTable.Rows.Cast<DataRow>().ToList();
                    }
                }
                connection.Close();
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index != dataGridView1.NewRowIndex)
                {
                    List<object> rowData = new List<object>();
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        if (dataGridView1.Columns[i].Visible)
                        {
                            rowData.Add(dataGridView1.Rows[row.Index].Cells[i].Value);
                        }
                    }
                    dataGridRows.Add(rowData);
                }
            }

            foreach (List<object> dataRowList in dataGridRows)
            {
                bool rowExists = false;
                DataTable tempTable = new DataTable();
                DataRow rowToCheck = tempTable.NewRow();
                for (int i = 0; i < dataRowList.Count; i++)
                {
                    tempTable.Columns.Add("Column" + (i + 1), typeof(string));
                }
                for (int i = 0; i < dataRowList.Count; i++)
                {
                    rowToCheck[i] = dataRowList[i].ToString();
                }
                foreach (DataRow dataRow in dataList)
                {
                    bool isMatch = true;
                    for (int i = 0; i < dataRow.Table.Columns.Count; i++)
                    {

                        if (i == 4)
                        {
                            dataRow[i] = false;
                            rowToCheck[i] = false;
                        }
                        //MessageBox.Show(dataRow[i].ToString());
                        if (!dataRow[i].ToString().Equals(rowToCheck[i].ToString()))
                        {
                            isMatch = false;
                            break;
                        }
                    }
                    if (isMatch)
                    {
                        rowExists = true;
                        break;
                    }
                }
                if (!rowExists)
                {
                    try
                    {
                        dataRowList[4] = false;
                        string insertQuery = "INSERT INTO dbo.Fatura (eid, tarih, musteri_kod, musteri_ad, alis_satis, cins, miktar, kur, tutar_tl, tutar_dolar, belge_no, takipte) VALUES (@eid, @tarih, @musteri_kod, @musteri_ad, @alis_satis, @cins, @miktar, @kur, @tutar_tl, @tutar_dolar, @belge_no, 0)";
                        connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(insertQuery, connection))
                            {
                                command.Parameters.Clear();
                                command.Parameters.AddWithValue("@eid", dataRowList[0]);
                                command.Parameters.AddWithValue("@tarih", dataRowList[1]);
                                command.Parameters.AddWithValue("@musteri_kod", dataRowList[2]);
                                command.Parameters.AddWithValue("@musteri_ad", dataRowList[3]);
                                command.Parameters.AddWithValue("@alis_satis", dataRowList[4]);
                                command.Parameters.AddWithValue("@cins", dataRowList[5]);
                                command.Parameters.AddWithValue("@miktar", dataRowList[6]);
                                command.Parameters.AddWithValue("@kur", dataRowList[7]);
                                command.Parameters.AddWithValue("@tutar_tl", dataRowList[8]);
                                command.Parameters.AddWithValue("@tutar_dolar", dataRowList[9]);
                                command.Parameters.AddWithValue("@belge_no", dataRowList[10]);

                                command.ExecuteNonQuery();
                            }
                            didSave = true;
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Kayıt Yapılamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }
            if (didSave == true)
                MessageBox.Show("Gelen fatura kaydı başarıyla gerçekleştirildi!", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_new_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Kaydedilmemiş girdileriniz var. Eğer devam ederseniz bu girdileri kaybedeceksiniz.\nYeni fatura girişi yapmak istiyor musunuz?", "Yeni Fatura Girişi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    faturaSelected = false;
                    dataGridView1.Rows.Clear();
                }
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bu işleme devam ederseniz veritabanınızdaki mevcut faturanın tamamı silinecek.\nBu işlemi gerçekleştirmek istiyor musunuz?", "Faturayı Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM dbo.Fatura WHERE alis_satis = 1";
                    string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected == dataGridView1.Rows.Count - 1)
                            {
                                faturaSelected = false;
                                MessageBox.Show("Fatura başarıyla silindi.", "Fatura Silme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dataGridView1.Rows.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Fatura silinemedi.", "Fatura Silme Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                }
            }
        }

        private void button_takip_Click(object sender, EventArgs e)
        {
            if (faturaSelected == true)
            {
                DialogResult result = MessageBox.Show("Seçili faturayı takibe almak istiyor musunuz?", "Faturayı Takibe Al", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    faturaSelected = false;
                    if (!CheckIfFaturaExists(dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString()))
                    {
                        CreateFatura(dataGridView1.Rows[selectedRowIndex]);
                    }
                    string query = "UPDATE dbo.Fatura SET takipte = 1 WHERE eid = @eid";
                    string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@eid", dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString());
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show($"{dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString()} kodlu fatura başarıyla takibe alındı.", "Fatura Takibe Alındı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"{dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString()} kodlu fatura takibe alınamadı", "Fatura Takibe Alınamadı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }


                    //MessageBox.Show("faturayı takibe alma sistemi henüz oturmadı");
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Ekranda şu anda görünürde olan birden fazla fatura var. Bu faturaların hepsini takibe almak istiyor musunuz?", "Faturaları Takibe Al", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (!CheckIfFaturaExists(dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString()))
                    {
                        CreateFatura(dataGridView1.Rows[selectedRowIndex]);
                    }
                    string query = "UPDATE dbo.Fatura SET takipte = 1 WHERE eid = @eid";
                    string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@eid", dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString());
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show($"{dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString()} kodlu fatura başarıyla takibe alındı.", "Fatura Takibe Alındı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"{dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString()} kodlu fatura takibe alınamadı", "Fatura Takibe Alınamadı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    //MessageBox.Show("faturayı takibe alma sistemi henüz oturmadı");
                }
            }
        }

        private bool CheckIfFaturaExists(string eid)
        {
            bool output = false;
            string query = "SELECT * FROM dbo.Fatura WHERE eid = @eid";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@eid", eid);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        int count = (int)result;
                        output = count > 0;
                    }
                }
            }

            return output;
        }

        private void CreateFatura(DataGridViewRow row)
        {
            string insertQuery = "INSERT INTO dbo.Fatura (eid, tarih, musteri_kod, musteri_ad, alis_satis, cins, miktar, kur, tutar_tl, tutar_dolar, belge_no, takipte) VALUES (@eid, @tarih, @musteri_kod, @musteri_ad, @alis_satis, @cins, @miktar, @kur, @tutar_tl, @tutar_dolar, @belge_no, 0)";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@eid", row.Cells["eid"].Value);
                    command.Parameters.AddWithValue("@tarih", row.Cells["tarih"].Value);
                    command.Parameters.AddWithValue("@musteri_kod", row.Cells["musteri_kod"].Value);
                    command.Parameters.AddWithValue("@musteri_ad", row.Cells["ad_soyad"].Value);
                    command.Parameters.AddWithValue("@alis_satis", 1);
                    command.Parameters.AddWithValue("@cins", row.Cells["cins"].Value);
                    command.Parameters.AddWithValue("@miktar", row.Cells["miktar"].Value);
                    command.Parameters.AddWithValue("@kur", row.Cells["dovizkur"].Value);
                    command.Parameters.AddWithValue("@tutar_tl", row.Cells["tutar_tl"].Value);
                    command.Parameters.AddWithValue("@tutar_dolar", row.Cells["tutar_dolar"].Value);
                    command.Parameters.AddWithValue("@belge_no", row.Cells["belge_no"].Value);
                    int affectedRows = command.ExecuteNonQuery();
                    if (affectedRows == 0)
                    {
                        MessageBox.Show($"{dataGridView1.Rows[selectedRowIndex].Cells[0].ToString()} kodlu fatura takibe alınmak için veritabanına eklenirken hata oluştu", "Fatura Takibe Alınamadı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }

    }
}
