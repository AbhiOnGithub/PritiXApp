using PritiXDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PritiXDataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IEnglishWordRepository _englishRepository;
        private readonly IDutchWordRepository _dutchRepository;
        private readonly IGermanWordRepository _germanRepository;
        private readonly IFrenchWordRepository _frenchRepository;

        public UnitOfWork(IEnglishWordRepository englishrepository, IDutchWordRepository dutchrepository, IGermanWordRepository germanRepository, IFrenchWordRepository frenchRepository)
        {
            _englishRepository = englishrepository;
            _dutchRepository = dutchrepository;
            _germanRepository = germanRepository;
            _frenchRepository = frenchRepository;
        }

        void IUnitOfWork.Complete()
        {
            throw new NotImplementedException();
        }

        public IEnglishWordRepository EnglishWordRepository
        {
            get
            {
                return _englishRepository;
            }
        }
        public IDutchWordRepository DutchWordRepository
        {
            get
            {
                return _dutchRepository;
            }
        }

        public IFrenchWordRepository FrenchWordRepository
        {
            get
            {
                return _frenchRepository;
            }
        }

        public IGermanWordRepository GermanWordRepository
        {
            get
            {
                return _germanRepository;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls



        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
