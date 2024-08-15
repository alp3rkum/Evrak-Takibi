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
using static Evrak_Takibi_Programı.YeniTuzel;
using System.Globalization;

using iText.Kernel.Pdf;
using iText.Kernel.Font;
using static iText.Kernel.Font.PdfFontFactory;
using iText.IO.Font;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Borders;
using iText.Layout.Font;
using iText.IO.Font.Constants;
using AxSHDocVw;
using SHDocVw;
using System.IO;
using OfficeOpenXml;
using iText.Kernel.Colors;
using System.Drawing.Printing;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Xobject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iText.IO.Image;
using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Colors.Gradients;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using Microsoft.Web.WebView2.Core;
using iText.Kernel.Geom;
using System.Security.Policy;

namespace Evrak_Takibi_Programı.Diğer
{
    public partial class DosyaGoster : Form
    {
        private bool isYetkiliKontrol;
        private int file_type;
        private string name;
        private string customer_type;
        List<object> customer_info = new List<object>();

        byte[] pdfBytes;
        string base64String;
        string tempPdfFilePath;

        public static int eslesmeSayisi;
        public static int percentage;

        public DosyaGoster(int filetype, string customername, string customertype, bool isYetkiliKontrol)
        {
            this.file_type = filetype;
            this.name = customername;
            this.customer_type = customertype;
            this.isYetkiliKontrol = isYetkiliKontrol;
            InitializeComponent();
        }

        public DosyaGoster(int filetype, string customername, string customertype, bool isYetkiliKontrol, List<object> yetkili_info)
        {
            this.file_type = filetype;
            this.name = customername;
            this.customer_type = customertype;
            this.isYetkiliKontrol = isYetkiliKontrol;
            this.customer_info = yetkili_info;
            InitializeComponent();
        }

