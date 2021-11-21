using MetroEventsMobile.Models;
using MetroEventsMobile.Services;
using MetroEventsMobile.Views.Organizer;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MetroEventsMobile.ViewModels.Organizer
{
    class EventReviewsViewModel : BaseViewModel
    {
        private List<Review> reviews = new List<Review>();
        private Event selectedEvent = new Event();

        public Event Event
        {
            get => selectedEvent;
            set => SetProperty(ref selectedEvent, value);
        }

        public List<Review> EventReviews
        {
            get => reviews;
            set => SetProperty(ref reviews, value);
        }

        public Command OnGoToEventEventDashboard { get; private set; }
        public Command OnCreateReviewCommand { get; private set; }

        public async void GoToEventDashboard()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EventDashboardView());
        }

        public async void LoadEventReviews()
        {
            EventReviews = await RESTServices.GetEventReviews(Event.id.ToString());
        }

        public EventReviewsViewModel(Event _event)
        {
            Event = _event;
            OnGoToEventEventDashboard = new Command(GoToEventDashboard);
            LoadEventReviews();
        }
    }
}
