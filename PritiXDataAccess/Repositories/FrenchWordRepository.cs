using Dapper;
using PritiXDataAccess.Entities;
using PritiXDataAccess.Infrastructure;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System;

namespace PritiXDataAccess.Repositories
{
    public class FrenchWordRepository :IWordRepository
    {
        IConnectionFactory _connectionFactory;

        public FrenchWordRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task<IEnumerable<IWord>> GetAllWordsOfDictionary(int dictId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddWord(IWord word)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteWord(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IWord>> GetAllWords()
        {
            var list = await SqlMapper.QueryAsync<FrenchWord>
                (_connectionFactory.GetConnection, "usp_GetAllFrenchWords", commandType: CommandType.StoredProcedure);
            return list;
        }

        public Task<bool> UpdateWord(IWord word)
        {
            throw new NotImplementedException();
        }
    }
}

