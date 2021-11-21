using MetroEventsMobile.Models;
using MetroEventsMobile.Services;
using MetroEventsMobile.Views;
using MetroEventsMobile.Views.Admin;
using MetroEventsMobile.Views.Organizer;
using MetroEventsMobile.Views.Regular;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MetroEventsMobile.ViewModels
{
    class SignInViewModel : BaseViewModel
    {
        private string email;
        private string password;

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public Command OnSignInCommand { get; private set; }
        public Command OnGoToCreateAccountCommand { get; private set; }

        private async void SignIn()
        {
            var payload = new
            {
                email = Email,
                password = Password
            };
            string payloadJson = JsonConvert.SerializeObject(payload);
            User user = await RESTServices.SignIn(payloadJson);
            Store.User = user;
            if (user.type.Equals("regular"))
                await Application.Current.MainPage.Navigation.PushAsync(new EventListView());
            else if (user.type.Equals("organizer"))
                await Application.Current.MainPage.Navigation.PushAsync(new EventDashboardView());
            else if (user.type.Equals("admin"))
                await Application.Current.MainPage.Navigation.PushAsync(new DashboardView());
        }

        private async void GoToCreateAccount()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CreateAccountView());
        }

        public SignInViewModel()
        {
            OnSignInCommand = new Command(SignIn);
            OnGoToCreateAccountCommand = new Command(GoToCreateAccount);
        }

    }
}
