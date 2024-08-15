using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Evrak_Takibi_Programı
{
    internal static class DBKontrol
    {
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;";

        public static void DatabaseCheck()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM sys.databases WHERE name = 'evraktakibi'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int databaseExists = (int)command.ExecuteScalar();
                        if (databaseExists == 0)
                        {
                            string createDatabaseQuery = "CREATE DATABASE evraktakibi";
                            using (SqlCommand createCommand = new SqlCommand(createDatabaseQuery, connection))
                            {
                                createCommand.ExecuteNonQuery();
                                string useDatabaseQuery = "USE evraktakibi";
                                command.CommandText = useDatabaseQuery;
                                command.ExecuteNonQuery();
                                string adiOrtaklikQuery = @"
CREATE TABLE [dbo].[AdiOrtaklik] (
    [Id]                        INT            IDENTITY (1, 1) NOT NULL,
    [donem]                     INT            NOT NULL,
    [musteri_kodu]              INT            NOT NULL,
    [sirket_tipi]               NVARCHAR (50)  NULL,
    [ad_soyad]                  NVARCHAR (100) NOT NULL,
    [referans]                  NVARCHAR (100) NOT NULL,
    [telefon_no]                NCHAR (10)     NULL,
    [is_baslangic_tarih]        DATE           NULL,
    [eposta_adres]              NVARCHAR (50)  NULL,
    [sermaye]                   NVARCHAR (15)  NULL,
    [matrah]                    NVARCHAR (15)  NULL,
    [tahakkuk_vergi]            NVARCHAR (15)  NULL,
    [imza_sirkuleri]            DATE           NULL,
    [son_islem_tarihi]          DATE           NULL,
    [son_islem_amaci]           NVARCHAR (50)  NULL,
    [son_islem_tipi]            INT            NULL,
    [ortak1_vergino]            NVARCHAR(12)            NULL,
    [ortak1_tcno]               NCHAR (11)     NULL,
    [ortak1_faydalanici]        NVARCHAR (50)  NULL,
    [ortak2_vergino]            NVARCHAR(12)            NULL,
    [ortak2_tcno]               NCHAR (11)     NULL,
    [ortak2_faydalanici]        NVARCHAR (50)  NULL,
    [kayit_tarih]               DATE           NULL,
    [vergi_dairesi]             NVARCHAR (100) NULL,
    [dosya_ortakliksozlesmesi]  BIT            NULL,
    [dosya_tahakkukfisi]        BIT            NULL,
    [dosya_ortak1cerceve]       BIT            NULL,
    [dosya_ortak1kimlik]        BIT            NULL,
    [dosya_ortak1sirkuler]      DATE           NULL,
    [dosya_ortak1vergilevha]    NVARCHAR (4)   NULL,
    [dosya_ortak1faaliyetbelge] DATE           NULL,
    [dosya_ortak1faydalanici]   BIT            NULL,
    [dosya_ortak1imza]          IMAGE          NULL,
    [dosya_ortak1fotograf]      IMAGE          NULL,
    [dosya_ortak2cerceve]       BIT            NULL,
    [dosya_ortak2kimlik]        BIT            NULL,
    [dosya_ortak2sirkuler]      DATE           NULL,
    [dosya_ortak2vergilevha]    NVARCHAR (4)   NULL,
    [dosya_ortak2faaliyetbelge] DATE           NULL,
    [dosya_ortak2faydalanici]   BIT            NULL,
    [dosya_ortak2imza]          IMAGE          NULL,
    [dosya_ortak2fotograf]      IMAGE          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
";
                                command.CommandText = adiOrtaklikQuery;
                                command.ExecuteNonQuery();
                                string cerceveYetkiliQuery = @"
CREATE TABLE [dbo].[CerceveYetkili] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [musteri_kodu]      INT            NOT NULL,
    [tc_kimlikno]       NCHAR (11)     NOT NULL,
    [ad_soyad]          NVARCHAR (100) NOT NULL,
    [telefon_no]        NVARCHAR (11)  NULL,
    [dogum_yili]        INT            NULL,
    [dogum_yeri1]       NVARCHAR (50)  NULL,
    [dogum_yeri2]       NVARCHAR (50)  NULL,
    [meslek]            NVARCHAR (50)  NOT NULL,
    [gorev]             NVARCHAR (50)  NOT NULL,
    [kayit_tarih]       DATE           NOT NULL,
    [son_islem_tarihi]  DATE           NULL,
    [dosya_kimlikkarti] BIT            NULL,
    [dosya_imza]        IMAGE          NULL,
    [dosya_fotograf]    IMAGE          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
";
                                command.CommandText = cerceveYetkiliQuery;
                                command.ExecuteNonQuery();
                                string dikkatKaydiQuery = @"
CREATE TABLE [dbo].[DikkatKaydi] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [MusteriNo]  INT            NOT NULL,
    [MusteriAdi] NVARCHAR (50)  NOT NULL,
    [Referans]   INT            NOT NULL,
    [KayitTarih] DATE           NOT NULL,
    [IslemTarih] DATE           NOT NULL,
    [IslemAmac]  NVARCHAR (255) NOT NULL,
    [Durum]      BIT            NOT NULL
);
";
                                command.CommandText = dikkatKaydiQuery;
                                command.ExecuteNonQuery();
                                string faturaQuery = @"
CREATE TABLE [dbo].[Fatura] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [eid]         NVARCHAR (100) NOT NULL,
    [tarih]       DATE           NOT NULL,
    [musteri_kod] INT            NOT NULL,
    [musteri_ad]  NVARCHAR (100) NOT NULL,
    [alis_satis]  BIT            NOT NULL,
    [cins]        NVARCHAR (50)  NOT NULL,
    [miktar]      INT            NOT NULL,
    [kur]         DECIMAL (18)   NOT NULL,
    [tutar_tl]    DECIMAL (18)   NOT NULL,
    [tutar_dolar] DECIMAL (18)   NOT NULL,
    [belge_no]    NVARCHAR (50)  NOT NULL,
    [takipte]     BIT            DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
";
                                command.CommandText = faturaQuery;
                                command.ExecuteNonQuery();
                                string gercekKisiQuery = @"
CREATE TABLE [dbo].[GercekKisi] (
    [Id]                      INT            IDENTITY (1, 1) NOT NULL,
    [donem]                   INT            NOT NULL,
    [musteri_kodu]            INT            NOT NULL,
    [vergi_numarasi]          NVARCHAR(12)            NOT NULL,
    [tc_kimlikno]             NCHAR (11)     NOT NULL,
    [sirket_tipi]             NVARCHAR (50)  NULL,
    [ad_soyad]                NVARCHAR (100) NOT NULL,
    [referans]                NVARCHAR (100) NOT NULL,
    [telefon_no]              NCHAR (10)     NOT NULL,
    [is_baslangic_tarih]      DATE           NOT NULL,
    [eposta_adres]            NVARCHAR (50)  NULL,
    [sermaye]                 NVARCHAR (15)  NOT NULL,
    [matrah]                  NVARCHAR (15)  NOT NULL,
    [tahakkuk_vergi]          NVARCHAR (15)  NOT NULL,
    [imza_sirkuleri]          DATE           NOT NULL,
    [son_islem_tarihi]        DATE           NOT NULL,
    [son_islem_amaci]         NVARCHAR (50)  NULL,
    [son_islem_tipi]          INT            NOT NULL,
    [kayit_tarih]             DATE           NOT NULL,
    [vergi_dairesi]           NVARCHAR (100) NULL,
    [vergi_levhasi]           NVARCHAR (4)   NULL,
    [dosya_cercevesozlesmesi] BIT            NULL,
    [dosya_kimlik]            BIT            NULL,
    [dosya_imza]              IMAGE          NULL,
    [dosya_fotograf]          IMAGE          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
";
                                command.CommandText = gercekKisiQuery;
                                command.ExecuteNonQuery();
                                string sahisQuery = @"
CREATE TABLE [dbo].[Sahis] (
    [Id]                      INT            IDENTITY (1, 1) NOT NULL,
    [donem]                   INT            NOT NULL,
    [musteri_kodu]            INT            NOT NULL,
    [vergi_numarasi]          NVARCHAR(12)            NOT NULL,
    [tc_kimlikno]             NCHAR (11)     NOT NULL,
    [sirket_tipi]             NVARCHAR (50)  NULL,
    [ad_soyad]                NVARCHAR (100) NOT NULL,
    [referans]                NVARCHAR (100) NOT NULL,
    [telefon_no]              NCHAR (10)     NOT NULL,
    [is_baslangic_tarih]      DATE           NOT NULL,
    [eposta_adres]            NVARCHAR (50)  NULL,
    [sermaye]                 NVARCHAR (15)  NOT NULL,
    [matrah]                  NVARCHAR (15)  NOT NULL,
    [tahakkuk_vergi]          NVARCHAR (15)  NOT NULL,
    [imza_sirkuleri]          DATE           NOT NULL,
    [son_islem_tarihi]        DATE           NOT NULL,
    [son_islem_amaci]         NVARCHAR (50)  NULL,
    [son_islem_tipi]          INT            NOT NULL,
    [kayit_tarih]             DATE           NOT NULL,
    [dosya_cercevesozlesmesi] BIT            NULL,
    [dosya_kimlik]            BIT            NULL,
    [dosya_ikametgah]         BIT            NULL,
    [dosya_islakimza]         BIT            NULL,
    [dosya_imza]              IMAGE          NULL,
    [dosya_fotograf]          IMAGE          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
";
                                command.CommandText = sahisQuery;
                                command.ExecuteNonQuery();
                                string tuzelKisiQuery = @"
CREATE TABLE [dbo].[TuzelKisi] (
    [Id]                      INT            IDENTITY (1, 1) NOT NULL,
    [donem]                   INT            NOT NULL,
    [musteri_kodu]            INT            NOT NULL,
    [vergi_numarasi]          NVARCHAR(12)   NOT NULL,
    [ad_soyad]                NVARCHAR (100) NOT NULL,
    [referans]                NVARCHAR (100) NOT NULL,
    [telefon_no]              NCHAR (10)     NULL,
    [is_baslangic_tarih]      DATE           NULL,
    [eposta_adres]            NVARCHAR (50)  NULL,
    [gercek_faydalanici]      NVARCHAR (50)  NULL,
    [sermaye]                 NVARCHAR (15)  NULL,
    [matrah]                  NVARCHAR (15)  NULL,
    [tahakkuk_vergi]          NVARCHAR (15)  NULL,
    [imza_sirkuleri]          DATE           NULL,
    [son_islem_tarihi]        DATE           NULL,
    [son_islem_amaci]         NVARCHAR (50)  NULL,
    [son_islem_sayisi]        INT            NULL,
    [son_islem_tipi]          INT            NULL,
    [kayit_tarih]             DATE           NULL,
    [vergi_dairesi]           NVARCHAR (100) NULL,
    [vergi_levhasi]           NVARCHAR (4)   NULL,
    [dosya_cercevesozlesmesi] BIT            NULL,
    [dosya_kimlik]            BIT            NULL,
    [dosya_faaliyetbelgesi]   DATE           NULL,
    [dosya_ticaretsicil]      DATE           NULL,
    [dosya_faydalaniciform]   BIT            NULL,
    [dosya_imza]              IMAGE          NULL,
    [dosya_fotograf]          IMAGE          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
";
                                command.CommandText = tuzelKisiQuery;
                                command.ExecuteNonQuery();
                                string yetkiliQuery = @"
CREATE TABLE [dbo].[Yetkili] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [musteri_kodu]      INT            NOT NULL,
    [tc_kimlikno]       NCHAR (11)     NOT NULL,
    [ad_soyad]          NVARCHAR (100) NOT NULL,
    [telefon_no]        NVARCHAR (11)  NULL,
    [dogum_yili]        INT            NULL,
    [dogum_yeri1]       NVARCHAR (50)  NULL,
    [dogum_yeri2]       NVARCHAR (50)  NULL,
    [meslek]            NVARCHAR (50)  NOT NULL,
    [gorev]             NVARCHAR (50)  NOT NULL,
    [kayit_tarih]       DATE           NOT NULL,
    [son_islem_tarihi]  DATE           NULL,
    [dosya_kimlikkarti] BIT            NULL,
    [dosya_imza]        IMAGE          NULL,
    [dosya_fotograf]    IMAGE          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
";
                                command.CommandText = yetkiliQuery;
                                command.ExecuteNonQuery();
                                string sirketQuery = @"
CREATE TABLE [dbo].[Sirket] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [musteri_kodu]     INT            NOT NULL,
    [musteri_adi]      NVARCHAR (100) NULL,
    [tc_kimlik]        NVARCHAR (11)  NULL,
    [unvan]            NVARCHAR (100) NULL,
    [telefon_no]       NVARCHAR (11)  NULL,
    [eposta_adresi]    NVARCHAR (100) NULL,
    [yetkili_kisi]     NVARCHAR (100) NULL,
    [vergi_dairesi]    NVARCHAR (100) NULL,
    [vergi_no]         INT            NULL,
    [gelis_tarihi]     DATE           NULL,
    [adres]            NVARCHAR (300) NULL,
    [ilce]             NVARCHAR (50)  NULL,
    [il_kodu]          INT            NULL,
    [kullanici_sirket] BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


";
                                command.CommandText = sirketQuery;
                                command.ExecuteNonQuery();
                                string kullaniciQuery = @"
CREATE TABLE [dbo].[LisansDurum] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [kullanici_ad]        NVARCHAR (100) NOT NULL,
    [eposta]              NVARCHAR (100) NOT NULL,
    [telefon]             NVARCHAR (11)  NOT NULL,
    [kurulus]             NVARCHAR (100) NULL,
    [lisans_anahtari]     NVARCHAR (20)  NOT NULL,
    [son_kullanim_tarihi] DATE           NOT NULL
);
";
                                command.CommandText = kullaniciQuery;
                                command.ExecuteNonQuery();
                            }
                            MessageBox.Show("Veritabanı sistemi oluşturuldu.", "Veritabanı sistemi oluşturuldu.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                if (ex.Number == -2146232060)
                {
                    MessageBox.Show("Bilgisayarınızda LocalDB (Yerel Veritabanı) sistemi bulunamadı.\nLocalDB barındıran SQL Server Express 2019 yüklemesini yapmanız için ilgili sayfa açılacak. O sayfadan yüklemeyi yaptıktan sonra uygulamayı tekrar açın.", "LocalDB Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Process.Start("https://www.microsoft.com/en-us/download/details.aspx?id=101064");
                    Application.Exit();
                }
            }
        }
    }
}
