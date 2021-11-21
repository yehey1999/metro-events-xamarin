using MetroEventsMobile.Models;
using MetroEventsMobile.Services;
using MetroEventsMobile.Views.Organizer;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace MetroEventsMobile.ViewModels.Organizer
{
    class RequestsReceivedViewModel : BaseViewModel
    {
        List<Request> eventRequests = new List<Request>();

        public List<Request> EventRequests
        {
            get => eventRequests;
            set => SetProperty(ref eventRequests, value);
        }

        public async void LoadEventRequests()
        {
            List<Event> createdEvents = await RESTServices.GetAllCreatedEvents(Store.User.id.ToString());
            List<Request> _requests = new List<Request>();
            foreach (Event ev in createdEvents)
            {
                if (ev.requests != null)
                {
                    _requests.AddRange(ev.requests);
                }
            }
            EventRequests = _requests;
        }

        public Command OnGoToEventDashboardCommand { get; private set; }
        public Command OnAcceptJoinEventRequestCommand { get; private set; }
        public Command OnDeclineJoinEventRequestCommand { get; private set; }

        public async void GoToEventDashboard()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EventDashboardView());
        }

        public async void AcceptJoinEventRequest(Request request)
        {
            var data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("type", "join event"));
            data.Add(new KeyValuePair<string, string>("status", "accepted"));
            FormUrlEncodedContent content = new FormUrlEncodedContent(data);
            await RESTServices.UpdateJoinEventRequest(content, request.id.ToString());
            LoadEventRequests();
        }

        public async void DeclineJoinEventRequest(Request request)
        {
            var data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("type", "join event"));
            data.Add(new KeyValuePair<string, string>("status", "declined"));
            FormUrlEncodedContent content = new FormUrlEncodedContent(data);
            await RESTServices.UpdateJoinEventRequest(content, request.id.ToString());
            LoadEventRequests();
        }

        public RequestsReceivedViewModel()
        {
            LoadEventRequests();            
            OnGoToEventDashboardCommand = new Command(GoToEventDashboard);
            OnAcceptJoinEventRequestCommand = new Command<Request>(AcceptJoinEventRequest);
            OnDeclineJoinEventRequestCommand = new Command<Request>(DeclineJoinEventRequest);
        }

    }
}
