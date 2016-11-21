using PritiXApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PritiXApp.Services
{
    public interface IRestService : IDisposable
    {
        Task<User> LoginAsync(Credentials credentails);
		Task<bool> SignupAsync(Newuser user);

        Task<IList<EnglishWord>> GetListOfWords(int dictId);
		Task<IList<Dict>> GetListOfDictionaries();

		Task<Translation> GetTranslation(int index);
    }
}