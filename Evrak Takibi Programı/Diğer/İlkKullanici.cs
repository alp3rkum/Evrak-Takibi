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
    public partial class İlkKullanici : Form
    {
        string key = "";
        DateTime sonTarih = new DateTime();
        public İlkKullanici()
        {
            InitializeComponent();
        }

        private bool YeterliGirdilerGirili()
        {
            bool gerekliGirdilerGirili = true;
            foreach (Control control in this.Controls)
            {
                if (control is MaskedTextBox maskedTextBox && string.IsNullOrEmpty(maskedTextBox.Text))
                {
                    gerekliGirdilerGirili = false;
                    break;
                }
                else if (control is System.Windows.Forms.TextBox textBox && string.IsNullOrEmpty(textBox.Text))
                {
                    gerekliGirdilerGirili = false;
                    break;
                }
            }
            return gerekliGirdilerGirili;
        }

        private void checkInput(object sender, EventArgs e)
        {
            button1.Enabled = YeterliGirdilerGirili();
        }

        public void OnKeyFound()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            string query = "INSERT INTO dbo.LisansDurum(kullanici_ad, eposta, telefon, kurulus, lisans_anahtari, son_kullanim_tarihi) VALUES (@AdSoyad,@Eposta,@Telefon,@Kurulus,@LisansAnahtari,@SonKullanimTarihi)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AdSoyad", text_username.Text);
                    command.Parameters.AddWithValue("@Eposta", text_email.Text);
                    command.Parameters.AddWithValue("@Telefon", text_phone.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", ""));
                    command.Parameters.AddWithValue("@Kurulus", text_company.Text);
                    command.Parameters.AddWithValue("@LisansAnahtari", key);
                    command.Parameters.AddWithValue("@SonKullanimTarihi", sonTarih);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Kullanıcı kaydı başarıyla gerçekleştirildi!\nLisans anahtarınız {sonTarih.ToString("dd.MM.yyyy")} gününe kadar geçerli.", "Kullanıcı Kaydı Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1 application = new Form1();
                        application.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            key = new LisansAnahtarı(text_username.Text, text_email.Text, text_phone.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", ""), text_company.Text).AnahtarOlustur();
            sonTarih = DateTime.Today.AddYears(1);
            LisansAnahtari anahtarDiyalog = new LisansAnahtari(false, key);
            anahtarDiyalog.Show();
        }
    }
}
