using PritiXDataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PritiXDataAccess.Services
{
    public interface IEnglishWordService
    {
        Task<IEnumerable<EnglishWord>> GetAllWords();
    }
}
