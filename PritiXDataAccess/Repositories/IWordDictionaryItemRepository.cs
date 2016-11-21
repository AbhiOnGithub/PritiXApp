using PritiXDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PritiXDataAccess.Repositories
{
    public interface IWordDictionaryItemRepository
    {
        Task<IEnumerable<WordDictionaryItem>> GetAllDictionaryItemsById(int DictId);

        Task<bool> AddDictionaryItem(WordDictionaryItem item);

        Task<bool> DeleteDictionaryItem(int Id);

        Task<bool> UpdateDictionaryItem(WordDictionaryItem item);
    }
}
