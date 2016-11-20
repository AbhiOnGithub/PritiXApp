using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PritiXApp
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected async override void OnAppearing()
        {
            if (App.LoadImmediately == false)
            {
                await Task.Delay(3000);
            }
           
            if (App.CurrentUser != null)
            {
                await this.Navigation.PushAsync(new HomePage());
            }
            else
            {
                await this.Navigation.PushAsync(new LoginPage());
            }
        }
    }
}
