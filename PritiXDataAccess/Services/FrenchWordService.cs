using PritiXDataAccess.Entities;
using PritiXDataAccess.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PritiXDataAccess.Services
{
    public class FrenchWordService : IFrenchWordService
    {
        IUnitOfWork _unitOfWork;
        public FrenchWordService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<FrenchWord>> GetAllWords()
        {
            return await _unitOfWork.FrenchWordRepository.GetAllWords();
        }

    }
}
