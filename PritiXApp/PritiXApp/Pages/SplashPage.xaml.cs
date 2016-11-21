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
			btnLogin.Clicked += (sender, e) => 
			{
				App.IsClosed = false;
				this.Navigation.PushAsync(new LoginPage());
				btnLogin.IsVisible = false;
			};
        }

        protected async override void OnAppearing()
        {
			if (App.IsClosed)
			{
				btnLogin.IsVisible = true;
				await Navigation.PopAsync();
				return;
			}
			btnLogin.IsVisible = false;
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
