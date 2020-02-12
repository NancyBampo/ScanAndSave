using ScanAndSaveMobile.Helpers;
using ScanAndSaveMobile.Models;
using ScanAndSaveMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScanAndSaveMobile.ViewModels
{
    public class AddNewCartViewModel
    {
        ApiServices _apiServices = new ApiServices();
        public string Name { get; set; }

        public ICommand AddGroceryList
        {
            get
            {
                return new Command(async () =>
                {
                    var cart = new Carts()
                    {
                        Name = Name
                    };
                    await _apiServices.PostCartAsync(cart, Settings.AccessToken);

                });
            }
        }
    }
}
