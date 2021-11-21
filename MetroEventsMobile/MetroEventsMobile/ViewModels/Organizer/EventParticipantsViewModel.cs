using MetroEventsMobile.Models;
using MetroEventsMobile.Services;
using MetroEventsMobile.Views.Organizer;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MetroEventsMobile.ViewModels.Organizer
{
    class EventParticipantsViewModel : BaseViewModel
    {

        private List<User> eventParticipants = new List<User>();

        public List<User> EventParticipants
        {
            get => eventParticipants;
            set => SetProperty(ref eventParticipants, value);
        }

        public Command OnGoToEventDashboardCommand { get; private set; }

        public async void GoToEventDashboard()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EventDashboardView());
        }

        public async void LoadParticipants(string eventId)
        {
            EventParticipants = await RESTServices.GetEventParticipants(eventId);
        }

        public EventParticipantsViewModel(string eventId)
        {
            LoadParticipants(eventId);
            OnGoToEventDashboardCommand = new Command(GoToEventDashboard);
        }
    }
}