        private void DosyaGoster_Load(object sender, EventArgs e)
        {
            if(isYetkiliKontrol == true)
            {
                button_save.BackColor = button_print.BackColor = System.Drawing.Color.FromArgb(255, 72, 106, 169);
            }
            string query = "";
            string[] queries = new string[] { $"SELECT * FROM dbo.TuzelKisi WHERE ad_soyad = @AdSoyad", $"SELECT * FROM dbo.GercekKisi WHERE ad_soyad = @AdSoyad", $"SELECT * FROM dbo.Sahis WHERE ad_soyad = @AdSoyad", $"SELECT * FROM dbo.AdiOrtaklik WHERE ad_soyad = @AdSoyad" };
            int[] fileCounts = new int[] { 8, 6, 6, 16 };
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = new PdfWriter(memoryStream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            PdfFont mainFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA, "Cp1254");
            PdfFont titleFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD, "Cp1254");
            PdfFont italicFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_OBLIQUE, "Cp1254");
            PdfFont bolditalicFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLDOBLIQUE, "Cp1254");
            switch (customer_type)
            {
                case "Tüzel Kişi":
                    {
                        query = $"SELECT * FROM dbo.TuzelKisi WHERE ad_soyad = @AdSoyad";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@AdSoyad", name);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    int columnCount = reader.FieldCount;
                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < columnCount - 8; i++)
                                        {
                                            customer_info.Add(reader.GetValue(i));
                                        }
                                    }
                                }
                            }
                        }

                    }
                    break;
                case "Gerçek Kişi":
                    {
                        query = $"SELECT * FROM dbo.GercekKisi WHERE ad_soyad = @AdSoyad";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@AdSoyad", name);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    int columnCount = reader.FieldCount;
                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < columnCount - 6; i++)
                                        {
                                            customer_info.Add(reader.GetValue(i));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case "Şahıs":
                    {
                        query = $"SELECT * FROM dbo.Sahis WHERE ad_soyad = @AdSoyad";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@AdSoyad", name);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    int columnCount = reader.FieldCount;
                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < columnCount - 6; i++)
                                        {
                                            customer_info.Add(reader.GetValue(i));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case "Adi Ortaklık":
                    {
                        query = $"SELECT * FROM dbo.AdiOrtaklik WHERE ad_soyad = @AdSoyad";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@AdSoyad", name);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    int columnCount = reader.FieldCount;
                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < columnCount - 16; i++)
                                        {
                                            customer_info.Add(reader.GetValue(i));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                default:
                    {
                        for(int i = 0; i < queries.Count(); i++)
                        {
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                using (SqlCommand command = new SqlCommand(queries[i], connection))
                                {
                                    command.Parameters.AddWithValue("@AdSoyad", name);
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        
                                        if (reader.HasRows)
                                        {
                                            int columnCount = reader.FieldCount;
                                            while (reader.Read())
                                            {
                                                for (int j = 0; j < columnCount - fileCounts[i]; j++)
                                                {
                                                    customer_info.Add(reader.GetValue(i));
                                                }
                                            }
                                        }
                                        
                                    }
                                }
                            }
                        }
                    }
                    break;
                case "Yetkili Kişi":
                    {
                        query = "SELECT * FROM dbo.Yetkili WHERE ad_soyad = @AdSoyad UNION ALL SELECT * FROM dbo.CerceveYetkili WHERE ad_soyad = @AdSoyad";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@AdSoyad", name);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    int columnCount = reader.FieldCount;
                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < columnCount - 3; i++)
                                        {
                                            customer_info.Add(reader.GetValue(i));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
            if(!(file_type == 3 || file_type == 4))
            {
                Table topTable = new Table(2);
                topTable.SetWidth(UnitValue.CreatePercentValue(100));

                Cell leftCell = new Cell();
                Cell rightCell = new Cell();
                leftCell.SetBorder(Border.NO_BORDER);
                rightCell.SetBorder(Border.NO_BORDER);
                leftCell.SetFont(mainFont);
                rightCell.SetFont(mainFont);
                leftCell.Add(new Cell());
                leftCell.SetTextAlignment(TextAlignment.LEFT);
                topTable.AddCell(leftCell);
                rightCell.Add(new Paragraph(DateTime.Today.ToString("dd MMMM yyyy")).SetFont(mainFont).SetFontSize(8));
                rightCell.SetTextAlignment(TextAlignment.RIGHT);
                topTable.AddCell(rightCell);
                document.Add(topTable);
            }
            

            switch (file_type)
            {
                case 0:
                    {
                        //başlık
                        Paragraph title = new Paragraph("\nMÜŞTERİ KONTROLÜ").SetFontSize(12).SetFont(titleFont).SetTextAlignment(TextAlignment.CENTER);
                        document.Add(title);
                        //alt başlık
                        Paragraph sub_title = new Paragraph("\nMÜŞTERİ BİLGİLERİ\n").SetFontSize(10).SetFont(titleFont).SetTextAlignment(TextAlignment.CENTER);
                        document.Add(sub_title);
                        //tablo (satır 1)
                        Table table_row1 = new Table(4);
                        table_row1.SetWidth(UnitValue.CreatePercentValue(100));
                        table_row1.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        table_row1.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(42)).Add(new Paragraph("Müşteri No:").SetFont(titleFont).SetFontSize(8)));
                        table_row1.AddCell(new Paragraph(customer_info[2].ToString()).SetFont(mainFont).SetFontSize(8));
                        table_row1.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(18)).Add(new Paragraph("Son İşlem Tarihi:").SetFont(titleFont).SetFontSize(8)));
                        switch (customer_type)
                        {
                            case "Tüzel Kişi":
                                table_row1.AddCell(new Paragraph(customer_info[14].ToString().Replace("00:00:00", "")).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Gerçek Kişi":
                                table_row1.AddCell(new Paragraph(customer_info[15].ToString().Replace("00:00:00", "")).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Şahıs":
                                table_row1.AddCell(new Paragraph(customer_info[15].ToString().Replace("00:00:00", "")).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Adi Ortaklık":
                                table_row1.AddCell(new Paragraph(customer_info[13].ToString().Replace("00:00:00", "")).SetFont(mainFont).SetFontSize(8));
                                break;
                        }
                        document.Add(table_row1);
                        //tablo (satır 2)
                        Table table_row2 = new Table(2);
                        table_row2.SetWidth(UnitValue.CreatePercentValue(100));
                        table_row2.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        table_row2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(42)).Add(new Paragraph("Ad Soyad & Unvan:").SetFont(titleFont).SetFontSize(8)));
                        switch (customer_type)
                        {
                            case "Tüzel Kişi":
                                table_row2.AddCell(new Paragraph(customer_info[4].ToString()).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Gerçek Kişi":
                                table_row2.AddCell(new Paragraph(customer_info[6].ToString()).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Şahıs":
                                table_row2.AddCell(new Paragraph(customer_info[6].ToString()).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Adi Ortaklık":
                                table_row2.AddCell(new Paragraph(customer_info[4].ToString()).SetFont(mainFont).SetFontSize(8));
                                break;
                        }
                        document.Add(table_row2);
                        //tablo (kayıt tarihi)
                        Table table_rowkayit = new Table(2);
                        table_rowkayit.SetWidth(UnitValue.CreatePercentValue(100));
                        table_rowkayit.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        table_rowkayit.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(42)).Add(new Paragraph("Kayıt Tarihi:").SetFont(titleFont).SetFontSize(8)));
                        switch (customer_type)
                        {
                            case "Tüzel Kişi":
                                table_rowkayit.AddCell(new Paragraph(customer_info[18].ToString().Replace("00:00:00","")).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Gerçek Kişi":
                                table_rowkayit.AddCell(new Paragraph(customer_info[18].ToString().Replace("00:00:00", "")).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Şahıs":
                                table_rowkayit.AddCell(new Paragraph(customer_info[18].ToString().Replace("00:00:00", "")).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Adi Ortaklık":
                                table_rowkayit.AddCell(new Paragraph(customer_info[22].ToString().Replace("00:00:00", "")).SetFont(mainFont).SetFontSize(8));
                                break;
                        }
                        document.Add(table_rowkayit);
                        //tablo (tc kimlik)
                        if (customer_type == "Gerçek Kişi" || customer_type == "Şahıs")
                        {
                            Table table_tcno = new Table(2);
                            table_tcno.SetWidth(UnitValue.CreatePercentValue(100));
                            table_tcno.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                            table_tcno.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(42)).Add(new Paragraph("TC Kimlik Numarası:").SetFont(titleFont).SetFontSize(8)));
                            table_tcno.AddCell(new Paragraph(customer_info[4].ToString()).SetFont(mainFont).SetFontSize(8));
                            document.Add(table_tcno);
                        }
                        else if (customer_type == "Adi Ortaklık")
                        {
                            Table table_tcno = new Table(3);
                            table_tcno.SetWidth(UnitValue.CreatePercentValue(100));
                            table_tcno.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                            table_tcno.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(42)).Add(new Paragraph("TC Kimlik Numaraları:").SetFont(titleFont).SetFontSize(8)));
                            table_tcno.AddCell(new Paragraph(customer_info[17].ToString()).SetFont(mainFont).SetFontSize(8));
                            table_tcno.AddCell(new Paragraph(customer_info[20].ToString()).SetFont(mainFont).SetFontSize(8));
                            document.Add(table_tcno);
                        }
                        //tablo (satır 3)
                        if (customer_type != "Adi Ortaklık")
                        {
                            Table table_row3 = new Table(2);
                            table_row3.SetWidth(UnitValue.CreatePercentValue(100));
                            table_row3.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                            table_row3.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(42)).Add(new Paragraph("Vergi Numarası:").SetFont(titleFont).SetFontSize(8)));
                            table_row3.AddCell(new Paragraph(customer_info[3].ToString()).SetFont(mainFont).SetFontSize(8));
                            document.Add(table_row3);
                        }
                        else
                        {
                            Table table_row3 = new Table(3);
                            table_row3.SetWidth(UnitValue.CreatePercentValue(100));
                            table_row3.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                            table_row3.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(42)).Add(new Paragraph("Vergi Numaraları:").SetFont(titleFont).SetFontSize(8)));
                            table_row3.AddCell(new Paragraph(customer_info[17].ToString()).SetFont(mainFont).SetFontSize(8));
                            table_row3.AddCell(new Paragraph(customer_info[20].ToString()).SetFont(mainFont).SetFontSize(8));
                            document.Add(table_row3);
                        }
                        //tablo (satır 4)
                        Table table_row4 = new Table(2);
                        table_row4.SetWidth(UnitValue.CreatePercentValue(100));
                        table_row4.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        table_row4.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(42)).Add(new Paragraph("Referans:").SetFont(titleFont).SetFontSize(8)));
                        switch (customer_type)
                        {
                            case "Tüzel Kişi":
                                table_row4.AddCell(new Paragraph(customer_info[5].ToString()).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Gerçek Kişi":
                                table_row4.AddCell(new Paragraph(customer_info[7].ToString()).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Şahıs":
                                table_row4.AddCell(new Paragraph(customer_info[7].ToString()).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Adi Ortaklık":
                                table_row4.AddCell(new Paragraph(customer_info[5].ToString()).SetFont(mainFont).SetFontSize(8));
                                break;
                        }
                        document.Add(table_row4);
                        //tablo (satır 5)
                        Table table_row5 = new Table(4);
                        table_row5.SetWidth(UnitValue.CreatePercentValue(100));
                        table_row5.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        table_row5.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(42)).Add(new Paragraph("Telefon Numarası:").SetFont(titleFont).SetFontSize(8)));
                        switch (customer_type)
                        {
                            case "Tüzel Kişi":
                                table_row5.AddCell(new Paragraph(customer_info[6].ToString()).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Gerçek Kişi":
                                table_row5.AddCell(new Paragraph(customer_info[8].ToString()).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Şahıs":
                                table_row5.AddCell(new Paragraph(customer_info[8].ToString()).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Adi Ortaklık":
                                table_row5.AddCell(new Paragraph(customer_info[6].ToString()).SetFont(mainFont).SetFontSize(8));
                                break;
                        }
                        table_row5.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(18)).Add(new Paragraph("Eposta Adresi:").SetFont(titleFont).SetFontSize(8)));
                        switch (customer_type)
                        {
                            case "Tüzel Kişi":
                                table_row5.AddCell(new Paragraph(customer_info[8].ToString()).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Gerçek Kişi":
                                table_row5.AddCell(new Paragraph(customer_info[10].ToString()).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Şahıs":
                                table_row5.AddCell(new Paragraph(customer_info[10].ToString()).SetFont(mainFont).SetFontSize(8));
                                break;
                            case "Adi Ortaklık":
                                table_row5.AddCell(new Paragraph(customer_info[8].ToString()).SetFont(mainFont).SetFontSize(8));
                                break;
                        }
                        document.Add(table_row5);
                        //tablo (satır 6)
                        Table table_row6 = new Table(2);
                        table_row6.SetWidth(UnitValue.CreatePercentValue(100));
                        table_row6.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        table_row6.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(42)).Add(new Paragraph("İşe başlama/Faaliyete Geçme Tarihi:").SetFont(titleFont).SetFontSize(8)));
                        if (customer_type == "Tüzel Kişi" || customer_type == "Adi Ortaklık")
                            table_row6.AddCell(new Paragraph(customer_info[7].ToString().Replace("00:00:00", "")).SetFont(mainFont).SetFontSize(8));
                        else
                            table_row6.AddCell(new Paragraph(customer_info[9].ToString().Replace("00:00:00", "")).SetFont(mainFont).SetFontSize(8));
                        document.Add(table_row6);
                        //tablo (satır 7)
                        string date = "";
                        DateTime endDate = new DateTime();
                        bool endDateBool = new bool();

                        Table table_row7 = new Table(3);
                        table_row7.SetWidth(UnitValue.CreatePercentValue(100));
                        table_row7.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        table_row7.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(42)).Add(new Paragraph("İmza Sirküleri Alım/Geçerlilik Tarihi:").SetFont(titleFont).SetFontSize(8)));
                        switch (customer_type)
                        {
                            case "Tüzel Kişi":
                                date = customer_info[13].ToString().Replace("00:00:00", "");
                                table_row7.AddCell(new Paragraph(date).SetFont(mainFont).SetFontSize(8));
                                bool endDatebool = DateTime.TryParse(date, out endDate);
                                endDate = endDate.AddMonths(2);
                                if (DateTime.Now < endDate)
                                    table_row7.AddCell(new Paragraph(endDate.ToString().Replace("00:00:00", "")).SetFont(mainFont).SetFontSize(8));
                                else
                                    table_row7.AddCell(new Paragraph(endDate.ToString().Replace("00:00:00", "")).SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                break;
                            case "Gerçek Kişi":
                                date = customer_info[14].ToString().Replace("00:00:00", "");
                                table_row7.AddCell(new Paragraph(date).SetFont(mainFont).SetFontSize(8));
                                endDatebool = DateTime.TryParse(date, out endDate);
                                endDate = endDate.AddMonths(2);
                                if (DateTime.Now < endDate)
                                    table_row7.AddCell(new Paragraph(endDate.ToString().Replace("00:00:00", "")).SetFont(mainFont).SetFontSize(8));
                                else
                                    table_row7.AddCell(new Paragraph(endDate.ToString().Replace("00:00:00", "")).SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                break;
                            case "Şahıs":
                                date = customer_info[14].ToString().Replace("00:00:00", "");
                                table_row7.AddCell(new Paragraph(date).SetFont(mainFont).SetFontSize(8));
                                endDatebool = DateTime.TryParse(date, out endDate);
                                endDate = endDate.AddMonths(2);
                                if (DateTime.Now < endDate)
                                    table_row7.AddCell(new Paragraph(endDate.ToString().Replace("00:00:00", "")).SetFont(mainFont).SetFontSize(8));
                                else
                                    table_row7.AddCell(new Paragraph(endDate.ToString().Replace("00:00:00", "")).SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                break;
                            case "Adi Ortaklık":
                                date = customer_info[12].ToString().Replace("00:00:00", "");
                                table_row7.AddCell(new Paragraph(date).SetFont(mainFont).SetFontSize(8));
                                endDatebool = DateTime.TryParse(date, out endDate);
                                endDate = endDate.AddMonths(2);
                                if (DateTime.Now < endDate)
                                    table_row7.AddCell(new Paragraph(endDate.ToString().Replace("00:00:00", "")).SetFont(mainFont).SetFontSize(8));
                                else
                                    table_row7.AddCell(new Paragraph(endDate.ToString().Replace("00:00:00", "")).SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                break;
                        }
                        document.Add(table_row7);
                        //gerçek faydalanıcı
                        if (customer_type == "Tüzel Kişi")
                        {
                            Table tablo_faydalanici = new Table(2);
                            tablo_faydalanici.SetWidth(UnitValue.CreatePercentValue(100));
                            tablo_faydalanici.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                            tablo_faydalanici.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(42)).Add(new Paragraph("Gerçek Faydalanıcı:").SetFont(titleFont).SetFontSize(8)));
                            tablo_faydalanici.AddCell(new Paragraph(customer_info[9].ToString()).SetFont(mainFont).SetFontSize(8));
                            document.Add(tablo_faydalanici);
                        }
                        else if (customer_type == "Adi Ortaklık")
                        {
                            Table tablo_faydalanici = new Table(3);
                            tablo_faydalanici.SetWidth(UnitValue.CreatePercentValue(100));
                            tablo_faydalanici.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                            tablo_faydalanici.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(42)).Add(new Paragraph("Gerçek Faydalanıcılar:").SetFont(titleFont).SetFontSize(8)));
                            tablo_faydalanici.AddCell(new Paragraph(customer_info[18].ToString()).SetFont(mainFont).SetFontSize(8));
                            tablo_faydalanici.AddCell(new Paragraph(customer_info[21].ToString()).SetFont(mainFont).SetFontSize(8));
                            document.Add(tablo_faydalanici);
                        }
                        //alt başlık
                        Paragraph sub_title2 = new Paragraph("\nBELGE TESLİMAT BİLGİLERİ\n").SetFontSize(10).SetFont(titleFont).SetTextAlignment(TextAlignment.CENTER);
                        document.Add(sub_title2);

                        Table belge_teslim_durum = new Table(2);
                        belge_teslim_durum.SetWidth(UnitValue.CreatePercentValue(100));
                        belge_teslim_durum.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        switch (customer_type)
                        {
                            case "Tüzel Kişi":
                                {
                                    belge_teslim_durum.AddCell(new Paragraph("Çerçeve Sözleşmesi").SetFont(titleFont));
                                    if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\cerceve_sozlesmesi.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\cerceve_sozlesmesi.pdf"))
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                                    }
                                    else
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                    }
                                    belge_teslim_durum.AddCell(new Paragraph("Kimlik Kartı").SetFont(titleFont).SetFontSize(8));
                                    if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\kimlik_karti.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\kimlik_karti.pdf"))
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                                    }
                                    else
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                    }
                                    belge_teslim_durum.AddCell(new Paragraph("İmza Sirküleri").SetFont(titleFont).SetFontSize(8));
                                    if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\imza_sirkuleri.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\imza_sirkuleri.pdf"))
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                                    }
                                    else
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                    }
                                    belge_teslim_durum.AddCell(new Paragraph("Vergi Levhası").SetFont(titleFont).SetFontSize(8));
                                    if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\vergi_levhası.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\vergi_levhası.pdf"))
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                                    }
                                    else
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                    }
                                    belge_teslim_durum.AddCell(new Paragraph("Faaliyet Belgesi").SetFont(titleFont).SetFontSize(8));
                                    if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\faaliyet_belgesi.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\faaliyet_belgesi.pdf"))
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                                    }
                                    else
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                    }
                                    belge_teslim_durum.AddCell(new Paragraph("Ticaret Sicil Gazetesi").SetFont(titleFont).SetFontSize(8));
                                    if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\faaliyet_belgesi.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\faaliyet_belgesi.pdf"))
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                                    }
                                    else
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                    }
                                }
                                break;
                            case "Gerçek Kişi":
                                {
                                    belge_teslim_durum.AddCell(new Paragraph("Çerçeve Sözleşmesi").SetFont(titleFont).SetFontSize(8));
                                    if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\cerceve_sozlesmesi.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\cerceve_sozlesmesi.pdf"))
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                                    }
                                    else
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                    }
                                    belge_teslim_durum.AddCell(new Paragraph("Kimlik Kartı").SetFont(titleFont).SetFontSize(8));
                                    if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\kimlik_karti.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\kimlik_karti.pdf"))
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                                    }
                                    else
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                    }
                                    belge_teslim_durum.AddCell(new Paragraph("İmza Sirküleri").SetFont(titleFont).SetFontSize(8));
                                    if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\imza_sirkuleri.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\imza_sirkuleri.pdf"))
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                                    }
                                    else
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                    }
                                    belge_teslim_durum.AddCell(new Paragraph("Vergi Levhası").SetFont(titleFont).SetFontSize(8));
                                    if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\vergi_levhası.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\vergi_levhası.pdf"))
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                                    }
                                    else
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                    }
                                }
                                break;
                            case "Şahıs":
                                {
                                    belge_teslim_durum.AddCell(new Paragraph("Çerçeve Sözleşmesi").SetFont(titleFont).SetFontSize(8));
                                    if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\cerceve_sozlesmesi.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\cerceve_sozlesmesi.pdf"))
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                                    }
                                    else
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                    }
                                    belge_teslim_durum.AddCell(new Paragraph("Kimlik Kartı").SetFont(titleFont).SetFontSize(8));
                                    if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\kimlik_karti.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\kimlik_karti.pdf"))
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                                    }
                                    else
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                    }
                                    belge_teslim_durum.AddCell(new Paragraph("İmza Sirküleri").SetFont(titleFont).SetFontSize(8));
                                    if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\imza_sirkuleri.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\imza_sirkuleri.pdf"))
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                                    }
                                    else
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                    }
                                    belge_teslim_durum.AddCell(new Paragraph("İkametgah").SetFont(titleFont).SetFontSize(8));
                                    if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\ikametgah.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\ikametgah.pdf"))
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                                    }
                                    else
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                    }
                                    belge_teslim_durum.AddCell(new Paragraph("Islak İmza").SetFont(titleFont).SetFontSize(8));
                                    if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\ikametgah.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\ikametgah.pdf"))
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                                    }
                                    else
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                    }
                                }
                                break;
                            case "Adi Ortaklık":
                                {
                                    belge_teslim_durum.AddCell(new Paragraph("Ortaklık Sözleşmesi").SetFont(titleFont).SetFontSize(8));
                                    if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\adi_ortaklik_sozlesmesi.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\adi_ortaklik_sozlesmesi.pdf"))
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                                    }
                                    else
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                    }
                                    belge_teslim_durum.AddCell(new Paragraph("Tahakkuk Fişi").SetFont(titleFont).SetFontSize(8));
                                    if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\tahakkuk_fisi.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\tahakkuk_fisi.pdf"))
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                                    }
                                    else
                                    {
                                        belge_teslim_durum.AddCell(new Paragraph("TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                                    }
                                }
                                break;
                        }
                        document.Add(belge_teslim_durum);
                        if (customer_type == "Adi Ortaklık")
                        {
                            Table belge_teslim_durum2 = new Table(3);
                            belge_teslim_durum2.SetWidth(UnitValue.CreatePercentValue(100));
                            belge_teslim_durum2.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                            belge_teslim_durum2.AddCell(new Paragraph("Çerçeve Sözleşmeleri").SetFont(titleFont).SetFontSize(8));
                            if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\ortak1_cerceve_sozlesmesi.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\ortak1_cerceve_sozlesmesi.pdf"))
                            {
                                belge_teslim_durum2.AddCell(new Paragraph("Ortak 1: TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                            }
                            else
                            {
                                belge_teslim_durum2.AddCell(new Paragraph("Ortak 1: TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                            }
                            if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\ortak2_cerceve_sozlesmesi.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\ortak2_cerceve_sozlesmesi.pdf"))
                            {
                                belge_teslim_durum2.AddCell(new Paragraph("Ortak 2: TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                            }
                            else
                            {
                                belge_teslim_durum2.AddCell(new Paragraph("Ortak 2: TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                            }

                            belge_teslim_durum2.AddCell(new Paragraph("Kimlik Kartları").SetFont(titleFont).SetFontSize(8));
                            if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\ortak1_kimlik_karti.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\ortak1_kimlik_karti.pdf"))
                            {
                                belge_teslim_durum2.AddCell(new Paragraph("Ortak 1: TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                            }
                            else
                            {
                                belge_teslim_durum2.AddCell(new Paragraph("Ortak 1: TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                            }
                            if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\ortak2_kimlik_karti.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\ortak2_kimlik_karti.pdf"))
                            {
                                belge_teslim_durum2.AddCell(new Paragraph("Ortak 2: TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                            }
                            else
                            {
                                belge_teslim_durum2.AddCell(new Paragraph("Ortak 2: TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                            }

                            belge_teslim_durum2.AddCell(new Paragraph("İmza Sirküleri").SetFont(titleFont).SetFontSize(8));
                            if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\ortak1_imza_sirkuleri.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\ortak1_imza_sirkuleri.pdf"))
                            {
                                belge_teslim_durum2.AddCell(new Paragraph("Ortak 1: TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                            }
                            else
                            {
                                belge_teslim_durum2.AddCell(new Paragraph("Ortak 1: TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                            }
                            if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[6].ToString()}\\ortak2_imza_sirkuleri.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\ortak2_imza_sirkuleri.pdf"))
                            {
                                belge_teslim_durum2.AddCell(new Paragraph("Ortak 2: TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                            }
                            else
                            {
                                belge_teslim_durum2.AddCell(new Paragraph("Ortak 2: TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                            }

                            belge_teslim_durum2.AddCell(new Paragraph("Vergi Levhaları").SetFont(titleFont).SetFontSize(8));
                            if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\ortak1_vergi_levhası.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\ortak1_vergi_levhası.pdf"))
                            {
                                belge_teslim_durum.AddCell(new Paragraph("Ortak 1: TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                            }
                            else
                            {
                                belge_teslim_durum.AddCell(new Paragraph("Ortak 1: TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                            }
                            if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\ortak2_vergi_levhası.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\ortak2_vergi_levhası.pdf"))
                            {
                                belge_teslim_durum.AddCell(new Paragraph("Ortak 2: TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                            }
                            else
                            {
                                belge_teslim_durum.AddCell(new Paragraph("Ortak 2: TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                            }
                            belge_teslim_durum.AddCell(new Paragraph("Faaliyet Belgeleri").SetFont(titleFont).SetFontSize(8));
                            if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\ortak1_faaliyet_belgesi.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\ortak1_faaliyet_belgesi.pdf"))
                            {
                                belge_teslim_durum.AddCell(new Paragraph("Ortak 1: TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                            }
                            else
                            {
                                belge_teslim_durum.AddCell(new Paragraph("Ortak 1: TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                            }
                            if (File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\ortak2_faaliyet_belgesi.png") || File.Exists($"belgeler\\{customer_info[1].ToString()}\\{customer_info[4].ToString()}\\ortak2_faaliyet_belgesi.pdf"))
                            {
                                belge_teslim_durum.AddCell(new Paragraph("Ortak 2: TESLİM EDİLDİ").SetFont(mainFont).SetFontSize(8));
                            }
                            else
                            {
                                belge_teslim_durum.AddCell(new Paragraph("Ortak 2: TESLİM EDİLMEDİ").SetFont(mainFont).SetFontSize(8).SetFontColor(DeviceRgb.RED));
                            }

                            document.Add(belge_teslim_durum2);
                        }
                    }
                    break;
                case 1:
                    {
                        System.Drawing.Image fatfImage = Properties.Resources.fatf;

                        Paragraph title = new Paragraph("\nGÜVENLİK TARAMASI SONUÇ BELGESİ\n\n").SetFontSize(12).SetFont(titleFont).SetTextAlignment(TextAlignment.CENTER);
                        document.Add(title);

                        using (MemoryStream imageStream = new MemoryStream())
                        {
                            fatfImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] imageBytes = imageStream.ToArray();

                            iText.Layout.Element.Image pdfImage = new iText.Layout.Element.Image(ImageDataFactory.Create(imageBytes));
                            document.Add(pdfImage);
                        }

                        Table table_row1 = new Table(2);
                        table_row1.SetWidth(UnitValue.CreatePercentValue(100));
                        table_row1.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                        Cell cell1 = new Cell();
                        cell1.SetWidth(UnitValue.CreatePercentValue(20)); // Set the width of the first cell to be 50%
                        cell1.Add(new Paragraph("Müşteri No:").SetFont(titleFont).SetFontSize(8));

                        Cell cell2 = new Cell();
                        cell2.SetWidth(UnitValue.CreatePercentValue(80)); // Set the width of the second cell to be 50%
                        if (isYetkiliKontrol == false)
                            cell2.Add(new Paragraph(customer_info[1].ToString()).SetFont(mainFont).SetFontSize(8));
                        else
                            cell2.Add(new Paragraph(customer_info[0].ToString()).SetFont(mainFont).SetFontSize(8));

                        table_row1.AddCell(cell1);
                        table_row1.AddCell(cell2);
                        document.Add(table_row1);

                        Table table_row2 = new Table(2);
                        table_row2.SetWidth(UnitValue.CreatePercentValue(100));
                        table_row2.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                        Cell cell3 = new Cell();
                        cell3.SetWidth(UnitValue.CreatePercentValue(20));
                        cell3.Add(new Paragraph("Adı Soyadı & Ünvanı:").SetFont(titleFont).SetFontSize(8));

                        Cell cell4 = new Cell();
                        cell4.SetWidth(UnitValue.CreatePercentValue(80));
                        if (isYetkiliKontrol == false)
                            cell4.Add(new Paragraph(customer_info[3].ToString()).SetFont(mainFont).SetFontSize(8));
                        else
                            cell4.Add(new Paragraph(customer_info[1].ToString()).SetFont(mainFont).SetFontSize(8));

                        table_row2.AddCell(cell3);
                        table_row2.AddCell(cell4);
                        document.Add(table_row2);

                        if(isYetkiliKontrol == true)
                        {
                            Table table_row3 = new Table(2);
                            table_row3.SetWidth(UnitValue.CreatePercentValue(100));
                            table_row3.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                            Cell cell5 = new Cell();
                            cell5.SetWidth(UnitValue.CreatePercentValue(20));
                            cell5.Add(new Paragraph("Eşleşme Sayısı:").SetFont(titleFont).SetFontSize(8));

                            Cell cell6 = new Cell();
                            cell6.SetWidth(UnitValue.CreatePercentValue(80));
                            if (isYetkiliKontrol == false)
                                cell6.Add(new Paragraph(customer_info[3].ToString()).SetFont(mainFont).SetFontSize(8));
                            else
                                cell6.Add(new Paragraph(customer_info[2].ToString()).SetFont(mainFont).SetFontSize(8));

                            table_row3.AddCell(cell5);
                            table_row3.AddCell(cell6);
                            document.Add(table_row3);

                            Table table_row4 = new Table(2);
                            table_row4.SetWidth(UnitValue.CreatePercentValue(100));
                            table_row4.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                            Cell cell7 = new Cell();
                            cell7.SetWidth(UnitValue.CreatePercentValue(20));
                            cell7.Add(new Paragraph("Tarama Oranı:").SetFont(titleFont).SetFontSize(8));

                            Cell cell8 = new Cell();
                            cell8.SetWidth(UnitValue.CreatePercentValue(80));
                            if (isYetkiliKontrol == false)
                                cell8.Add(new Paragraph(customer_info[3].ToString()).SetFont(mainFont).SetFontSize(8));
                            else
                                cell8.Add(new Paragraph(customer_info[3].ToString()).SetFont(mainFont).SetFontSize(8));

                            table_row4.AddCell(cell7);
                            table_row4.AddCell(cell8);
                            document.Add(table_row4);
                        }
                        

                        Table table_row5 = new Table(1);
                        table_row5.SetWidth(UnitValue.CreatePercentValue(100));
                        table_row5.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        table_row5.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        table_row5.AddCell(new Paragraph("Bu tarama x firması adına gerçekleştirilmiştir.").SetFont(mainFont).SetFontSize(8));
                        document.Add(table_row5);

                        Paragraph splitter = new Paragraph("\n");
                        document.Add(splitter);

                        iText.Kernel.Colors.Color whiteColor = DeviceRgb.WHITE;
                        iText.Kernel.Colors.Color silverColor = new DeviceRgb(240, 240, 240);

                        Table table_blacklist = new Table(2);
                        table_blacklist.SetWidth(UnitValue.CreatePercentValue(100));
                        table_blacklist.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        table_blacklist.AddCell(new Paragraph("Taranan Liste").SetFont(titleFont).SetTextAlignment(TextAlignment.CENTER)).SetBackgroundColor(new DeviceRgb(224, 224, 224));
                        table_blacklist.AddCell(new Paragraph("Açıklama").SetFont(titleFont).SetTextAlignment(TextAlignment.CENTER)).SetBackgroundColor(new DeviceRgb(224, 224, 224));

                        Cell blacklist11 = new Cell().Add(new Paragraph("MASAK Yasaklılar Listesi").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(whiteColor);
                        Cell blacklist12 = new Cell().Add(new Paragraph("A - BİRLEŞMİŞ MİLLETLER GÜVENLİK KONSEYİ KARARINA İSTİNADEN MALVARLIKLARI DONDURULANLAR (6415 SAYILI KANUN 5.MADDE KAPSAMINDA)").SetFont(mainFont)).SetFontSize(8).SetBackgroundColor(whiteColor);
                        Cell blacklist21 = new Cell().Add(new Paragraph("MASAK Yasaklılar Listesi").SetFont(mainFont)).SetFontSize(8).SetBackgroundColor(silverColor);
                        Cell blacklist22 = new Cell().Add(new Paragraph("B - YABANCI ÜLKE TALEPLERİNE İSTİNADEN MALVARLIKLARI DONDURULANLAR (6415 SAYILI KANUN 6. MADDE KAPSAMINDA)").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(silverColor);
                        Cell blacklist31 = new Cell().Add(new Paragraph("MASAK Yasaklılar Listesi").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(whiteColor);
                        Cell blacklist32 = new Cell().Add(new Paragraph("C - İÇ DONDURMA KARARI İLE MALVARLIKLARI DONDURULANLAR (6415 SAYILI KANUN 7. MADDE KAPSAMINDA)").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(whiteColor);
                        Cell blacklist41 = new Cell().Add(new Paragraph("MASAK Yasaklılar Listesi").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(silverColor);
                        Cell blacklist42 = new Cell().Add(new Paragraph("D - KİTLE İMHA SİLAHLARININ YAYILMASININ FİNANSMANININ ÖNLENMESİ KAPSAMINDA MALVARLIKLARI DONDURULANLAR (7262 SAYILI KANUN 3.A VE 3.B MADDELERİ KAPSAMINDA)").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(silverColor);
                        Cell blacklist51 = new Cell().Add(new Paragraph("İçişleri Bakanlığı").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(whiteColor);
                        Cell blacklist52 = new Cell().Add(new Paragraph("TERÖRDEN ARANANLAR LİSTESİ").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(whiteColor);
                        Cell blacklist61 = new Cell().Add(new Paragraph("Sermaye Piyasası Kurulu").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(silverColor);
                        Cell blacklist62 = new Cell().Add(new Paragraph("İDARİ PARA CEZALARI").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(silverColor);
                        Cell blacklist71 = new Cell().Add(new Paragraph("Sermaye Piyasası Kurulu").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(whiteColor);
                        Cell blacklist72 = new Cell().Add(new Paragraph("İŞLEM YASAKLILAR").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(whiteColor);
                        Cell blacklist81 = new Cell().Add(new Paragraph("Amerika Hazine Bakanlığı").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(silverColor);
                        Cell blacklist82 = new Cell().Add(new Paragraph("OFACT YAPTIRIMLILAR LİSTESİ").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(silverColor);
                        Cell blacklist91 = new Cell().Add(new Paragraph("Avrupa Birliği").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(whiteColor);
                        Cell blacklist92 = new Cell().Add(new Paragraph("FİNANSAL YAPTIRIMLILAR LİSTESİ").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(whiteColor);
                        Cell blacklist101 = new Cell().Add(new Paragraph("Birleşmiş Milletler").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(silverColor);
                        Cell blacklist102 = new Cell().Add(new Paragraph("YAPTIRIMLILAR LİSTESİ").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(silverColor);
                        Cell blacklist111 = new Cell().Add(new Paragraph("İsviçre").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(whiteColor);
                        Cell blacklist112 = new Cell().Add(new Paragraph("YAPTIRIMLILAR LİSTESİ").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(whiteColor);
                        Cell blacklist121 = new Cell().Add(new Paragraph("Birleşik Krallık").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(silverColor);
                        Cell blacklist122 = new Cell().Add(new Paragraph("YAPTIRIMLILAR LİSTESİ").SetFont(mainFont).SetFontSize(8)).SetBackgroundColor(silverColor);

                        table_blacklist.AddCell(blacklist11);
                        table_blacklist.AddCell(blacklist12);
                        table_blacklist.AddCell(blacklist21);
                        table_blacklist.AddCell(blacklist22);
                        table_blacklist.AddCell(blacklist31);
                        table_blacklist.AddCell(blacklist32);
                        table_blacklist.AddCell(blacklist41);
                        table_blacklist.AddCell(blacklist42);
                        table_blacklist.AddCell(blacklist51);
                        table_blacklist.AddCell(blacklist52);
                        table_blacklist.AddCell(blacklist61);
                        table_blacklist.AddCell(blacklist62);
                        table_blacklist.AddCell(blacklist71);
                        table_blacklist.AddCell(blacklist72);
                        table_blacklist.AddCell(blacklist81);
                        table_blacklist.AddCell(blacklist82);
                        table_blacklist.AddCell(blacklist91);
                        table_blacklist.AddCell(blacklist92);
                        table_blacklist.AddCell(blacklist101);
                        table_blacklist.AddCell(blacklist102);
                        table_blacklist.AddCell(blacklist111);
                        table_blacklist.AddCell(blacklist112);
                        table_blacklist.AddCell(blacklist121);
                        table_blacklist.AddCell(blacklist122);

                        document.Add(table_blacklist);

                        Text text_footnote1 = new Text("\n\nYapılan araştırma sonucunda ").SetFont(mainFont);
                        Text text_footnote2 = new Text("Müşteri Hakkında Olumsuz Bir Duruma Rastlanılmamıştır.").SetFont(bolditalicFont);
                        Text text_footnote3 = new Text(" Araştırmalarda olumsuz sonuç çıkması Halinde ").SetFont(mainFont);
                        Text text_footnote4 = new Text("\"Müşteri Hakkında Şüpheli İşlem Bildirimi\"").SetFont(italicFont);
                        Text text_footnote5 = new Text(" Prosedürüne göre işlem yapılır.").SetFont(mainFont);

                        Paragraph footnote = new Paragraph().SetFontSize(10).SetFont(mainFont).SetTextAlignment(TextAlignment.CENTER);
                        footnote.Add(text_footnote1);
                        footnote.Add(text_footnote2);
                        footnote.Add(text_footnote3);
                        footnote.Add(text_footnote4);
                        footnote.Add(text_footnote5);
                        document.Add(footnote);

                        document.Close();

                        tempPdfFilePath = System.IO.Path.GetTempFileName();
                        File.WriteAllBytes(tempPdfFilePath, memoryStream.ToArray());
                    }
                    break;
                case 2:
                    {
                        string? custname = "";
                        int? custno = 0;
                        DateTime? recorddate = new DateTime();
                        string? custtype = "";
                        string? custphone = "";
                        string? custemail = "";

                        switch(customer_type)
                        {
                            case "Tüzel Kişi":
                                {
                                    custname = customer_info[4].ToString();
                                    custno = Convert.ToInt32(customer_info[2]);
                                    recorddate = Convert.ToDateTime(customer_info[18]);
                                    custtype = "Tüzel Kişi";
                                    custphone = Convert.ToString(customer_info[6]);
                                    custemail = Convert.ToString(customer_info[8]);
                                }
                                break;
                            case "Gerçek Kişi":
                                {
                                    custname = customer_info[6].ToString();
                                    custno = Convert.ToInt32(customer_info[2]);
                                    recorddate = Convert.ToDateTime(customer_info[18]);
                                    custtype = "Gerçek Kişi";
                                    custphone = Convert.ToString(customer_info[8]);
                                    custemail = Convert.ToString(customer_info[10]);
                                }
                                break;
                            case "Şahıs":
                                {
                                    custname = customer_info[6].ToString();
                                    custno = Convert.ToInt32(customer_info[2]);
                                    recorddate = Convert.ToDateTime(customer_info[18]);
                                    custtype = "Şahıs";
                                    custphone = Convert.ToString(customer_info[8]);
                                    custemail = Convert.ToString(customer_info[10]);
                                }
                                break;
                            case "Adi Ortaklık":
                                {
                                    custname = customer_info[4].ToString();
                                    custno = Convert.ToInt32(customer_info[2]);
                                    recorddate = Convert.ToDateTime(customer_info[22]);
                                    custtype = "Adi Ortaklık";
                                    custphone = Convert.ToString(customer_info[6]);
                                    custemail = Convert.ToString(customer_info[8]);
                                }
                                break;
                        }

                        System.Drawing.Image checkbox = Properties.Resources.checkbox;

                        MemoryStream checkboxStream = new MemoryStream();
                        checkbox.Save(checkboxStream, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] imageBytes = checkboxStream.ToArray();

                        iText.Layout.Element.Image checkbox_img = new iText.Layout.Element.Image(ImageDataFactory.Create(imageBytes));

                        Paragraph title = new Paragraph("\nMÜŞTERİNİN TANINMASINA İLİŞKİN FORM\n\n").SetFontSize(14).SetFont(titleFont).SetTextAlignment(TextAlignment.CENTER);
                        document.Add(title);

                        //satır 1
                        Table table1 = new Table(2);
                        table1.SetWidth(UnitValue.CreatePercentValue(100));
                        Cell leftCell_table1 = new Cell();
                        Cell rightCell_table1 = new Cell();
                        Cell leftCell2_table1 = new Cell();
                        Cell rightCell2_table1 = new Cell();

                        leftCell_table1.SetBorder(Border.NO_BORDER);
                        rightCell_table1.SetBorder(Border.NO_BORDER);
                        leftCell_table1.SetFont(mainFont);
                        rightCell_table1.SetFont(mainFont);

                        leftCell_table1.Add(new Paragraph($"Müşteri Adı Soyadı/Unvanı: {custname}").SetFontSize(10));
                        leftCell_table1.SetTextAlignment(TextAlignment.LEFT);
                        table1.AddCell(leftCell_table1);
                        rightCell_table1.Add(new Paragraph($"MÜŞTERİ NO: {custno}").SetFontSize(10));
                        rightCell_table1.SetTextAlignment(TextAlignment.CENTER);
                        table1.AddCell(rightCell_table1);

                        leftCell2_table1.SetBorder(Border.NO_BORDER);
                        rightCell2_table1.SetBorder(Border.NO_BORDER);
                        leftCell2_table1.SetFont(mainFont);
                        rightCell2_table1.SetFont(mainFont);
                        leftCell2_table1.Add(new Paragraph($"Müşteri Kayıt Tarihi: {recorddate.ToString().Replace("00:00:00","")}").SetFontSize(10));
                        leftCell2_table1.SetTextAlignment(TextAlignment.LEFT);
                        table1.AddCell(leftCell2_table1);
                        rightCell2_table1.Add(new Paragraph($"MÜŞTERİ TİPİ: {custtype}").SetFontSize(10));
                        rightCell2_table1.SetTextAlignment(TextAlignment.CENTER);
                        table1.AddCell(rightCell2_table1);
                        document.Add(table1);

                        Paragraph paragraph3 = new Paragraph($"(Varsa) Yetkili Kişi:").SetFont(mainFont).SetFontSize(10);
                        document.Add(paragraph3);

                        Paragraph paragraph1 = new Paragraph($"Telefon No: {custphone}").SetFont(mainFont).SetFontSize(10);
                        document.Add(paragraph1);

                        Paragraph paragraph2 = new Paragraph($"Eposta Adresi: {custemail}").SetFont(mainFont).SetFontSize(10);
                        document.Add(paragraph2);

                        Paragraph paragraph4 = new Paragraph("Mesleği & İşi / Alanı:").SetFont(mainFont).SetFontSize(10);
                        document.Add(paragraph4);

                        Paragraph paragraph5 = new Paragraph("Doğum Yılı & Yeri:").SetFont(mainFont).SetFontSize(10);
                        document.Add(paragraph5);

                        Paragraph splitter = new Paragraph("\n");
                        document.Add(splitter);

                        Table table2 = new Table(2);
                        table2.SetWidth(UnitValue.CreatePercentValue(100));
                        table2.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        
                        table2.AddCell(new Cell().Add(new Paragraph("GERÇEK KİŞİLER").SetFont(titleFont).SetFontSize(11).SetTextAlignment(TextAlignment.LEFT)).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().Add(new Paragraph("TÜZEL KİŞİLER").SetFont(titleFont).SetFontSize(11).SetTextAlignment(TextAlignment.LEFT)).SetBorder(Border.NO_BORDER));

                        Div kimlik_div = new Div();
                        kimlik_div.Add(new Paragraph().Add(checkbox_img).Add(" Kimlik Fotokopisi").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div kimlik_div2 = new Div();
                        kimlik_div2.Add(new Paragraph().Add(checkbox_img).Add(" Yetkili Kişi Kimlik Fotokopisi").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div kimlik_div3 = new Div();
                        kimlik_div3.Add(new Paragraph().Add(checkbox_img).Add(" Ortakların Kimlik Fotokopileri").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div imza_div = new Div();
                        imza_div.Add(new Paragraph().Add(checkbox_img).Add(" İmza Beyannamesi").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div imza_div2 = new Div();
                        imza_div2.Add(new Paragraph().Add(checkbox_img).Add(" İmza Sirküleri").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div imza_div3 = new Div();
                        imza_div3.Add(new Paragraph().Add(checkbox_img).Add(" İmza Beyannameleri").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div vergi_div = new Div();
                        vergi_div.Add(new Paragraph().Add(checkbox_img).Add(" Vergi Levhası").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div vergi_div2 = new Div();
                        vergi_div2.Add(new Paragraph().Add(checkbox_img).Add(" Vergi Levhaları").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div telefon_div = new Div();
                        telefon_div.Add(new Paragraph().Add(checkbox_img).Add(" Telefon Numarası").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div ticaret_div = new Div();
                        ticaret_div.Add(new Paragraph().Add(checkbox_img).Add(" Ticaret Sicil Gazetesi").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div email_div = new Div();
                        email_div.Add(new Paragraph().Add(checkbox_img).Add(" Eposta Adresi").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div faaliyet_div = new Div();
                        faaliyet_div.Add(new Paragraph().Add(checkbox_img).Add(" Faaliyet Belgesi").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div cerceve_div = new Div();
                        cerceve_div.Add(new Paragraph().Add(checkbox_img).Add(" Çerçeve Sözleşmesi").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div faydalanici_div = new Div();
                        faydalanici_div.Add(new Paragraph().Add(checkbox_img).Add(" Gerçek Faydalanıcı Bilgileri").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div ikametgah_div = new Div();
                        ikametgah_div.Add(new Paragraph().Add(checkbox_img).Add(" İkametgah").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div adiortaklik_div = new Div();
                        adiortaklik_div.Add(new Paragraph().Add(checkbox_img).Add(" Adi Ortaklık Sözleşmesi").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div tahakkuk_div = new Div();
                        tahakkuk_div.Add(new Paragraph().Add(checkbox_img).Add(" Tahakkuk Fişi").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div tim_div = new Div();
                        tahakkuk_div.Add(new Paragraph().Add(checkbox_img).Add(" Tim").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div imib_div = new Div();
                        tahakkuk_div.Add(new Paragraph().Add(checkbox_img).Add(" İmib").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        Div sanayi_div = new Div();
                        tahakkuk_div.Add(new Paragraph().Add(checkbox_img).Add(" Sanayi").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));

                        table2.AddCell(new Cell().Add(kimlik_div).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(30)).Add(kimlik_div2).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().Add(imza_div).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(30)).Add(imza_div2).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().Add(vergi_div).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(30)).Add(vergi_div).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().Add(cerceve_div).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(30)).Add(ticaret_div).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().Add(imza_div2).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(30)).Add(faaliyet_div).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(30)).Add(cerceve_div).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(30)).Add(faydalanici_div).SetBorder(Border.NO_BORDER));

                        table2.AddCell(new Cell().Add(new Paragraph("ŞAHISLAR\n").SetFont(titleFont).SetFontSize(11).SetTextAlignment(TextAlignment.LEFT)).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().Add(new Paragraph("ADİ ORTAKLIKLAR\n").SetFont(titleFont).SetFontSize(11).SetTextAlignment(TextAlignment.LEFT)).SetBorder(Border.NO_BORDER));

                        table2.AddCell(new Cell().Add(kimlik_div).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(30)).Add(kimlik_div3).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().Add(imza_div).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(30)).Add(imza_div3).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().Add(ikametgah_div).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(30)).Add(vergi_div2).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(30)).Add(ticaret_div).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(30)).Add(faaliyet_div).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(30)).Add(adiortaklik_div).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(30)).Add(tahakkuk_div).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(30)).Add(tim_div).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(30)).Add(imib_div).SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetBorder(Border.NO_BORDER));
                        table2.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(30)).Add(sanayi_div).SetBorder(Border.NO_BORDER));

                        document.Add(table2);

                    }
                    break;
                case 3:
                    {
                        System.Drawing.Image fatfImage = Properties.Resources.fatf_isole;
                        using (MemoryStream imageStream = new MemoryStream())
                        {
                            fatfImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] imageBytes = imageStream.ToArray();

                            iText.Layout.Element.Image pdfImage = new iText.Layout.Element.Image(ImageDataFactory.Create(imageBytes));
                            pdfImage.SetWidth(30);
                            pdfImage.SetHeight(50);

                            pdfImage.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                            Cell cell = new Cell().Add(pdfImage).SetBorder(Border.NO_BORDER);
                            cell.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                            Table logo_table = new Table(1);
                            logo_table.SetWidth(UnitValue.CreatePercentValue(100));
                            logo_table.AddCell(cell);

                            document.Add(logo_table);

                            Text text_headnote1 = new Text("\nFATF Tavsiyeleri, ülkelerin yasadışı mali akışlarla mücadele etmesine yardımcı olacak kapsamlı bir önlem çerçevesi sunmaktadır. Bunlar arasında, ulusal makamların suçu ve terörizmi körükleyen mali akışları tespit etmek ve engellemek ve yasa dışı faaliyetten sorumlu olanları cezalandırmak için etkili eylemlerde bulunabilmesini sağlayacak güçlü bir yasa, yönetmelik ve operasyonel önlemler çerçevesi yer almaktadır.").SetFont(mainFont).SetFontSize(9);
                            Text text_headnote2 = new Text("Çıtak Yetkili Müessese FATF'nin yayınlamış olduğu raporlar ve önleyici tedbirler kapsamında yaptığı ticarette bu kriterleri göz önüne tutarak işlem yapar.").SetFont(titleFont).SetFontSize(9);

                            Paragraph headnote = new Paragraph().SetFontSize(10).SetFont(mainFont).SetTextAlignment(TextAlignment.CENTER);
                            headnote.Add(text_headnote1);
                            headnote.Add(text_headnote2);
                            document.Add(headnote);

                            Paragraph header_gray = new Paragraph("GRİ LİSTE").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
                            document.Add(header_gray);
                            Paragraph subheader_gray = new Paragraph("Arttırılmış İzleme Altındaki Yargı Bölgeleri").SetFont(titleFont).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER);
                            document.Add(subheader_gray);
                            Paragraph paragraph_gray = new Paragraph("Bu beyan, kara para aklama, terörün finansmanı ve nükleer silahların yayılmasına ilişkin finansmanla mücadele etmek amacıyla rejimlerindeki stratejik eksiklikleri gidermek için FATF ile aktif olarak çalışan ülkeleri tanımlamaktadır. FATF'nin bir yargı yetkisini artırılmış denetim altına alması, ülkenin belirlenen stratejik eksiklikleri kararlaştırılan zaman dilimleri içerisinde hızlı bir şekilde çözmeyi taahhüt ettiği ve artırılmış izlemeye tabi olduğu anlamına gelir.").SetFont(mainFont).SetFontSize(8);
                            document.Add(paragraph_gray);

                            Table table_gray = new Table(3);
                            table_gray.SetWidth(UnitValue.CreatePercentValue(100));
                            table_gray.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                            table_gray.AddCell(new Paragraph("POSITION/SIRA").SetFont(titleFont).SetFontSize(9));
                            table_gray.AddCell(new Paragraph("TYPE/TÜR").SetFont(titleFont).SetFontSize(9));
                            table_gray.AddCell(new Paragraph("COUNTRY/AREA/ÜLKE").SetFont(titleFont).SetFontSize(9));

                            Cell cell11 = new Cell().Add(new Paragraph("1").SetFont(mainFont).SetFontSize(8));
                            Cell cell12 = new Cell(20,1).Add(new Paragraph("Arttırılmış İzleme Altındaki Yargı Bölgeleri").SetFont(mainFont).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetFont(mainFont).SetFontSize(8));
                            Cell cell13 = new Cell().Add(new Paragraph("Bulgaristan").SetFont(mainFont).SetFontSize(8));
                            Cell cell21 = new Cell().Add(new Paragraph("2").SetFont(mainFont).SetFontSize(8));
                            Cell cell23 = new Cell().Add(new Paragraph("Burkina Faso").SetFont(mainFont).SetFontSize(8));
                            Cell cell31 = new Cell().Add(new Paragraph("3").SetFont(mainFont).SetFontSize(8));
                            Cell cell33 = new Cell().Add(new Paragraph("Kamerun").SetFont(mainFont).SetFontSize(8));
                            Cell cell41 = new Cell().Add(new Paragraph("4").SetFont(mainFont).SetFontSize(8));
                            Cell cell43 = new Cell().Add(new Paragraph("Hırvatistan").SetFont(mainFont).SetFontSize(8));
                            Cell cell51 = new Cell().Add(new Paragraph("5").SetFont(mainFont).SetFontSize(8));
                            Cell cell53 = new Cell().Add(new Paragraph("Kongo Demokratik Cumhuriyeti").SetFont(mainFont).SetFontSize(8));
                            Cell cell61 = new Cell().Add(new Paragraph("6").SetFont(mainFont).SetFontSize(8));
                            Cell cell63 = new Cell().Add(new Paragraph("Haiti").SetFont(mainFont).SetFontSize(8));
                            Cell cell71 = new Cell().Add(new Paragraph("7").SetFont(mainFont).SetFontSize(8));
                            Cell cell73 = new Cell().Add(new Paragraph("Jamaika").SetFont(mainFont).SetFontSize(8));
                            Cell cell81 = new Cell().Add(new Paragraph("8").SetFont(mainFont).SetFontSize(8));
                            Cell cell83 = new Cell().Add(new Paragraph("Kenya").SetFont(mainFont).SetFontSize(8));
                            Cell cell91 = new Cell().Add(new Paragraph("9").SetFont(mainFont).SetFontSize(8));
                            Cell cell93 = new Cell().Add(new Paragraph("Mali").SetFont(mainFont).SetFontSize(8));
                            Cell cell101 = new Cell().Add(new Paragraph("10").SetFont(mainFont).SetFontSize(8));
                            Cell cell103 = new Cell().Add(new Paragraph("Mozambik").SetFont(mainFont).SetFontSize(8));
                            Cell cell111 = new Cell().Add(new Paragraph("11").SetFont(mainFont).SetFontSize(8));
                            Cell cell113 = new Cell().Add(new Paragraph("Namibya").SetFont(mainFont).SetFontSize(8));
                            Cell cell121 = new Cell().Add(new Paragraph("12").SetFont(mainFont).SetFontSize(8));
                            Cell cell123 = new Cell().Add(new Paragraph("Nijerya").SetFont(mainFont).SetFontSize(8));
                            Cell cell131 = new Cell().Add(new Paragraph("13").SetFont(mainFont).SetFontSize(8));
                            Cell cell133 = new Cell().Add(new Paragraph("Filipinler").SetFont(mainFont).SetFontSize(8));
                            Cell cell141 = new Cell().Add(new Paragraph("14").SetFont(mainFont).SetFontSize(8));
                            Cell cell143 = new Cell().Add(new Paragraph("Senegal").SetFont(mainFont).SetFontSize(8));
                            Cell cell151 = new Cell().Add(new Paragraph("15").SetFont(mainFont).SetFontSize(8));
                            Cell cell153 = new Cell().Add(new Paragraph("Güney Afrika").SetFont(mainFont).SetFontSize(8));
                            Cell cell161 = new Cell().Add(new Paragraph("16").SetFont(mainFont).SetFontSize(8));
                            Cell cell163 = new Cell().Add(new Paragraph("Güney Sudan").SetFont(mainFont).SetFontSize(8));
                            Cell cell171 = new Cell().Add(new Paragraph("17").SetFont(mainFont).SetFontSize(8));
                            Cell cell173 = new Cell().Add(new Paragraph("Suriye").SetFont(mainFont).SetFontSize(8));
                            Cell cell181 = new Cell().Add(new Paragraph("18").SetFont(mainFont).SetFontSize(8));
                            Cell cell183 = new Cell().Add(new Paragraph("Tanzanya").SetFont(mainFont).SetFontSize(8));
                            Cell cell191 = new Cell().Add(new Paragraph("19").SetFont(mainFont).SetFontSize(8));
                            Cell cell193 = new Cell().Add(new Paragraph("Vietnam").SetFont(mainFont).SetFontSize(8));
                            Cell cell201 = new Cell().Add(new Paragraph("20").SetFont(mainFont).SetFontSize(8));
                            Cell cell203 = new Cell().Add(new Paragraph("Yemen").SetFont(mainFont).SetFontSize(8));

                            table_gray.AddCell(cell11);
                            table_gray.AddCell(cell12);
                            table_gray.AddCell(cell13);
                            table_gray.AddCell(cell21);
                            table_gray.AddCell(cell23);
                            table_gray.AddCell(cell31);
                            table_gray.AddCell(cell33);
                            table_gray.AddCell(cell41);
                            table_gray.AddCell(cell43);
                            table_gray.AddCell(cell51);
                            table_gray.AddCell(cell53);
                            table_gray.AddCell(cell61);
                            table_gray.AddCell(cell63);
                            table_gray.AddCell(cell71);
                            table_gray.AddCell(cell73);
                            table_gray.AddCell(cell81);
                            table_gray.AddCell(cell83);
                            table_gray.AddCell(cell91);
                            table_gray.AddCell(cell93);
                            table_gray.AddCell(cell101);
                            table_gray.AddCell(cell103);
                            table_gray.AddCell(cell111);
                            table_gray.AddCell(cell113);
                            table_gray.AddCell(cell121);
                            table_gray.AddCell(cell123);
                            table_gray.AddCell(cell131);
                            table_gray.AddCell(cell133);
                            table_gray.AddCell(cell141);
                            table_gray.AddCell(cell143);
                            table_gray.AddCell(cell151);
                            table_gray.AddCell(cell153);
                            table_gray.AddCell(cell161);
                            table_gray.AddCell(cell163);
                            table_gray.AddCell(cell171);
                            table_gray.AddCell(cell173);
                            table_gray.AddCell(cell181);
                            table_gray.AddCell(cell183);
                            table_gray.AddCell(cell191);
                            table_gray.AddCell(cell193);
                            table_gray.AddCell(cell201);
                            table_gray.AddCell(cell203);

                            document.Add(table_gray);

                            Paragraph header_black = new Paragraph("KARA LİSTE").SetFont(titleFont).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER);
                            document.Add(header_black);
                            Paragraph subheader_black = new Paragraph("Eylem Çağrısına Tabi Yüksek Riskli Bölgeler").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
                            document.Add(subheader_black);
                            Paragraph paragraph_black = new Paragraph("Bu beyan (önceden \"Kamu Açıklaması\" olarak adlandırılıyordu) , kara para aklama, terörün finansmanı ve nükleer silahların yayılmasının finansmanıyla mücadele konusunda ciddi stratejik eksiklikleri olan ülkeleri veya yargı bölgelerini tanımlamaktadır. FATF, yüksek riskli olarak tanımlanan tüm ülkeler için tüm üyelerine çağrıda bulunur ve tüm yetki alanlarını daha iyi bir durum tespitine başvurmaya çağırır; en ciddi vakalarda ise ülkelerden, uluslararası mali sistemi süregelen krizden korumak için karşı önlemler uygulamaları istenmektedir. Kara para aklama, terörün finansmanı ve nükleer silahların yayılmasının finansmanı ülkeden kaynaklanan risklerdir.").SetFont(mainFont).SetFontSize(8);
                            document.Add(paragraph_black);

                            Table table_black = new Table(3);
                            table_black.SetWidth(UnitValue.CreatePercentValue(100));
                            table_black.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                            table_black.AddCell(new Paragraph("POSITION/SIRA").SetFont(titleFont).SetFontSize(9));
                            table_black.AddCell(new Paragraph("TYPE/TÜR").SetFont(titleFont).SetFontSize(9));
                            table_black.AddCell(new Paragraph("COUNTRY/AREA/ÜLKE").SetFont(titleFont).SetFontSize(9));

                            Cell cell211 = new Cell().Add(new Paragraph("1").SetFont(mainFont).SetFontSize(8));
                            Cell cell212 = new Cell(3, 1).Add(new Paragraph("Eylem Çağrısına Tabi Yüksek Riskli Bölgeler").SetFont(mainFont).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetFont(mainFont).SetFontSize(8));
                            Cell cell213 = new Cell().Add(new Paragraph("Kore Demokratik Halk Cumhuriyeti\r\n").SetFont(mainFont).SetFontSize(8));
                            Cell cell221 = new Cell().Add(new Paragraph("2").SetFont(mainFont).SetFontSize(8));
                            Cell cell223 = new Cell().Add(new Paragraph("İran").SetFont(mainFont).SetFontSize(8));
                            Cell cell231 = new Cell().Add(new Paragraph("3").SetFont(mainFont).SetFontSize(8));
                            Cell cell233 = new Cell().Add(new Paragraph("Myanmar").SetFont(mainFont).SetFontSize(8));

                            table_black.AddCell(cell211);
                            table_black.AddCell(cell212);
                            table_black.AddCell(cell213);
                            table_black.AddCell(cell221);
                            table_black.AddCell(cell223);
                            table_black.AddCell(cell231);
                            table_black.AddCell(cell233);

                            document.Add(table_black);

                            document.Close();

                            tempPdfFilePath = System.IO.Path.GetTempFileName();
                            File.WriteAllBytes(tempPdfFilePath, memoryStream.ToArray());
                        }
                    }
                    break;
                case 4:
                    {
                        document.SetMargins(0, 0, 0, 0);
                        Table topTable_risk = new Table(3);
                        iText.Kernel.Colors.Color borderColor = new DeviceRgb(224, 224, 224);
                        iText.Kernel.Colors.Color color1 = new DeviceRgb(208, 208, 208);
                        topTable_risk.SetWidth(UnitValue.CreatePercentValue(98));
                        topTable_risk.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT);
                        topTable_risk.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(86)).Add(new Paragraph("RİSK YÖNETİMİ BELGESİ").SetFont(titleFont).SetFontSize(10)).SetBorder(Border.NO_BORDER));
                        topTable_risk.AddCell(new Cell().SetBackgroundColor(color1).SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).SetBorderBottom(Border.NO_BORDER).SetBorderRight(Border.NO_BORDER).Add(new Paragraph("Risk Puan").SetFont(mainFont).SetFontSize(8)));
                        topTable_risk.AddCell(new Cell().SetBackgroundColor(color1).SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).SetBorderBottom(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER).Add(new Paragraph("Puan").SetFont(mainFont).SetFontSize(8)));
                        topTable_risk.AddCell(new Cell().SetBackgroundColor(color1).SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).SetBorderRight(Border.NO_BORDER).Add(new Paragraph("A. Müşteri Riski").SetFont(titleFont).SetFontSize(9)));
                        topTable_risk.AddCell(new Cell().SetBackgroundColor(color1).SetBorder(Border.NO_BORDER));
                        topTable_risk.AddCell(new Cell().SetBackgroundColor(color1).SetBorder(Border.NO_BORDER).SetBorderRight(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("a. İş ilişkilerini ve işlemlerini alışılmadık şartlarda yürüten müşteriler").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("* 10.000 USD ve üzerinde işlemler veya 10.000 USD'nin altında olmakla birlikte birbiriyle bağlantılı olarak belirlenen meblağın üzerinde işlemler").SetFont(mainFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("* Karmaşık ve olağandışı büyüklükteki işlemler ile görünürde makul hukuki ve ekonomik amacı bulunmayan işlemler").SetFont(mainFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("b. Nakit işlemlerinin yoğun olduğu veya nakit yoğun olmamakla birlikte, belirli işlemlerden yüksek miktarda nakit üreten müşteriler").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("* Değerli taş ve maden ticareti yapan müşteriler").SetFont(mainFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("* Talih oyunları ve kumarhane faaliyetlerinde bulunan müşteriler").SetFont(mainFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("* Akaryakıt istasyonları").SetFont(mainFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("* Lüks araç satan galeriler").SetFont(mainFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("* Antikacılar").SetFont(mainFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("* Sanat Galeri").SetFont(mainFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("* Otopark İşletmecileri").SetFont(mainFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("* Piyango Bayileri vb.").SetFont(mainFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("c. Kar amacı gütmeyen kuruluşlar, Elçilik/Konsolosluklar, Yurtdışı kurulu tüzel kişilikler").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("d. Siyasi nüfuz sahibi kişiler").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("e. Yüksek değerde mal alım satımı ile uğraşanlar").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("f. Uluslararası fon transferine imkan veren işleri yapanlar").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("g. Basında veya diğer açık kaynaklarda isimleri olumsuz haberlerde geçenler").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("h. Günlük işlem hacminin 100.000 USD'nin üzerinde olması").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("i. Müşterinin riskli ülkeler ile çalışıyor olması").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("j. Nakit işlemlerinin sürekli olarak fiziki teslimat (banka kullanmadan) şeklinde yapılması").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("k. Altın tedarik sürekli iş ilişkisinde her yeni müşteri").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));

                        topTable_risk.AddCell(new Cell().SetBackgroundColor(color1).SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).SetBorderRight(Border.NO_BORDER).Add(new Paragraph("B. Hizmet Riski").SetFont(titleFont).SetFontSize(9)));
                        topTable_risk.AddCell(new Cell().SetBackgroundColor(color1).SetBorder(Border.NO_BORDER));
                        topTable_risk.AddCell(new Cell().SetBackgroundColor(color1).SetBorder(Border.NO_BORDER).SetBorderRight(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("a. Yüzyüze yapılmadan/İnternet üzerinden gerçekleşen elektronik işlemler").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("b. Başkası adına/hesabına yapılan işlemler").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("c. Yeni sunulacak ürünler").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));

                        topTable_risk.AddCell(new Cell().SetBackgroundColor(color1).SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).SetBorderRight(Border.NO_BORDER).Add(new Paragraph("C. Ülke Riski/Coğrafi Risk").SetFont(titleFont).SetFontSize(9)));
                        topTable_risk.AddCell(new Cell().SetBackgroundColor(color1).SetBorder(Border.NO_BORDER));
                        topTable_risk.AddCell(new Cell().SetBackgroundColor(color1).SetBorder(Border.NO_BORDER).SetBorderRight(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("a. FATF tarafından listeye alınan ülkeler (İşbirliği Yapmayan Ülke Listesi'nde yer alan ülkelerin vatandaşları, şirketleri ve finansal kuruluşları)").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("b. OECF/IMF gibi kuruluşlar tarafından vergi cenneti olarak yayımlanan ya da dünya genelinde vergi cenneti olarak bilinen yerler").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("c. Kıyı bankacılığı yapılan yerler").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("d. Serbest bölgeler, sınır ötesi merkezler").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("e. Suçla mücadele etmeyen, yasadışı uyuşturucu üretim-dağıtım yolları üzerinde bulunan, kaçakçılık ve terör gibi suçların oranının yüksek, yolsuzluk ve rüşvetin yaygın oludğu antidemokratik ülkeler ve bölgeler").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("f. Suç gelirinin aklanmasının ve terörün finansmanının önlenmesi konusunda yeterli düzenlemelere sahip olmayan ülkeler").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("g. Uluslararası kuruluşlarca riskli kabul edilen ülkeler/bölgeler").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));

                        topTable_risk.AddCell(new Cell().SetBackgroundColor(color1).SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).SetBorderRight(Border.NO_BORDER).Add(new Paragraph("D. Altın Tedarik Zinciri Kapsamında Riskler").SetFont(titleFont).SetFontSize(9)));
                        topTable_risk.AddCell(new Cell().SetBackgroundColor(color1).SetBorder(Border.NO_BORDER));
                        topTable_risk.AddCell(new Cell().SetBackgroundColor(color1).SetBorder(Border.NO_BORDER).SetBorderRight(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("a. Madenden çıkarılmış veya geri dönüştürülmüş altının, ihtilaflardan etkilenen veya insan hakları ihlalleri bakımından yüksek riskli olan bölgelerden tedarik edilmesi, buralardan geçmesi veya buralardan taşınması").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("b. Madenden çıkarılmış altının; rezervleri, muhtemel veya beklenen üretim miktarı sınırlı olarak bilinen bir ülkeden geldiğinin belirlenmesi").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("c. Geri dönüştürülmüş altının ihtilaflar etkilenen ve insan hakları ihlalleri bakımından yüksek riskli olarak bilinen veya makul derecede şüphelenilen bir ülkeden gelmesi veya bu ülkeden geçmiş olması").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("d. Tedarikçinin veya madenden rafineye kadar olan zincirdeki diğer bilinen şirketlerin para aklama, suç veya yolsuzluk bakımından yüksek riskli olan bir ülkede yerleşmiş olması").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("e. Tedarikçinin veya madenden rafineye kadar olan zincirdeki diğer bilinen şirketlerin veya bunların menfaat sahiplerinin siyasi nüfuzlu kişiler olması").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("f. Tedarikçinin veya madenden rafineye kadar olan zincirdeki diğer bilinen şirketlerin silah, bahis ve kumarhane, antika ve sanat eserleri, elmas ticareti ve dini gruplar ile bunların liderleri gibi işlerde aktif olmaları").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));

                        topTable_risk.AddCell(new Cell(1, 2).SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("TOPLAM RİSK PUANI").SetFont(titleFont).SetFontSize(7)).SetTextAlignment(TextAlignment.RIGHT));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));
                        topTable_risk.AddCell(new Cell(1, 2).SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("RİSK GRUBU").SetFont(titleFont).SetFontSize(7)).SetTextAlignment(TextAlignment.RIGHT));
                        topTable_risk.AddCell(new Cell().SetBorder(new SolidBorder(borderColor, (float)0.9, 1)));

                        topTable_risk.AddCell(new Cell(1,3).SetBackgroundColor(color1).SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).SetBorderRight(Border.NO_BORDER).Add(new Paragraph("Risk Grubu Sınıflandırmaları").SetFont(titleFont).SetFontSize(9)));
                        topTable_risk.AddCell(new Cell(1,3).SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("A. Yüksek Risk Grubuna Giren Müşteriler (4+ Puan)").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell(1, 3).SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("B. Orta Risk Grubuna Giren Müşteriler (4+ Puan)").SetFont(titleFont).SetFontSize(7)));
                        topTable_risk.AddCell(new Cell(1, 3).SetBorder(new SolidBorder(borderColor, (float)0.9, 1)).Add(new Paragraph("C. Düşük Risk Grubuna Giren Müşteriler (4+ Puan)").SetFont(titleFont).SetFontSize(7)));

                        document.Add(topTable_risk);

                    }
                    break;
                case 5:
                    {
                        string currentMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Today.Month);

                        List<object> gonderenSirket = new List<object>();
                        query = "SELECT vergi_dairesi, vergi_no, telefon_no, yetkili_kisi, eposta_adresi FROM dbo.Sirket WHERE kullanici_sirket = 1";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    int columnCount = reader.FieldCount;
                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < columnCount; i++)
                                        {
                                            gonderenSirket.Add(reader.GetValue(i));
                                        }
                                    }
                                }
                            }
                            connection.Close();
                        }

                        List<List<object>> faturas = new List<List<object>>();
                        query = $"SELECT * FROM dbo.Fatura WHERE musteri_ad = @AdSoyad AND MONTH(tarih) = @Ay";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@AdSoyad", name);
                                command.Parameters.AddWithValue("@Ay", DateTime.Today.Month);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    int columnCount = reader.FieldCount;
                                    while (reader.Read())
                                    {
                                        List<object> rowData = new List<object>();
                                        for (int i = 0; i < columnCount; i++)
                                        {
                                            rowData.Add(reader.GetValue(i));
                                        }
                                        faturas.Add(rowData);
                                    }
                                }
                            }
                        }
                        Paragraph title = new Paragraph("\nMutabakat Formu\n").SetFontSize(14).SetFont(titleFont).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("(Lütfen Acil Cevaplayınız)").SetFontSize(14).SetFont(mainFont).SetTextAlignment(TextAlignment.CENTER));
                        document.Add(title);
                        Paragraph greeting = new Paragraph($"Sayın, {name}").SetFontSize(9).SetFont(titleFont);
                        Paragraph topnote = new Paragraph($"{DateTime.Today.Year}/{currentMonthName} Dönemi Formlarına ilişkin fatura sayısı ve tutarlarına ait bilgiler aşağıda yer almaktadır. Mutabık olup olmadığınızı bildirmenizi rica ederiz.\r\nSaygılarımızla\n\n\n").SetFontSize(9).SetFont(mainFont);
                        document.Add(greeting);
                        document.Add(topnote);

                        Table cariTable = new Table(2);
                        cariTable.SetWidth(UnitValue.CreatePercentValue(100));
                        cariTable.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        cariTable.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(50)).SetBorderTop(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER).SetBorderRight(Border.NO_BORDER).Add(new Paragraph("Gönderen").SetFont(titleFont).SetFontSize(12)));
                        cariTable.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(50)).SetBorderTop(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER).SetBorderRight(Border.NO_BORDER).Add(new Paragraph("Cari Hesap Bilgileriniz").SetFont(titleFont).SetFontSize(12)));
                        cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Vergi Dairesi: {gonderenSirket[0].ToString()}").SetFont(titleFont).SetFontSize(9)));
                        if(customer_type != "Adi Ortaklık")
                        {
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Vergi Dairesi: {customer_info[19].ToString()}").SetFont(titleFont).SetFontSize(9)));
                        }
                        else
                        {
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Vergi Dairesi: {customer_info[23].ToString()}").SetFont(titleFont).SetFontSize(9)));
                        }
                        //cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Vergi Dairesi:").SetFont(titleFont).SetFontSize(9)));
                        cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Vergi Numarası: {gonderenSirket[1].ToString()}").SetFont(titleFont).SetFontSize(9)));
                        if(customer_type != "Adi Ortaklık")
                        {
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Vergi Numarası: {customer_info[3].ToString()}").SetFont(titleFont).SetFontSize(9)));
                        }
                        else
                        {
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Vergi Numaraları: {customer_info[16].ToString()} / {customer_info[19].ToString()}").SetFont(titleFont).SetFontSize(9)));
                        }
                        cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Telefon: {gonderenSirket[2].ToString()}").SetFont(titleFont).SetFontSize(9)));
                        if (customer_type != "Gerçek Kişi" || customer_type != "Şahıs")
                        {
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Telefon: {customer_info[6].ToString()}").SetFont(titleFont).SetFontSize(9)));
                        }
                        else
                        {
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Telefon: {customer_info[8].ToString()}").SetFont(titleFont).SetFontSize(9)));
                        }
                        cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Yetkili:{gonderenSirket[3].ToString()}").SetFont(titleFont).SetFontSize(9)));
                        cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph("Yetkili:").SetFont(titleFont).SetFontSize(9)));
                        cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"E-Posta:{gonderenSirket[4].ToString()}").SetFont(titleFont).SetFontSize(9)));
                        if (customer_type != "Gerçek Kişi" || customer_type != "Şahıs")
                        {
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"E-Posta: {customer_info[8].ToString()}").SetFont(titleFont).SetFontSize(9)));
                        }
                        else
                        {
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Telefon: {customer_info[10].ToString()}").SetFont(titleFont).SetFontSize(9)));
                        }
                        

                        document.Add(cariTable);

                        Paragraph splitter = new Paragraph("\n");
                        document.Add(splitter);

                        //Table mutabakat_ustTablo = new Table(4);
                        //mutabakat_ustTablo.SetWidth(UnitValue.CreatePercentValue(100));
                        //mutabakat_ustTablo.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        //mutabakat_ustTablo.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(25)).Add(new Paragraph("Mutabakat").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        //mutabakat_ustTablo.AddCell(new Cell().Add(new Paragraph("Dönem").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        //mutabakat_ustTablo.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(25)).Add(new Paragraph("Belge Sayısı").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        //mutabakat_ustTablo.AddCell(new Cell().Add(new Paragraph("Toplam Tutar").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        //mutabakat_ustTablo.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(25)).Add(new Paragraph(" ").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        //mutabakat_ustTablo.AddCell(new Cell().Add(new Paragraph(" ").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        //mutabakat_ustTablo.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(25)).Add(new Paragraph(" ").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        //mutabakat_ustTablo.AddCell(new Cell().Add(new Paragraph(" ").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));

                        //document.Add(mutabakat_ustTablo);

                        Paragraph mutabakat_alttablo_title = new Paragraph("\nYAPILAN İŞLEMLER\n").SetFontSize(12).SetFont(titleFont).SetTextAlignment(TextAlignment.CENTER);
                        document.Add(mutabakat_alttablo_title);

                        Table mutabakat_altTablo = new Table(9);
                        mutabakat_altTablo.SetWidth(UnitValue.CreatePercentValue(100));
                        mutabakat_altTablo.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                        mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph("Tarih").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph("Müşteri Ad/Unvan").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph("Alış/Satış").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph("Cinsi").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph("Miktarı").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph("Kuru").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph("TL Tutarı").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph("Dolar Karşılığı").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph("Belge No").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        //for(int i = 0; i < faturas.Count; i++)
                        foreach(var fatura in faturas)
                        {
                            mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph($"{fatura[2]}").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                            mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph($"{fatura[4]}").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                            if (Convert.ToInt32(fatura[5]) == 0)
                                mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph($"A").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                            else
                                mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph($"S").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                            mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph($"{fatura[6]}").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                            mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph($"{fatura[7]}").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                            mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph($"{fatura[8]}").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                            mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph($"{fatura[9]}").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                            mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph($"{fatura[10]}").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                            mutabakat_altTablo.AddCell(new Cell().Add(new Paragraph($"{fatura[11]}").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        }

                        document.Add(mutabakat_altTablo);

                        document.Add(splitter);

                        Paragraph notlar_title = new Paragraph("Notlar").SetFontSize(10).SetFont(titleFont);
                        document.Add(notlar_title);

                        document.Add(splitter);
                        document.Add(splitter);

                        Table kaseTable = new Table(2);
                        kaseTable.SetWidth(UnitValue.CreatePercentValue(100));
                        kaseTable.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                        kaseTable.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).Add(new Paragraph("Kaşe/İmza").SetTextAlignment(TextAlignment.CENTER).SetFont(titleFont).SetFontSize(12)));
                        kaseTable.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).Add(new Paragraph("Kaşe/İmza").SetTextAlignment(TextAlignment.CENTER).SetFont(titleFont).SetFontSize(12)));

                        document.Add(kaseTable);
                    }
                    break;
                case 6:
                    {
                        List<object> fatura = new List<object>();

                        List<object> gonderenSirket = new List<object>();
                        List<object> musteri = new List<object>();

                        query = "SELECT * FROM dbo.Sirket WHERE kullanici_sirket = 1";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    int columnCount = reader.FieldCount;
                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < columnCount; i++)
                                        {
                                            gonderenSirket.Add(reader.GetValue(i));
                                        }
                                    }
                                }
                            }
                            connection.Close();
                        }

                        query = $"SELECT * FROM dbo.Fatura WHERE eid = @EID";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@EID", customer_type);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    int columnCount = reader.FieldCount;
                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < columnCount; i++)
                                        {
                                            fatura.Add(reader.GetValue(i));
                                        }
                                    }
                                }
                            }
                        }

                        int musteriKod = Convert.ToInt32(fatura[3]);
                        string[] getMusteriQueries = new string[] { "SELECT vergi_dairesi, vergi_numarasi, telefon_no, musteri_ad, eposta_adres FROM dbo.TuzelKisi WHERE musteri_kodu = @MusteriKod", "SELECT vergi_dairesi, vergi_numarasi, telefon_no, musteri_ad, eposta_adres FROM dbo.GercekKisi WHERE musteri_kodu = @MusteriKod", "SELECT vergi_numarasi, telefon_no, musteri_ad, eposta_adres FROM dbo.Sahis WHERE musteri_kodu = @MusteriKod", "SELECT vergi_dairesi, ortak1_vergino, telefon_no, musteri_ad, eposta_adres, ortak2_vergino FROM dbo.AdiOrtaklik WHERE musteri_kodu = @MusteriKod" };
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand())
                            {
                                command.Parameters.AddWithValue("@MusteriKod", musteriKod);
                                foreach (string getQuery in getMusteriQueries)
                                {
                                    if (getQuery.Contains("Sahis"))
                                        musteri.Add("Bireysel");
                                    command.CommandText = getQuery;
                                    object rowCount = command.ExecuteScalar();
                                    if(Convert.ToInt32(rowCount) == 1)
                                    {
                                        using (SqlDataReader reader = command.ExecuteReader())
                                        {
                                            int columnCount = reader.FieldCount;
                                            while (reader.Read())
                                            {
                                                for (int i = 0; i < columnCount; i++)
                                                {
                                                    musteri.Add(reader.GetValue(i));
                                                }
                                            }
                                        }
                                        break;
                                    }
                                    musteri.Clear();
                                }
                                
                                
                            }
                        }
                        
                        //List<object> musteri = new List<object>();

                        Paragraph title = new Paragraph("\nTeslim Tesellüm\n").SetFontSize(14).SetFont(titleFont).SetTextAlignment(TextAlignment.CENTER);
                        document.Add(title);
                        Paragraph billno = new Paragraph($"Fatura No: {customer_type}").SetFontSize(9).SetFont(titleFont);
                        document.Add(billno);

                        Paragraph splitter = new Paragraph("\n");
                        document.Add(splitter);

                        Table cariTable = new Table(2);
                        cariTable.SetWidth(UnitValue.CreatePercentValue(100));
                        cariTable.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        cariTable.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(50)).SetBorderTop(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER).SetBorderRight(Border.NO_BORDER).Add(new Paragraph("Satın Alan Firma Bilgileri ").SetFont(titleFont).SetFontSize(12)));
                        cariTable.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(50)).SetBorderTop(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER).SetBorderRight(Border.NO_BORDER).Add(new Paragraph("Satış Yapan Firma Bilgileri").SetFont(titleFont).SetFontSize(12)));
                        if (fatura[5].ToString() == "0")
                        {
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Vergi Dairesi: {gonderenSirket[8].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Vergi Dairesi: {musteri[0].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Vergi Numarası: {gonderenSirket[9].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Vergi Numarası: {musteri[1].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Telefon: {gonderenSirket[5].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Telefon: {musteri[2].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Yetkili: {gonderenSirket[7].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Yetkili: {musteri[3].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"E-Posta: {gonderenSirket[6].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"E-Posta: {musteri[4].ToString()}").SetFont(titleFont).SetFontSize(9)));
                        }
                        else
                        {
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Vergi Dairesi: {musteri[0].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Vergi Dairesi: {gonderenSirket[8].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Vergi Numarası: {musteri[1].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Vergi Numarası: {gonderenSirket[9].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Telefon: {musteri[2].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Telefon: {gonderenSirket[5].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Yetkili: {musteri[3].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"Yetkili: {gonderenSirket[7].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"E-Posta: {musteri[4].ToString()}").SetFont(titleFont).SetFontSize(9)));
                            cariTable.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(new Paragraph($"E-Posta: {gonderenSirket[6].ToString()}").SetFont(titleFont).SetFontSize(9)));
                        }
                        

                        document.Add(cariTable);

                        document.Add(splitter);

                        Paragraph teslim_alttablo_title = new Paragraph("\nYAPILAN İŞLEMLER\n").SetFontSize(12).SetFont(titleFont).SetTextAlignment(TextAlignment.CENTER);
                        document.Add(teslim_alttablo_title);

                        Table teslim_altTablo = new Table(9);
                        teslim_altTablo.SetWidth(UnitValue.CreatePercentValue(100));
                        teslim_altTablo.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                        teslim_altTablo.AddCell(new Cell().Add(new Paragraph("Tarih").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        teslim_altTablo.AddCell(new Cell().Add(new Paragraph("Müşteri Ad/Unvan").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        teslim_altTablo.AddCell(new Cell().Add(new Paragraph("Alış/Satış").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        teslim_altTablo.AddCell(new Cell().Add(new Paragraph("Cinsi").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        teslim_altTablo.AddCell(new Cell().Add(new Paragraph("Miktarı").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        teslim_altTablo.AddCell(new Cell().Add(new Paragraph("Kuru").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        teslim_altTablo.AddCell(new Cell().Add(new Paragraph("TL Tutarı").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        teslim_altTablo.AddCell(new Cell().Add(new Paragraph("Dolar Karşılığı").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        teslim_altTablo.AddCell(new Cell().Add(new Paragraph("Belge No").SetFont(titleFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));

                            teslim_altTablo.AddCell(new Cell().Add(new Paragraph($"{fatura[2].ToString()}").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                            teslim_altTablo.AddCell(new Cell().Add(new Paragraph($"{fatura[4].ToString()}").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        if (Convert.ToInt32(fatura[5]) == 0)
                            teslim_altTablo.AddCell(new Cell().Add(new Paragraph($"A").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                        else
                            teslim_altTablo.AddCell(new Cell().Add(new Paragraph($"S").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                            
                            teslim_altTablo.AddCell(new Cell().Add(new Paragraph($"{fatura[6].ToString()}").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                            teslim_altTablo.AddCell(new Cell().Add(new Paragraph($"{fatura[7].ToString()}").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                            teslim_altTablo.AddCell(new Cell().Add(new Paragraph($"{fatura[8].ToString()}").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                            teslim_altTablo.AddCell(new Cell().Add(new Paragraph($"{fatura[9].ToString()}").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                            teslim_altTablo.AddCell(new Cell().Add(new Paragraph($"{fatura[10].ToString()}").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                            teslim_altTablo.AddCell(new Cell().Add(new Paragraph($"{fatura[11].ToString()}").SetFont(mainFont).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));


                        document.Add(teslim_altTablo);

                        document.Add(splitter);

                        Table kaseTable = new Table(2);
                        kaseTable.SetWidth(UnitValue.CreatePercentValue(100));
                        kaseTable.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                        kaseTable.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).Add(new Paragraph("Kaşe/İmza").SetTextAlignment(TextAlignment.CENTER).SetFont(titleFont).SetFontSize(10)));
                        kaseTable.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).Add(new Paragraph("Kaşe/İmza").SetTextAlignment(TextAlignment.CENTER).SetFont(titleFont).SetFontSize(10)));
                        kaseTable.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).Add(new Paragraph("Ad Soyad").SetTextAlignment(TextAlignment.CENTER).SetFont(titleFont).SetFontSize(10)));
                        kaseTable.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).Add(new Paragraph("Ad Soyad").SetTextAlignment(TextAlignment.CENTER).SetFont(titleFont).SetFontSize(10)));
                        kaseTable.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).Add(new Paragraph("İmza").SetTextAlignment(TextAlignment.CENTER).SetFont(titleFont).SetFontSize(10)));
                        kaseTable.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).Add(new Paragraph("İmza").SetTextAlignment(TextAlignment.CENTER).SetFont(titleFont).SetFontSize(10)));
                        kaseTable.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).Add(new Paragraph("TC Kimlik Numarası").SetTextAlignment(TextAlignment.CENTER).SetFont(titleFont).SetFontSize(10)));
                        kaseTable.AddCell(new Cell().SetWidth(UnitValue.CreatePercentValue(50)).SetBorder(Border.NO_BORDER).Add(new Paragraph("TC Kimlik Numarası").SetTextAlignment(TextAlignment.CENTER).SetFont(titleFont).SetFontSize(10)));

                        document.Add(kaseTable);

                        Paragraph description_title = new Paragraph("Açıklamalar").SetFontSize(10).SetFont(titleFont);
                        document.Add(description_title);

                        Text description_text1 = new Text($"İş bu teslim tesellüm belgesi; Müşteri ile {gonderenSirket[2].ToString()} şirketinin miktar ve fiyatta mutabık kalarak {gonderenSirket[2].ToString()} şirketi tarafından tarafından yukarıda yazılı ").SetFontSize(9).SetFont(mainFont);
                        Text description_text2 = new Text("satın alınan").SetFontSize(9).SetFont(titleFont).SetUnderline();
                        Text description_text3 = new Text("");
                        if (Convert.ToInt32(fatura[5]) == 0)
                            description_text3 = new Text($"dövizin Karşılığı Yukarıda yazılı Türk Lirası Miktarını nakit olarak {gonderenSirket[2].ToString()} tam ve eksiksiz olarak teslim alındığını belgelemek adına tanzim edilmiştir. Alacak borç bakiyesi sıfırdır. {musteri[3].ToString()} tarafından Döviz Alım belgesi teslim alan kişiye verilmiştir.").SetFontSize(9).SetFont(mainFont);
                        else
                            description_text3 = new Text($"dövizin Karşılığı Yukarıda yazılı Türk Lirası Miktarını nakit olarak {musteri[3].ToString()} tam ve eksiksiz olarak teslim alındığını belgelemek adına tanzim edilmiştir. Alacak borç bakiyesi sıfırdır. {gonderenSirket[2].ToString()} tarafından Döviz Alım belgesi teslim alan kişiye verilmiştir.").SetFontSize(9).SetFont(mainFont);

                        Paragraph description = new Paragraph().Add(description_text1).Add(description_text2).Add(description_text3);
                        document.Add(description);
                    }
                    break;
            }


            if (file_type == 0 || file_type == 2 || file_type == 4 || file_type == 5 || file_type == 6)
            {
                document.Close();
                pdfBytes = memoryStream.ToArray();
                base64String = Convert.ToBase64String(pdfBytes);

                string htmlContent = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        html, body {{
            margin: 0;
            padding: 0;
            height: 100%;
        }}
        embed {{
            width: 100%;
            height: 100%;
        }}
    </style>
</head>
<body>
    <embed src='data:application/pdf;base64,{Uri.EscapeDataString(base64String)}#toolbar=0&navpanes=0' type='application/pdf' />
</body>
</html>
";
                browser_file.Source = new Uri("data:text/html;base64," + Convert.ToBase64String(Encoding.UTF8.GetBytes(htmlContent)));
            }
            else if (file_type == 1 || file_type == 3)
            {
                browser_file.Source = new Uri($"{tempPdfFilePath}");
            }

            
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            string filename = "";
            switch(file_type)
            {
                case 0:
                    filename = $"{name}_kontrolraporu.pdf";
                    break;
                case 1:
                    filename = $"{name}_guvenlikraporu.pdf";
                    pdfBytes = File.ReadAllBytes(tempPdfFilePath);
                    break;
                case 2:
                    filename = $"{name}_tanimaformu.pdf";
                    break;
                case 3:
                    filename = $"{name}_fatf.pdf";
                    pdfBytes = File.ReadAllBytes(tempPdfFilePath);
                    break;
                case 4:
                    filename = $"{name}_riskyonetimi.pdf";
                    break;
                case 5:
                    filename = $"{name}_mutabakat.pdf";
                    break;
                case 6:
                    filename = $"{name}_teslimtesellum.pdf";
                    break;
            }
            
            string filePath = $"pdf\\{filename}";
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    fileStream.Write(pdfBytes, 0, pdfBytes.Length);
                    MessageBox.Show("Dosya 'pdf' klasörüne kaydedildi.", "Dosya Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Belge kaydı gerçekleştirilemedi.", "Dosya Kaydedilemedi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button_print_Click(object sender, EventArgs e)
        {
            string filename = "";
            switch (file_type)
            {
                case 0:
                    filename = $"{name}_kontrolraporu.pdf";
                    break;
                case 1:
                    filename = $"{name}_guvenlikraporu.pdf";
                    pdfBytes = File.ReadAllBytes(tempPdfFilePath);
                    break;
                case 2:
                    filename = $"{name}_tanimaformu.pdf";
                    break;
                case 3:
                    filename = $"{name}_fatf.pdf";
                    pdfBytes = File.ReadAllBytes(tempPdfFilePath);
                    break;
                case 4:
                    filename = $"{name}_riskyonetimi.pdf";
                    break;
                case 5:
                    filename = $"{name}_mutabakat.pdf";
                    break;
                case 6:
                    filename = $"{name}_teslimtesellum.pdf";
                    break;
            }
            string filePath = $"pdf\\{filename}";
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                fileStream.Write(pdfBytes, 0, pdfBytes.Length);
                PrintPDF(filePath);
            }
        }

        private void PrintPDF(string filePath)
        {
            PrintDocument printDocument = new PrintDocument();

            printDocument.PrintPage += (sender, e) =>
            {
                e.Graphics.DrawImage(System.Drawing.Image.FromFile(filePath), e.MarginBounds);
            };
            try
            {
                printDocument.Print();
            }
            catch
            {
                MessageBox.Show("Yazıcı şu anda kullanılamıyor veya yazıcı tanımlanmadı.", "Yazdırma Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}