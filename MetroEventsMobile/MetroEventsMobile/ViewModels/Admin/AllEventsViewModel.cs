using MetroEventsMobile.Models;
using MetroEventsMobile.Services;
using MetroEventsMobile.Views.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MetroEventsMobile.ViewModels.Admin
{
    class AllEventsViewModel : BaseViewModel
    {
        private List<Event> events = new List<Event>();

        public List<Event> Events
        {
            get => events;
            set => SetProperty(ref events, value);
        }

        public Command OnGoToDashboardCommand { get; private set; }

        public async void GoToDashboard()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new DashboardView());
        }

        public async void LoadEvents()
        {
            Events = await RESTServices.GetAllEvents();
        }

        public AllEventsViewModel()
        {
            OnGoToDashboardCommand = new Command(GoToDashboard);
            LoadEvents();
        }
    }
}
