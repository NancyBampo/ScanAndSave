using ScanAndSaveMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScanAndSaveMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
        }

        private async void NewGroceryCart_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCartPage());
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var cart = e.Item as Carts;
            await Navigation.PushAsync(new EditCartPage(cart));
        }



        private async void Logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        /*private async void Scan_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScannerPage());
        }*/
    }
}
