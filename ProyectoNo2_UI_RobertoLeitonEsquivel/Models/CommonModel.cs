using MODELS.Models.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoNo2_UI_RobertoLeitonEsquivel.Models
{
    public class CommonModel : ICommon
    {
        private static readonly Lazy<HttpClient> lazyHttpClient = new Lazy<HttpClient>(() => new HttpClient());

        private static HttpClient Instance => lazyHttpClient.Value;


        private readonly string baseAddress;

        public CommonModel()
        {
            baseAddress = ConfigurationManager.AppSettings["BaseUrl"].ToString();
        }

        public async Task<T> ExecuteHttpAsync<T>(HttpMethod _httpMethod, string _enpoint, T _data = default)
        {
            StringContent content = null;

            if (_httpMethod == HttpMethod.Post)
            {
                string jsonData = JsonConvert.SerializeObject(_data);

                content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            }
           

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = _httpMethod,
                Content = content,
                RequestUri = new Uri($"{baseAddress}{_enpoint}")
            };

            var result = await Instance.SendAsync(request);

            if (result.IsSuccessStatusCode)
            {
                if (_httpMethod == HttpMethod.Get)
                {
                    T datos = JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());

                    return datos;
                }
            }

            return default;
        }
    }
}