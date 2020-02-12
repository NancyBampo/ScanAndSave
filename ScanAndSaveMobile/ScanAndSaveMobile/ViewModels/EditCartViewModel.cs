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
    public class EditCartViewModel
    {
        ApiServices _apiServcices = new ApiServices();

        public Carts Cart { get; set; }

        public ICommand EditCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _apiServcices.EditCartAsync(Cart, Settings.AccessToken);

                });
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _apiServcices.DeleteCartAsync(Cart.Id, Settings.AccessToken);
                });
            }
        }
    }
}

