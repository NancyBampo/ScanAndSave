using ScanAndSaveMobile.Helpers;
using ScanAndSaveMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScanAndSaveMobile.ViewModels
{
    public class LoginViewModel
    {
        private ApiServices _apiServices = new ApiServices();
        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accessToken = await _apiServices.LoginAsync(Username, Password);

                    Settings.AccessToken = accessToken;


                    /* if (isSuccess)
                         Message = "Registered Succesfully";
                     else

                         Message = "Try Again Later";*/

                });

            }
        }
        public LoginViewModel()
        {
            Username = Settings.UserName;
            Password = Settings.Password;
        }
    }
}
