using PritiXAPI.Attributes;
using PritiXDataAccess.Entities;
using PritiXDataAccess.Infrastructure;
using PritiXDataAccess.Repositories;
using System.Threading.Tasks;
using System.Web.Http;

namespace PritiXAPI.Controllers
{
    public class EnglishWordsController : BaseApiController
    {
        IWordRepository _englishWordRepository;

        public EnglishWordsController()
        {
            _englishWordRepository = new EnglishWordRepository(new ConnectionFactory());
        }

        [HttpGet]
        //[BasicAuthentication(RequireSsl = false)]
        public async Task<IHttpActionResult> GetAllEnglishWords()
        {
            var resultData = await _englishWordRepository.GetAllWords();
            if (resultData == null)
            {
                return NotFound();
            }
            return Ok(resultData);
        }

        [HttpGet]
        //[BasicAuthentication(RequireSsl = false)]
        public async Task<IHttpActionResult> GetAllEnglishWordsOfDictionary(int id)
        {
            var resultData = await _englishWordRepository.GetAllWordsOfDictionary(id);
            if (resultData == null)
            {
                return NotFound();
            }
            return Ok(resultData);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddEnglishWord(EnglishWord word)
        {
            var resultData = await _englishWordRepository.AddWord(word);
            if (resultData == false)
            {
                return InternalServerError();
            }
            else
                return Ok();
        }

    }
}
