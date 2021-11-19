﻿using MetroEventsMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetroEventsMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SignInView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
