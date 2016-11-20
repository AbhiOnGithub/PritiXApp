using PritiXDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PritiXDataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGermanWordRepository GermanWordRepository { get; }
        IEnglishWordRepository EnglishWordRepository { get; }
        IFrenchWordRepository FrenchWordRepository { get; }
        IDutchWordRepository DutchWordRepository { get; }
        void Complete();
    }
}
