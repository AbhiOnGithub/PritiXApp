using PritiXApp.ViewModels;
using System;
using Xamarin.Forms;
using PritiXApp.Services;
using PritiXApp.Models;

namespace PritiXApp
{
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel viewModel;

        public LoginPage()
        {
            InitializeComponent();
            viewModel = new LoginViewModel(App.Service);
			viewModel.Username = "abhishek.msft@outlook.com";
			viewModel.Password = "abhishek@123";
            BindingContext = viewModel;
            NavigationPage.SetHasNavigationBar(this, false);
            App.LoadImmediately = false;
        }

        protected async override void OnAppearing()
        {
			if (App.IsClosed)
			{
				await Navigation.PopAsync();
				return;
			}

            loginButton.Clicked += OnLoginClicked;
			signupButton.Clicked += OnSignupClickd;
        }

		private async void OnSignupClickd(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(etName.Text) || String.IsNullOrEmpty(etUserName.Text) ||
				String.IsNullOrEmpty(etPass.Text) || string.IsNullOrEmpty(etRePass.Text))
			{
				await DisplayAlert($"Error", "Please enter all Details", "Ok", "Cancel");
				return;
			}

			if (etPass.Text != etRePass.Text)
			{
				await DisplayAlert($"Error", "Passwords mismatched", "Ok", "Cancel");
				return;
			}

			var restService = new RestService();
			var result = await restService.SignupAsync(new Newuser()
			{
				Fullname = etName.Text,
				Username = etUserName.Text.ToLower(),
				Password = etPass.Text
			});

			var res = await restService.LoginAsync(new Credentials(etUserName.Text.ToLower(), etPass.Text));
			if (res == null)
				await DisplayAlert($"Sign Up Unsuccessful", "Email already registered !!", "Ok", "Cancel");
			else
			{
				App.LastUseTime = DateTime.UtcNow;
				App.LoadImmediately = true;
				App.Pass = etPass.Text;
				App.CurrentUser = res;
				etPass.Text = etUserName.Text = etRePass.Text = etName.Text = String.Empty;
				await DisplayAlert($"Signed Up Successfully", "Preparaing your data !!", "Ok", "Cancel");
				App.LoadImmediately = true;
				await this.Navigation.PopAsync();
			}

		}
				                                                                                                                          

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (viewModel.CanLogin)
            {
                if(await viewModel.LoginAsync())
                {
                    App.LastUseTime = DateTime.UtcNow;
                    App.LoadImmediately = true;
                    await DisplayAlert($"Welcome {viewModel.UserLoggedIn.FullName}","Loading data.." , "Ok", "Cancel");
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
