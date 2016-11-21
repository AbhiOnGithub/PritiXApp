using System;
using System.Collections.Generic;
using PritiXApp.Models;
using PritiXApp.Services;
using Xamarin.Forms;

namespace PritiXApp
{
	public partial class DictionariesPage : ContentPage
	{
		private IRestService _restService;
		private IList<Dict> _dictionaries; 


		public DictionariesPage()
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
		}

		protected override void OnAppearing()
		{
			GetData();
		}

		private async void GetData()
		{
			_dictionaries = await _restService.GetListOfDictionaries();
			lstOnlineDict.ItemsSource = _dictionaries;
		}

		void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			App.CurrentDict = e.SelectedItem as Dict;
			Navigation.PushAsync(new DictionaryItemsPage());	
		}
	}
}