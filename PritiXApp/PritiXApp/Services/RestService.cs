using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PritiXApp.Models;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Diagnostics;

namespace PritiXApp.Services
{
    public class RestService : IRestService
    {
        HttpClient client;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:PritiXApp.Services.RestService"/> class.
		/// </summary>
		/// <param name="username">Username.</param>
		/// <param name="password">Password.</param>
        public RestService(string username, string password)
        {
            //var authData = string.Format("{0}:{1}", username, password);
            //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public RestService()
        {
            client = new HttpClient();
        }

        public void Dispose()
        {
        }

        public async Task<IList<EnglishWord>> GetListOfWords(int dictId)
        {
			var uri = new Uri(string.Format(Consts.RestUrl + $"EnglishWords/{dictId}", String.Empty));
			try
			{
				HttpResponseMessage response = null;
				response = client.GetAsync(uri).GetAwaiter().GetResult();
				if (response.IsSuccessStatusCode)
				{
					var dicts = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<List<EnglishWord>>(dicts);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
			return null;
        }

		public async Task<IList<Dict>> GetListOfDictionaries()
		{
			var uri = new Uri(string.Format(Consts.RestUrl + "Dictionary/", String.Empty));
			try
			{
				HttpResponseMessage response = null;
				response =  client.GetAsync(uri).GetAwaiter().GetResult();
				if (response.IsSuccessStatusCode)
				{
					var dicts = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<List<Dict>>(dicts);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
			return null;
		}

		//public Task<IList<IWord>> GetListOfWords(Consts.Languages lang, CancellationToken cancellationToken)
		//{
		//    Words = new List<IWord>();
		//    return Words;
		//}

		public async Task<bool> SignupAsync(Newuser user)
		{
			var uri = new Uri(string.Format(Consts.RestUrl + "Signup/", String.Empty));
			try
			{
				var json = JsonConvert.SerializeObject(user);
				var content = new StringContent(json, Encoding.UTF8, "application/json");

				HttpResponseMessage response = null;
				response = client.PostAsync(uri, content).GetAwaiter().GetResult();
				if (response.IsSuccessStatusCode)
				{
					var userString = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<bool>(userString);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
			return false;
		}

		public async Task<Translation> GetTranslation(int index)
		{
			var uri = new Uri(string.Format(Consts.RestUrl + $"Translations/?idx={index}", String.Empty));
			try
			{
				HttpResponseMessage response = null;
				response = client.GetAsync(uri).GetAwaiter().GetResult();
				if (response.IsSuccessStatusCode)
				{
					var dicts = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<Translation>(dicts);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
			return null;
		}

        public async Task<User> LoginAsync(Credentials credentials)
        {
            var uri = new Uri(string.Format(Consts.RestUrl + "User/", String.Empty));
            try
            {
                var json = JsonConvert.SerializeObject(credentials);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = client.PostAsync(uri, content).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var userString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<User>(userString);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);                
            }
            return null;
        }
    }
}