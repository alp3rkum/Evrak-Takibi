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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Evrak_Takibi_Programı.Diğer
{
    public partial class EksikBelgeliKullaniciListesi : Form
    {
        private int musteriTipi;
        private int belgeTipi;
        public EksikBelgeliKullaniciListesi(int musteriTipi = 0, int belgeTipi = 0)
        {
            this.musteriTipi = musteriTipi;
            this.belgeTipi = belgeTipi;
            InitializeComponent();
        }

        private void EksikBelgeliKullaniciListesi_Load(object sender, EventArgs e)
        {
            string tablo_adi = "";
            string sutun_adi = "";
            switch(musteriTipi)
            {
                case 0:
                    tablo_adi = "dbo.TuzelKisi"; break;
                case 1:
                    tablo_adi = "dbo.GercekKisi"; break;
                case 2:
                    tablo_adi = "dbo.Sahis"; break;
                case 3:
                    tablo_adi = "dbo.AdiOrtaklik"; break;
                case 4:
                    tablo_adi = "dbo.Yetkili"; break;
                case 5:
                    tablo_adi = "dbo.CerceveYetkili"; break;
            }
            switch(belgeTipi)
            {
                case 0:
                    sutun_adi = "dosya_cercevesozlesmesi"; break;
                case 1:
                    if (musteriTipi < 4)
                        sutun_adi = "dosya_kimlik";
                    else
                        sutun_adi = "dosya_kimlikkarti"; break;
                case 2:
                    sutun_adi = "dosya_imzasirkuleri"; break;
                case 3:
                    sutun_adi = "dosya_vergilevhasi"; break;
                case 4:
                    sutun_adi = "dosya_faaliyetbelgesi"; break;
                case 5:
                    sutun_adi = "dosya_ticaretsicil"; break;
                case 6:
                    sutun_adi = "dosya_ikametgah"; break;
                case 7:
                    sutun_adi = "dosya_islakimza"; break;
                case 8:
                    sutun_adi = "dosya_ortak1cerceve"; break;
                case 9:
                    sutun_adi = "dosya_ortak1kimlik"; break;
                case 10:
                    sutun_adi = "dosya_ortak1sirkuler"; break;
                case 11:
                    sutun_adi = "dosya_ortak1vergilevha"; break;
                case 12:
                    sutun_adi = "dosya_ortak1faaliyetbelge"; break;
                case 13:
                    sutun_adi = "dosya_ortak2cerceve"; break;
                case 14:
                    sutun_adi = "dosya_ortak2kimlik"; break;
                case 15:
                    sutun_adi = "dosya_ortak2sirkuler"; break;
                case 16:
                    sutun_adi = "dosya_ortak2vergilevha"; break;
                case 17:
                    sutun_adi = "dosya_ortak2faaliyetbelge"; break;
                case 18:
                    sutun_adi = "dosya_ortakliksozlesmesi"; break;
                case 19:
                    sutun_adi = "dosya_tahakkukfisi"; break;
            }
            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                query = $"SELECT ad_soyad FROM {tablo_adi} WHERE {sutun_adi} IS NULL";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        StringBuilder sb = new StringBuilder();
                        while (reader.Read())
                        {
                            string adSoyad = reader.GetString(reader.GetOrdinal("ad_soyad"));
                            sb.AppendLine(adSoyad);
                        }
                        text_userlist.Text = sb.ToString();
                    }
                }
            }
        }
    }
}
