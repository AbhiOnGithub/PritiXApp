using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PritiXApp
{
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
				this.Navigation.PopAsync();
			};
			btnBack.GestureRecognizers.Add(tapGestureRecognizer);
		}
	}
}
