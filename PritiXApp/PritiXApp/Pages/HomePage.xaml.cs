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
    }
}
