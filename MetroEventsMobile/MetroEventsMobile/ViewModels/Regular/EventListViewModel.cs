using MetroEventsMobile.Models;
using MetroEventsMobile.Services;
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

        public async void LoadEvents()
        {
            Events = await RESTServices.GetAllEvents();
        }

        public EventListViewModel()
        {
            OnCreateJoinEventRequestCommand = new Command<Event>(CreateJoinEventRequest);
            OnGoToRequestsCommand = new Command(GoToRequests);
            LoadEvents();
        }
    }
}
