using MetroEventsMobile.Models;
using MetroEventsMobile.Services;
using MetroEventsMobile.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace MetroEventsMobile.ViewModels
{
    class CreateAccountViewModel : BaseViewModel
    {
        private string firstName;
        private string lastName;
        private string email;
        private string password;

        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

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

        public Command OnCreateAccountCommand { get; private set; }
        public Command OnGoToSignInCommand { get; private set; }

        private async void CreateAccount()
        {
            var user = new
            {
                firstName = FirstName,
                lastName = LastName,
                email = Email,
                password = Password,
            };
            string userJson = JsonConvert.SerializeObject(user);
            HttpResponseMessage response = await RESTServices.CreateAccount(userJson);
            if (response.IsSuccessStatusCode)
                await Application.Current.MainPage.Navigation.PushAsync(new SignInView());
        }

        private async void GoToSignIn()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SignInView());
        }

        public CreateAccountViewModel()
        {
            OnCreateAccountCommand = new Command(CreateAccount);
            OnGoToSignInCommand = new Command(GoToSignIn);
        }
    }
}
