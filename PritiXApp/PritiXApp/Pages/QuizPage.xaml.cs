using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PritiXApp
{
	public partial class QuizPage : ContentPage
	{
		public QuizPage()
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


		}
	}
}
