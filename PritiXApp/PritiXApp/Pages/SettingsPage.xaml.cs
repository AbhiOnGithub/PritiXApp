using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PritiXApp
{
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage()
		{
			InitializeComponent();

			//LoadData();
			NavigationPage.SetHasNavigationBar(this, false);
			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
				this.Navigation.PopAsync();
			};
			btnBack.GestureRecognizers.Add(tapGestureRecognizer);
			pickLanguage.SelectedIndex = 0;


		}
	}
}
