using PritiXDataAccess.Entities;
using PritiXDataAccess.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PritiXDataAccess.Services
{
    public class GermanWordService : IGermanWordService
    {
        IUnitOfWork _unitOfWork;
        public GermanWordService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<GermanWord>> GetAllWords()
        {
            return await _unitOfWork.GermanWordRepository.GetAllWords();
        }

    }
}
