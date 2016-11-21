using System;
using System.Collections.Generic;
using PritiXApp.Services;
using Xamarin.Forms;

namespace PritiXApp
{
	public partial class TranslationPage : ContentPage
	{
		private IRestService _restService;

		public TranslationPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
				this.Navigation.PopAsync();
			};
			btnBack.GestureRecognizers.Add(tapGestureRecognizer);
			_restService = new RestService(App.CurrentUser.Email, App.Pass);
			EWord.Text = App.word.Word;
		}

		protected override void OnAppearing()
		{
			GetData();
		}


		private async void GetData()
		{
			await DisplayAlert("Loading Translations", "Please wait...", "Ok", "Cancel");
			var data = await _restService.GetTranslation(App.word.Index);
			if (data != null)
			{
				FWord.Text = data.FWord;
				DWord.Text = data.DWord;
				GWord.Text = data.GWord;
			}
		}
	}
}
