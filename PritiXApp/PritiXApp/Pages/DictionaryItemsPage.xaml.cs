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
			GetData();
		}

		private async void GetData()
		{
			_dictionaries = await _restService.GetListOfWords();
			lstWords.ItemsSource = _dictionaries;
		}

		void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{

		}
	}
}