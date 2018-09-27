using System.Data;

namespace Abstract.Infrastructure
{
     public interface IConnectionFactory
    {
        IDbConnection GetConnection{get;}
    }
}