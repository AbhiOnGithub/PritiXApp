using PritiXApp.Models;
using PritiXApp.Services;
using System;

using Xamarin.Forms;

namespace PritiXApp
{
    public partial class App : Application
    {
        private static readonly App _instance = new App();
        public static App Instance
        {
            get
            {
                return _instance;
            }
        }

        public static IRestService Service { get; set; }
        public static DateTime LastUseTime { get; set; }
        public static User CurrentUser { get; set; }
        public static bool LoadImmediately { get; set; }
        public App()
        {
            InitializeComponent();
            Service = new RestService();
            MainPage = new NavigationPage(new SplashPage());
        }
        
        public void InitializeRestService(string username,string password)
        {
            Service = new RestService(username, password);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
