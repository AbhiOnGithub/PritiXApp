using Dapper;
using PritiXDataAccess.Entities;
using PritiXDataAccess.Infrastructure;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System;

namespace PritiXDataAccess.Repositories
{
    public class EnglishWordRepository :  IWordRepository
    {
        IConnectionFactory _connectionFactory;

        public EnglishWordRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> AddWord(IWord word)
        {
            var param = new DynamicParameters();
            param.Add("@Word", word.Word);
            var result = await SqlMapper.ExecuteAsync(_connectionFactory.GetConnection, "usp_AddEnglishWord",param, commandType: CommandType.StoredProcedure);

            return result == -1 ? true : false;
        }

        public async Task<bool> DeleteWord(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IWord>> GetAllWords()
        {
            var list = await SqlMapper.QueryAsync<EnglishWord>
                (_connectionFactory.GetConnection, "usp_GetAllEnglishWords", commandType: CommandType.StoredProcedure);
            return list;
        }

        public async Task<bool> UpdateWord(IWord word)
        {
            throw new NotImplementedException();
        }
    }
}

