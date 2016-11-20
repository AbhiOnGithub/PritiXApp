using PritiXDataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PritiXDataAccess.Repositories
{
    public interface IWordRepository
    {
        Task<IEnumerable<IWord>> GetAllWords();

        Task<bool> AddWord(IWord word);

        Task<bool> DeleteWord(int Id);

        Task<bool> UpdateWord(IWord word);
    }
}
