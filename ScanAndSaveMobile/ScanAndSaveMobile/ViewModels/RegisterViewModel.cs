using ScanAndSaveMobile.Helpers;
using ScanAndSaveMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScanAndSaveMobile.ViewModels
{
    public class RegisterViewModel
    {
        ApiServices _apiServices = new ApiServices();
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    /*if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
                    {
                        Message = "Credentials cannot be left empty";
                    }
                    if(Password != ConfirmPassword)
                    {
                        Message = "Passwords Do Not Match";
                    }
                    else
                    {*/
                        var isSuccess = await _apiServices.RegisterAsync(UserName, Email, Password, ConfirmPassword);

                        Settings.UserName = UserName;
                        Settings.Password = Password;

                        if (isSuccess)
                            Message = "Registered Succesfully";
                        else

                            Message = "Try Again Later";
                    
                  
                    /*var isSuccess = await _apiServices.RegisterAsync(UserName, Email, Password, ConfirmPassword);

                    Settings.UserName = UserName;
                    Settings.Password = Password;

                    if (isSuccess)
                        Message = "Registered Succesfully";
                    else

                        Message = "Try Again Later";*/



                });
            }
        }
    }
}
