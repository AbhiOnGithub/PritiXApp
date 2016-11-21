using PritiXDataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PritiXDataAccess.Repositories
{
    public interface IDictRepository
    {
        Task<IEnumerable<Dict>> GetAllDictionaries();

        Task<bool> AddDictionary(Dict dict);

        Task<bool> DeleteDictionary(int Id);

        Task<bool> UpdateDictionary(Dict dict);
    }
}
