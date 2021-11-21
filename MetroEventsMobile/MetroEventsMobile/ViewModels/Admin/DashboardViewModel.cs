using MetroEventsMobile.Models;
using MetroEventsMobile.Services;
using MetroEventsMobile.Views;
using MetroEventsMobile.Views.Admin;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace MetroEventsMobile.ViewModels.Admin
{
    class DashboardViewModel : BaseViewModel
    {
        public List<Request> requests = new List<Request>();

        public List<Request> Requests
        {
            get => requests;
            set => SetProperty(ref requests, value);
        }

        public Command OnLogoutCommand { get; private set; }
        public Command OnAcceptRequestCommand { get; private set; }
        public Command OnDeclineRequestCommand { get; private set; }
        public Command OnShowAllUsersViewCommand { get; private set; }
        public Command OnShowAllEventsViewCommand { get; private set; }

        public async void GoToSignIn()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SignInView());
        }

        public async void AcceptRequest(Request request)
        {
            var data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("type", request.type));
            data.Add(new KeyValuePair<string, string>("status", "accepted"));
            FormUrlEncodedContent content = new FormUrlEncodedContent(data);
            await RESTServices.UpdateRequest(content, request.id.ToString());
            LoadRequests();
        }

        public async void DeclineRequest(Request request)
        {
            var data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("type", request.type));
            data.Add(new KeyValuePair<string, string>("status", "declined"));
            FormUrlEncodedContent content = new FormUrlEncodedContent(data);
            await RESTServices.UpdateRequest(content, request.id.ToString());
            LoadRequests();
        }

        public async void ShowAllUsers()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AllUsersView());
        }

        public async void ShowAllEvents()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AllEventsView());
        }

        public async void LoadRequests()
        {
            Requests = await RESTServices.GetAllRequests();
            Requests = Requests.FindAll(request => !request.type.Equals("join event"));
        }

        public DashboardViewModel()
        {
            OnAcceptRequestCommand = new Command<Request>(AcceptRequest);
            OnDeclineRequestCommand = new Command<Request>(DeclineRequest);
            OnLogoutCommand = new Command(GoToSignIn);
            OnShowAllUsersViewCommand = new Command(ShowAllUsers);
            OnShowAllEventsViewCommand = new Command(ShowAllEvents);

            LoadRequests();
        }
    }
}
