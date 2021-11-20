using MetroEventsMobile.Models;
using MetroEventsMobile.Services;
using MetroEventsMobile.Views.Regular;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MetroEventsMobile.ViewModels.Regular
{
    class RequestsViewModel : BaseViewModel
    {
        private List<Request> requests = new List<Request>();

        public List<Request> Requests
        {
            get => requests;
            set => SetProperty(ref requests, value);
        }

        public Command OnGoToEventListCommand { get; private set; }

        public async void GoToEventList()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EventListView());
        }

        public async void LoadRequests()
        {
            Requests = await RESTServices.GetAllSentRequests(Store.User.id.ToString());
            Console.WriteLine(Requests[0].sender.id);
        }

        public RequestsViewModel ()
        {
            OnGoToEventListCommand = new Command(GoToEventList);
            LoadRequests();
        }

    }
}
