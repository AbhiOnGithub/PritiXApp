using PritiXDataAccess.Entities;
using PritiXDataAccess.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PritiXDataAccess.Services
{
    public class DutchWordService : IDutchWordService
    {
        IUnitOfWork _unitOfWork;
        public DutchWordService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<DutchWord>> GetAllWords()
        {
            return await _unitOfWork.DutchWordRepository.GetAllWords();
        }

    }
}
