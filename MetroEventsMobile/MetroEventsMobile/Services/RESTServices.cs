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
        private static string BaseUrl = "https://6b3a-124-107-184-208.ngrok.io";
        private static string Version = "metro";

        private static string urlUserCreateAccount = BaseUrl + "/" + Version + "/users";
        private static string urlUserCreatedEvents(string id) => BaseUrl + "/" + Version + "/users/" + id + "/created-events";
        private static string urlUserSignIn = BaseUrl + "/" + Version + "/login";
        
        private static string urlEventCreate = BaseUrl + "/" + Version + "/events";
        private static string urlEventDelete(string id) => BaseUrl + "/" + Version + "/events/" + id;


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

        public static async Task<HttpResponseMessage> CreateAccount(string json)
        {
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await RestCall.PostAsync(urlUserCreateAccount, content);
            return response;
        }

        public static async Task<User> SignIn(string json)
        {
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await RestCall.PostAsync(urlUserSignIn, content);
            string responseContent = await response.Content.ReadAsStringAsync();
            User user = JsonConvert.DeserializeObject<User>(responseContent);
            return user;
        }

        public static async Task<Event> CreateEvent(string json)
        {
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await RestCall.PostAsync(urlEventCreate, content);
            string responseContent = await response.Content.ReadAsStringAsync();
            Event _event = JsonConvert.DeserializeObject<Event>(responseContent);
            return _event;
        }

        public static async Task<HttpResponseMessage> DeleteEvent(string id)
        {
            HttpResponseMessage response = await RestCall.DeleteAsync(urlEventDelete(id));
            return response;
        }

        public static async Task<List<Event>> GetAllCreatedEvents(string id)
        {
            HttpResponseMessage response = await RestCall.GetAsync(urlUserCreatedEvents(id));
            string responseContent = await response.Content.ReadAsStringAsync();
            List<Event> events = JsonConvert.DeserializeObject<List<Event>>(responseContent);
            return events;
        }
    }
}
