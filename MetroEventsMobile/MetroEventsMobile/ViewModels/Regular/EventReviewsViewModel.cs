using MetroEventsMobile.Models;
using MetroEventsMobile.Services;
using MetroEventsMobile.Views.Regular;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace MetroEventsMobile.ViewModels.Regular
{
    class EventReviewsViewModel : BaseViewModel
    {
        private List<Review> reviews = new List<Review>();
        private Event selectedEvent = new Event();
        private string review = "";

        public Event Event
        {
            get => selectedEvent;
            set => SetProperty(ref selectedEvent, value);
        }

        public string Review
        {
            get => review;
            set => SetProperty(ref review, value);
        }

        public List<Review> EventReviews
        {
            get => reviews;
            set => SetProperty(ref reviews, value);
        }

        public Command OnGoToEventListCommand { get; private set; }
        public Command OnCreateReviewCommand { get; private set; }

        public async void GoToEventList()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EventListView());
        }

        public async void CreateReview()
        {
            var data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("comment", Review));
            data.Add(new KeyValuePair<string, string>("user", Store.User.id.ToString()));
            FormUrlEncodedContent content = new FormUrlEncodedContent(data);
            await RESTServices.CreateReview(content, Event.id.ToString());
            Review = "";
            LoadEventReviews();
        }

        public async void LoadEventReviews()
        {
            EventReviews = await RESTServices.GetEventReviews(Event.id.ToString());
        }

        public EventReviewsViewModel(Event _event)
        {
            Event = _event;
            OnGoToEventListCommand = new Command(GoToEventList);
            OnCreateReviewCommand = new Command(CreateReview);
            LoadEventReviews();
        }
            
    }
}
