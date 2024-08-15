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
    public partial class EksikEvrakRaporu : Form
    {
        EksikBelgeliKullaniciListesi eksikListe;
        internal static class TuzelKisiEksikleri
        {
            internal static int cerceveSozlesmesi;
            internal static int kimlikKarti;
            internal static int imzaSirkuleri;
            internal static int vergiLevhasi;
            internal static int faaliyetBelgesi;
            internal static int ticaretSicilGazetesi;
        }
        internal static class GercekKisiEksikleri
        {
            internal static int cerceveSozlesmesi;
            internal static int kimlikKarti;
            internal static int imzaSirkuleri;
            internal static int vergiLevhasi;
        }
        internal static class SahisEksikleri
        {
            internal static int cerceveSozlesmesi;
            internal static int kimlikKarti;
            internal static int imzaSirkuleri;
            internal static int ikametgah;
            internal static int islakimza;
        }
        internal static class AdiOrtaklikEksikleri
        {
            internal static int ortaklikSozlesmesi;
            internal static int tahakkukFisi;
            internal static int[] cerceveSozlesmesi = { 0, 0 };
            internal static int[] kimlikKarti = { 0, 0 };
            internal static int[] imzaSirkuleri = { 0, 0 };
            internal static int[] vergiLevhasi = { 0, 0 };
            internal static int[] faaliyetBelgesi = { 0, 0 };
        }

        internal static class YetkiliEksikleri
        {
            internal static int kimlikKarti;
        }

        internal static class CerceveYetkiliEksikleri
        {
            internal static int kimlikKarti;
        }
        public EksikEvrakRaporu()
        {
            InitializeComponent();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void EksikEvrakRaporu_Load(object sender, EventArgs e)
        {
            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                query = $"SELECT dosya_cercevesozlesmesi, dosya_kimlik, imza_sirkuleri, vergi_levhasi, dosya_faaliyetbelgesi, dosya_ticaretsicil FROM dbo.TuzelKisi";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.IsDBNull(reader.GetOrdinal("dosya_cercevesozlesmesi")))
                            {
                                TuzelKisiEksikleri.cerceveSozlesmesi++;
                            }
                            if (reader.IsDBNull(reader.GetOrdinal("dosya_kimlik")))
                            {
                                TuzelKisiEksikleri.kimlikKarti++;
                            }
                            if (reader.IsDBNull(reader.GetOrdinal("imza_sirkuleri")))
                            {
                                TuzelKisiEksikleri.imzaSirkuleri++;
                            }
                            if (reader.IsDBNull(reader.GetOrdinal("vergi_levhasi")))
                            {
                                TuzelKisiEksikleri.vergiLevhasi++;
                            }
                            if (reader.IsDBNull(reader.GetOrdinal("dosya_faaliyetbelgesi")))
                            {
                                TuzelKisiEksikleri.faaliyetBelgesi++;
                            }
                            if (reader.IsDBNull(reader.GetOrdinal("dosya_ticaretsicil")))
                            {
                                TuzelKisiEksikleri.ticaretSicilGazetesi++;
                            }
                        }
                    }
                    label_cerceve1.Text = TuzelKisiEksikleri.cerceveSozlesmesi.ToString();
                    label_kimlik1.Text = TuzelKisiEksikleri.kimlikKarti.ToString();
                    label_imza1.Text = TuzelKisiEksikleri.imzaSirkuleri.ToString();
                    label_vergi1.Text = TuzelKisiEksikleri.vergiLevhasi.ToString();
                    label_faaliyet1.Text = TuzelKisiEksikleri.faaliyetBelgesi.ToString();
                    label_ticaret1.Text = TuzelKisiEksikleri.ticaretSicilGazetesi.ToString();

                }
                query = $"SELECT dosya_cercevesozlesmesi, dosya_kimlik, imza_sirkuleri, vergi_levhasi FROM dbo.GercekKisi";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.IsDBNull(reader.GetOrdinal("dosya_cercevesozlesmesi")))
                            {
                                GercekKisiEksikleri.cerceveSozlesmesi++;
                            }

                            if (reader.IsDBNull(reader.GetOrdinal("dosya_kimlik")))
                            {
                                GercekKisiEksikleri.kimlikKarti++;
                            }

                            if (reader.IsDBNull(reader.GetOrdinal("imza_sirkuleri")))
                            {
                                GercekKisiEksikleri.imzaSirkuleri++;
                            }

                            if (reader.IsDBNull(reader.GetOrdinal("vergi_levhasi")))
                            {
                                GercekKisiEksikleri.vergiLevhasi++;
                            }
                        }
                    }
                    label_cerceve2.Text = GercekKisiEksikleri.cerceveSozlesmesi.ToString();
                    label_kimlik2.Text = GercekKisiEksikleri.kimlikKarti.ToString();
                    label_imza2.Text = GercekKisiEksikleri.imzaSirkuleri.ToString();
                    label_vergi2.Text = GercekKisiEksikleri.vergiLevhasi.ToString();

                }
                query = $"SELECT dosya_cercevesozlesmesi, dosya_kimlik, imza_sirkuleri, dosya_ikametgah, dosya_islakimza FROM dbo.Sahis";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.IsDBNull(reader.GetOrdinal("dosya_cercevesozlesmesi")))
                            {
                                SahisEksikleri.cerceveSozlesmesi++;
                            }
                            if (reader.IsDBNull(reader.GetOrdinal("dosya_kimlik")))
                            {
                                SahisEksikleri.kimlikKarti++;
                            }
                            if (reader.IsDBNull(reader.GetOrdinal("imza_sirkuleri")))
                            {
                                SahisEksikleri.imzaSirkuleri++;
                            }
                            if (reader.IsDBNull(reader.GetOrdinal("dosya_ikametgah")))
                            {
                                SahisEksikleri.ikametgah++;
                            }
                            if (reader.IsDBNull(reader.GetOrdinal("dosya_islakimza")))
                            {
                                SahisEksikleri.islakimza++;
                            }
                        }
                    }
                    label_cerceve3.Text = SahisEksikleri.cerceveSozlesmesi.ToString();
                    label_kimlik3.Text = SahisEksikleri.kimlikKarti.ToString();
                    label_imza3.Text = SahisEksikleri.imzaSirkuleri.ToString();
                    label_ikametgah.Text = SahisEksikleri.ikametgah.ToString();
                    label_islakimza.Text = SahisEksikleri.islakimza.ToString();

                }
                query = $"SELECT dosya_ortakliksozlesmesi, dosya_tahakkukfisi, dosya_ortak1cerceve, dosya_ortak1kimlik, dosya_ortak1sirkuler, dosya_ortak1vergilevha, dosya_ortak1faaliyetbelge, dosya_ortak2cerceve, dosya_ortak2kimlik, dosya_ortak2sirkuler, dosya_ortak2vergilevha, dosya_ortak2faaliyetbelge FROM dbo.AdiOrtaklik";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.IsDBNull(reader.GetOrdinal("dosya_ortakliksozlesmesi")))
                            {
                                AdiOrtaklikEksikleri.ortaklikSozlesmesi++;
                            }

                            if (reader.IsDBNull(reader.GetOrdinal("dosya_tahakkukfisi")))
                            {
                                AdiOrtaklikEksikleri.tahakkukFisi++;
                            }

                            if (reader.IsDBNull(reader.GetOrdinal("dosya_ortak1cerceve")))
                            {
                                AdiOrtaklikEksikleri.cerceveSozlesmesi[0]++;
                            }

                            if (reader.IsDBNull(reader.GetOrdinal("dosya_ortak1kimlik")))
                            {
                                AdiOrtaklikEksikleri.kimlikKarti[0]++;
                            }

                            if (reader.IsDBNull(reader.GetOrdinal("dosya_ortak1sirkuler")))
                            {
                                AdiOrtaklikEksikleri.imzaSirkuleri[0]++;
                            }

                            if (reader.IsDBNull(reader.GetOrdinal("dosya_ortak1vergilevha")))
                            {
                                AdiOrtaklikEksikleri.vergiLevhasi[0]++;
                            }

                            if (reader.IsDBNull(reader.GetOrdinal("dosya_ortak1faaliyetbelge")))
                            {
                                AdiOrtaklikEksikleri.faaliyetBelgesi[0]++;
                            }
                            if (reader.IsDBNull(reader.GetOrdinal("dosya_ortak2cerceve")))
                            {
                                AdiOrtaklikEksikleri.cerceveSozlesmesi[1]++;
                            }
                            if (reader.IsDBNull(reader.GetOrdinal("dosya_ortak2kimlik")))
                            {
                                AdiOrtaklikEksikleri.kimlikKarti[1]++;
                            }
                            if (reader.IsDBNull(reader.GetOrdinal("dosya_ortak2sirkuler")))
                            {
                                AdiOrtaklikEksikleri.imzaSirkuleri[1]++;
                            }
                            if (reader.IsDBNull(reader.GetOrdinal("dosya_ortak2vergilevha")))
                            {
                                AdiOrtaklikEksikleri.vergiLevhasi[1]++;
                            }
                            if (reader.IsDBNull(reader.GetOrdinal("dosya_ortak2faaliyetbelge")))
                            {
                                AdiOrtaklikEksikleri.faaliyetBelgesi[1]++;
                            }
                        }
                    }
                    label_adiortaklik.Text = AdiOrtaklikEksikleri.ortaklikSozlesmesi.ToString();
                    label_tahakkuk.Text = AdiOrtaklikEksikleri.tahakkukFisi.ToString();
                    label_cerceve41.Text = AdiOrtaklikEksikleri.cerceveSozlesmesi[0].ToString();
                    label_cerceve42.Text = AdiOrtaklikEksikleri.cerceveSozlesmesi[1].ToString();
                    label_kimlik41.Text = AdiOrtaklikEksikleri.kimlikKarti[0].ToString();
                    label_kimlik42.Text = AdiOrtaklikEksikleri.kimlikKarti[1].ToString();
                    label_imza41.Text = AdiOrtaklikEksikleri.imzaSirkuleri[0].ToString();
                    label_imza42.Text = AdiOrtaklikEksikleri.imzaSirkuleri[1].ToString();
                    label_vergi41.Text = AdiOrtaklikEksikleri.vergiLevhasi[0].ToString();
                    label_vergi42.Text = AdiOrtaklikEksikleri.vergiLevhasi[1].ToString();
                    label_faaliyet41.Text = AdiOrtaklikEksikleri.faaliyetBelgesi[0].ToString();
                    label_faaliyet42.Text = AdiOrtaklikEksikleri.faaliyetBelgesi[1].ToString();
                }
                query = $"SELECT dosya_kimlikkarti FROM dbo.Yetkili";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.IsDBNull(reader.GetOrdinal("dosya_kimlikkarti")))
                            {
                                YetkiliEksikleri.kimlikKarti++;
                            }
                        }
                    }
                    label_kimlik5.Text = YetkiliEksikleri.kimlikKarti.ToString();
                }
                query = $"SELECT dosya_kimlikkarti FROM dbo.CerceveYetkili";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.IsDBNull(reader.GetOrdinal("dosya_kimlikkarti")))
                            {
                                CerceveYetkiliEksikleri.kimlikKarti++;
                            }
                        }
                    }
                    label_kimlik6.Text = CerceveYetkiliEksikleri.kimlikKarti.ToString();
                }
            }
        }

        private void label_cerceve1_Click(object sender, EventArgs e)
        {
            if (label_cerceve1.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(0, 0);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_kimlik1_Click(object sender, EventArgs e)
        {
            if (label_kimlik1.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(0, 1);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_imza1_Click(object sender, EventArgs e)
        {
            if (label_imza1.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(0, 2);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_vergi1_Click(object sender, EventArgs e)
        {
            if (label_vergi1.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(0, 3);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_faaliyet1_Click(object sender, EventArgs e)
        {
            if (label_faaliyet1.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(0, 4);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_ticaret1_Click(object sender, EventArgs e)
        {
            if (label_ticaret1.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(0, 5);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_cerceve2_Click(object sender, EventArgs e)
        {
            if (label_cerceve2.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(1, 0);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_kimlik2_Click(object sender, EventArgs e)
        {
            if (label_kimlik2.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(1, 1);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_imza2_Click(object sender, EventArgs e)
        {
            if (label_imza2.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(1, 2);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_vergi2_Click(object sender, EventArgs e)
        {
            if (label_vergi2.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(1, 3);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_cerceve3_Click(object sender, EventArgs e)
        {
            if (label_cerceve3.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(2, 0);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_kimlik3_Click(object sender, EventArgs e)
        {
            if (label_kimlik3.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(2, 1);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_imza3_Click(object sender, EventArgs e)
        {
            if (label_imza3.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(2, 2);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_ikametgah_Click(object sender, EventArgs e)
        {
            if (label_ikametgah.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(2, 6);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_islakimza_Click(object sender, EventArgs e)
        {
            if (label_islakimza.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(2, 7);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_adiortaklik_Click(object sender, EventArgs e)
        {
            if (label_adiortaklik.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(3, 18);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_tahakkuk_Click(object sender, EventArgs e)
        {
            if (label_tahakkuk.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(3, 19);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_cerceve41_Click(object sender, EventArgs e)
        {
            if (label_cerceve41.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(3, 8);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_cerceve42_Click(object sender, EventArgs e)
        {
            if (label_cerceve42.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(3, 13);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_kimlik41_Click(object sender, EventArgs e)
        {
            if (label_kimlik41.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(3, 9);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_kimlik42_Click(object sender, EventArgs e)
        {
            if (label_kimlik42.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(3, 14);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_imza41_Click(object sender, EventArgs e)
        {
            if (label_imza41.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(3, 10);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_imza42_Click(object sender, EventArgs e)
        {
            if (label_imza42.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(3, 15);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_vergi41_Click(object sender, EventArgs e)
        {
            if (label_vergi41.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(3, 11);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_vergi42_Click(object sender, EventArgs e)
        {
            if (label_vergi42.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(3, 16);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_faaliyet41_Click(object sender, EventArgs e)
        {
            if (label_faaliyet41.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(3, 12);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_faaliyet42_Click(object sender, EventArgs e)
        {
            if (label_faaliyet42.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(3, 17);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_kimlik5_Click(object sender, EventArgs e)
        {
            if (label_kimlik5.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(4, 1);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label_kimlik6_Click(object sender, EventArgs e)
        {
            if (label_kimlik6.Text != "0")
            {
                eksikListe = new EksikBelgeliKullaniciListesi(5, 1);
                eksikListe.Show();
            }
            else
            {
                MessageBox.Show("Bu türde bu belgesi eksik olan müşteri yok.", "Eksik Belge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
