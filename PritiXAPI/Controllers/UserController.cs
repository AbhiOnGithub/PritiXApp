using PritiXAPI.Models;
using PritiXDataAccess.Infrastructure;
using PritiXDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PritiXAPI.Controllers
{
    public class UserController : BaseApiController
    {
        private IUserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository(new ConnectionFactory());
        }

        [HttpPost]
        [ActionName("ValidateUserLogin")]
        public async Task<IHttpActionResult> ValidatedUserLogin(Credentials credential)
        {
            var resultData = await _userRepository.GetUserLoggedIn(credential.username,credential.password);
            if (resultData == null)
            {
                return Unauthorized();
            }
            return Ok(resultData);
        }
    }
}