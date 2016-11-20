using PritiXDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PritiXDataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserLoggedIn(string username,string password);
    }
}
