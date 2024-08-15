using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Evrak_Takibi_Programı
{
    internal static class GüvenlikTaramaİstekleri
    {
        public interface IResponse { }

        public class IdariParaCezasi
        {
            public int id { get; set; }
            public string? mkkSicilNo { get; set; }
            public string? unvan { get; set; }
            public DateTime kurulKararTarihi { get; set; }
            public string? kurulKararNo { get; set; }
            public string? aciklama { get; set; }
            public string? teblig { get; set; }
            public double tutar { get; set; }
            public string? davaBilgisi { get; set; }
            public string? yargilamaAsamasi { get; set; }
            public string? kurulKarari { get; set; }
            public string? ihlal { get; set; }
        }

        public class TekilİdariParaCezasi
        {
            public string? Unvan { get; set; }
            public string? MkkSicilNo { get; set; }
            public string? Pay { get; set; }
            public string? PayKodu { get; set; }
            public string? KurulKararTarihi { get; set; }
            public string? KurulKararNo { get; set; }
        }

        public class SingleResponse : IResponse
        {
            public TekilİdariParaCezasi Item { get; set; }
        }

        public class ListResponse : IResponse
        {
            public List<IdariParaCezasi> Items { get; set; }
        }

        public static async Task<String> TCKimlikKontrolu(long tcKimlikNo, string ad, string soyad, int dogumYili)
        {
            var soapRequest = $@"<?xml version=""1.0"" encoding=""utf-8""?>
            <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
              <soap:Body>
                <TCKimlikNoDogrula xmlns=""http://tckimlik.nvi.gov.tr/WS"">
                  <TCKimlikNo>{tcKimlikNo}</TCKimlikNo>
                  <Ad>{ad}</Ad>
                  <Soyad>{soyad}</Soyad>
                  <DogumYili>{dogumYili}</DogumYili>
                </TCKimlikNoDogrula>
              </soap:Body>
            </soap:Envelope>";
            using (var httpClient = new HttpClient())
            {
                HttpContent content = new StringContent(soapRequest, Encoding.UTF8, "text/xml");
                content.Headers.Add("SOAPAction", "http://tckimlik.nvi.gov.tr/WS/TCKimlikNoDogrula");
                var response = await httpClient.PostAsync("https://tckimlik.nvi.gov.tr/Service/KPSPublic.asmx", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return null;
            }
        }
        public static async Task<IResponse> SPK(int step, string? tc_id = null)
        {
            string request = "";
            switch(step)
            {
                case 1:
                    request = "https://ws.spk.gov.tr/IdariYaptirimlar/api/TumIdariParaCezalari";
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();
                            List<IdariParaCezasi> idariParaCezalari = JsonConvert.DeserializeObject<List<IdariParaCezasi>>(responseBody);
                            return new ListResponse { Items = idariParaCezalari };
                        }
                        else
                        {
                            string errorMessage = $"Error: {response.StatusCode}\n{response.ReasonPhrase}";
                            MessageBox.Show(errorMessage,"SPK Taramaları",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                    break;
                case 2:
                    if(tc_id != null)
                    {
                        request = $"https://ws.spk.gov.tr/IdariYaptirimlar/api/IslemYasaklari/Kisi/{tc_id}";
                        using (HttpClient client = new HttpClient())
                        {
                            HttpResponseMessage response = await client.GetAsync(request);
                            if(response.IsSuccessStatusCode)
                            {
                                string responseBody = await response.Content.ReadAsStringAsync();
                                TekilİdariParaCezasi idariParaCezasi = JsonConvert.DeserializeObject<TekilİdariParaCezasi>(responseBody);
                                return new SingleResponse { Item = idariParaCezasi };
                            }
                        }
                    }
                    break;
            }
            return null;
        }
        public static async Task<String> NullTask()
        {
            return "";
        }
    }
}
