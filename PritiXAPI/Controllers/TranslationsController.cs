using PritiXDataAccess.Infrastructure;
using PritiXDataAccess.Repositories;
using System.Threading.Tasks;
using System.Web.Http;

namespace PritiXAPI.Controllers
{
    public class TranslationsController : ApiController
    {
        ITranslateRepository _translateRepository;

        public TranslationsController()
        {
            _translateRepository = new TranslateRepository(new ConnectionFactory());
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllTranslations(int idx)
        {
            var resultData = await _translateRepository.TranslateWords(idx);
            if (resultData == null)
            {
                return NotFound();
            }
            return Ok(resultData);
        }
    }
}
