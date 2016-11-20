using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PritiXApp
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.Title = "PritiX Dictionary";
            NavigationPage.SetHasNavigationBar(this, false);
            App.LoadImmediately = false;

        }

		public async void OnDictionariesClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new DictionariesPage());
		}

		public async void OnQuizClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new QuizPage());
		}

		public async void OnSettingsClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SettingsPage());
		}
    }
}
