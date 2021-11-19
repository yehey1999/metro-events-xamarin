using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using MetroEventsMobile.Models;
using Newtonsoft.Json;

namespace MetroEventsMobile.Services
{
    class RESTServices
    {
        private static string BaseUrl = "https://6444-124-107-184-208.ngrok.io";
        private static string Version = "metro";

        private static string urlUserCreateAccount = BaseUrl + "/" + Version + "/users";

        private static HttpClient client = null;

        public static HttpClient RestCall
        {
            get
            {
                if (client == null)
                {
                    client = new HttpClient();  
                }
                return client;
            }
            set { }
        }

        public static async Task<HttpResponseMessage> CreateAccount(String json)
        {
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await RestCall.PostAsync(urlUserCreateAccount, content);
            return response;
        }
    }
}
