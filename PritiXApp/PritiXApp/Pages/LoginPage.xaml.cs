using PritiXApp.ViewModels;
using System;
using Xamarin.Forms;

namespace PritiXApp
{
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel viewModel;

        public LoginPage()
        {
            InitializeComponent();
            viewModel = new LoginViewModel(App.Service);
            BindingContext = viewModel;
            NavigationPage.SetHasNavigationBar(this, false);
            App.LoadImmediately = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            string platformName = Device.OS.ToString();

            loginButton.Clicked += OnLoginClicked;
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (viewModel.CanLogin)
            {
                if(await viewModel.LoginAsync())
                {
                    App.LastUseTime = DateTime.UtcNow;
                    App.LoadImmediately = true;
                    await DisplayAlert($"Welcome {viewModel.UserLoggedIn.FullName}","Please wait , while we are loading your Dictioanaries" , "Ok", "Cancel");
                    App.LoadImmediately = true;
                    await this.Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Wrong Credentials", "Please enter correct Credentials", "Ok", "Cancel");
                }
            }
            else
            {
                await DisplayAlert("Error", viewModel.ValidationErrors, "OK", "Cancel");
            }
        }
    }
}
