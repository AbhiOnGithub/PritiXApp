using PritiXAPI.Attributes;
using PritiXDataAccess.Entities;
using PritiXDataAccess.Infrastructure;
using PritiXDataAccess.Repositories;
using System.Threading.Tasks;
using System.Web.Http;

namespace PritiXAPI.Controllers
{
    public class DictionaryController : BaseApiController
    {
        IDictRepository _dictionaryRepository;

        public DictionaryController()
        {
            _dictionaryRepository = new DictRepository(new ConnectionFactory());
        }

        [HttpGet]
        //[BasicAuthentication(RequireSsl = false)]
        public async Task<IHttpActionResult> GetAllDictionaries()
        {
            var resultData = await _dictionaryRepository.GetAllDictionaries();
            if (resultData == null)
            {
                return NotFound();
            }
            return Ok(resultData);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddDictionary(Dict dict)
        {
            var resultData = await _dictionaryRepository.AddDictionary(dict);
            if (resultData == false)
            {
                return InternalServerError();
            }
            else
                return Ok();
        }
    }
}
