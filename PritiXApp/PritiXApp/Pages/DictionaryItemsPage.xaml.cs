using System;
using System.Collections.Generic;
using PritiXApp.Models;
using PritiXApp.Services;
using Xamarin.Forms;

namespace PritiXApp
{
	public partial class DictionaryItemsPage : ContentPage
	{
		private IRestService _restService;
		private IList<EnglishWord> _dictionaries;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:PritiXApp.DictionaryItemsPage"/> class.
		/// </summary>
		public DictionaryItemsPage()
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
			lbl.Text = App.CurrentDict.Name;
		}

		protected override void OnAppearing()
		{
			if(_dictionaries == null)
				GetData();
		}

		private async void GetData()
		{
			await DisplayAlert("Loading Words", "Please wait...", "Ok", "Cancel");
			_dictionaries = await _restService.GetListOfWords(App.CurrentDict.Id);
			lstWords.ItemsSource = _dictionaries;
		}

		void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			App.word = lstWords.SelectedItem as EnglishWord;
			Navigation.PushAsync(new TranslationPage());
		}
	}
}