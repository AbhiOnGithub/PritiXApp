using System;
using System.Data;

namespace PritiXDataAccess.Infrastructure
{
    public interface IConnectionFactory : IDisposable
    {
        IDbConnection GetConnection { get; }
    }
}