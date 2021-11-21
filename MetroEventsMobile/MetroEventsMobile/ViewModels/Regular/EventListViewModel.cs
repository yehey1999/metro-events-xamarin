using MetroEventsMobile.Models;
using MetroEventsMobile.Services;
using MetroEventsMobile.Views;
using MetroEventsMobile.Views.Regular;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MetroEventsMobile.ViewModels.Regular
{
    class EventListViewModel : BaseViewModel
    {
        private List<Event> events = new List<Event>();

        public List<Event> Events
        {
            get => events;
            set => SetProperty(ref events, value);
        }

        public Command OnCreateJoinEventRequestCommand { get; private set; }
        public Command OnGoToRequestsCommand { get; private set; }
        public Command OnCreateRequestCommand { get; private set; }
        public Command OnGoEventReviewsCommand { get; private set; }
        public Command OnLogoutCommand { get; private set; }

        public async void CreateJoinEventRequest(Event _event)
        {
            var data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("title", "Request to Join Event"));
            data.Add(new KeyValuePair<string, string>("details", ""));
            data.Add(new KeyValuePair<string, string>("type", "join event"));
            data.Add(new KeyValuePair<string, string>("sender", Store.User.id.ToString()));
            data.Add(new KeyValuePair<string, string>("event", _event.id.ToString() ));
            FormUrlEncodedContent content = new FormUrlEncodedContent(data);
            await RESTServices.CreateJoinEventRequest(content);
            GoToRequests();
        }

        public async void GoToRequests()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RequestsView());
        }

        public async void GoToSignIn()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SignInView());
        }

        public async void CreateRequest(string type)
        {
            var data = new List<KeyValuePair<string, string>>();
            string info = type.Equals("request to admin") ? "admin" : "organizer";
            data.Add(new KeyValuePair<string, string>("title", "Request to " +  info));
            data.Add(new KeyValuePair<string, string>("details", ""));
            data.Add(new KeyValuePair<string, string>("type", type));
            data.Add(new KeyValuePair<string, string>("sender", Store.User.id.ToString()));
            FormUrlEncodedContent content = new FormUrlEncodedContent(data);
            await RESTServices.CreateRequest(content);
            GoToRequests();
        }

        public async void GoToEventReviews(Event _event)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EventReviewsView(_event));
        }

        public async void LoadEvents()
        {
            Events = await RESTServices.GetAllEvents();
        }

        public EventListViewModel()
        {
            OnCreateJoinEventRequestCommand = new Command<Event>(CreateJoinEventRequest);
            OnGoToRequestsCommand = new Command(GoToRequests);
            OnCreateRequestCommand = new Command<string>(CreateRequest);
            OnGoEventReviewsCommand = new Command<Event>(GoToEventReviews);
            OnLogoutCommand = new Command(GoToSignIn);
            LoadEvents();
        }
    }
}
