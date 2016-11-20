using Dapper;
using PritiXDataAccess.Entities;
using PritiXDataAccess.Infrastructure;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System;

namespace PritiXDataAccess.Repositories
{
    public class DutchWordRepository : IWordRepository
    {
        IConnectionFactory _connectionFactory;

        public DutchWordRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
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
            var list = await SqlMapper.QueryAsync<DutchWord>
                (_connectionFactory.GetConnection, "usp_GetAllDutchWords", commandType: CommandType.StoredProcedure);
            return list;
        }

        public Task<bool> UpdateWord(IWord word)
        {
            throw new NotImplementedException();
        }
    }
}

