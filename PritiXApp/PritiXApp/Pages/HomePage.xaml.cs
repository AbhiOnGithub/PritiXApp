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

			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
				App.IsClosed = true;
				this.Navigation.PopAsync();
			};
			btnBack.GestureRecognizers.Add(tapGestureRecognizer);

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
