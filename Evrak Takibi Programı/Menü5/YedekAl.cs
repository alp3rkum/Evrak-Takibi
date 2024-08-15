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

namespace Evrak_Takibi_Programı.Menü5
{
    public partial class YedekAl : Form
    {
        public YedekAl()
        {
            InitializeComponent();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string filePath = "yedek.bak";
            string absolutePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath));
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            DialogResult result = MessageBox.Show("Veritabanını yedeğe alma işlemini gerçekleştireceksiniz.\nİşleme devam etmek istiyor musunuz?", "Veritabanını Yedeğe Al", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"BACKUP DATABASE evraktakibi TO DISK = @BackupPath";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BackupPath", absolutePath);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                MessageBox.Show("Veritabanı başarıyla yedeklendi!", "Yedekleme Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label_status.Text = "Veritabanı geri yükleniyor. Lütfen bekleyin...";
            string filePath = "yedek.bak";
            string absolutePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath));
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True";
            DialogResult result = MessageBox.Show("Veritabanını yedekten geri yükleme işlemini gerçekleştireceksiniz.\nİşleme devam etmek istiyor musunuz?", "Veritabanını Geri Yükle", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "ALTER DATABASE evraktakibi SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    query = $"RESTORE DATABASE evraktakibi FROM DISK = @BackupPath WITH REPLACE";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BackupPath", absolutePath);
                        command.ExecuteNonQuery();
                    }
                    query = "ALTER DATABASE evraktakibi SET MULTI_USER";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                MessageBox.Show("Veritabanı başarıyla geri yüklendi!", "Geri Yükleme Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label_status.Text = "";
            }
            else
            {
                label_status.Text = "";
            }
        }
    }
}
