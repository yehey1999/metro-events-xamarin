using MetroEventsMobile.Models;
using MetroEventsMobile.Services;
using MetroEventsMobile.Views.Organizer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace MetroEventsMobile.ViewModels.Organizer
{
    class CreateEventViewModel : BaseViewModel
    {
        private string title;
        private string description;
        private string startDateTime;
        private string endDateTime;
        private string address;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string StartDateTime
        {
            get => startDateTime;
            set => SetProperty(ref startDateTime, value);
        }

        public string EndDateTime
        {
            get => endDateTime;
            set => SetProperty(ref endDateTime, value);
        }

        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }

        public Command OnCreateEventCommand { get; set; }
        public Command OnGoToEventDashboardCommand { get; set; }

        public async void CreateEvent()
        {
            var _event = new
            {
                title = Title,
                description = Description,
                startDatetime = StartDateTime,
                endDatetime = EndDateTime,
                address = Address,
                createdByUserId = Store.User.id
            };
            string _eventJson = JsonConvert.SerializeObject(_event);
            Event createdEvent = await RESTServices.CreateEvent(_eventJson);
            if (createdEvent != null)
                await Application.Current.MainPage.Navigation.PushAsync(new EventDashboardView());
        }

        public async void GoToEventDashboard()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EventDashboardView());
        }

        public CreateEventViewModel()
        {
            OnCreateEventCommand = new Command(CreateEvent);
            OnGoToEventDashboardCommand = new Command(GoToEventDashboard);
        }
    }
}
