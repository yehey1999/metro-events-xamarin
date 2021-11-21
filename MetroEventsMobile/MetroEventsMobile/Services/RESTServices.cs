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
        private static string BaseUrl = "https://5d03-124-107-184-208.ngrok.io";
        private static string Version = "metro";
        
        private static string urlUserAll = BaseUrl + "/" + Version + "/users";
        private static string urlUserCreateAccount = BaseUrl + "/" + Version + "/users";
        private static string urlUserCreatedEvents(string id) => BaseUrl + "/" + Version + "/users/" + id + "/created-events";
        private static string urlUserSentRequests(string id) => BaseUrl + "/" + Version + "/users/" + id + "/requests";
        private static string urlUserSignIn = BaseUrl + "/" + Version + "/login";
        
        private static string urlEventCreate = BaseUrl + "/" + Version + "/events";
        private static string urlEventAll = BaseUrl + "/" + Version + "/events";
        private static string urlEventParticipants(string id) => BaseUrl + "/" + Version + "/events/" + id + "/participants";
        private static string urlEventRequests(string id) => BaseUrl + "/" + Version + "/events/" + id + "/requests";
        private static string urlEventReviews(string id) => BaseUrl + "/" + Version + "/reviews/events/" + id;
        private static string urlEventUpdate(string id) => BaseUrl + "/" + Version + "/events/" + id;
        private static string urlEventCreateReview(string id) => BaseUrl + "/" + Version + "/reviews/events/" + id;
        private static string urlEventDelete(string id) => BaseUrl + "/" + Version + "/events/" + id;

        private static string urlCreateRequest = BaseUrl + "/" + Version + "/requests";
        private static string urlRequestAll = BaseUrl + "/" + Version + "/requests";
        private static string urlRequestUpdate(string id) => BaseUrl + "/" + Version + "/requests/" + id;
        



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

        public static async Task<List<User>> GetAllUsers()
        {
            HttpResponseMessage response = await RestCall.GetAsync(urlUserAll);
            string responseContent = await response.Content.ReadAsStringAsync();
            List<User> users = JsonConvert.DeserializeObject<List<User>>(responseContent);
            return users;
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

        public static async Task<List<Event>> GetAllEvents()
        {
            HttpResponseMessage response = await RestCall.GetAsync(urlEventAll);
            string responseContent = await response.Content.ReadAsStringAsync();
            List<Event> events = JsonConvert.DeserializeObject<List<Event>>(responseContent);
            return events;
        }

        public static async Task<List<Event>> GetAllCreatedEvents(string id)
        {
            HttpResponseMessage response = await RestCall.GetAsync(urlUserCreatedEvents(id));
            string responseContent = await response.Content.ReadAsStringAsync();
            List<Event> events = JsonConvert.DeserializeObject<List<Event>>(responseContent);
            return events;
        }

        public static async Task<Request> CreateJoinEventRequest(FormUrlEncodedContent content)
        {
            HttpResponseMessage response = await RestCall.PostAsync(urlCreateRequest, content);
            string responseContent = await response.Content.ReadAsStringAsync();
            Request request = JsonConvert.DeserializeObject<Request>(responseContent);
            return request;
        }

        public static async Task<Request> CreateRequest(FormUrlEncodedContent content)
        {
            HttpResponseMessage response = await RestCall.PostAsync(urlCreateRequest, content);
            string responseContent = await response.Content.ReadAsStringAsync();
            Request request = JsonConvert.DeserializeObject<Request>(responseContent);
            return request;
        }

        public static async Task<List<Request>> GetAllSentRequests(string id)
        {
            HttpResponseMessage response = await RestCall.GetAsync(urlUserSentRequests(id));
            string responseContent = await response.Content.ReadAsStringAsync();
            List<Request> requests = JsonConvert.DeserializeObject<List<Request>>(responseContent);
            return requests;
        }

        public static async Task<Request> UpdateJoinEventRequest(FormUrlEncodedContent content, string id)
        {
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), urlRequestUpdate(id))
            {
                Content = content
            };
            HttpResponseMessage response = await client.SendAsync(request);
            string responseContent = await response.Content.ReadAsStringAsync();
            Request _request = JsonConvert.DeserializeObject<Request>(responseContent);
            return _request;
        }

        public static async Task<Request> UpdateRequest(FormUrlEncodedContent content, string id)
        {
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), urlRequestUpdate(id))
            {
                Content = content
            };
            HttpResponseMessage response = await client.SendAsync(request);
            string responseContent = await response.Content.ReadAsStringAsync();
            Request _request = JsonConvert.DeserializeObject<Request>(responseContent);
            return _request;
        }

        public static async Task<List<User>> GetEventParticipants(string id)
        {
            HttpResponseMessage response = await RestCall.GetAsync(urlEventParticipants(id));
            string responseContent = await response.Content.ReadAsStringAsync();
            List<User> participants = JsonConvert.DeserializeObject<List<User>>(responseContent);
            return participants;
        }

        public static async Task<List<Request>> GetAllRequests()
        {
            HttpResponseMessage response = await RestCall.GetAsync(urlRequestAll);
            string responseContent = await response.Content.ReadAsStringAsync();
            List<Request> requests = JsonConvert.DeserializeObject<List<Request>>(responseContent);
            return requests;
        }

        public static async Task<List<Review>> GetEventReviews(string id)
        {
            HttpResponseMessage response = await RestCall.GetAsync(urlEventReviews(id));
            string responseContent = await response.Content.ReadAsStringAsync();
            List<Review> reviews = JsonConvert.DeserializeObject<List<Review>>(responseContent);
            return reviews;
        }

        public static async Task<Review> CreateReview(FormUrlEncodedContent content, string id)
        {
            HttpResponseMessage response = await RestCall.PostAsync(urlEventCreateReview(id), content);
            string responseContent = await response.Content.ReadAsStringAsync();
            Review review = JsonConvert.DeserializeObject<Review>(responseContent);
            return review;
        }

        public static async Task<Event> UpdateEvent(FormUrlEncodedContent content, string id)
        {
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), urlEventUpdate(id))
            {
                Content = content
            };
            HttpResponseMessage response = await client.SendAsync(request);
            string responseContent = await response.Content.ReadAsStringAsync();
            Event _event = JsonConvert.DeserializeObject<Event>(responseContent);
            return _event;
        }

    }
}
