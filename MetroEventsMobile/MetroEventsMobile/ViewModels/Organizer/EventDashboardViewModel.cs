using MetroEventsMobile.Models;
using MetroEventsMobile.Services;
using MetroEventsMobile.Views.Organizer;
using System;
using System.Collections.Generic;
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

        public async void GoToCreateEvent()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CreateEventView());
        }

        public async void DeleteEvent(Event _event)
        {
            await RESTServices.DeleteEvent(_event.id.ToString());
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
            LoadEvents();
        }
    }
}
