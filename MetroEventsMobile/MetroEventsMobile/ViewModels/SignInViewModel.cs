using MetroEventsMobile.Views;
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

        private void SignIn()
        {

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
