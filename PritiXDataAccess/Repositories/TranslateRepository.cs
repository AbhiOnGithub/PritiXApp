using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PritiXDataAccess.Entities;
using PritiXDataAccess.Infrastructure;
using Dapper;
using System.Data;

namespace PritiXDataAccess.Repositories
{
    public class TranslateRepository : ITranslateRepository
    {
        IConnectionFactory _connectionFactory;

        public TranslateRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Translation> TranslateWords(int index)
        {
            var param = new DynamicParameters();
            param.Add("@Idx", index);
            var list = await SqlMapper.QueryAsync<Translation>
                (_connectionFactory.GetConnection, "usp_GetAllTranslations", param, commandType: CommandType.StoredProcedure);
            return list.FirstOrDefault();

        }
    }
}
