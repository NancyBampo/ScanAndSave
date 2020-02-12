using ScanAndSaveMobile.Helpers;
using ScanAndSaveMobile.ViewModels;
using ScanAndSaveMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScanAndSaveMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();

            //MainPage = //new NavigationPage(new ScannerPage());
            //new NavigationPage(new RegisterPage());
        }

        private void SetMainPage()
        {
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                if (Settings.AccessTokenExpiration < DateTime.UtcNow.AddHours(1))
                {
                    var vm = new LoginViewModel();
                    vm.LoginCommand.Execute(null);
                }
                MainPage = new NavigationPage(new CartPage());
            }
            else if (!string.IsNullOrEmpty(Settings.UserName)
                && !string.IsNullOrEmpty(Settings.Password))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new RegisterPage());
            }


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
