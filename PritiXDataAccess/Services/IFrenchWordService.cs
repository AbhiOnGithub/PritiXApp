using PritiXDataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PritiXDataAccess.Services
{
    public interface IFrenchWordService
    {
        Task<IEnumerable<FrenchWord>> GetAllWords();
    }
}
