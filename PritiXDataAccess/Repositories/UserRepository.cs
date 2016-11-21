using System.Linq;
using System.Threading.Tasks;
using PritiXDataAccess.Entities;
using PritiXDataAccess.Infrastructure;
using Dapper;
using System.Data;

namespace PritiXDataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        IConnectionFactory _connectionFactory;

        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> SignupNewUser(string username, string password, string fullname)
        {
            var param = new DynamicParameters();
            param.Add("@Username", username);
            param.Add("@Password", password);
            param.Add("@Fullname", fullname);
            var result = await SqlMapper.ExecuteAsync(_connectionFactory.GetConnection, "usp_AddNewUser", param, commandType: CommandType.StoredProcedure);

            return result == 1 ? true : false;
        }


        public async Task<User> GetUserLoggedIn(string username, string password)
        {
            var param = new DynamicParameters();
            param.Add("@Username", username);
            param.Add("@Password", password);
            var users = await SqlMapper.QueryAsync<User>
                (_connectionFactory.GetConnection, "usp_GetUserVerified", param: param, commandType: CommandType.StoredProcedure);
            if (users != null)
                return users.FirstOrDefault();
            else
                return null;
        }
    }
}