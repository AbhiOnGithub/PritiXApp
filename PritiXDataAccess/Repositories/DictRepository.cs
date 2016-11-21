using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PritiXDataAccess.Entities;
using Dapper;
using PritiXDataAccess.Infrastructure;
using System.Data;

namespace PritiXDataAccess.Repositories
{
    public class DictRepository : IDictRepository
    {
        IConnectionFactory _connectionFactory;

        public DictRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> AddDictionary(Dict dict)
        {
            var param = new DynamicParameters();
            param.Add("@Name", dict.Name);
            param.Add("@Purpose", dict.Purpose);
            var result = await SqlMapper.ExecuteAsync(_connectionFactory.GetConnection, "usp_AddDictionary", param, commandType: CommandType.StoredProcedure);

            return result == -1 ? true : false;
        }

        public Task<bool> DeleteDictionary(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Dict>> GetAllDictionaries()
        {
            var list = await SqlMapper.QueryAsync<Dict>
                (_connectionFactory.GetConnection, "usp_GetAllDictionaries", commandType: CommandType.StoredProcedure);
            return list;
        }

        public Task<bool> UpdateDictionary(Dict dict)
        {
            throw new NotImplementedException();
        }
    }
}
