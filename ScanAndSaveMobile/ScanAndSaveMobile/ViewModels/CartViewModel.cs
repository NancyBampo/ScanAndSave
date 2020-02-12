using ScanAndSaveMobile.Helpers;
using ScanAndSaveMobile.Models;
using ScanAndSaveMobile.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScanAndSaveMobile.ViewModels
{
    public class CartViewModel : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();
        private List<Carts> carts;

        public string AccessToken { get; set; }

        public List<Carts> Carts
        {
            get { return carts; }
            set
            {
                carts = value;
                OnPropertyChanged();
            }

        }





        public ICommand GetCartCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accessToken = Settings.AccessToken;
                    Carts = await _apiServices.GetCartAsync(accessToken);

                });

            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    Settings.AccessToken = "";
                    Settings.UserName = "";
                    Settings.Password = "";

                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string
            propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
