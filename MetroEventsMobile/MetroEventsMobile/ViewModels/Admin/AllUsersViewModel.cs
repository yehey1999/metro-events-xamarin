using MetroEventsMobile.Models;
using MetroEventsMobile.Services;
using MetroEventsMobile.Views.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MetroEventsMobile.ViewModels.Admin
{
    class AllUsersViewModel : BaseViewModel
    {
        private List<User> users = new List<User>();

        public List<User> Users
        {
            get => users;
            set => SetProperty(ref users, value);
        }

        public Command OnGoToDashboardCommand { get; private set; }

        public async void GoToDashboard()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new DashboardView());
        }

        public async void LoadUsers()
        {
            Users = await RESTServices.GetAllUsers();
        }

        public AllUsersViewModel()
        {
            OnGoToDashboardCommand = new Command(GoToDashboard);
            LoadUsers();
        }
    }
}
