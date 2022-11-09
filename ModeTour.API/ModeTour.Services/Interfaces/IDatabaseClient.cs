using System.Data;
using System.Data.Common;

namespace ModeTour.Services.Interfaces
{
    public interface IDatabaseClient
    {
        DbTransaction BeginTransaction(IsolationLevel level = IsolationLevel.ReadCommitted);
    }
}
