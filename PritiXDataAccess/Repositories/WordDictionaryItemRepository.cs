using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PritiXDataAccess.Entities;
using PritiXDataAccess.Infrastructure;
using Dapper;

namespace PritiXDataAccess.Repositories
{
    public class WordDictionaryItemRepository : IWordDictionaryItemRepository
    {
        IConnectionFactory _connectionFactory;

        public WordDictionaryItemRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task<bool> AddDictionaryItem(WordDictionaryItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDictionaryItem(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WordDictionaryItem>> GetAllDictionaryItemsById(int DictId)
        {
            var param = new DynamicParameters();
            param.Add("@DictId", DictId);
            var dictItems = _connectionFactory.GetConnection.Query("usp_GetDictItems", param, commandType: System.Data.CommandType.StoredProcedure);



            throw new NotImplementedException();
        }

        public Task<bool> UpdateDictionaryItem(WordDictionaryItem item)
        {
            throw new NotImplementedException();
        }
    }
}
