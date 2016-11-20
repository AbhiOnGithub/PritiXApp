using PritiXApp.Models;
using PritiXApp.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PritiXApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private IRestService service;
        public User UserLoggedIn;

        private static TimeSpan ForceLoginTimespan
        {
            get
            {
                return TimeSpan.FromMinutes(5);
            }
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string ValidationErrors { get; private set; }
        public bool CanLogin
        {
            get
            {
                ValidationErrors = string.Empty;
                if (string.IsNullOrEmpty(Username))
                    ValidationErrors = "Please enter a username.";
                if (string.IsNullOrEmpty(Password))
                    ValidationErrors += "Please enter a password.";
                return string.IsNullOrEmpty(ValidationErrors);
            }
        }

        public LoginViewModel(IRestService service)
        {
            this.service = service;
        }

        public async Task<bool> LoginAsync()
        {
            IsBusy = true;
            this.UserLoggedIn = await service.LoginAsync(new Credentials(Username,Password));
            App.CurrentUser = UserLoggedIn;
            IsBusy = false;
            if (this.UserLoggedIn == null)
                return false;
            else
                return true;

        }

        public static bool ShouldShowLogin(DateTime? lastUseTime)
        {
            if (!lastUseTime.HasValue)
                return true;
            return (DateTime.UtcNow - lastUseTime) > ForceLoginTimespan;
        }
    }
}