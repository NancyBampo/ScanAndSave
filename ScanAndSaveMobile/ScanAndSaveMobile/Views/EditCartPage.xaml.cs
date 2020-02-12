using ScanAndSaveMobile.Models;
using ScanAndSaveMobile.ViewModels;
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
    public partial class EditCartPage : ContentPage
    {
        public EditCartPage()
        {
            InitializeComponent();
        }

        public EditCartPage(Carts cart)
        {
            var editCartViewModel = new EditCartViewModel();
            editCartViewModel.Cart = cart;

            BindingContext = editCartViewModel;

            InitializeComponent();

            //var editCartViewModel = BindingContext as EditCartViewModel;
            //editCartViewModel.Cart = cart;
        }
    }
}