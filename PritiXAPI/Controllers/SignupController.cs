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
    public class SignupController : BaseApiController
    {
        private IUserRepository _userRepository;

        public SignupController()
        {
            _userRepository = new UserRepository(new ConnectionFactory());
        }

        [HttpPost]
        [ActionName("SignupNewUser")]
        public async Task<IHttpActionResult> SignupNewUser(Newuser user)
        {
            var resultData = await _userRepository.SignupNewUser(user.Username, user.Password, user.Fullname);
            if (!resultData)
            {
                return Unauthorized();
            }
            return Ok();
        }
    }
}
