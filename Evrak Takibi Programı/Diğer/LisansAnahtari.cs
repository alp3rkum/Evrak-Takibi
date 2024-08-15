using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using iText.Layout.Splitting;
using Evrak_Takibi_Programı.Menü5;
using System.Data.SqlClient;

namespace Evrak_Takibi_Programı.Diğer
{
    public partial class LisansAnahtari : Form
    {
        private bool isMainMenu = true;
        private string trueKey = "";
        private bool keyFound = false;

        private KullaniciTanimla? kullaniciTanimla;
        private İlkKullanici? ilkKullaniciFormu;
        private KullaniciGuncelle? kullaniciGuncelle;
        public LisansAnahtari(bool isMainMenu, string trueKey="")
        {
            InitializeComponent();
            this.isMainMenu = isMainMenu;
            this.trueKey = trueKey;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(isMainMenu == true)
            {
                string key = Regex.Replace(text_licensekey.Text, "-", "");
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
                string query = "SELECT lisans_anahtari, son_kullanim_tarihi FROM dbo.LisansDurum WHERE lisans_anahtari = @Anahtar";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Anahtar", key);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string retrievedKey = reader.GetString(0);
                                DateTime sonTarih = reader.GetDateTime(1);
                                if(DateTime.Now <= sonTarih)
                                {
                                    if(key.Equals(retrievedKey,StringComparison.OrdinalIgnoreCase))
                                    {
                                        keyFound = true;
                                        if(DateTime.Now == sonTarih)
                                        {
                                            MessageBox.Show("Bugün yıllık aboneliğinizin son günü. Lütfen aboneliğinizi güncelleyin.", "Aboneliğinizi Güncelleyin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                        break;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Lütfen yıllık aboneliğinizi güncelleyin.", "Aboneliğinizi Güncelleyin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            }
                        }
                        
                    }

                    connection.Close();
                }
            }
            else
            {
                string key = Regex.Replace(text_licensekey.Text, "-", "");
                if(key.Equals(trueKey, StringComparison.OrdinalIgnoreCase))
                {
                    keyFound = true;
                }
            }

            if (keyFound == true)
            {
                MessageBox.Show("Lisans anahtarı doğru! İyi kullanımlar.", "Anahtar Doğru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                if(isMainMenu == true)
                {
                    this.Hide();
                    Form1 uygulama = new Form1();
                    uygulama.Show();
                }
                else
                {
                    kullaniciTanimla = Application.OpenForms.OfType<KullaniciTanimla>().FirstOrDefault();
                    ilkKullaniciFormu = Application.OpenForms.OfType<İlkKullanici>().FirstOrDefault();
                    if(kullaniciTanimla != null)
                        kullaniciTanimla.OnKeyFound();
                    if(ilkKullaniciFormu != null)
                        ilkKullaniciFormu.OnKeyFound();
                    if (kullaniciGuncelle != null)
                        kullaniciGuncelle.OnKeyFound();
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Lisans anahtarı yanlış", "Anahtar Yanlış", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LisansAnahtari_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (isMainMenu == true)
                {
                    Program.userClosed = true;
                    Application.Exit();
                }

                
            }
        }

        private void text_licensekey_TextChanged(object sender, EventArgs e)
        {
            string input = text_licensekey.Text;
            string pattern = @"^[A-Za-z0-9]{5}-[A-Za-z0-9]{5}-[A-Za-z0-9]{5}-[A-Za-z0-9]{5}$";
            if (Regex.IsMatch(input, pattern))
            {
                button1.Enabled = true; //DOESN'T 
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}
