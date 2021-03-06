using MetroEventsMobile.Models;
using MetroEventsMobile.Services;
using MetroEventsMobile.Views;
using MetroEventsMobile.Views.Organizer;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace MetroEventsMobile.ViewModels.Organizer
{
    class EventDashboardViewModel : BaseViewModel
    {
        public List<Event> createdEvents = new List<Event>();

        public List<Event> CreatedEvents
        {
            get => createdEvents;
            set => SetProperty(ref createdEvents, value);
        }

        public Command OnGoToCreateEventCommand { get; private set; }

        public Command OnDeleteEventCommand { get; private set; }

        public Command OnCancelEventCommand { get; private set; }

        public Command OnGoToRequestsReceivedCommand { get; private set; }

        public Command OnShowEventParticipantsCommand { get; private set; }

        public Command OnShowEventReviewsCommand { get; private set; }

        public Command OnLogoutCommand { get; private set; }

        public async void GoToCreateEvent()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CreateEventView());
        }

        public async void GoToRequestsReceived()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RequestsReceivedView());
        }

        public async void GoToSignIn()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SignInView());
        }

        public async void DeleteEvent(Event _event)
        {
            await RESTServices.DeleteEvent(_event.id.ToString());
            LoadEvents();
        }

        public async void ShowEventParticipants(Event _event)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EventParticipantsView(_event.id.ToString()));
        }

        public async void ShowEventReviews(Event _event)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EventReviewsView(_event));
        }

        public async void CancelEvent(Event _event)
        {
            var data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("status", "cancelled"));
            FormUrlEncodedContent content = new FormUrlEncodedContent(data);
            await RESTServices.UpdateEvent(content, _event.id.ToString());
            LoadEvents();
        }

        public async void LoadEvents()
        {
            CreatedEvents = await RESTServices.GetAllCreatedEvents(Store.User.id.ToString());
        }

        public EventDashboardViewModel()
        {
            OnGoToCreateEventCommand = new Command(GoToCreateEvent);
            OnDeleteEventCommand = new Command<Event>(DeleteEvent);
            OnGoToRequestsReceivedCommand = new Command(GoToRequestsReceived);
            OnShowEventParticipantsCommand = new Command<Event>(ShowEventParticipants);
            OnShowEventReviewsCommand = new Command<Event>(ShowEventReviews);
            OnCancelEventCommand = new Command<Event>(CancelEvent);
            OnLogoutCommand = new Command(GoToSignIn);
            LoadEvents();
        }
    }
}
