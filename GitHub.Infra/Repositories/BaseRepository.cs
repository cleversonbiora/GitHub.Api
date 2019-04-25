using System;
using System.Data;

namespace GitHub.Infra.Repositories
{
    public class BaseRepository : IDisposable
    {
        internal IDbConnection _conn;
        public BaseRepository()
        {
            _conn = ConnectionFactory.GetGitHubOpenConnection(); //Open the coonection
        }
        public void Dispose()
        {
            _conn.Close();
            GC.SuppressFinalize(this);
        }
    }
}
