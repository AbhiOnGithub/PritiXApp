using PritiXAPI.Extensions;
using PritiXDataAccess.Infrastructure;
using PritiXDataAccess.Repositories;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace PritiXAPI.Attributes
{
    public class BasicAuthenticationAttribute : AuthorizeAttribute
    {
        private IUserRepository UserRepository;

        public bool RequireSsl { get; set; }

        public BasicAuthenticationAttribute()
        {
            this.RequireSsl = true;
            UserRepository = new UserRepository(new ConnectionFactory());
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            var isAuthenticated = this.Authorize(actionContext);
            if (!isAuthenticated)
            {
                SendUnauthorizedResponse(actionContext);
            }
        }

        private BasicAuthenticationIdentity ParseAuthorizationHeader(HttpActionContext actionContext)
        {
            string authHeader = null;
            var auth = actionContext.Request.Headers.Authorization;
            if (auth != null && auth.Scheme == "Basic")
            {
                authHeader = auth.Parameter;
            }

            if (string.IsNullOrWhiteSpace(authHeader))
            {
                return null;
            }

            if (authHeader.IsBase64Encoded())
            {
                authHeader = Encoding.Default.GetString(Convert.FromBase64String(authHeader));
            }
            else
            {
                return null;
            }

            int index = authHeader.IndexOf(':');
            if (index < 0)
            {
                return null;
            }

            string username = authHeader.Substring(0, index);
            string password = authHeader.Substring(index + 1);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            return new BasicAuthenticationIdentity(username, password);
        }

        private bool Authorize(HttpActionContext actionContext)
        {
            var httpContext = HttpContext.Current;

            if (httpContext.Request.IsAuthenticated)
            {
                return true;
            }

            if (this.RequireSsl && !httpContext.Request.IsSecureConnection && !httpContext.Request.IsLocal)
            {
                return false;
            }

            if (!httpContext.Request.Headers.AllKeys.Contains("Authorization"))
            {
                return false;
            }


            var identity = ParseAuthorizationHeader(actionContext);
            if (identity == null)
            {
                return false;
            }

            return CheckIfUserValid(identity.Name,identity.Password).GetAwaiter().GetResult();
        }

        private async Task<bool> CheckIfUserValid(string username,string password)
        {
            var user = await UserRepository.GetUserLoggedIn(username, password);
            if (user != null)
                return true;
            else
                return false;           
        }

        private void SendUnauthorizedResponse(HttpActionContext actionContext)
        {
            var host = actionContext.Request.RequestUri.DnsSafeHost;
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic");
        }
    }
}